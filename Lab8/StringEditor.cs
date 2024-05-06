using System.Text;

namespace Lab8;

static class StringEditor
{
    public static string? AppendChar(string? str, char character)
    {
        if(str == null)
        {
            return null;
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            stringBuilder.Append(character);
            return stringBuilder.ToString();
        }
    }

    public static string? ToLower(string? str)
    {
        if (str == null)
        {
            return null;
        }
        else
        {
            return str.ToLower();
        }
    }

    public static string? ToUpper(string? str)
    {
        if (str == null)
        {
            return null;
        }
        else
        {
            return str.ToUpper();
        }
    }

    public static string? RemoveExtraSpace(string? str)
    {
        if(str == null)
        {
            return null;
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            int space = 0;

            for(int i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == ' ')
                {
                    space++;
                }
                else
                {
                    space = 0;
                }

                if(space == 2)
                {
                    stringBuilder.Remove(i, 1);
                    i-=2;
                    space = 0;
                }
            }

            return stringBuilder.ToString();
        }
    }

    public static string? RemoveChar(string? str, char character)
    {
        if(str == null)
        {
            return null;
        }
        else
        {
            StringBuilder s = new StringBuilder(str);
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == character)
                {
                    s.Remove(i, 1);
                    i--;
                }
            }

            return s.ToString();
        }
    }

    public static void NoticeIfContain(string? str, char character)
    {
        if(str == null)
        {
            Console.WriteLine("NullReference Exception!");
        }
        else
        {
            if(str.Contains(character))
            {
                Console.WriteLine($"Your string contains character: '{character}'");
            }
            else
            {
                Console.WriteLine($"Your string doesn't contains character: '{character}'");
            }
        }
    }
}
