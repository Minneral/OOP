using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10;

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

    public float GetPerimeter()
    {
        float side1_2 = CalcLength(points[0]._x, points[1]._x, points[0]._y, points[1]._y);
        float side2_3 = CalcLength(points[1]._x, points[2]._x, points[1]._y, points[2]._y);
        float side1_3 = CalcLength(points[0]._x, points[2]._x, points[0]._y, points[2]._y);
        return side1_2 + side1_3 + side2_3;
    }
    public float GetArea()
    {
        float side1_2 = CalcLength(points[0]._x, points[1]._x, points[0]._y, points[1]._y);
        float side2_3 = CalcLength(points[1]._x, points[2]._x, points[1]._y, points[2]._y);
        float side1_3 = CalcLength(points[0]._x, points[2]._x, points[0]._y, points[2]._y);
        float perimeter = side1_2 + side1_3 + side2_3;
        float halfPerimeter = perimeter / 2;
        return (float)Math.Sqrt(halfPerimeter * (halfPerimeter - side1_2) * (halfPerimeter - side2_3) * (halfPerimeter - side1_3));
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
        Console.WriteLine("Area: {0}", GetArea());
        Console.WriteLine("Type: " + DefineType());
    }
    public bool BelongToRange(float from, float to)
    {
        float side1_2 = CalcLength(points[0]._x, points[1]._x, points[0]._y, points[1]._y);
        float side2_3 = CalcLength(points[1]._x, points[2]._x, points[1]._y, points[2]._y);
        float side1_3 = CalcLength(points[0]._x, points[2]._x, points[0]._y, points[2]._y);

        if(side1_2 > from && side1_2 < to)
        {
            if(side1_3 > from && side1_3 < to)
            {
                if(side2_3 > from && side2_3 < to)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        else
        {
            Triangle tr = (Triangle)obj;
            return ((tr.points[0].Equals(points[0]) || tr.points[0].Equals(points[1]) || tr.points[0].Equals(points[2])) &&
                    (tr.points[1].Equals(points[0]) || tr.points[1].Equals(points[1]) || tr.points[1].Equals(points[2])) &&
                    (tr.points[2].Equals(points[0]) || tr.points[2].Equals(points[1]) || tr.points[2].Equals(points[2])));
        }
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    double CalcAngle(ref Point p1, ref Point p2, ref Point p3)
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
        float alpha = (float)((Math.Acos(CalcAngle(ref points[0], ref points[1], ref points[2])) * 180) / Math.PI);
        float beta = (float)((Math.Acos(CalcAngle(ref points[1], ref points[0], ref points[2])) * 180) / Math.PI);
        float gamma = (float)((Math.Acos(CalcAngle(ref points[2], ref points[0], ref points[1])) * 180) / Math.PI);

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
