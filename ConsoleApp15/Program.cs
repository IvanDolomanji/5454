using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Каталог фильмов по жанрам ===\n");

            int n = ReadPositiveInt("Введите общее количество фильмов: ");

            // Коллекция List<Film>
            List<Film> films = new List<Film>();

            // Ввод данных
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\n--- Фильм {0} из {1} ---", i, n);

                string title = ReadNonEmptyString("Название фильма: ");

                DateTime releaseDate = ReadDate("Дата выхода на экраны (дд.мм.гггг): ");

                string genre = ReadNonEmptyString("Жанр: ");

                try
                {
                    Film film = new Film(title, releaseDate, genre);
                    films.Add(film);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    i--; // повтор ввода
                }
            }

            // Вывод всей коллекции
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ВСЕ ФИЛЬМЫ:");
            Console.WriteLine(new string('=', 60));
            foreach (Film f in films)
            {
                f.PrintInfo();
                Console.WriteLine();
            }

            // Группировка по жанрам с помощью Dictionary<string, List<Film>>
            Dictionary<string, List<Film>> filmsByGenre = new Dictionary<string, List<Film>>();

            foreach (Film f in films)
            {
                string genreKey = f.Genre.ToLower(); // для независимости от регистра

                if (!filmsByGenre.ContainsKey(genreKey))
                {
                    filmsByGenre[genreKey] = new List<Film>();
                }

                filmsByGenre[genreKey].Add(f);
            }

            // Ввод жанра для вывода фильмов конкретного жанра
            Console.WriteLine("\nВведите жанр для вывода списка фильмов этого жанра:");
            string searchGenre = ReadNonEmptyString("Жанр: ").ToLower();

            Console.WriteLine("\n" + new string('=', 60));
            if (filmsByGenre.ContainsKey(searchGenre))
            {
                Console.WriteLine("ФИЛЬМЫ ЖАНРА \"{0}\":", searchGenre.ToUpper());
                Console.WriteLine(new string('=', 60));

                List<Film> selectedFilms = filmsByGenre[searchGenre];
                foreach (Film f in selectedFilms)
                {
                    Console.WriteLine(f.ToString());
                }
            }
            else
            {
                Console.WriteLine("Фильмов жанра \"{0}\" в коллекции нет.", searchGenre.ToUpper());
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы ввода
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

        static DateTime ReadDate(string prompt)
        {
            DateTime value;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out value))
                    return value;
                Console.WriteLine("Ошибка: введите дату в формате дд.мм.гггг (например, 15.03.1999).");
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
    }
}
