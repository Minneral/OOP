using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Amoni;

/// <summary>
/// Логика взаимодействия для myUserControl.xaml
/// </summary>
public partial class myUserControl : UserControl
{
    public static readonly DependencyProperty MyProperty;
    public static readonly RoutedEvent MyCustomEvent;
    public string ControlContent
    {
        get { return (string)GetValue(MyProperty); }
        set { SetValue(MyProperty, value); }
    }

    public myUserControl()
    {
        InitializeComponent();
        this.MouseDown += OnMyCustomEvent;
    }

    public event RoutedEventHandler MyEvent
    {
        add
        {
            AddHandler(myUserControl.MyCustomEvent, value);
        }
        remove
        {
            RemoveHandler(myUserControl.MyCustomEvent, value);
        }
    }

    static myUserControl()
    {
        MyProperty = DependencyProperty.Register("ControlContent",
                                                         typeof(string),
                                                         typeof(myUserControl),
                                                         new FrameworkPropertyMetadata(string.Empty,
                                                                                       FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                       new PropertyChangedCallback(OnContentChanged),
                                                                                       new CoerceValueCallback(CoerceContent)));
        MyCustomEvent = EventManager.RegisterRoutedEvent("MyCustomEvent", RoutingStrategy.Bubble, typeof(RoutedEvent), typeof(myUserControl));
    }

    private void OnMyCustomEvent(object sender, RoutedEventArgs e)
    {
        RoutedEventArgs args = new RoutedEventArgs(MyCustomEvent);
        RaiseEvent(args);
    }

    private static bool IsValidContent(object value)
    {
        var val = (string)value;
        if (val == string.Empty)
            return false;
        else
            return true;
    }

    private static object CoerceContent(DependencyObject d, object value)
    {
        var val = (string)value;

        if (val == string.Empty)
            return "Null";
        else
            return val;
    }

    private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {

    }
}
