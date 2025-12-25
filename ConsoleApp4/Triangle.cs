using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Triangle
    {
        // Скрытые поля
        private double _angleA;
        private double _angleB;
        private double _angleC;

        // Статические поля для подсчёта типов треугольников
        private static int _acuteCount = 0;    // остроугольные
        private static int _rightCount = 0;    // прямоугольные
        private static int _obtuseCount = 0;   // тупоугольные

        // Конструктор
        public Triangle(double angleA, double angleB, double angleC)
        {
            // Проверка корректности треугольника: сумма углов ≈ 180°
            double sum = angleA + angleB + angleC;
            if (Math.Abs(sum - 180.0) > 0.001)
            {
                throw new ArgumentException($"Ошибка: сумма углов ({sum:F2}°) не равна 180°.");
            }

            // Проверка, что все углы положительные
            if (angleA <= 0 || angleB <= 0 || angleC <= 0)
            {
                throw new ArgumentException("Все углы должны быть положительными.");
            }

            _angleA = angleA;
            _angleB = angleB;
            _angleC = angleC;

            // Определяем тип и увеличиваем соответствующий счётчик
            if (angleA == 90 || angleB == 90 || angleC == 90)
            {
                _rightCount++;
            }
            else if (angleA > 90 || angleB > 90 || angleC > 90)
            {
                _obtuseCount++;
            }
            else
            {
                _acuteCount++;
            }
        }

        // Свойства (только для чтения)
        public double AngleA => _angleA;
        public double AngleB => _angleB;
        public double AngleC => _angleC;

        // Статические свойства для получения количества
        public static int AcuteCount => _acuteCount;
        public static int RightCount => _rightCount;
        public static int ObtuseCount => _obtuseCount;

        // Метод вывода информации о треугольнике
        public void PrintInfo()
        {
            Console.WriteLine($"Углы: {AngleA:F1}°, {AngleB:F1}°, {AngleC:F1}°");
        }

        // Метод для определения типа (строкой)
        public string GetTypeName()
        {
            if (AngleA == 90 || AngleB == 90 || AngleC == 90)
                return "прямоугольный";
            else if (AngleA > 90 || AngleB > 90 || AngleC > 90)
                return "тупоугольный";
            else
                return "остроугольный";
        }

        // Статический метод сброса счётчиков (полезно при повторных запусках)
        public static void ResetCounters()
        {
            _acuteCount = 0;
            _rightCount = 0;
            _obtuseCount = 0;
        }
    }
}
