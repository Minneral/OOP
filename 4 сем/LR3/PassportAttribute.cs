using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LR2;

public class PassportAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is PASSPORT pas)
        {
            var res = Regex.Match(pas.ToString(), @"^\w{2}[1-9]{1}\d{6}");
            if (res.Success)
                return true;
            else
                ErrorMessage = "Некорректные данные паспорта!\nФормат (Б - буква, Ц - цифра): ББЦЦЦЦЦЦЦ";
        }
        return false;
    }
}