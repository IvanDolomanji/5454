using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Классификация треугольников по углам ===\n");

            Console.Write("Введите количество треугольников (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка: введите положительное целое число.");
                Console.ReadKey();
                return;
            }

            // Сброс счётчиков
            Triangle.ResetCounters();

            // Списки для разделения по типу
            List<Triangle> acuteTriangles = new List<Triangle>();
            List<Triangle> rightTriangles = new List<Triangle>();
            List<Triangle> obtuseTriangles = new List<Triangle>();

            Console.WriteLine("\nВведите углы каждого треугольника в градусах:\n");

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"--- Треугольник {i} из {n} ---");

                double a, b, c;

                while (true)
                {
                    try
                    {
                        Console.Write("Угол A (°): ");
                        a = double.Parse(Console.ReadLine().Replace('.', ','));

                        Console.Write("Угол B (°): ");
                        b = double.Parse(Console.ReadLine().Replace('.', ','));

                        Console.Write("Угол C (°): ");
                        c = double.Parse(Console.ReadLine().Replace('.', ','));

                        Triangle triangle = new Triangle(a, b, c);

                        // Добавляем в соответствующий список
                        if (triangle.GetTypeName() == "остроугольный")
                            acuteTriangles.Add(triangle);
                        else if (triangle.GetTypeName() == "прямоугольный")
                            rightTriangles.Add(triangle);
                        else
                            obtuseTriangles.Add(triangle);

                        break; // Успешно — выходим из цикла ввода
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: введите числовое значение (можно с запятой).");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Повторите ввод углов для этого треугольника.\n");
                    }
                }

                Console.WriteLine();
            }

            // Вывод результатов
            Console.WriteLine("========================================");
            Console.WriteLine("РЕЗУЛЬТАТЫ КЛАССИФИКАЦИИ:");
            Console.WriteLine("========================================");

            Console.WriteLine($"\nОстроугольных треугольников: {Triangle.AcuteCount}");
            PrintTriangleList(acuteTriangles, "Остроугольные треугольники:");

            Console.WriteLine($"\nПрямоугольных треугольников: {Triangle.RightCount}");
            PrintTriangleList(rightTriangles, "Прямоугольные треугольники:");

            Console.WriteLine($"\nТупоугольных треугольников: {Triangle.ObtuseCount}");
            PrintTriangleList(obtuseTriangles, "Тупоугольные треугольники:");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательный метод для красивого вывода списка
        static void PrintTriangleList(List<Triangle> list, string header)
        {
            if (list.Count > 0)
            {
                Console.WriteLine(header);
                foreach (var t in list)
                {
                    Console.Write("  ");
                    t.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Нет треугольников этого типа.");
            }
        }
    }
}
