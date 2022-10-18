using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LAB2
{
    class Point
    {
        float x;
        float y;
        private static int amount;
        public readonly int ID;
        public Point() : this(0,0) { }
        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
            ID = this.GetHashCode();
            ++amount;
        }
        static Point()
        {
            amount = 0;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            else
            {
                Point p = (Point)obj;
                return (p.x == x && p.y == y);
            }
        }

        public override int GetHashCode()
        {
            return ((int)x * 7 + (int)y * 11) * 13;
        }

        public override string ToString()
        {
            return string.Format("Point({0}, {1})", x, y);
        }
        public float _x
        {
            get
            {
                return x;
            }
        }
        public float _y
        {
            get
            {
                return y;
            }
        }
        public static void ClassInfo()
        {
            Console.WriteLine("Amount of the Point objects: {0}", amount);
        }
    }
    partial class Triangle
    {
        const int pointAmount = 3;
        Point[] points = new Point[pointAmount];
        public Triangle() : this(new Point(0, 0), new Point(0, 3), new Point(4, 0)) { }
        public Triangle(params Point[] p)
        {
            if (p.Length == pointAmount)
            {
                for (byte i = 0; i < pointAmount; ++i)
                {
                    points[i] = p[i];
                }
            }
        }
        float CalcLength(float x1, float x2, float y1, float y2)
        {
            return (float)Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        public void Print()
        {
            Console.WriteLine("Point 1 = ({0}, {1})", points[0]._x, points[0]._y);
            Console.WriteLine("Point 2 = ({0}, {1})", points[1]._x, points[1]._y);
            Console.WriteLine("Point 3 = ({0}, {1})", points[2]._x, points[2]._y);
        }
        public void ShowInfo()
        {
            float side1_2 = CalcLength(points[0]._x, points[1]._x, points[0]._y, points[1]._y);
            float side2_3 = CalcLength(points[1]._x, points[2]._x, points[1]._y, points[2]._y);
            float side1_3 = CalcLength(points[0]._x, points[2]._x, points[0]._y, points[2]._y);
            float perimeter = side1_2 + side1_3 + side2_3;

            Print();

            Console.WriteLine("\nLength from Point_1 to Point_2: {0}", side1_2);
            Console.WriteLine("Length from Point_1 to Point_3: {0}", side1_3);
            Console.WriteLine("Length from Point_2 to Point_3: {0}", side2_3);
            Console.WriteLine("Perimeter: {0}", perimeter);
            Console.WriteLine("Type: " + DefineType());
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            else
            {
                Triangle tr = (Triangle)obj;
                return ((tr.points[0].Equals(points[0]) || tr.points[0].Equals(points[1]) || tr.points[0].Equals(points[2])) &&
                        (tr.points[1].Equals(points[0]) || tr.points[1].Equals(points[1]) || tr.points[1].Equals(points[2])) &&
                        (tr.points[2].Equals(points[0]) || tr.points[2].Equals(points[1]) || tr.points[2].Equals(points[2])) );
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        double CalcAngle(ref Point p1,ref Point p2,ref Point p3)
        {
            float side1_2 = CalcLength(p1._x, p2._x, p1._y, p2._y);
            float side1_3 = CalcLength(p1._x, p3._x, p1._y, p3._y);
            float side2_3 = CalcLength(p2._x, p3._x, p2._y, p3._y);

            return (Math.Pow(side1_2, 2) + Math.Pow(side1_3, 2) - Math.Pow(side2_3, 2)) / (2 * side1_2 * side1_3);
        }
    }
    partial class Triangle
    {
        public string DefineType()
        {
            float alpha = (float)((Math.Acos(CalcAngle(ref points[0],ref points[1],ref points[2])) * 180) / Math.PI);
            float beta = (float)((Math.Acos(CalcAngle(ref points[1], ref points[0],ref points[2])) * 180) / Math.PI);
            float gamma = (float)((Math.Acos(CalcAngle(ref points[2], ref points[0],ref points[1])) * 180) / Math.PI);

            if (alpha == 90 || beta == 90 || gamma == 90)
            {
                return "Right";
            }
            else
            {
                if (alpha == gamma && beta == alpha)
                {
                    return "Equilateral";
                }
                else
                {
                    if (alpha == gamma || gamma == beta || alpha == beta)
                    {
                        return "Isosceles";
                    }
                    else
                    {
                        return "Arbitrary";
                    }
                }
            }


        }
    }

    class Program
    {
        static byte rightAmount;
        static byte equilateralAmount;
        static byte isoscelesAmount;
        static byte arbitraryAmount;
        private Program()
        {
            rightAmount = 0;
            equilateralAmount = 0;
            isoscelesAmount = 0;
            arbitraryAmount = 0;
        }
        static void Main()
        {
            Triangle triangle = new Triangle();
            triangle.ShowInfo();

            Console.ReadKey();
            Console.Clear();

            Triangle[] tr = new Triangle[3];
            tr[0] = new Triangle(new Point(0, 0), new Point(5, 1), new Point(-5, 1));
            tr[1] = new Triangle(new Point(0, 0), new Point(5, 3), new Point(-5, 1));
            tr[2] = new Triangle(new Point(6, 0), new Point(0, 8), new Point(6, 8));

            foreach(var item in tr)
            {
                item.ShowInfo();
                Console.WriteLine();
            }

            for(byte i=0; i<3; ++i)
            {
                string type = tr[i].DefineType();
                if(type == "Right")
                {
                    rightAmount++;
                }
                else
                {
                    if(type == "Equilateral")
                    {
                        equilateralAmount++;
                    }
                    else
                    {
                        if(type == "Isosceles")
                        {
                            isoscelesAmount++;
                        }
                        else
                        {
                            arbitraryAmount++;
                        }
                    }
                }
            }

            Console.WriteLine("Amount of Triangle types:");
            Console.WriteLine("Right: {0}", rightAmount);
            Console.WriteLine("Equilateral: {0}", equilateralAmount);
            Console.WriteLine("Isosceles: {0}", isoscelesAmount);
            Console.WriteLine("Arbitrary: {0}", arbitraryAmount);

        }
    }
}
