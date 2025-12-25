using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Для корректного отображения русского текста

            Console.WriteLine("=== Программа учёта школьников ===\n");

            Console.Write("Введите количество школьников (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка: введите положительное целое число.");
                Console.ReadKey();
                return;
            }

            // Сбрасываем счётчики перед началом
            Student.ResetCounters();

            // Списки для разделения по полу
            List<Student> boys = new List<Student>();
            List<Student> girls = new List<Student>();

            Console.WriteLine("\nВведите данные по каждому школьнику:\n");

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"--- Школьник {i} из {n} ---");

                Console.Write("Ф.И.О.: ");
                string fullName = Console.ReadLine();

                string genderInput;
                while (true)
                {
                    Console.Write("Пол (м/ж): ");
                    genderInput = Console.ReadLine().Trim().ToLower();
                    if (genderInput == "м" || genderInput == "ж" ||
                        genderInput == "мальчик" || genderInput == "девочка")
                        break;
                    Console.WriteLine("Ошибка: введите 'м' или 'ж'.");
                }

                int birthYear;
                while (true)
                {
                    Console.Write("Год рождения: ");
                    if (int.TryParse(Console.ReadLine(), out birthYear) &&
                        birthYear >= 1900 && birthYear <= DateTime.Now.Year)
                        break;
                    Console.WriteLine($"Ошибка: введите корректный год (от 1900 до {DateTime.Now.Year}).");
                }

                try
                {
                    // Передаём введённые данные в конструктор
                    Student student = new Student(fullName, genderInput, birthYear);

                    if (student.Gender == "м")
                        boys.Add(student);
                    else
                        girls.Add(student);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при создании объекта: {ex.Message}");
                    i--; // Повторяем ввод для этого школьника
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            // Вывод результатов
            Console.WriteLine("========================================");
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine("========================================");

            Console.WriteLine($"\nВсего мальчиков: {Student.TotalBoys}");
            if (boys.Count > 0)
            {
                Console.WriteLine("Список мальчиков:");
                foreach (var boy in boys)
                {
                    boy.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Мальчиков нет.");
            }

            Console.WriteLine($"\nВсего девочек: {Student.TotalGirls}");
            if (girls.Count > 0)
            {
                Console.WriteLine("Список девочек:");
                foreach (var girl in girls)
                {
                    girl.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("Девочек нет.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
