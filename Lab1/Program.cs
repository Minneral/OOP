using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //LocalVarDeclarations();
            //MyStrings();
            //MyArrays();
            //Tuple();
            /*{ //Fifth 
                dynamic foo(int[] Array, string str)
                {
                    (int, int, int, char) tup = (Array.Max(), Array.Min(), Array.Sum(), char.Parse(str.Substring(0, 1)));
                    return tup;
                }
                (int, int, int, char) tup = foo(new int[] { 1, 2, 3, 4, 5 }, "Fenster");
                Console.WriteLine($"Greatest element in array: {tup.Item1}");
                Console.WriteLine($"Lowest element in array: {tup.Item2}");
                Console.WriteLine($"Sum of the elements in array: {tup.Item3}");
                Console.WriteLine($"First letter of the string: {tup.Item4}");
            }*/

            //Check();
        }

        
        static void LocalVarDeclarations()
        {
            int myInt = default;   
            byte myByte = default;
            sbyte mySByte = default;
            uint myUInt = default;
            short myShort= default;
            ushort myUShort = default;
            long myLong = default;
            ulong myULong = default;
            bool myBool = default;
            char myChar = default;
            double myDouble = default;
            float myFloat = default;
            decimal myDecimal = default;

            // Conversations

            myChar = (char)myByte;
            myShort = (short)myInt;
            myInt = (int)myLong;
            myFloat = (float)myDouble;
            myDouble = (double)myDecimal;

            // end -> onversations


            // Boxing

            Object myObject = myInt;

            myInt = (int)myObject;

            // end -> Boxing



            // var type

            var name = "myName";
            // name = 5;

            // end -> var type


            // Nullable

            //Nullable<bool> mBool = default;
            //if(mBool is bool)
            //{
            //    Console.WriteLine("Bool variable has a value!");
            //}

            // end -> Nullable

            void LocalVarOutput()
            {
                Console.WriteLine("Int = {0}", myInt);
                Console.WriteLine("Uint = {0}", myUInt);
                Console.WriteLine("Byte = {0}", myByte);
                Console.WriteLine("SByte = {0}", mySByte);
                Console.WriteLine("Short = {0}", myShort);
                Console.WriteLine("UShort = {0}", myUShort);
                Console.WriteLine("Long = {0}", myLong);
                Console.WriteLine("ULong = {0}", myULong);
                Console.WriteLine("Boolean = {0}", myBool);
                Console.WriteLine("Char = {0}", myChar);
                Console.WriteLine("Double = {0}", myDouble);
                Console.WriteLine("Float = {0}", myFloat);
                Console.WriteLine("Decimal = {0}", myDecimal);
            }

            LocalVarOutput();

            Console.WriteLine("\nDo you want to change values of var types?");
            if(Console.ReadLine().Equals("yes"))
            {
                Console.WriteLine("\nEnter new values:");


                Console.Write("Int = ");
                myInt = Convert.ToInt32(Console.ReadLine());
                Console.Write("UInt = ");
                myUInt = Convert.ToUInt32(Console.ReadLine());

                Console.Write("Byte = ");
                myByte = Convert.ToByte(Console.ReadLine());

                Console.Write("SByte = ");
                mySByte = Convert.ToSByte(Console.ReadLine());

                Console.Write("Short = ");
                myShort = Convert.ToInt16(Console.ReadLine());

                Console.Write("UShort = ");
                myUShort = Convert.ToUInt16(Console.ReadLine());

                Console.Write("Long = ");
                myLong = Convert.ToInt64(Console.ReadLine());

                Console.Write("ULong = ");
                myULong = Convert.ToUInt64(Console.ReadLine());

                while (true)
                {
                    Console.Write("Boolean = ");
                    if (bool.TryParse(Console.ReadLine(), out bool myBoolean))
                    {
                        myBool = myBoolean;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your value isn't correct! Please retry...");
                    }
                }

                
                while (true)
                {
                    string condition;
                    Console.Write("Char = ");
                    if ((condition = Console.ReadLine()).Length>1)
                    {
                        Console.WriteLine("You've entered not the correct value!");
                    }
                    else
                    {
                        myChar = Convert.ToChar(condition);
                        break;
                    }
                }
                
                Console.Write("Double = ");
                myDouble = Convert.ToDouble(Console.ReadLine());

                Console.Write("Float = ");
                myFloat = (float)Convert.ToDouble(Console.ReadLine());

                Console.Write("Decimal = ");
                myDecimal = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine();
                LocalVarOutput();
            }
        }
        static void MyStrings()
        {
            string str1 = "First";
            string str2 = "Second";
            string str3 = "Third";
            string strBuff;

            if (string.Equals(str1,str2))
            {
                Console.WriteLine("Strings are equal");
            }
            else
            {
                Console.WriteLine("String values are different");
            }

            Console.WriteLine("String1 + String2 + String3 = {0}", String.Join(str1, str2, str3));
            Console.WriteLine("\nLet's make a copy of String1 value: StringBuffer = {0}", strBuff = String.Copy(str1));
            Console.WriteLine("\nSubString of StringBuffer ({0}) from 1 to 4 position = {1}", strBuff, strBuff.Substring(1, 4));

            strBuff = "How could you have come to hate me so?";
            string[] words = strBuff.Split(' ');
            Console.WriteLine($"\nNow i show u how we can Split our StringBuffer = {strBuff}, by words:");
            foreach(var item in words)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();

            strBuff = "ihrunterschatztmeinemacht";
            Console.WriteLine($"Our string now is <{strBuff}> - insert substring in it: {strBuff.Insert(3, "TEXT")}");
            Console.WriteLine($"Same way we can delete substring: before <{strBuff}> - after <{strBuff.Remove(3, 10)}>");

            string nullString = null;
            string emptySting = "";

            if(string.IsNullOrEmpty(nullString) && string.IsNullOrEmpty(emptySting))
            {
                // It's true :)
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder("Some text here");
            sb.Remove(0, 2);
            sb.Insert(0, "TTT");
            sb.Append("TTT");
            Console.WriteLine(sb);
        }
        static void MyArrays()
        {
            int[,] matrix = {
            {1,2,3 },
            {4,5,6 },
            {7,8,9 }
            };

            for(int i=0;i<matrix.GetLength(1);++i)
            {
                for(int j=0;j<matrix.GetLength(0);++j)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            string[] strArray = { "Ihr", "unterschatzt", "maine", "macht" };
            foreach(var item in strArray)
            {
                Console.Write('<' + item + "> ");
            }

            Console.WriteLine($"\nLength of the string array: {strArray.Length}");
            Console.WriteLine("Which element would you like to change?");
            byte position = byte.Parse(Console.ReadLine());
            Console.WriteLine($"Enter new value for element {position}: ");
            strArray[position] = Console.ReadLine();
            foreach (var item in strArray)
            {
                Console.Write('<' + item + "> ");
            }
            Console.WriteLine();
            Console.WriteLine("Enter values of float-based matrix down here:");

            float[][] fMatrix = new float[3][];
            fMatrix[0] = new float[2];
            fMatrix[1] = new float[3];
            fMatrix[2] = new float[4];
            for(int i=0;i<fMatrix.Length;++i)
            {
                for(int j=0;j<fMatrix[i].Length;++j)
                {
                    Console.Write($"Enter element [{i}][{j}]: ");
                    fMatrix[i][j] = float.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < fMatrix.Length; ++i)
            {
                for (int j = 0; j < fMatrix[i].Length; ++j)
                {
                    Console.Write(fMatrix[i][j] + "\t");
                }
                Console.WriteLine();
            }


            var varArray = new[] { 1, 2, 3, 4 };
            var varString = "String";

        }
        static void Tuple()
        {
            (int, string, char, string, ulong) myTuple = (1, "str", 'g', "axe", 90);
            Console.WriteLine(myTuple);
            Console.WriteLine($"{myTuple.Item1} {myTuple.Item2} {myTuple.Item4}");

            {
                (int a, string b, char c, string d, ulong e) = myTuple;
            }

            {
                int a; string b; char c; string d; ulong e;
                (a, b, c, d, e) = myTuple;
            }

            int _ = 10;

            (int, string) tup1 = (1, "CS");
            (int, string) tup2 = (1, "CS");
            if(tup1==tup2)
            {

            }


        }
        static void Check()
        {
            byte a, b, rez;

            try
            {
                a = unchecked((byte)240);
                b = unchecked((byte)16);
                Console.WriteLine($"a = {a}");
                Console.WriteLine($"a = {b}");
                rez = checked((byte)(a + b));
                Console.WriteLine($"a+b = {rez}");
                rez = checked((byte)(a * b));
                Console.WriteLine($"a*b = {rez}");
            }
            catch(OverflowException)
            {
                Console.WriteLine("OverFlow!");
            }
        }

    }
}
