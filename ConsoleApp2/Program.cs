using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Интерфейс на русском языке
            Console.WriteLine("Введите данные о товаре:");

            Console.Write("Наименование: ");
            string name = Console.ReadLine();

            Console.Write("Цена (в рублях): ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Ошибка! Введите положительное число для цены.");
                Console.Write("Цена (в рублях): ");
            }

            Console.Write("Количество (в штуках): ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.WriteLine("Ошибка! Введите положительное целое число для количества.");
                Console.Write("Количество (в штуках): ");
            }

            // Создание объекта класса Product
            Product product = new Product(name, price, quantity);

            // Вывод информации
            Console.WriteLine("\nИнформация о товаре:");
            product.PrintInfo();

            // Вывод стоимости
            double cost = product.GetCost();
            Console.WriteLine($"Общая стоимость: {cost} руб.");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}

