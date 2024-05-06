using LR4_5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4_5.MVVM.ViewModel;

internal class SnackViewModel
{
    public ObservableCollection<Product> SnackList { get; set; }

    public SnackViewModel()
    {
        SnackList = new ObservableCollection<Product>()
        {
            new Product("Додстер", "Вкусный", "Очень вкусный", 10, "https://dodopizza-a.akamaihd.net/static/Img/Products/50692dab4b18412c917d7683561cfd1c_292x292.webp"),
            new Product("Дэнвич ветчина и сыр", "Вкусный", "Очень вкусный", 12, "https://dodopizza-a.akamaihd.net/static/Img/Products/d1ea4a35a5774c89bfd8081d2b274b9b_292x292.webp"),
            new Product("Салат цэзарь", "Вкусный", "Очень вкусный", 8, "https://dodopizza-a.akamaihd.net/static/Img/Products/cec36c453f6f4a59ab88d80e4d868be2_292x292.webp"),
            new Product("Картофель из печи", "Вкусный", "Очень вкусный", 6, "https://dodopizza-a.akamaihd.net/static/Img/Products/6e57c291d3d44b78b75b0123f0f32314_292x292.webp")
        };
    }
}
