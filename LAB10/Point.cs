using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10;
class Point
{
    float x;
    float y;
    private static int amount;
    public readonly int ID;
    public Point() : this(0, 0) { }
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
        if (obj == null)
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
