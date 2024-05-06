using System.Linq.Expressions;
using System.Diagnostics;

namespace LAB5;

class Program
{
    static void Foo()
    {
        try
        {
            Boo();
        }
        finally
        {
            Console.WriteLine("Finally Foo()");
        }
    }

    static void Boo()
    {
        try
        {
            int x = 5;
            int y = 0;
            int z = x / y;
        }
        finally
        {
            Console.WriteLine("Finally Boo()");
        }
        Console.WriteLine("Somestring");
    }
    static void Zoo()
    {
        Debug.Assert(1 == 2, "Error");
    }

    static void Main()
    {
        Screen Oled = new Screen("Oled", "70", "321-452", "JK-47L90", "4k", "21.5'");

        Monitor LG = new Monitor(Oled, "Osiris", "200", "ET-90403", "LG-K0432", "2.1 kg");

        PC Lenovo = new PC("Gerbert", "1200", "L-8231", "942-231", "Intel i9-11900k", "128 GB", "4 TB", "B450", "300W");

        Projector Proj = new Projector("myProjector", "100", "proj-9MLTP", "195-234", "500 NIT", "8 bit");

        EarBuds Xiaomi = new EarBuds("Xiaomi earbuds", "30", "988-888", "mi-4", "2000mAh", "2.2 ddb");

        Table table = new Table("Stinger", "oak", "0,5", "1", "Rectangle");

        Product[] products = new Product[]
        {
            table,
            Oled,
            LG,
            Lenovo,
            Proj,
            Xiaomi,
        };

        iTechnique[] iTech = new iTechnique[]
        {
            Oled,
            LG,
            Lenovo,
            Proj,
            Xiaomi,
        };

        Product[] computers = new Product[]
        {
            Lenovo,
            new PC("ASUS", "1000", "L-8331", "912-231", "Intel i9-8900k", "128 GB", "4 TB", "B450", "500W"),
            new PC("MSI", "1500", "K-3231", "942-531", "Intel i7-11900k", "256 GB", "4 TB", "B450", "800W"),
            new PC("HP", "900", "L-3231", "142-231", "Intel i5-8700k", "64 GB", "2 TB", "B450", "400W")
        };

        try
        {
            try
            {
                Screen Qled = new Screen("Qled", "70", "321-452", "JK-47L90", "4k", "21.5'");
                if (int.TryParse(Qled.Price, out int price))
                {
                    if (price < 0)
                    {
                        throw new ProductWrongArgument("Неверная цена для товара!", Qled.Price);
                    }
                }
                else
                {
                    throw new InvalidCastException("Неверно задана цена!");
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message + "Цена не может содержать символы, отличные от цифр! " + ex.StackTrace);
            }
            catch (ProductWrongArgument ex)

            {
                Console.WriteLine(ex.Message + " Цена не может быть отрицательной.\nВы ввели: " + ex.Value);
            }
            finally
            {
                Console.WriteLine("Finally 1");
            }



            try
            {
                int index = 3;
                Product[] list = new Product[3];
                list[0] = Oled;
                if (list[0] == null)
                {
                    throw new ProductNullReference("Используется нуль-ссылка!");
                }
                else
                {
                    list[0].Price = "200";
                }

                if (index >= 3)
                {
                    throw new ListWrongIndex("Индекс вышел за диапазон!");
                }
                else
                {
                    list[index].Name = "BENQ";
                }
            }
            catch (ListWrongIndex ex)
            {
                Console.WriteLine("Вы ввели неверный индекс! " + ex.Message + ex.StackTrace);
            }
            catch (ProductNullReference ex)
            {
                Console.WriteLine(ex.Message + " Нельзя обратиться по Null-ссылке! " + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally 2");
            }

            try
            {
                try
                {
                    int x = 5;
                    int y = 0;
                    int z = x / y;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Нельзя делить на ноль! " + ex.StackTrace);
                    throw;
                }
                finally
                {
                    Console.WriteLine("Finally 3");
                }
            }
            catch
            {
                Console.WriteLine("Повторная ошибка!");
            }



            try
            {
                Foo();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("На нуль делить нельзя! " + ex.TargetSite);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Ошибка! " + ex.Message + ex.StackTrace);
        }
        finally
        {
            Console.WriteLine("Все ошибки обработаны!");
        }


        Zoo();
        Console.WriteLine("Text after");

        
    }
}