using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ShapeSystem.Models;

namespace ShapeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] shape = new Shape[]
            {
                new Circle(5),
                new Rectangle(10,5),
                new Triangle(3,6)
            };

            foreach (Shape n in shape)
            {
                n.Describe();

                if(n is IDrawable drawable)
                {
                    drawable.Draw();
                }
            
            }

        }
    }
}
