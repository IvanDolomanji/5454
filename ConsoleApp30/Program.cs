using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт сотрудников ===\n");

            int n = ReadPositiveInt("Введите количество сотрудников: ");

            List<Employee> employees = new List<Employee>();

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Сотрудник {i + 1} из {n} ---");

                int id = ReadPositiveInt("Табельный номер: ");
                string fullName = ReadNonEmptyString("ФИО: ");
                char gender = ReadGender("Пол (м/ж): ");
                DateTime hireDate = ReadDate("Дата поступления на работу (дд.мм.гггг): ");
                double salary = ReadNonNegativeDouble("Оклад (руб.): ");

                try
                {
                    Employee emp = new Employee(id, fullName, gender, hireDate, salary);
                    employees.Add(emp);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    i--;
                }
            }

            // Вывод исходной таблицы
            PrintTable(employees, "ИСХОДНЫЙ СПИСОК СОТРУДНИКОВ");

            // 1. Сортировка по табельному номеру
            var sortedById = employees.OrderBy(e => e.Id).ToList();
            PrintTable(sortedById, "СОРТИРОВКА ПО ТАБЕЛЬНОМУ НОМЕРУ");

            // 2. Сортировка по ФИО
            var sortedByName = employees.OrderBy(e => e.FullName).ToList();
            PrintTable(sortedByName, "СОРТИРОВКА ПО ФИО");

            // 3. Сортировка по окладу
            var sortedBySalary = employees.OrderBy(e => e.Salary).ToList();
            PrintTable(sortedBySalary, "СОРТИРОВКА ПО ОКЛАДУ");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void PrintTable(List<Employee> list, string title)
        {
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("{0,8} {1,-30} {2,5} {3,-12} {4,12}",
                "Таб. №", "ФИО", "Пол", "Приём", "Оклад");
            Console.WriteLine(new string('-', 80));

            foreach (Employee e in list)
            {
                Console.WriteLine(e.ToTableRow());
            }

            Console.WriteLine(new string('=', 80));
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

        static char ReadGender(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "м") return 'м';
                if (input == "ж") return 'ж';
                Console.WriteLine("Ошибка: введите 'м' или 'ж'.");
            }
        }

        static DateTime ReadDate(string prompt)
        {
            DateTime value;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out value))
                    return value;
                Console.WriteLine("Ошибка: введите дату в формате дд.мм.гггг.");
            }
        }

        static double ReadNonNegativeDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out value) && value >= 0)
                    return value;
                Console.WriteLine("Ошибка: введите неотрицательное число.");
            }
        }
    }
}
