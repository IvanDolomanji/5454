using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TriangleExample
    {
        // скрытые (private) поля
        private double a;
        private double b;
        private double c;

        // Конструктор
        public TriangleExample(double a, double b, double c)
        {
            // Проверяем, что стороны положительные
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Длины сторон должны быть положительными числами");
            }

            // Проверка неравенства треугольника
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Треугольник с такими сторонами не существует (нарушено неравенство треугольника)");
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        // Свойства (Properties) — доступ только для чтения
        public double SideA => a;
        public double SideB => b;
        public double SideC => c;

        // Периметр (для удобства)
        public double Perimeter => a + b + c;

        // Площадь по формуле Герона
        public double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        // Вывод информации об объекте
        public void PrintInfo()
        {
            Console.WriteLine($"Треугольник со сторонами: {a:F2}, {b:F2}, {c:F2}");
            Console.WriteLine($"Периметр: {Perimeter:F2}");
            Console.WriteLine($"Площадь:   {Area:F2}");
            Console.WriteLine($"Тип:      {GetTriangleType()}");
            Console.WriteLine();
        }

        // Определение типа треугольника
        public string GetTriangleType()
        {
            // Используем небольшую погрешность для сравнения вещественных чисел
            const double EPS = 1e-9;

            if (Math.Abs(a - b) < EPS && Math.Abs(b - c) < EPS)
            {
                return "Равносторонний";
            }
            else if (Math.Abs(a - b) < EPS || Math.Abs(a - c) < EPS || Math.Abs(b - c) < EPS)
            {
                return "Равнобедренный";
            }
            else
            {
                return "Разносторонний";
            }
        }
    }
}
