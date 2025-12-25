using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Определение вида параллелограмма ===\n");

            Console.WriteLine("Введите параметры параллелограмма:");

            double a = ReadPositiveDouble("Сторона a: ");
            double b = ReadPositiveDouble("Сторона b: ");
            double alpha = ReadDoubleInRange("Угол α между сторонами a и b (в градусах): ", 0.001, 179.999);

            Parallelogram parallelogram = null;

            try
            {
                parallelogram = new Parallelogram(a, b, alpha);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nОшибка при создании объекта: {0}", ex.Message);
                Console.WriteLine("Программа завершится.");
                Console.ReadKey();
                return;
            }

            // Вывод информации
            Console.WriteLine("\n" + new string('=', 50));
            parallelogram.PrintInfo();
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы ввода
        static double ReadPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное число.");
            }
        }

        static double ReadDoubleInRange(string prompt, double min, double max)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out value) && value > min && value < max)
                    return value;
                Console.WriteLine("Ошибка: значение должно быть больше {0} и меньше {1}.", min, max);
            }
        }
    }
}
