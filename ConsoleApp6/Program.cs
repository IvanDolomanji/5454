using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Демонстрация наследования: Стол и Письменный стол ===\n");

            try
            {
                // Создаём объект базового класса
                Table simpleTable = new Table("Кухонный стол", 1.5);

                // Создаём объект производного класса
                WritingDesk writingDesk = new WritingDesk(
                    name: "Письменный стол дубовый",
                    area: 2.0,
                    material: "Дуб",
                    finishingCost: 5000
                );

                // Демонстрация полиморфизма: массив базового типа
                Table[] tables = { simpleTable, writingDesk };

                Console.WriteLine("Информация об объектах:\n");

                foreach (var table in tables)
                {
                    table.PrintInfo(); // Вызывается переопределённая версия для WritingDesk
                    Console.WriteLine($"Стоимость: {table.CalculateCost()} руб.");
                    Console.WriteLine(new string('-', 40));
                }

                // Дополнительно: прямой вызов методов
                Console.WriteLine("Проверка отдельных вызовов:");
                Console.WriteLine($"Обычный стол: стоимость = {simpleTable.CalculateCost()} руб.");
                Console.WriteLine($"Письменный стол: стоимость = {writingDesk.CalculateCost()} руб.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
