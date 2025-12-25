using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
   
        // Базовый класс: Стол
        public class Table
        {
            // Поля
            private string _name;
            private double _area; // площадь в м²

            // Конструктор с параметрами
            public Table(string name, double area)
            {
                Name = name;
                Area = area;
            }

            // Свойства с проверкой
            public string Name
            {
                get => _name;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Название стола не может быть пустым.");
                    _name = value.Trim();
                }
            }

            public double Area
            {
                get => _area;
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Площадь должна быть положительной.");
                    _area = value;
                }
            }

            // Виртуальный метод вывода информации
            public virtual void PrintInfo()
            {
                Console.WriteLine($"Тип: Обычный стол");
                Console.WriteLine($"Название: {Name}");
                Console.WriteLine($"Площадь: {Area} м²");
            }

            // Метод расчёта стоимости (виртуальный, чтобы можно было переопределить)
            public virtual double CalculateCost()
            {
                return 50 + 100 * Area;
            }
        }
}
