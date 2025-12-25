using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Ввод данных о газете ===\n");

            Newspaper newspaper = null;

            // Цикл ввода до успешного создания объекта
            while (newspaper == null)
            {
                try
                {
                    Console.WriteLine("Введите данные газеты:");

                    int circulation = ReadPositiveInt("Тираж (экземпляров): ");

                    int sheetCount = ReadPositiveInt("Количество листов в одном экземпляре: ");

                    double pricePerSheet = ReadNonNegativeDouble("Стоимость одного листа (руб.): ");

                    // Создаём объект — проверка в свойствах
                    newspaper = new Newspaper(circulation, sheetCount, pricePerSheet);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный формат числа. Повторите ввод.\n");
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
            newspaper.PrintInfo();

            double totalCost = newspaper.GetTotalCost();
            Console.WriteLine("Стоимость всего тиража: {0:F2} руб.", totalCost);
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы безопасного ввода
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
