using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSystem.Models
{
    internal class Triangle:Shape,IDrawable
    {
        public double Base {  get; set; }
        public double Height { get; set; }

        public Triangle(double baselength, double height)
        {
            Base = baselength;
            Height = height;
        }
        public override double Area()
        {
            return 0.5 * Base * Height;
        }
        public void Draw()
        {
            Console.WriteLine("Short ASCII Triangle");
        }
    }
}
