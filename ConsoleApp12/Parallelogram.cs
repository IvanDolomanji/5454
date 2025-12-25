using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Parallelogram
    {
        // Скрытые поля
        private double _a;     // сторона a
        private double _b;     // сторона b
        private double _alpha; // угол между сторонами a и b в градусах

        // Конструктор с параметрами
        public Parallelogram(double a, double b, double alpha)
        {
            A = a;
            B = b;
            Alpha = alpha;
        }

        // Свойства с проверкой значений
        public double A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Сторона a должна быть положительной.");
                _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Сторона b должна быть положительной.");
                _b = value;
            }
        }

        public double Alpha
        {
            get { return _alpha; }
            set
            {
                if (value <= 0 || value >= 180)
                    throw new ArgumentException("Угол α должен быть больше 0° и меньше 180°.");
                _alpha = value;
            }
        }

        // Метод вывода информации об объекте
        public void PrintInfo()
        {
            Console.WriteLine("Параллелограмм:");
            Console.WriteLine("  Сторона a = {0:F2}", A);
            Console.WriteLine("  Сторона b = {0:F2}", B);
            Console.WriteLine("  Угол α между сторонами = {0:F2}°", Alpha);
            Console.WriteLine("  Вид четырехугольника: {0}", GetTypeName());
        }

        // Метод, определяющий вид четырехугольника
        public string GetTypeName()
        {
            // Допуск на сравнение с 90° (прямоугольник)
            bool isRightAngle = Math.Abs(Alpha - 90) < 0.001 || Math.Abs(Alpha - 270) < 0.001;

            // Допуск на равенство сторон
            bool sidesEqual = Math.Abs(A - B) < 0.001;

            if (sidesEqual && isRightAngle)
                return "квадрат";
            else if (isRightAngle)
                return "прямоугольник";
            else if (sidesEqual)
                return "ромб";
            else
                return "параллелограмм";
        }
    }
}
