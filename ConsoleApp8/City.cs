using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    // Потомок: Город
    public class City : Settlement
    {
        private int _population;
        private double _area; // км²

        public City(string name, int population, double area)
            : base(name)
        {
            Population = population;
            Area = area;
        }

        public int Population
        {
            get => _population;
            set
            {
                if (value <= 0) throw new ArgumentException("Население должно быть положительным.");
                _population = value;
            }
        }

        public double Area
        {
            get => _area;
            set
            {
                if (value <= 0) throw new ArgumentException("Площадь должна быть положительной.");
                _area = value;
            }
        }

        // Переопределённый метод вывода
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Тип: Город");
            Console.WriteLine($"Население: {Population} чел.");
            Console.WriteLine($"Площадь: {Area} км²");
        }

        // Реализация абстрактного метода
        public override double PopulationDensity()
        {
            return Population / Area;
        }
    }
}
