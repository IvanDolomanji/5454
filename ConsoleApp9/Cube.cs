using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Cube : ISolid
    {
        private double _side;

        public Cube(double side)
        {
            Side = side;
        }

        public double Side
        {
            get => _side;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина ребра должна быть положительной.");
                _side = value;
            }
        }

        public double Volume()
        {
            return Math.Pow(Side, 3);
        }

        public double SurfaceArea()
        {
            return 6 * Math.Pow(Side, 2);
        }

        public string GetName()
        {
            return "Куб";
        }

        public string GetParameters()
        {
            return $"Длина ребра: {Side} ед.";
        }
    }
}
