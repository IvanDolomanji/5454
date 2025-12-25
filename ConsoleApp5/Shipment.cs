using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Shipment
    {
        // Скрытые поля
        private string _flightNumber;
        private string _destination;
        private double _weight;

        // Конструктор с параметрами и проверкой
        public Shipment(string flightNumber, string destination, double weight)
        {
            FlightNumber = flightNumber;  // Используем свойство для проверки
            Destination = destination;
            Weight = weight;
        }

        // Свойства с логикой проверки
        public string FlightNumber
        {
            get => _flightNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер рейса не может быть пустым.");
                _flightNumber = value.Trim();
            }
        }

        public string Destination
        {
            get => _destination;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Пункт назначения не может быть пустым.");
                _destination = value.Trim();
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес груза должен быть положительным числом.");
                _weight = value;
            }
        }

        // Метод для вывода информации о перевозке
        public void PrintInfo()
        {
            Console.WriteLine($"Рейс: {FlightNumber}, Пункт назначения: {Destination}, Вес: {Weight} кг");
        }

        // Переопределение ToString для удобного вывода
        public override string ToString()
        {
            return $"Рейс {FlightNumber} → {Destination}, вес: {Weight} кг";
        }
    }
}
