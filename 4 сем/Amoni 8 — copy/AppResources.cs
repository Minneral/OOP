using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amoni;

public class AppResources
{
    private static ResourceDictionary _resources;

    public static ResourceDictionary Resources { 
        get { return _resources; }
        set
        {
            _resources = value;


        }
    } 
    

    static AppResources()
    {
        if (CultureInfo.CurrentUICulture.Name == "lang-ru")
            _resources = new ResourceDictionary() { Source = new Uri("/Resources/lang-ru.xaml", UriKind.Relative) };
        else
            _resources = new ResourceDictionary() { Source = new Uri("/Resources/lang-en.xaml", UriKind.Relative) };
    }

    public static void Reload()
    {
        if (CultureInfo.CurrentUICulture.Name == "lang-ru")
            _resources = new ResourceDictionary() { Source = new Uri("/Resources/lang-ru.xaml", UriKind.Relative) };
        else
            _resources = new ResourceDictionary() { Source = new Uri("/Resources/lang-en.xaml", UriKind.Relative) };
    }
}
