using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    // Структура Хоккеист
    struct HockeyPlayer
    {
        public string LastName;             // Фамилия
        public int Age;                     // Возраст
        public int GamesPlayed;             // Количество игр
        public int GoalsScored;             // Количество заброшенных шайб

        // Конструктор структуры
        public HockeyPlayer(string lastName, int age, int gamesPlayed, int goalsScored)
        {
            LastName = lastName;
            Age = age;
            GamesPlayed = gamesPlayed;
            GoalsScored = goalsScored;
        }

        // Метод вывода информации о хоккеисте в строку таблицы
        public string ToTableRow()
        {
            return string.Format("{0,-20} {1,5} {2,8} {3,10}",
                LastName, Age, GamesPlayed, GoalsScored);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт хоккеистов ===\n");

            int n = ReadPositiveInt("Введите количество хоккеистов (N): ");

            // Массив из N объектов структуры
            HockeyPlayer[] players = new HockeyPlayer[n];

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Хоккеист {i + 1} из {n} ---");

                string lastName = ReadNonEmptyString("Фамилия: ");
                int age = ReadPositiveInt("Возраст: ");
                int games = ReadNonNegativeInt("Количество игр: ");
                int goals = ReadNonNegativeInt("Количество заброшенных шайб: ");

                players[i] = new HockeyPlayer(lastName, age, games, goals);
            }

            // Вывод таблицы
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("ТАБЛИЦА ХОККЕИСТОВ:");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine("{0,-20} {1,5} {2,8} {3,10}",
                "Фамилия", "Возраст", "Игр", "Шайб");
            Console.WriteLine(new string('-', 70));

            int totalAge = 0;
            int playersOver25Count = 0;

            foreach (HockeyPlayer p in players)
            {
                Console.WriteLine(p.ToTableRow());
                totalAge += p.Age;

                if (p.Age > 25)
                    playersOver25Count++;
            }

            Console.WriteLine(new string('=', 70));

            // Средний возраст
            double averageAge = n > 0 ? (double)totalAge / n : 0;
            Console.WriteLine($"\nСредний возраст хоккеистов: {averageAge:F2} лет");

            // Вывод хоккеистов старше 25 лет
            Console.WriteLine("\nХоккеисты, возраст которых больше 25 лет:");
            if (playersOver25Count > 0)
            {
                Console.WriteLine("{0,-20} {1,5} {2,8} {3,10}",
                    "Фамилия", "Возраст", "Игр", "Шайб");
                Console.WriteLine(new string('-', 70));

                foreach (HockeyPlayer p in players)
                {
                    if (p.Age > 25)
                    {
                        Console.WriteLine(p.ToTableRow());
                    }
                }
            }
            else
            {
                Console.WriteLine("Таких хоккеистов нет.");
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

        static int ReadNonNegativeInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное целое число.");
            }
        }
    }
}