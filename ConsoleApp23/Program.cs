using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Ввод данных о студенте ===\n");

            Student student = null;

            // Цикл ввода до успешного создания объекта
            while (student == null)
            {
                try
                {
                    Console.WriteLine("Введите данные студента:");

                    string lastName = ReadNonEmptyString("Фамилия: ");

                    string firstName = ReadNonEmptyString("Имя: ");

                    int grade1 = ReadGrade("Первая оценка (2-5): ");
                    int grade2 = ReadGrade("Вторая оценка (2-5): ");
                    int grade3 = ReadGrade("Третья оценка (2-5): ");

                    // Создаём объект — проверка в свойствах
                    student = new Student(lastName, firstName, grade1, grade2, grade3);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный формат числа. Повторите ввод.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка ввода данных: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла непредвиденная ошибка: {0}", ex.Message);
                    Console.WriteLine("Повторите ввод.\n");
                }
            }

            // Успешно создан объект — выводим информацию
            Console.WriteLine("\n" + new string('=', 50));
            student.PrintInfo();

            double average = student.GetAverageGrade();
            Console.WriteLine("Средний балл: {0:F2}", average);
            Console.WriteLine(new string('=', 50));

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

        static int ReadGrade(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 2 && value <= 5)
                    return value;
                Console.WriteLine("Ошибка: оценка должна быть целым числом от 2 до 5.");
            }
        }
    }
}
