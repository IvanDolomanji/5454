using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    // Производный класс: Письменный стол
    public class WritingDesk : Table
    {
        // Дополнительные поля
        private string _material;
        private double _finishingCost;

        // Конструктор — вызывает базовый конструктор
        public WritingDesk(string name, double area, string material, double finishingCost)
            : base(name, area)
        {
            Material = material;
            FinishingCost = finishingCost;
        }

        // Свойства для новых полей
        public string Material
        {
            get => _material;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Материал не может быть пустым.");
                _material = value.Trim();
            }
        }

        public double FinishingCost
        {
            get => _finishingCost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стоимость отделки не может быть отрицательной.");
                _finishingCost = value;
            }
        }

        // Переопределённый метод вывода информации
        public override void PrintInfo()
        {
            Console.WriteLine($"Тип: Письменный стол");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Площадь: {Area} м²");
            Console.WriteLine($"Материал: {Material}");
            Console.WriteLine($"Стоимость отделки: {FinishingCost} руб.");
        }

        // Переопределённый метод расчёта стоимости с учётом отделки
        public override double CalculateCost()
        {
            // Базовая стоимость + стоимость отделки
            return base.CalculateCost() + FinishingCost;
        }
    }
}
