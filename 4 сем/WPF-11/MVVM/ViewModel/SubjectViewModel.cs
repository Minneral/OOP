using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_11.Core;
using WPF_11.MVVM.Model;

namespace WPF_11.MVVM.ViewModel;

public class SubjectViewModel : ObservableObject
{
	private readonly MainViewModel mainViewModel;
    public ObservableCollection<Subject> Subjects { get; set; }
	public ObservableCollection<string> SubjectsComboBox { get; }
	public ObservableCollection<string> StudentsComboBox { get; }
	public ObservableCollection<string> UnSubStudentsComboBox { get; }

    private string selectedSubject;
    private string selectedStudent;

    public string SelectedSubject
	{
		get { return selectedSubject; }
		set
		{
			selectedSubject = value;
			OnPropertyChanged();
		}
	}
	public string SelectedStudent
	{
		get { return selectedStudent; }
		set
		{
			selectedStudent = value;
			OnPropertyChanged();
		}
	}



    public RelayCommand SubscribeCommand { get; }
	public RelayCommand UnSubscribeCommand { get; }
	public RelayCommand SelectionChangedCommand { get;}

	public SubjectViewModel(MainViewModel mainViewModel = null)
	{
		this.mainViewModel = mainViewModel;
		Subjects = new ObservableCollection<Subject>();
		SubjectsComboBox = new ObservableCollection<string>();
		StudentsComboBox = new ObservableCollection<string>();
        UnSubStudentsComboBox = new ObservableCollection<string>();



        using (MyDbContext db = new MyDbContext())
        {
			Subject subj;
			Student stud;
			Subjects = new ObservableCollection<Subject>(db.Subjects.ToList<Subject>());

			foreach(var item in db.SubjectStudents.ToList<SubjectStudent>())
			{
				subj = db.Subjects.Find(item.SubjectId);
				stud = db.Students.Find(item.StudentId);

				foreach(var obj in Subjects)
				{
					if(obj.Name == subj.Name)
					{
						obj.Listeners.Add(stud);
					}
				}
			}
        }


  //      Subjects.Add(new Subject("ООП", 108, "Мищук"));
		//Subjects.Add(new Subject("ОАиП", 248, "Пустовалова"));
		//Subjects.Add(new Subject("КСИС", 108, "Романенко"));

		foreach(var item in Subjects)
		{
			SubjectsComboBox.Add(item.ToString());
		}


		SubscribeCommand = new RelayCommand(o => ExecuteSubscribeCommand());
		UnSubscribeCommand = new RelayCommand(o => ExecuteUnSubscribeCommand());
		SelectionChangedCommand = new RelayCommand(o => ExecuteSelectionChangedCommand());
    }

	void ExecuteSubscribeCommand()
	{
		try
		{
			if (Validate())
			{
				Subject subject = Subjects.First(t => t.Name == SelectedSubject);
				Student student = mainViewModel.StudentVM.StudentList.First(t => t.CardNumber == Student.ParseCardNumber(SelectedStudent));

				if (subject == null)
					throw new Exception();

				subject.Listeners.Add(student);

                SelectedStudent = null;
				SelectedSubject = null;

				using(MyDbContext db = new MyDbContext())
				{
					db.SubjectStudents.Add(new SubjectStudent(db.Subjects.First(t => t.Name == subject.Name).Id, student.CardNumber));
					db.SaveChanges();
				}


				MessageBox.Show("Запись оформлена!");
			}
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	void ExecuteUnSubscribeCommand()
	{
		try
		{
			if(selectedSubject != null && selectedSubject != String.Empty)
			{
				if(selectedStudent != null && selectedStudent != String.Empty)
				{
					Subject subject = Subjects.First(t => t.Name == selectedSubject);
					Student student = subject.Listeners.First(t => t.ToString() == selectedStudent);

					subject.Listeners.Remove(student);

					SelectedSubject = null;
					SelectedStudent = null;

                    using (MyDbContext db = new MyDbContext())
                    {
						db.SubjectStudents.Remove(db.SubjectStudents.First(t => t.SubjectId == subject.Id && t.StudentId == student.CardNumber));
						db.SaveChanges();
                    }

                    MessageBox.Show("Студент успешно отписан!");
				}
			}
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}

	}

	void ExecuteSelectionChangedCommand()
	{
		if(SelectedSubject != null && SelectedSubject != String.Empty)
		{
			UnSubStudentsComboBox.Clear();
			Subject subject = Subjects.First(t => t.Name == SelectedSubject);

			foreach(var item in subject.Listeners)
			{
				UnSubStudentsComboBox.Add(item.ToString());
            }
        }
	}


    bool Validate()
	{
		try
		{
			if (SelectedSubject == String.Empty || SelectedSubject == null)
				throw new Exception("Выберите дисциплину!");

            if (SelectedStudent == String.Empty || SelectedStudent == null)
                throw new Exception("Выберите студента!");

			Subject subject = Subjects.First(t => t.Name == selectedSubject);

			foreach (var obj in subject.Listeners)
			{
				if (obj.CardNumber == Student.ParseCardNumber(SelectedStudent))
					throw new Exception("Этот студент уже подписан на дисциплину!");
			}
			

            return true;
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
			return false;
		}
	}

    public void FillLists()
	{
        if (mainViewModel != null)
        {
            StudentsComboBox.Clear();
            foreach (var item in mainViewModel.StudentVM.StudentList)
            {
                StudentsComboBox.Add(item.ToString());
            }
        }
    }

	public void DeleteStudent(Student student)
	{
		using (MyDbContext db = new MyDbContext())
		{
			foreach (var item in Subjects)
			{
				foreach (var obj in item.Listeners)
				{
					if (obj.ToString() == student.ToString())
					{
						db.SubjectStudents.Remove(db.SubjectStudents.First(t => t.SubjectId == db.Subjects.First(t => t.Name == item.Name).Id && t.StudentId == obj.CardNumber));

						item.Listeners.Remove(obj);
						StudentsComboBox.Remove(obj.ToString());
						UnSubStudentsComboBox.Clear();
						SelectedStudent = null;
						SelectedSubject = null;
						break;
					}
				}
			}

			db.SaveChanges();
		}
	}
}
