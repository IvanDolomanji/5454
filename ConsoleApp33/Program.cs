using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
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

            // 1. Список элементов, кратных 3, отсортированный по возрастанию
            var multiplesOf3Sorted = numbers.Where(x => x % 3 == 0).OrderBy(x => x).ToList();
            Console.WriteLine("\n1. Элементы, кратные 3 (по возрастанию):");
            Console.WriteLine(multiplesOf3Sorted.Count > 0 ? string.Join(" ", multiplesOf3Sorted) : "Нет элементов, кратных 3.");

            // 2. Сумма элементов, кратных 4
            int sumMultiplesOf4 = numbers.Where(x => x % 4 == 0).Sum();
            Console.WriteLine("\n2. Сумма элементов, кратных 4: {0}", sumMultiplesOf4);

            // 3. Количество положительных элементов ≤ 20
            int countPositiveUpTo20 = numbers.Where(x => x > 0 && x <= 20).Count();
            Console.WriteLine("\n3. Количество положительных элементов ≤ 20: {0}", countPositiveUpTo20);

            // 4. Минимальный по модулю элемент
            int minByAbs = numbers.OrderBy(x => Math.Abs(x)).FirstOrDefault();
            Console.WriteLine("\n4. Минимальный по модулю элемент: {0}", minByAbs);

            // 5. Есть ли отрицательные элементы, кратные 5
            bool hasNegativeMultiple5 = numbers.Any(x => x < 0 && x % 5 == 0);
            Console.WriteLine("\n5. Есть отрицательные элементы, кратные 5: {0}", hasNegativeMultiple5 ? "Да" : "Нет");

            // 6. Первый нечётный элемент
            var firstOdd = numbers.FirstOrDefault(x => x % 2 != 0);
            Console.WriteLine("\n6. Первый нечётный элемент: {0}",
                firstOdd != 0 ? firstOdd.ToString() : "Отсутствует (все элементы чётные)");

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
