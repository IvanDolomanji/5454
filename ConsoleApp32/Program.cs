using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Обработка списка случайных чисел с помощью LINQ ===\n");

            int n = ReadPositiveInt("Введите количество элементов n: ");

            int a = ReadInt("Введите нижнюю границу диапазона a: ");
            int b = ReadInt("Введите верхнюю границу диапазона b: ");

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            // Создание списка и заполнение случайными числами
            Random rnd = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int value = rnd.Next(a, b + 1); // включительно b
                numbers.Add(value);
            }

            // Вывод исходного списка
            Console.WriteLine("\nСгенерированный список ({0} элементов):", n);
            Console.WriteLine(string.Join(" ", numbers));

            // 1. Список положительных элементов, отсортированный по возрастанию
            var positiveSorted = numbers.Where(x => x > 0).OrderBy(x => x).ToList();
            Console.WriteLine("\n1. Положительные элементы (по возрастанию):");
            Console.WriteLine(positiveSorted.Count > 0 ? string.Join(" ", positiveSorted) : "Нет положительных элементов.");

            // 2. Сумма положительных элементов, состоящих из двух цифр (от 10 до 99 включительно)
            int sumTwoDigitPositive = numbers
                .Where(x => x > 0 && x >= 10 && x <= 99)
                .Sum();

            Console.WriteLine("\n2. Сумма положительных двухзначных элементов: {0}", sumTwoDigitPositive);

            // 3. Количество элементов, |x| > 10 и x кратно 5
            int countAbsGreater10Multiple5 = numbers
                .Where(x => Math.Abs(x) > 10 && x % 5 == 0)
                .Count();

            Console.WriteLine("\n3. Количество элементов с |x| > 10 и кратных 5: {0}", countAbsGreater10Multiple5);

            // 4. Максимальный нечётный элемент
            var maxOdd = numbers.Where(x => x % 2 != 0).DefaultIfEmpty(int.MinValue).Max();
            Console.WriteLine("\n4. Максимальный нечётный элемент: {0}",
                maxOdd != int.MinValue ? maxOdd.ToString() : "Нет нечётных элементов");

            // 5. Есть ли отрицательные элементы, кратные 3
            bool hasNegativeMultiple3 = numbers.Any(x => x < 0 && x % 3 == 0);
            Console.WriteLine("\n5. Есть отрицательные элементы, кратные 3: {0}", hasNegativeMultiple3 ? "Да" : "Нет");

            // 6. Первый отрицательный нечётный элемент
            var firstNegativeOdd = numbers.FirstOrDefault(x => x < 0 && x % 2 != 0);
            Console.WriteLine("\n6. Первый отрицательный нечётный элемент: {0}",
                firstNegativeOdd != 0 ? firstNegativeOdd.ToString() : "Отсутствует");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Вспомогательные методы ввода
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

        static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }
    }
}
