using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт спортсменов ===\n");

            Console.Write("Введите количество спортсменов (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка: введите положительное целое число.");
                Console.ReadKey();
                return;
            }

            // Список для хранения спортсменов (можно и массив Athlete[])
            List<Athlete> athletes = new List<Athlete>();

            Console.WriteLine("\nВведите данные по каждому спортсмену:\n");

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"--- Спортсмен {i} из {n} ---");

                string fullName = ReadString("Ф.И.О.: ");

                int height = ReadIntInRange("Рост (см): ", 100, 250);

                double weight = ReadDoubleInRange("Вес (кг): ", 30, 200);

                try
                {
                    Athlete athlete = new Athlete(fullName, height, weight);
                    athletes.Add(athlete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Повторите ввод для этого спортсмена.\n");
                    i--; // Повторяем текущего спортсмена
                }

                Console.WriteLine();
            }

            // Поиск спортсменов с весом > 70 кг
            List<Athlete> heavyAthletes = new List<Athlete>();
            foreach (var athlete in athletes)
            {
                if (athlete.IsOver70Kg())
                {
                    heavyAthletes.Add(athlete);
                }
            }

            // Вывод результатов
            Console.WriteLine("========================================");
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine("========================================");

            Console.WriteLine($"\nКоличество спортсменов с весом > 70 кг: {heavyAthletes.Count}");

            if (heavyAthletes.Count > 0)
            {
                Console.WriteLine("\nСписок таких спортсменов:");
                foreach (var athlete in heavyAthletes)
                {
                    Console.WriteLine($"• {athlete}");
                    // Если нужно подробнее:
                    // athlete.PrintInfo();
                    // Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\nТаких спортсменов нет.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы ввода с проверкой
        static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Console.WriteLine("Ошибка: поле не может быть пустым.");
            }
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Ошибка: введите целое число от {min} до {max}.");
            }
        }

        static double ReadDoubleInRange(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out double value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Ошибка: введите число от {min} до {max}.");
            }
        }
    }
}
