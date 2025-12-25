using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Классификация треугольников по сторонам ===\n");

            int n = ReadPositiveInt("Введите количество треугольников (N): ");

            // Сброс счётчиков перед началом
            Triangle.ResetCounters();

            // Списки для хранения треугольников каждого типа
            List<Triangle> equilateral = new List<Triangle>();
            List<Triangle> isosceles = new List<Triangle>();
            List<Triangle> scalene = new List<Triangle>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\n--- Треугольник {0} из {1} ---", i, n);

                double a, b, c;
                Triangle triangle = null;

                while (triangle == null)
                {
                    a = ReadPositiveDouble("Сторона a: ");
                    b = ReadPositiveDouble("Сторона b: ");
                    c = ReadPositiveDouble("Сторона c: ");

                    try
                    {
                        triangle = new Triangle(a, b, c);

                        // Добавляем в соответствующий список
                        string type = triangle.GetTypeName();
                        if (type == "равносторонний")
                            equilateral.Add(triangle);
                        else if (type == "равнобедренный")
                            isosceles.Add(triangle);
                        else
                            scalene.Add(triangle);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Ошибка: {0}", ex.Message);
                        Console.WriteLine("Повторите ввод сторон для этого треугольника.\n");
                        triangle = null;
                    }
                }
            }

            // Вывод результатов
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine(new string('=', 50));

            PrintList("Равносторонние треугольники", equilateral, Triangle.EquilateralCount);
            PrintList("Равнобедренные треугольники", isosceles, Triangle.IsoscelesCount);
            PrintList("Разносторонние треугольники", scalene, Triangle.ScaleneCount);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void PrintList(string header, List<Triangle> list, int count)
        {
            Console.WriteLine("\n{0}: {1} шт.", header, count);
            if (list.Count > 0)
            {
                foreach (Triangle t in list)
                {
                    Console.Write("  ");
                    t.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("  Нет таких треугольников.");
            }
        }

        // Вспомогательные методы ввода
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
