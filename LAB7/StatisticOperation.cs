using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7;

static class StatisticOperation
{
    public static str Sum(str s1, str s2) 
    {
        return new str(s1.value + s2.value); 
    }

    public static int CharCounter(str s1) 
    {
        return s1.value.Length;
    }



    public static int WordsCounter(this string s1) 
    {                                             
        int amount = 0;                            
        for(int i=0; i < s1.Length; ++i)
        {
            if(s1[i] == ' ')
            {
                amount++;
            }

        }

        return amount + 1;
    }



    public static string AddSmile(this string s1, int position)
    {
        return new string(s1.Insert(position, ":)"));
    }
}
