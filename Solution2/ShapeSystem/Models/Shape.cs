using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSystem.Models
{
    public abstract class Shape
    {
        public abstract double Area();
        
        public void Describe()
        {
            Console.WriteLine($"Shape: {ToString()} ,the area is {Area()}");
        }
    }
}
