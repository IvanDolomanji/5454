using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Каталог автомобилей ===\n");

            // Ввод количества автомобилей для каждого списка
            Console.Write("Введите количество автомобилей в первом списке: ");
            int n1 = ReadPositiveInt();

            List<Car> list1 = InputCars(n1, "первого");

            Console.Write("\nВведите количество автомобилей во втором списке: ");
            int n2 = ReadPositiveInt();

            List<Car> list2 = InputCars(n2, "второго");

            // Вывод информации обо всех объектах обоих списков
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("АВТОМОБИЛИ ПЕРВОГО СПИСКА:");
            Console.WriteLine(new string('=', 60));
            PrintCarList(list1);

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("АВТОМОБИЛИ ВТОРОГО СПИСКА:");
            Console.WriteLine(new string('=', 60));
            PrintCarList(list2);

            // 1. Список автомобилей марки «Toyota», зарегистрированных до 01.01.2015
            List<Car> toyotaBefore2015 = new List<Car>();
            DateTime threshold2015 = new DateTime(2015, 1, 1);

            foreach (Car car in list1)
            {
                if (car.Brand.Equals("Toyota", StringComparison.OrdinalIgnoreCase) &&
                    car.RegistrationDate < threshold2015)
                {
                    toyotaBefore2015.Add(car);
                }
            }
            foreach (Car car in list2)
            {
                if (car.Brand.Equals("Toyota", StringComparison.OrdinalIgnoreCase) &&
                    car.RegistrationDate < threshold2015)
                {
                    toyotaBefore2015.Add(car);
                }
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("АВТОМОБИЛИ МАРКИ «TOYOTA», ЗАРЕГИСТРИРОВАННЫЕ ДО 01.01.2015:");
            Console.WriteLine(new string('=', 60));
            PrintShortList(toyotaBefore2015, "Таких автомобилей нет.");

            // 2. Список автомобилей, выпущенных за последние 10 лет (с учётом текущей даты 26.12.2025)
            DateTime tenYearsAgo = DateTime.Today.AddYears(-10); // 26.12.2015 и позже

            List<Car> last10Years = new List<Car>();

            foreach (Car car in list1)
            {
                if (car.RegistrationDate >= tenYearsAgo)
                    last10Years.Add(car);
            }
            foreach (Car car in list2)
            {
                if (car.RegistrationDate >= tenYearsAgo)
                    last10Years.Add(car);
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("АВТОМОБИЛИ С РЕГИСТРАЦИЕЙ В 2016–2025 ГГ.:");
            Console.WriteLine(new string('=', 60));
            PrintShortList(last10Years, "Таких автомобилей нет.");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Ввод списка автомобилей
        static List<Car> InputCars(int count, string listName)
        {
            List<Car> cars = new List<Car>();

            Console.WriteLine("\nВвод данных для {0} списка ({1} автомобиль(ей)):", listName, count);

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("\n--- Автомобиль {0} из {1} ---", i, count);

                string brand = ReadNonEmptyString("Марка автомобиля: ");
                string manufacturer = ReadNonEmptyString("Производитель: ");
                string engineType = ReadNonEmptyString("Тип двигателя: ");
                DateTime regDate = ReadDate("Дата регистрации (дд.мм.гггг): ");

                try
                {
                    Car car = new Car(brand, manufacturer, engineType, regDate);
                    cars.Add(car);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                    i--;
                }
            }

            return cars;
        }

        // Полный вывод списка автомобилей
        static void PrintCarList(List<Car> list)
        {
            foreach (Car car in list)
            {
                car.PrintInfo();
                Console.WriteLine();
            }
        }

        // Краткий вывод списка (для результатов поиска)
        static void PrintShortList(List<Car> list, string emptyMessage)
        {
            if (list.Count > 0)
            {
                foreach (Car car in list)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else
            {
                Console.WriteLine(emptyMessage);
            }
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
                Console.WriteLine("Ошибка: введите дату в формате дд.мм.гггг (например, 15.03.2018).");
            }
        }

        static int ReadPositiveInt()
        {
            int value;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Ошибка: введите положительное целое число.");
            }
        }
    }
}
