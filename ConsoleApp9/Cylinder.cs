using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Cylinder : ISolid
    {
        private double _radius;
        private double _height;

        public Cylinder(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public double Radius
        {
            get => _radius;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Радиус должен быть положительным.");
                _radius = value;
            }
        }

        public double Height
        {
            get => _height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть положительной.");
                _height = value;
            }
        }

        public double Volume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }

        public double SurfaceArea()
        {
            // Полная поверхность: 2 боковые + 2 основания
            return 2 * Math.PI * Radius * Height + 2 * Math.PI * Math.Pow(Radius, 2);
        }

        public string GetName()
        {
            return "Цилиндр";
        }

        public string GetParameters()
        {
            return $"Радиус основания: {Radius} ед., Высота: {Height} ед.";
        }
    }
}
