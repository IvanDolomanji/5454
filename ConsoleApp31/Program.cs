using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Расписание экзаменационной сессии ===\n");

            int n = ReadPositiveInt("Введите количество занятий: ");

            List<Lesson> lessons = new List<Lesson>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Занятие {i + 1} из {n} ---");

                DateTime dateTime = ReadDateTime("Дата и время начала (дд.мм.гггг чч:мм): ");
                string subject = ReadNonEmptyString("Предмет: ");
                string teacher = ReadNonEmptyString("ФИО преподавателя: ");
                string audience = ReadNonEmptyString("№ аудитории: ");

                try
                {
                    Lesson lesson = new Lesson(dateTime, subject, teacher, audience);
                    lessons.Add(lesson);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    i--;
                }
            }

            // Исходный список
            PrintTable(lessons, "ИСХОДНОЕ РАСПИСАНИЕ");

            // 1. Сортировка по ФИО преподавателя
            var sortedByTeacher = lessons.OrderBy(l => l.TeacherFullName).ToList();
            PrintTable(sortedByTeacher, "СОРТИРОВКА ПО ФИО ПРЕПОДАВАТЕЛЯ");

            // 2. Сортировка по группе (предмету)
            var sortedBySubject = lessons.OrderBy(l => l.Subject).ToList();
            PrintTable(sortedBySubject, "СОРТИРОВКА ПО ПРЕДМЕТУ (ГРУППЕ)");

            // 3. Сортировка по аудитории
            var sortedByAudience = lessons.OrderBy(l => l.Audience).ToList();
            PrintTable(sortedByAudience, "СОРТИРОВКА ПО № АУДИТОРИИ");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void PrintTable(List<Lesson> list, string title)
        {
            Console.WriteLine("\n" + new string('=', 90));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 90));
            Console.WriteLine("{0,-20} | {1,-25} | {2,-30} | {3,-10}",
                "Дата и время", "Предмет", "Преподаватель", "Аудитория");
            Console.WriteLine(new string('-', 90));

            foreach (Lesson l in list)
            {
                Console.WriteLine(l.ToTableRow());
            }

            Console.WriteLine(new string('=', 90));
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

        static DateTime ReadDateTime(string prompt)
        {
            DateTime value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "dd.MM.yyyy HH:mm", null,
                    System.Globalization.DateTimeStyles.None, out value))
                    return value;
                if (DateTime.TryParseExact(input, "dd.MM.yyyy H:mm", null,
                    System.Globalization.DateTimeStyles.None, out value))
                    return value;
                Console.WriteLine("Ошибка: введите в формате дд.мм.гггг чч:мм (например, 15.01.2026 10:30)");
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
