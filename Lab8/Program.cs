namespace Lab8;

class Program
{
    static void Main()
    {
        Programmer junior1 = new Programmer();
        junior1.Mutate += () =>
        {
            if (junior1.DerivingPleasure)
            {
                Console.WriteLine("Люблю постоянно развиваться!");
            }
            else
            {
                Console.WriteLine("Я не горю этим!");
            }
        };
        junior1.Remove += () =>
        {
            if (junior1.Level <= 1)
            {
                if(junior1.DerivingPleasure)
                {
                    Console.WriteLine("Я должен больше стараться!");
                }
                else
                {
                    Console.WriteLine("Я уволен :(");
                }
            }
            else
            {
                if(junior1.DerivingPleasure)
                    Console.WriteLine("Работаем в штатном режиме :)");
                else
                    Console.WriteLine("Думаю, нужно взять отпуск...");
            }
        };

        junior1.doMutate();
        junior1.doFire();

        Console.WriteLine("\nУстраиваем на работу нового junior-сотрудника:\n");
        Programmer junior2 = new Programmer(0, true);
        junior2.Mutate += () =>
        {
            if (junior2.DerivingPleasure)
            {
                Console.WriteLine("Люблю постоянно развиваться!");
            }
            else
            {
                Console.WriteLine("Я не горю этим!");
            }
        };
        junior2.Remove += () =>
        {
            if (junior2.Level <= 1)
            {
                if (junior2.DerivingPleasure)
                {
                    Console.WriteLine("Я должен больше стараться!");
                }
                else
                {
                    Console.WriteLine("Я уволен :(");
                }
            }
            else
            {
                if (junior2.DerivingPleasure)
                    Console.WriteLine("Работаем в штатном режиме :)");
                else
                    Console.WriteLine("Думаю, нужно взять отпуск...");
            }
        };

        junior2.doMutate();
        junior2.doFire();

        Console.WriteLine("\nНовый сотрудник спустя полгода работы:\n");
        junior2.Mutate += () => Console.WriteLine("А все же правильную работу я выбрал!");
        junior2.doMutate();
        junior2.doFire();





        string str = "Denkt nicht       an Hunger    und Erschopfung!   Denkt nur an das Grossartige Deutsche Reich...%%%%%";

        Func<string?, char, string?> Append = StringEditor.AppendChar;
        Func<string?, string?> ToUpper = StringEditor.ToUpper;
        Func<string?, string?> ToLower = StringEditor.ToLower;
        Func<string?, string?> ExtraSpaces = StringEditor.RemoveExtraSpace;
        Func<string?, char, string?> RemoveChar = StringEditor.RemoveChar;
        Action<string?, char> Notice = StringEditor.NoticeIfContain;

        Console.WriteLine("\n\n\nLegacy string:\n" + str + "\n");

        Console.WriteLine("Append Char: '@'\nResult: " + Append(str, '@'));
        Console.WriteLine("\nToLower:\nResult: " + ToLower(str));
        Console.WriteLine("\nToUpper:\nResult: " + ToUpper(str));
        Console.WriteLine("\nRemove extra spaces:\nResult: " + ExtraSpaces(str));
        Console.WriteLine("\nRemove char '%'\nResult: " + RemoveChar(str, '%'));
        Console.WriteLine("\nDoes string containes char 'p'?");
        Notice(str, 'p');
    }
}