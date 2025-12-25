using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Плотность населения в селе и городе ===\n");

            // Ввод села
            Console.WriteLine("Введите данные о селе:");
            Village village = CreateVillage();

            // Ввод города
            Console.WriteLine("\nВведите данные о городе:");
            City city = CreateCity();

            // Вывод результатов
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine(new string('=', 50));

            // Село
            village.PrintInfo();
            Console.WriteLine($"Плотность населения: {village.PopulationDensity():F2} чел./км²\n");

            // Город
            city.PrintInfo();
            Console.WriteLine($"Плотность населения: {city.PopulationDensity():F2} чел./км²\n");

            // Полиморфизм: работа через базовый класс
            Console.WriteLine("Демонстрация полиморфизма:");
            Settlement[] settlements = { village, city };
            foreach (var s in settlements)
            {
                s.PrintInfo();
                Console.WriteLine($"Плотность: {s.PopulationDensity():F2} чел./км²");
                Console.WriteLine(new string('-', 40));
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static Village CreateVillage()
        {
            string name = ReadString("Название села: ");
            int houses = ReadPositiveInt("Количество домов: ");
            double avg = ReadPositiveDouble("Среднее число жителей в одном доме: ");
            double area = ReadPositiveDouble("Площадь села (км²): ");

            return new Village(name, houses, avg, area);
        }

        static City CreateCity()
        {
            string name = ReadString("Название города: ");
            int population = ReadPositiveInt("Количество жителей: ");
            double area = ReadPositiveDouble("Площадь города (км²): ");

            return new City(name, population, area);
        }

        // Вспомогательные методы ввода
        static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
                Console.WriteLine("Ошибка: поле не может быть пустым.");
            }
        }

        static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0) return value;
                Console.WriteLine("Ошибка: введите положительное целое число.");
            }
        }

        static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out double value) && value > 0) return value;
                Console.WriteLine("Ошибка: введите положительное число.");
            }
        }
    }
}
