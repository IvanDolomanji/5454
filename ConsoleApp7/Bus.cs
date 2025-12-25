using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    // Базовый класс: Автобус
    public class Bus
    {
        private string _brand;
        private int _seats;
        private double _ticketPrice;

        // Конструктор с параметрами
        public Bus(string brand, int seats, double ticketPrice)
        {
            Brand = brand;
            Seats = seats;
            TicketPrice = ticketPrice;
        }

        // Свойства с проверкой
        public string Brand
        {
            get => _brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Марка автобуса не может быть пустой.");
                _brand = value.Trim();
            }
        }

        public int Seats
        {
            get => _seats;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество мест должно быть положительным.");
                _seats = value;
            }
        }

        public double TicketPrice
        {
            get => _ticketPrice;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стоимость билета не может быть отрицательной.");
                _ticketPrice = value;
            }
        }

        // Виртуальный метод вывода информации
        public virtual void PrintInfo()
        {
            Console.WriteLine("=== Обычный автобус ===");
            Console.WriteLine($"Марка: {Brand}");
            Console.WriteLine($"Количество мест: {Seats}");
            Console.WriteLine($"Стоимость билета: {TicketPrice} руб.");
        }

        // Виртуальный метод расчёта общей выручки
        public virtual double CalculateTotalRevenue()
        {
            return Seats * TicketPrice;
        }
    }
}
