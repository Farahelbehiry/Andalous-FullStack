using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSystem.Models
{
    internal class Circle:Shape,IDrawable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double Area()
        {
            return Math.PI* Radius *Radius;
        }
        public void Draw()
        {
            Console.WriteLine("Short ASCII Circle");

        }
    }
}
