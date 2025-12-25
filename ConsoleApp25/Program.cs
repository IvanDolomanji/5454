using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    // Структура Книга
    struct Book
    {
        public string Author;       // Автор
        public string Title;        // Название
        public int Circulation;     // Тираж
        public double Price;        // Цена

        // Конструктор структуры
        public Book(string author, string title, int circulation, double price)
        {
            Author = author;
            Title = title;
            Circulation = circulation;
            Price = price;
        }

        // Метод вывода информации о книге в строку таблицы
        public string ToTableRow()
        {
            return string.Format("{0,-25} {1,-35} {2,10} {3,10:F2}",
                Author, Title, Circulation, Price);
        }

        // Метод возврата стоимости тиража книги (тираж * цена)
        public double GetTotalCost()
        {
            return Circulation * Price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт книг ===\n");

            int n = ReadPositiveInt("Введите количество книг (N): ");

            // Массив из N объектов структуры
            Book[] books = new Book[n];

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Книга {i + 1} из {n} ---");

                string author = ReadNonEmptyString("Автор: ");
                string title = ReadNonEmptyString("Название: ");
                int circulation = ReadPositiveInt("Тираж (экземпляров): ");
                double price = ReadNonNegativeDouble("Цена одного экземпляра (руб.): ");

                books[i] = new Book(author, title, circulation, price);
            }

            // Вывод таблицы
            Console.WriteLine("\n" + new string('=', 90));
            Console.WriteLine("ТАБЛИЦА КНИГ:");
            Console.WriteLine(new string('=', 90));
            Console.WriteLine("{0,-25} {1,-35} {2,10} {3,10}",
                "Автор", "Название", "Тираж", "Цена");
            Console.WriteLine(new string('-', 90));

            double totalHighCirculationCost = 0;

            foreach (Book b in books)
            {
                Console.WriteLine(b.ToTableRow());

                // Если тираж > 10000 — добавляем стоимость тиража к общей сумме
                if (b.Circulation > 10000)
                {
                    totalHighCirculationCost += b.GetTotalCost();
                }
            }

            Console.WriteLine(new string('=', 90));

            // Вывод общей стоимости книг с тиражом > 10000
            Console.WriteLine($"\nОбщая стоимость всех книг с тиражом более 10000 экземпляров: {totalHighCirculationCost:F2} руб.");

            if (totalHighCirculationCost == 0)
            {
                Console.WriteLine("Книг с тиражом более 10000 экземпляров нет.");
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
    }
}
