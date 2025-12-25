using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт товаров ===\n");

            int n = ReadPositiveInt("Введите количество видов товаров (N): ");

            // Массив объектов Product
            Product[] products = new Product[n];

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n--- Товар {0} из {1} ---", i + 1, n);

                string name = ReadNonEmptyString("Наименование товара: ");

                double price = ReadNonNegativeDouble("Цена товара (руб.): ");

                int quantity = ReadNonNegativeInt("Количество (шт.): ");

                try
                {
                    products[i] = new Product(name, price, quantity);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод для этого товара.\n");
                    i--; // повторяем текущий товар
                    continue;
                }
            }

            // Вывод исходного списка
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ИСХОДНЫЙ СПИСОК ТОВАРОВ:");
            Console.WriteLine(new string('=', 60));
            PrintArray(products);

            // 1. Сортировка по наименованию (по возрастанию)
            Array.Sort(products, (p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("СОРТИРОВКА ПО НАИМЕНОВАНИЮ:");
            Console.WriteLine(new string('=', 60));
            PrintArray(products);

            // 2. Сортировка по цене (по возрастанию)
            Array.Sort(products, (p1, p2) => p1.Price.CompareTo(p2.Price));

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("СОРТИРОВКА ПО ЦЕНЕ:");
            Console.WriteLine(new string('=', 60));
            PrintArray(products);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вывод массива товаров
        static void PrintArray(Product[] array)
        {
            foreach (Product p in array)
            {
                Console.WriteLine(p.ToString());
            }
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
                Console.WriteLine("Ошибка: наименование не может быть пустым.");
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

        static int ReadNonNegativeInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное целое число.");
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
    }
}
