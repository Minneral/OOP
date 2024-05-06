using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_11.Core;
using WPF_11.MVVM.Model;
using WPF_11.MVVM.View;

namespace WPF_11.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    private object _currentView;
    public object CurrentView
    {
        get
        {
            return _currentView;
        }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }
    public StudentViewModel StudentVM { get; set; }
    public SubjectViewModel SubjectVM { get; set; }

    public RelayCommand StudentVMCommand { get; set; }
    public RelayCommand SubjectVMCommand { get; set; }

    public MainViewModel()
    {
        StudentVM = new StudentViewModel(this);
        SubjectVM = new SubjectViewModel(this);

        //using(MyDbContext db = new MyDbContext())
        //{
        //    StudentVM.StudentList = new ObservableCollection<Student>(db.Students);
        //    SubjectVM.Subjects = new ObservableCollection<Subject>(db.Subjects);
        //}

        StudentVMCommand = new RelayCommand(o => CurrentView = StudentVM);
        SubjectVMCommand = new RelayCommand(o => { CurrentView = SubjectVM; SubjectVM.FillLists(); });

        CurrentView = StudentVM;
    }
}
