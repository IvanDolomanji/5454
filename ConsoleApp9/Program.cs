using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Расчёт объёма и площади поверхности геометрических тел ===\n");

            // Ввод куба
            Console.WriteLine("Введите данные для куба:");
            double cubeSide = ReadPositiveDouble("Длина ребра: ");
            Cube cube = new Cube(cubeSide);

            // Ввод цилиндра
            Console.WriteLine("\nВведите данные для цилиндра:");
            double radius = ReadPositiveDouble("Радиус основания: ");
            double height = ReadPositiveDouble("Высота: ");
            Cylinder cylinder = new Cylinder(radius, height);

            // Вывод информации через общий метод
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine(new string('=', 60));

            PrintSolidInfo(cube);
            Console.WriteLine();
            PrintSolidInfo(cylinder);

            // Демонстрация полиморфизма через интерфейс
            Console.WriteLine("\nПолиморфизм через интерфейс ISolid:");
            ISolid[] solids = { cube, cylinder };
            foreach (var solid in solids)
            {
                PrintSolidInfo(solid);
                Console.WriteLine(new string('-', 50));
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Универсальный метод для вывода информации о любом теле
        static void PrintSolidInfo(ISolid solid)
        {
            Console.WriteLine($"Тело: {solid.GetName()}");
            Console.WriteLine($"Параметры: {solid.GetParameters()}");
            Console.WriteLine($"Объём: {solid.Volume():F3} куб. ед.");
            Console.WriteLine($"Площадь поверхности: {solid.SurfaceArea():F3} кв. ед.");
        }

        // Вспомогательный метод ввода положительного числа
        static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out double value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное число.");
            }
        }
    }
}
