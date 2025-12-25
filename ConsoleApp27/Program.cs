using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    // Структура Сотрудник
    struct Employee
    {
        public string LastName;             // Фамилия
        public string FirstName;            // Имя
        public string Position;             // Должность
        public DateTime HireDate;           // Дата приёма на работу

        // Конструктор структуры
        public Employee(string lastName, string firstName, string position, DateTime hireDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Position = position;
            HireDate = hireDate;
        }

        // Метод вычисления стажа в годах на заданную дату
        public int GetExperienceYears(DateTime currentDate)
        {
            int years = currentDate.Year - HireDate.Year;
            if (currentDate.Month < HireDate.Month ||
                (currentDate.Month == HireDate.Month && currentDate.Day < HireDate.Day))
            {
                years--;
            }
            return years < 0 ? 0 : years;
        }

        // Метод вывода информации о сотруднике в строку таблицы
        public string ToTableRow(DateTime currentDate)
        {
            int experience = GetExperienceYears(currentDate);
            return string.Format("{0,-15} {1,-15} {2,-20} {3:dd.MM.yyyy} {4,5} лет",
                LastName, FirstName, Position, HireDate, experience);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DateTime currentDate = new DateTime(2025, 12, 26); // Текущая дата

            Console.WriteLine("=== Учёт сотрудников ===\n");
            Console.WriteLine($"Текущая дата для расчёта стажа: {currentDate:dd.MM.yyyy}\n");

            int n = ReadPositiveInt("Введите количество сотрудников (N): ");

            // Массив из N объектов структуры
            Employee[] employees = new Employee[n];

            // Ввод данных
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Сотрудник {i + 1} из {n} ---");

                string lastName = ReadNonEmptyString("Фамилия: ");
                string firstName = ReadNonEmptyString("Имя: ");
                string position = ReadNonEmptyString("Должность: ");
                DateTime hireDate = ReadDate("Дата приёма на работу (дд.мм.гггг): ");

                employees[i] = new Employee(lastName, firstName, position, hireDate);
            }

            // Вывод таблицы
            Console.WriteLine("\n" + new string('=', 90));
            Console.WriteLine("ТАБЛИЦА СОТРУДНИКОВ:");
            Console.WriteLine(new string('=', 90));
            Console.WriteLine("{0,-15} {1,-15} {2,-20} {3,-12} {4,10}",
                "Фамилия", "Имя", "Должность", "Приём", "Стаж");
            Console.WriteLine(new string('-', 90));

            int totalExperience = 0;
            int employeesOver30Count = 0;

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.ToTableRow(currentDate));
                int exp = e.GetExperienceYears(currentDate);
                totalExperience += exp;

                if (exp > 30)
                    employeesOver30Count++;
            }

            Console.WriteLine(new string('=', 90));

            // Средний стаж
            double averageExperience = n > 0 ? (double)totalExperience / n : 0;
            Console.WriteLine($"\nСредний стаж сотрудников: {averageExperience:F2} лет");

            // Вывод сотрудников со стажем > 30 лет
            Console.WriteLine("\nСотрудники со стажем более 30 лет:");
            if (employeesOver30Count > 0)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-20} {3,-12} {4,10}",
                    "Фамилия", "Имя", "Должность", "Приём", "Стаж");
                Console.WriteLine(new string('-', 90));

                foreach (Employee e in employees)
                {
                    int exp = e.GetExperienceYears(currentDate);
                    if (exp > 30)
                    {
                        Console.WriteLine(e.ToTableRow(currentDate));
                    }
                }
            }
            else
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
