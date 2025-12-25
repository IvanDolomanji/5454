using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            try
            {
                // Примеры создания треугольников
                var t1 = new TriangleExample(3, 4, 5);
                var t2 = new TriangleExample(7, 7, 7);
                var t3 = new TriangleExample(6, 8, 7.5);
                var t4 = new TriangleExample(5, 5, 8);

                // Вывод информации
                Console.WriteLine("Пример 1:");
                t1.PrintInfo();

                Console.WriteLine("Пример 2:");
                t2.PrintInfo();

                Console.WriteLine("Пример 3:");
                t3.PrintInfo();

                Console.WriteLine("Пример 4:");
                t4.PrintInfo();

                // Пример обработки ошибки
                // var wrong = new Triangle(1, 1, 3); // выбросит исключение
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
    
