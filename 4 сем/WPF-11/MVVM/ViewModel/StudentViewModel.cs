using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using WPF_11.Core;
using WPF_11.MVVM.Model;

namespace WPF_11.MVVM.ViewModel;

public class StudentViewModel : ObservableObject
{
	private readonly MainViewModel mainViewModel;
    public ObservableCollection<Student> StudentList { get; set; }

	private string nameInput;
	public string NameInput
	{
		get { return nameInput; }
		set { nameInput = value;
			OnPropertyChanged();
		}
	}
	private string surnameInput;
	public string SurnameInput
	{
		get { return surnameInput; }
		set { surnameInput = value;
			OnPropertyChanged();
		}
	}
	private string patrynomicInput;
	public string PatrynomicInput
	{
		get { return patrynomicInput; }
		set { patrynomicInput = value;
			OnPropertyChanged();
		}
	}
	private string facultyInput;
	public string FacultyInput
	{
		get { return facultyInput; }
		set {
            facultyInput = value;
			OnPropertyChanged();
		}
	}
	private int courseInput;
	public int CourseInput
	{
		get { return courseInput; }
		set { courseInput = value;
			OnPropertyChanged();
		}
	}
	private int cardNumberInput;
	public int CardNumberInput
	{
		get { return cardNumberInput; }
		set { cardNumberInput = value;
			OnPropertyChanged();
		}
	}


	public RelayCommand AddStudentCommand { get; set; }
	public RelayCommand DeleteStudentCommand { get; set; }



	public StudentViewModel(MainViewModel mainViewModel = null)
	{
		this.mainViewModel = mainViewModel;
		StudentList = new ObservableCollection<Student>();

		nameInput = String.Empty;
		surnameInput = String.Empty;
		patrynomicInput = String.Empty;
		facultyInput = String.Empty;
		courseInput = 0;
		cardNumberInput = 0;

		AddStudentCommand = new RelayCommand(o => ExecuteAddStudentCommand());
		DeleteStudentCommand = new RelayCommand(o => ExecuteDeleteStudentCommand(o));


		using(MyDbContext db = new MyDbContext())
		{
			StudentList = new ObservableCollection<Student>(db.Students.ToList<Student>());
		}

    }

	void ExecuteAddStudentCommand()
	{
		if (Validate())
		{
			Student student = new Student(nameInput, surnameInput, patrynomicInput, facultyInput, courseInput, cardNumberInput);

            StudentList.Add(student);

			NameInput = String.Empty;
			SurnameInput = String.Empty;
			PatrynomicInput = String.Empty;
			FacultyInput = String.Empty;
			CourseInput = default(int);
			CardNumberInput = default(int);

			using (MyDbContext db = new MyDbContext())
			{
				db.Students.Add(student);
				db.SaveChanges();
			}

			MessageBox.Show("Студент добавлен!");
		}
    }

	void ExecuteDeleteStudentCommand(object o)
	{
		Student student = (Student)o;

		try
		{
			StudentList.Remove(StudentList.FirstOrDefault(t => t.CardNumber == student.CardNumber));
			mainViewModel.SubjectVM.DeleteStudent(student);

			using (MyDbContext db = new MyDbContext())
			{
				Student stud = db.Students.Find(student.CardNumber);
				db.Students.Remove(stud);
				db.SaveChanges();
			}
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}


    bool Validate()
	{
		string namePattern = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s]*[A-Za-zА-Яа-яЁё]$";

        try
		{

			if (Regex.IsMatch(SurnameInput, namePattern) == false)
			{
				throw new Exception("Недопустимая Фамилия!");
			}

			if (Regex.IsMatch(NameInput, namePattern) == false)
			{
				throw new Exception("Недопустимое Имя!");
			}

			if (PatrynomicInput != String.Empty)
			{
				if (Regex.IsMatch(PatrynomicInput, namePattern) == false)
				{
					throw new Exception("Недопустимое Отчество!");
				}
			}

			if (Regex.IsMatch(FacultyInput, namePattern) == false)
			{
				throw new Exception("Недопустимое название Факультета!");
			}

			if (courseInput <= 0 || courseInput > 5)
			{
				throw new Exception("Допустимые значения для курса: 1-5!");
			}

			if (cardNumberInput <= 0)
			{
				throw new Exception("Номер зачетки не может быть отрицательным числом!");
			}

			foreach(var item in StudentList)
			{
				if(item.CardNumber == CardNumberInput)
				{
					throw new Exception("У двух студентов не может быть одинаковый номер зачетки!");
				}
			}

			return true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return false;
		}
	}
}
