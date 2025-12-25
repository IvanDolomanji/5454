using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    // Структура Сотрудник
    struct Employee
    {
        public string LastName;     // Фамилия
        public string FirstName;    // Имя
        public string Patronymic;   // Отчество
        public string Position;     // Должность
        public double Salary;       // Зарплата
        public DateTime BirthDate;  // Дата рождения

        // Конструктор структуры
        public Employee(string lastName, string firstName, string patronymic,
                        string position, double salary, DateTime birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Position = position;
            Salary = salary;
            BirthDate = birthDate;
        }

        // Метод вычисления возраста на заданную дату
        public int GetAge(DateTime currentDate)
        {
            int age = currentDate.Year - BirthDate.Year;
            if (currentDate.Month < BirthDate.Month ||
                (currentDate.Month == BirthDate.Month && currentDate.Day < BirthDate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

        // Метод вывода информации о сотруднике в строку таблицы
        public string ToTableRow(DateTime currentDate)
        {
            int age = GetAge(currentDate);
            return string.Format("{0,-15} {1,-12} {2,-15} {3,-20} {4,10:F2} {5,5} лет",
                LastName, FirstName, Patronymic, Position, Salary, age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DateTime currentDate = new DateTime(2025, 12, 26); // Текущая дата

            Console.WriteLine("=== Учёт сотрудников ===\n");
            Console.WriteLine($"Текущая дата для расчёта возраста: {currentDate:dd.MM.yyyy}\n");

            int n = ReadPositiveInt("Введите количество сотрудников (N): ");

            // Массив из N объектов структуры
            Employee[] employees = new Employee[n];

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Сотрудник {i + 1} из {n} ---");

                string lastName = ReadNonEmptyString("Фамилия: ");
                string firstName = ReadNonEmptyString("Имя: ");
                string patronymic = ReadString("Отчество (если нет — Enter): ");
                string position = ReadNonEmptyString("Должность: ");
                double salary = ReadPositiveDouble("Зарплата (руб.): ");
                DateTime birthDate = ReadDate("Дата рождения (дд.мм.гггг): ");

                employees[i] = new Employee(lastName, firstName, patronymic, position, salary, birthDate);
            }

            // Вывод таблицы
            Console.WriteLine("\n" + new string('=', 100));
            Console.WriteLine("ТАБЛИЦА СОТРУДНИКОВ:");
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("{0,-15} {1,-12} {2,-15} {3,-20} {4,12} {5,10}",
                "Фамилия", "Имя", "Отчество", "Должность", "Зарплата", "Возраст");
            Console.WriteLine(new string('-', 100));

            double totalSalary = 0;

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.ToTableRow(currentDate));
                totalSalary += e.Salary;
            }

            Console.WriteLine(new string('=', 100));

            // Средняя зарплата
            double averageSalary = n > 0 ? totalSalary / n : 0;
            Console.WriteLine($"\nСредняя зарплата сотрудников: {averageSalary:F2} руб.");

            // Вывод сотрудников с зарплатой выше средней и возрастом менее 30 лет
            Console.WriteLine("\nСотрудники с зарплатой выше средней и возрастом менее 30 лет:");
            int matchingCount = 0;

            foreach (Employee e in employees)
            {
                int age = e.GetAge(currentDate);
                if (e.Salary > averageSalary && age < 30)
                {
                    if (matchingCount == 0)
                    {
                        Console.WriteLine("{0,-15} {1,-12} {2,-15} {3,-20} {4,12} {5,10}",
                            "Фамилия", "Имя", "Отчество", "Должность", "Зарплата", "Возраст");
                        Console.WriteLine(new string('-', 100));
                    }
                    Console.WriteLine(e.ToTableRow(currentDate));
                    matchingCount++;
                }
            }

            if (matchingCount == 0)
            {
                Console.WriteLine("Таких сотрудников нет.");
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

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim();
        }

        static double ReadPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Replace('.', ',');
                if (double.TryParse(input, out value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное число.");
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