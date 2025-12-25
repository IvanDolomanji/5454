using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Ввод данных об автобусе ===\n");

            Bus bus = null;

            // Цикл ввода с обработкой исключений до успешного создания объекта
            while (bus == null)
            {
                try
                {
                    Console.WriteLine("Введите данные автобуса:");

                    string brand = ReadNonEmptyString("Марка автобуса: ");

                    int seats = ReadPositiveInt("Количество мест: ");

                    double price = ReadNonNegativeDouble("Стоимость билета (руб.): ");

                    // Создаём объект — если проверка в свойствах не пройдёт, выбросится исключение
                    bus = new Bus(brand, seats, price);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено некорректное число. Повторите ввод.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка ввода данных: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла непредвиденная ошибка: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод.\n");
                }
            }

            // Успешно создан объект — выводим информацию
            Console.WriteLine("\n" + new string('=', 50));
            bus.PrintInfo();

            double totalCost = bus.GetTotalSeatsCost();
            Console.WriteLine("Общая стоимость всех мест: {0:F2} руб.", totalCost);
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы безопасного ввода
        static string ReadNonEmptyString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Ошибка: поле не может быть пустым.");
            } while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }

        static int ReadPositiveInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное целое число.");
            }
        }

        static double ReadNonNegativeDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное число.");
            }
        }
    }
}
