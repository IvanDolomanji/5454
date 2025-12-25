using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    // Делегат: принимает int, возвращает bool
    delegate bool IntPredicate(int value);

    class Program
    {
        // Метод для вывода элементов массива с условием
        static void Print(int[] array, IntPredicate predicate)
        {
            Console.Write("Элементы: ");
            bool hasAny = false;
            foreach (int num in array)
            {
                if (predicate(num))
                {
                    Console.Write(num + " ");
                    hasAny = true;
                }
            }
            if (!hasAny)
                Console.Write("нет подходящих");
            Console.WriteLine();
        }

        // Метод для подсчёта суммы элементов с условием
        static int Sum(int[] array, IntPredicate predicate)
        {
            int total = 0;
            foreach (int num in array)
            {
                if (predicate(num))
                {
                    total += num;
                }
            }
            return total;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Работа с делегатами и лямбда-выражениями ===\n");

            int n = ReadPositiveInt("Введите количество элементов массива n: ");

            // Создание и заполнение массива случайными числами из [-20, 20]
            Random rnd = new Random();
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = rnd.Next(-20, 21); // от -20 до 20 включительно
            }

            // Вывод исходного массива
            Console.WriteLine("\nИсходный массив:");
            Console.WriteLine(string.Join(" ", numbers));

            Console.WriteLine("\n--- Вывод элементов ---");

            // 1. Все элементы массива
            Console.Write("1. Все элементы: ");
            Print(numbers, x => true); // всегда true — выводим все

            // 2. Чётные элементы массива
            Console.Write("2. Чётные элементы: ");
            Print(numbers, x => x % 2 == 0);

            // Подсчёт суммы отрицательных нечётных элементов
            Console.WriteLine("\n--- Подсчёт суммы ---");
            int negativeOddSum = Sum(numbers, x => x < 0 && x % 2 != 0);

            Console.WriteLine($"Сумма отрицательных нечётных элементов: {negativeOddSum}");

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
    }
}