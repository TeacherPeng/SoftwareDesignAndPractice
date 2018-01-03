using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLesson01
{
    public class Complex
    {
        public Complex(double ax, double ay)
        {
            x = ax;
            y = ay;
        }
        public double x { get; set; }
        public double y { get; set; }
        public static Complex operator+(Complex c1, Complex c2)
        {
            return new Complex(c1.x + c2.x, c1.y + c2.y);
        }
        public static Complex operator-(Complex c1, Complex c2)
        {
            return new Complex(c1.x - c2.x, c1.x - c2.y);
        }
    }
}
