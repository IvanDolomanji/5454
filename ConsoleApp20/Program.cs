using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Ввод данных о треугольнике ===\n");

            Triangle triangle = null;

            while (triangle == null)
            {
                try
                {
                    Console.WriteLine("Введите длины трёх сторон треугольника:");

                    double a = ReadPositiveDouble("Сторона a: ");
                    double b = ReadPositiveDouble("Сторона b: ");
                    double c = ReadPositiveDouble("Сторона c: ");

                    // Создаём объект
                    triangle = new Triangle(a, b, c);

                    // Дополнительная проверка неравенства треугольника после установки свойств
                    triangle.ValidateTriangleInequality();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный формат числа. Повторите ввод.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неизвестная ошибка: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод.\n");
                }
            }

            // Успешно создан объект — выводим информацию
            Console.WriteLine("\n" + new string('=', 50));
            triangle.PrintInfo();
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
    }
}
