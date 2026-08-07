using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSystem.Models
{
    internal class Rectangle:Shape,IDrawable
    {
        public double Width {  get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public override double Area()
        {
            return Width * Height;
        }
        public void Draw()
        {
            Console.WriteLine("Short ASCII Rectangle");   
        }


    }
}
