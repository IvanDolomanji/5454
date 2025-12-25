using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        // Статические поля для подсчёта типов треугольников
        private static int _equilateralCount = 0;
        private static int _isoscelesCount = 0;
        private static int _scaleneCount = 0;

        // Конструктор
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны треугольника должны быть положительными.");

            // Проверка неравенства треугольника
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Треугольник с такими сторонами не существует (нарушено неравенство треугольника).");

            _a = a;
            _b = b;
            _c = c;

            // Определяем тип и увеличиваем соответствующий счётчик
            if (Math.Abs(a - b) < 1e-9 && Math.Abs(b - c) < 1e-9 && Math.Abs(a - c) < 1e-9)
            {
                _equilateralCount++; // равносторонний
            }
            else if (Math.Abs(a - b) < 1e-9 || Math.Abs(b - c) < 1e-9 || Math.Abs(a - c) < 1e-9)
            {
                _isoscelesCount++; // равнобедренный
            }
            else
            {
                _scaleneCount++; // разносторонний
            }
        }

        // Свойства (только для чтения)
        public double A { get { return _a; } }
        public double B { get { return _b; } }
        public double C { get { return _c; } }

        // Статические свойства для получения количества
        public static int EquilateralCount { get { return _equilateralCount; } }
        public static int IsoscelesCount { get { return _isoscelesCount; } }
        public static int ScaleneCount { get { return _scaleneCount; } }

        // Статический метод сброса счётчиков (на случай повторного использования)
        public static void ResetCounters()
        {
            _equilateralCount = 0;
            _isoscelesCount = 0;
            _scaleneCount = 0;
        }

        // Метод вывода информации о треугольнике
        public void PrintInfo()
        {
            Console.WriteLine("Стороны: {0:F2}, {1:F2}, {2:F2}", _a, _b, _c);
        }

        // Метод возвращает название типа треугольника
        public string GetTypeName()
        {
            if (Math.Abs(_a - _b) < 1e-9 && Math.Abs(_b - _c) < 1e-9 && Math.Abs(_a - _c) < 1e-9)
                return "равносторонний";
            else if (Math.Abs(_a - _b) < 1e-9 || Math.Abs(_b - _c) < 1e-9 || Math.Abs(_a - _c) < 1e-9)
                return "равнобедренный";
            else
                return "разносторонний";
        }
    }
}
