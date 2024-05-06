using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7;

class str
{
    public string value; 
    public class Developer 
    {
        public string fio;
        public string id;
        public string department;

        public Developer() : this("", "", "") { }
        public Developer(string fio, string id, string department)
        {
            this.fio = fio;
            this.id = id;
            this.department = department;
        }
    }

    Production prod = new Production("18537", "Company"); 
    Developer dev = new Developer("Name", "Id", "dep");
    public str() : this("") { } 
    public str(string s)
    {
        this.value = s; 
    }
    public static str operator -(str s1, int x) 
    {                                           
        if (s1.value.Contains(x.ToString()))
        {
            return new str { value = s1.value.Replace(x.ToString(), "") };
        }
        else
        {
            return new str { value = s1.value };
        }
    }
    public static str operator +(str s1, int x) 
    {
        return new str { value = s1.value + x };
    }
    public static str operator +(str s1, string x)
    {
        return new str { value = s1.value + x };
    }
    public static bool operator >(str s1, string s2)
    {
        if (s1.value.Contains(s2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <(str s1, string s2)
    {
        if (s2.Contains(s1.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(str s1, string s2)
    {
        if (string.Compare(s1.value, s2) == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static bool operator ==(str s1, string s2)
    {
        if (string.Compare(s1.value, s2) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
