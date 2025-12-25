using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const int CurrentYear = 2025;

            Console.WriteLine("=== Учёт товаров ===\n");
            Console.WriteLine($"Текущий год для расчёта: {CurrentYear}\n");

            int n = ReadPositiveInt("Введите количество товаров (N): ");

            // Массив из N объектов структуры
            Product[] products = new Product[n];

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Товар {i + 1} из {n} ---");

                string name = ReadNonEmptyString("Наименование товара: ");
                string manufacturer = ReadNonEmptyString("Изготовитель: ");
                int quantity = ReadPositiveInt("Количество: ");
                double price = ReadNonNegativeDouble("Цена (руб.): ");
                int year = ReadYear("Год выпуска: ");

                products[i] = new Product(name, manufacturer, quantity, price, year);
            }

            // Вывод таблицы
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("ТАБЛИЦА ТОВАРОВ:");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("{0,-20} {1,-20} {2,8} {3,10} {4,8}",
                "Наименование", "Изготовитель", "Кол-во", "Цена", "Год");
            Console.WriteLine(new string('-', 80));

            double totalCurrentYearCost = 0;

            foreach (Product p in products)
            {
                Console.WriteLine(p.ToTableRow());

                // Если товар выпущен в текущем году — добавляем к общей стоимости
                if (p.ReleaseYear == CurrentYear)
                {
                    totalCurrentYearCost += p.GetTotalCost();
                }
            }

            Console.WriteLine(new string('=', 80));

            // Вывод общей стоимости товаров текущего года
            Console.WriteLine($"\nОбщая стоимость всех товаров, выпущенных в {CurrentYear} году: {totalCurrentYearCost:F2} руб.");

            if (totalCurrentYearCost == 0)
            {
                Console.WriteLine("Товаров, выпущенных в текущем году, нет.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы ввода с проверкой
        static string ReadNonEmptyString(string prompt)
        {
            string value;
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                    return value.Trim();
                Console.WriteLine("Ошибка: поле не может быть пустым.");
            }
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

        static int ReadYear(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 1900 && value <= 2025)
                    return value;
                Console.WriteLine("Ошибка: введите год от 1900 до 2025.");
            }
        }
    }
}
