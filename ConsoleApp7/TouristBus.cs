using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    // Производный класс: Туристический автобус
    public class TouristBus : Bus
    {
        private double _excursionCost;

        // Конструктор — вызывает базовый
        public TouristBus(string brand, int seats, double ticketPrice, double excursionCost)
            : base(brand, seats, ticketPrice)
        {
            ExcursionCost = excursionCost;
        }

        // Свойство для стоимости экскурсии
        public double ExcursionCost
        {
            get => _excursionCost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стоимость экскурсии не может быть отрицательной.");
                _excursionCost = value;
            }
        }

        // Переопределённый метод вывода информации
        public override void PrintInfo()
        {
            Console.WriteLine("=== Туристический автобус ===");
            Console.WriteLine($"Марка: {Brand}");
            Console.WriteLine($"Количество мест: {Seats}");
            Console.WriteLine($"Базовая стоимость билета: {TicketPrice} руб.");
            Console.WriteLine($"Стоимость экскурсии (добавляется к билету): {ExcursionCost} руб.");
            Console.WriteLine($"Итоговая цена билета: {TicketPrice + ExcursionCost} руб.");
        }

        // Переопределённый метод: общая выручка с учётом экскурсии
        public override double CalculateTotalRevenue()
        {
            // Цена билета увеличивается на стоимость экскурсии для каждого пассажира
            return Seats * (TicketPrice + ExcursionCost);
        }
    }
}
