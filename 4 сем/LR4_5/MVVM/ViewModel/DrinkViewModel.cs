using LR4_5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_5.MVVM.ViewModel;

internal class DrinkViewModel
{
    public ObservableCollection<Product> DrinkList { get; set; }

    public DrinkViewModel()
    {
        DrinkList = new ObservableCollection<Product>()
        {
            new Product("Pepsi 0.5 разливной", "Вкусная", "Очень вкусная", 3, "https://dodopizza-a.akamaihd.net/static/Img/Products/e317d9c7d0634b2c84261d35c8614c85_292x292.webp"),
            new Product("Mirinda 0.5 разливной", "Вкусная", "Очень вкусная", 3, "https://dodopizza-a.akamaihd.net/static/Img/Products/e422988f27064be7b30e0b623196dbaa_292x292.webp"),
            new Product("Чай Lipton зеленый", "Вкусный", "Очень вкусный", 2, "https://dodopizza-a.akamaihd.net/static/Img/Products/a346b56aa9ca4f249bb85d9cc6928861_292x292.webp"),
            new Product("Кофе Капучино", "Вкусное", "Очень вкусное", 5, "https://dodopizza-a.akamaihd.net/static/Img/Products/3d88a04e1c6c408291aacf02501ef205_292x292.webp")
        };
    }
}
