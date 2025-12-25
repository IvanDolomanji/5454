using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт заказов в салоне мебели ===\n");

            int n = ReadPositiveInt("Введите количество заказов: ");

            // Коллекция List<Order>
            List<Order> orders = new List<Order>();

            // Ввод данных
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\n--- Заказ {0} из {1} ---", i, n);

                string fullName = ReadNonEmptyString("Ф.И.О. заказчика: ");

                DateTime orderDate = ReadDate("Дата заказа (дд.мм.гггг): ");

                string furniture = ReadNonEmptyString("Наименование мебели: ");

                int quantity = ReadPositiveInt("Количество (шт.): ");

                double cost = ReadNonNegativeDouble("Стоимость (руб.): ");

                try
                {
                    Order order = new Order(fullName, orderDate, furniture, quantity, cost);
                    orders.Add(order);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    i--; // повтор ввода
                }
            }

            // Вывод всей коллекции
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("ВСЕ ЗАКАЗЫ:");
            Console.WriteLine(new string('=', 70));
            foreach (Order o in orders)
            {
                o.PrintInfo();
                Console.WriteLine();
            }

            // 1. Сортировка по Ф.И.О. заказчика (по возрастанию)
            List<Order> sortedByName = orders.OrderBy(o => o.CustomerFullName).ToList();

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("ЗАКАЗЫ, ОТСОРТИРОВАННЫЕ ПО Ф.И.О. ЗАКАЗЧИКА:");
            Console.WriteLine(new string('=', 70));
            PrintShortList(sortedByName);

            // 2. Сортировка по дате заказа (по возрастанию)
            List<Order> sortedByDate = orders.OrderBy(o => o.OrderDate).ToList();

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("ЗАКАЗЫ, ОТСОРТИРОВАННЫЕ ПО ДАТЕ ЗАКАЗА:");
            Console.WriteLine(new string('=', 70));
            PrintShortList(sortedByDate);

            // 3. Сортировка по стоимости заказа (по возрастанию)
            List<Order> sortedByCost = orders.OrderBy(o => o.Cost).ToList();

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("ЗАКАЗЫ, ОТСОРТИРОВАННЫЕ ПО СТОИМОСТИ ЗАКАЗА:");
            Console.WriteLine(new string('=', 70));
            PrintShortList(sortedByCost);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Краткий вывод списка заказов
        static void PrintShortList(List<Order> list)
        {
            foreach (Order o in list)
            {
                Console.WriteLine(o.ToString());
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
                Console.WriteLine("Ошибка: введите дату в формате дд.мм.гггг.");
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
    }
}
