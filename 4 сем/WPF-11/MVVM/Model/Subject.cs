using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_11.Core;

namespace WPF_11.MVVM.Model;

public class Subject : ObservableObject
{
	public int Id { get; set; }
	private string name;

	public string Name
	{
		get { return name; }
		set
		{
			name = value;
			OnPropertyChanged();
		}
	}

	private int hours;

	public int Hours
	{
		get { return hours; }
		set { hours = value;
			OnPropertyChanged();
		}
	}

	private string professor;

	public string Professor
	{
		get { return professor; }
		set { professor = value;
			OnPropertyChanged();
		}
	}

	private ObservableCollection<Student> listeners;
	public ObservableCollection<Student> Listeners
	{
		get { return listeners; }
		set
		{
            if (listeners != null)
                listeners.CollectionChanged -= Listeners_CollectionChanged;

            listeners = value;

			if (listeners != null)
				listeners.CollectionChanged += Listeners_CollectionChanged;

			OnPropertyChanged();
			OnPropertyChanged(nameof(ListenersCount));
		}
	}

	public int ListenersCount
	{
		get
		{
			if(listeners != null)
				return listeners.Count;

			return -1;
		}
	}

	public Subject()
	{
		name = string.Empty;
		hours = 0;
		professor = string.Empty;
		Listeners = new ObservableCollection<Student>();
	}

	public Subject(string name, int hours, string professor, ObservableCollection<Student> listeners = null)
	{
		Name = name;
		Hours = hours;
		Professor = professor;
		if (Listeners != null)
			Listeners = listeners;
		else
			Listeners = new ObservableCollection<Student>();
        
	}

    private void Listeners_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
		//Students.Clear();
		//foreach(var item in Listeners)
		//{
		//	Students.Add(item);
  //      }

        OnPropertyChanged(nameof(ListenersCount));
    }

    public override string ToString()
	{
		return Name;
	}
}
