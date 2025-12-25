using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DateTime currentDateTime = new DateTime(2025, 12, 26, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            // Для тестирования можно задать фиксированное текущее время, например:
            // DateTime currentDateTime = new DateTime(2025, 12, 26, 9, 30, 0);

            Console.WriteLine("=== Расчёт времени до визита к доктору ===\n");
            Console.WriteLine($"Текущая дата и время: {currentDateTime:dd.MM.yyyy HH:mm}\n");

            DateTime visitDateTime = ReadDateTime("Введите дату и время визита к доктору (дд.мм.гггг чч:мм): ");

            // Проверка, что визит в будущем или настоящем
            if (visitDateTime < currentDateTime)
            {
                Console.WriteLine("\nВнимание: указанное время визита уже прошло!");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
                return;
            }

            // Расчёт оставшегося времени
            TimeSpan remaining = visitDateTime - currentDateTime;
            int remainingHours = (int)Math.Ceiling(remaining.TotalHours);

            // Определение части дня
            string dayPart;
            if (visitDateTime.Hour < 12)
                dayPart = "в первой половине дня (до 12:00)";
            else
                dayPart = "во второй половине дня (после 12:00)";

            // Вывод результата
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("РЕЗУЛЬТАТ:");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"Визит к доктору назначен на: {visitDateTime:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Осталось до визита: {remainingHours} час(ов)");
            Console.WriteLine($"Визит предстоит {dayPart}");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Метод для ввода даты и времени в формате дд.мм.гггг чч:мм
        static DateTime ReadDateTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Попытка разобрать в формате "дд.мм.гггг чч:мм"
                if (DateTime.TryParseExact(input, "dd.MM.yyyy HH:mm", null,
                    System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }

                // Альтернативный формат "дд.мм.гггг ч:мм" (для однозначного часа)
                if (DateTime.TryParseExact(input, "dd.MM.yyyy H:mm", null,
                    System.Globalization.DateTimeStyles.None, out result))
                {
                    return result;
                }

                Console.WriteLine("Ошибка: введите дату и время в формате дд.мм.гггг чч:мм (например, 27.12.2025 14:30)");
            }
        }
    }
}
