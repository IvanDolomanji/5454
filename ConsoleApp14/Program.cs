using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт товаров с контролем срока годности ===\n");

            // Ввод двух списков
            Console.WriteLine("Введите данные для обычных товаров (2 списка):\n");

            Console.Write("Введите количество товаров в первом списке: ");
            int n1 = ReadPositiveInt();

            List<Product> list1 = InputProducts(n1, "первого");

            Console.Write("\nВведите количество товаров во втором списке: ");
            int n2 = ReadPositiveInt();

            List<Product> list2 = InputProducts(n2, "второго");

            // Вывод информации обо всех объектах
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ИНФОРМАЦИЯ О ТОВАРАХ ПЕРВОГО СПИСКА:");
            Console.WriteLine(new string('=', 60));
            PrintProductList(list1);

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ИНФОРМАЦИЯ О ТОВАРАХ ВТОРОГО СПИСКА:");
            Console.WriteLine(new string('=', 60));
            PrintProductList(list2);

            // Поиск товаров, у которых срок годности заканчивается в ближайшие 30 суток
            List<Product> expiringSoon = new List<Product>();

            foreach (Product p in list1)
            {
                if (p.IsExpiringSoon(30))
                    expiringSoon.Add(p);
            }
            foreach (Product p in list2)
            {
                if (p.IsExpiringSoon(30))
                    expiringSoon.Add(p);
            }

            // Вывод списка товаров с заканчивающимся сроком годности
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ТОВАРЫ, У КОТОРЫХ СРОК ГОДНОСТИ ЗАКАНЧИВАЕТСЯ В ТЕЧЕНИЕ 30 СУТОК:");
            Console.WriteLine(new string('=', 60));

            if (expiringSoon.Count > 0)
            {
                foreach (Product p in expiringSoon)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("Таких товаров нет.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Ввод списка товаров
        static List<Product> InputProducts(int count, string listName)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("\nВвод данных для {0} списка ({1} товар(ов)):", listName, count);

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("\n--- Товар {0} из {1} ---", i, count);

                string name = ReadNonEmptyString("Наименование товара: ");

                DateTime productionDate = ReadDate("Дата производства (дд.мм.гггг): ");

                int shelfLife = ReadNonNegativeInt("Срок годности (дней): ");

                double price = ReadNonNegativeDouble("Цена (руб.): ");

                try
                {
                    Product p = new Product(name, productionDate, shelfLife, price);
                    products.Add(p);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    i--; // повтор ввода
                }
            }

            return products;
        }

        // Вывод списка товаров
        static void PrintProductList(List<Product> list)
        {
            foreach (Product p in list)
            {
                p.PrintInfo();
                Console.WriteLine();
            }
        }

        // Вспомогательные методы ввода
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

        static DateTime ReadDate(string prompt)
        {
            DateTime value;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out value))
                    return value;
                Console.WriteLine("Ошибка: введите дату в формате дд.мм.гггг (например, 25.12.2025).");
            }
        }

        static int ReadPositiveInt()
        {
            int value;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное целое число.");
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
