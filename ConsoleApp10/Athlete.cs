using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Athlete
    {
        private string _fullName;
        private int _height;    // в см
        private double _weight; // в кг

        // Конструктор с параметрами и проверкой через свойства
        public Athlete(string fullName, int height, double weight)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
        }

        // Свойства с логикой проверки
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ф.И.О. не может быть пустым.");
                _fullName = value.Trim();
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (value <= 100 || value >= 250)
                    throw new ArgumentException("Рост должен быть в разумных пределах (100–250 см).");
                _height = value;
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 30 || value >= 200)
                    throw new ArgumentException("Вес должен быть в разумных пределах (30–200 кг).");
                _weight = value;
            }
        }

        // Метод для проверки, превышает ли вес 70 кг
        public bool IsOver70Kg()
        {
            return Weight > 70;
        }

        // Метод вывода информации о спортсмене
        public void PrintInfo()
        {
            Console.WriteLine($"Ф.И.О.: {FullName}");
            Console.WriteLine($"Рост: {Height} см");
            Console.WriteLine($"Вес: {Weight} кг");
        }

        // Переопределение ToString для удобного вывода в списке
        public override string ToString()
        {
            return $"{FullName} (рост: {Height} см, вес: {Weight} кг)";
        }
    }
}
