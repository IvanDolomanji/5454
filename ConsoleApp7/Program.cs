using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Программа расчёта выручки автобусов ===\n");

            Bus regularBus = null;
            TouristBus touristBus = null;

            // Ввод данных для обычного автобуса
            Console.WriteLine("Введите данные обычного автобуса:");
            regularBus = CreateBus();

            // Ввод данных для туристического автобуса
            Console.WriteLine("\nВведите данные туристического автобуса:");
            touristBus = CreateTouristBus();

            // Вывод информации и расчёт выручки
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine(new string('=', 50));

            // Обычный автобус
            regularBus.PrintInfo();
            Console.WriteLine($"Общая выручка: {regularBus.CalculateTotalRevenue()} руб.\n");

            // Туристический автобус (полиморфизм в действии)
            touristBus.PrintInfo();
            Console.WriteLine($"Общая выручка (с экскурсией): {touristBus.CalculateTotalRevenue()} руб.\n");

            // Демонстрация полиморфизма через базовый тип
            Console.WriteLine("Полиморфизм: вызов через базовый класс Bus:");
            Bus[] buses = { regularBus, touristBus };
            foreach (var bus in buses)
            {
                bus.PrintInfo();
                Console.WriteLine($"Выручка: {bus.CalculateTotalRevenue()} руб.");
                Console.WriteLine(new string('-', 40));
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательный метод для создания обычного автобуса
        static Bus CreateBus()
        {
            string brand = ReadString("Марка автобуса: ");
            int seats = ReadPositiveInt("Количество мест: ");
            double price = ReadNonNegativeDouble("Стоимость билета (руб.): ");

            return new Bus(brand, seats, price);
        }

        // Вспомогательный метод для создания туристического автобуса
        static TouristBus CreateTouristBus()
        {
            string brand = ReadString("Марка автобуса: ");
            int seats = ReadPositiveInt("Количество мест: ");
            double price = ReadNonNegativeDouble("Базовая стоимость билета (руб.): ");
            double excursion = ReadNonNegativeDouble("Стоимость экскурсии (руб., добавляется к билету): ");

            return new TouristBus(brand, seats, price, excursion);
        }

        // Удобные методы ввода с проверкой
        static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Console.WriteLine("Ошибка: поле не может быть пустым.");
            }
        }

        static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное целое число.");
            }
        }

        static double ReadNonNegativeDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out double value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное число.");
            }
        }
    }
}
