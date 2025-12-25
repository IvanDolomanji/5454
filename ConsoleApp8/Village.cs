using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    // Потомок: Село
    public class Village : Settlement
    {
        private int _housesCount;
        private double _avgResidentsPerHouse;
        private double _area; // км²

        public Village(string name, int housesCount, double avgResidentsPerHouse, double area)
            : base(name)
        {
            HousesCount = housesCount;
            AvgResidentsPerHouse = avgResidentsPerHouse;
            Area = area;
        }

        public int HousesCount
        {
            get => _housesCount;
            set
            {
                if (value <= 0) throw new ArgumentException("Количество домов должно быть положительным.");
                _housesCount = value;
            }
        }

        public double AvgResidentsPerHouse
        {
            get => _avgResidentsPerHouse;
            set
            {
                if (value <= 0) throw new ArgumentException("Среднее число жителей в доме должно быть положительным.");
                _avgResidentsPerHouse = value;
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
            Console.WriteLine("Тип: Село");
            Console.WriteLine($"Количество домов: {HousesCount}");
            Console.WriteLine($"Среднее число жителей в доме: {AvgResidentsPerHouse}");
            Console.WriteLine($"Площадь: {Area} км²");
            int totalResidents = (int)Math.Round(HousesCount * AvgResidentsPerHouse);
            Console.WriteLine($"Общее население: {totalResidents} чел.");
        }

        // Реализация абстрактного метода
        public override double PopulationDensity()
        {
            double totalResidents = HousesCount * AvgResidentsPerHouse;
            return totalResidents / Area;
        }
    }
}
