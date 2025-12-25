using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Учёт грузовых перевозок ===\n");

            Console.Write("Введите количество перевозок (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка: введите положительное целое число.");
                Console.ReadKey();
                return;
            }

            // Массив объектов (или List для удобства)
            List<Shipment> shipments = new List<Shipment>();

            Console.WriteLine("\nВведите данные по каждой перевозке:\n");

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"--- Перевозка {i} из {n} ---");

                Console.Write("Номер рейса: ");
                string flightNumber = Console.ReadLine();

                Console.Write("Пункт назначения: ");
                string destination = Console.ReadLine();

                double weight;
                while (true)
                {
                    Console.Write("Вес груза (кг): ");
                    if (double.TryParse(Console.ReadLine().Replace('.', ','), out weight) && weight > 0)
                        break;
                    Console.WriteLine("Ошибка: введите положительное число.");
                }

                try
                {
                    Shipment shipment = new Shipment(flightNumber, destination, weight);
                    shipments.Add(shipment);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Повторите ввод этой перевозки.\n");
                    i--; // Повторяем текущую итерацию
                    continue;
                }

                Console.WriteLine();
            }

            if (shipments.Count == 0)
            {
                Console.WriteLine("Нет данных о перевозках.");
                Console.ReadKey();
                return;
            }

            // Поиск перевозки с минимальным весом
            Shipment minWeightShipment = shipments[0];
            double totalWeight = 0;

            foreach (var s in shipments)
            {
                totalWeight += s.Weight;
                if (s.Weight < minWeightShipment.Weight)
                {
                    minWeightShipment = s;
                }
            }

            // Вывод результатов
            Console.WriteLine("========================================");
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine("========================================");

            Console.WriteLine($"\nСуммарный вес всех перевозок: {totalWeight} кг");

            Console.WriteLine("\nПеревозка с минимальным весом:");
            minWeightShipment.PrintInfo();

            Console.WriteLine("\nВсе введённые перевозки:");
            foreach (var s in shipments)
            {
                Console.WriteLine($"• {s}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
