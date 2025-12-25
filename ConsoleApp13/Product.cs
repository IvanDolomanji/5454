using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Product
    {
        // Скрытые поля
        private string _name;
        private double _price;
        private int _quantity;

        // Конструктор с параметрами
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // Свойства с проверкой значений
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Наименование товара не может быть пустым.");
                _name = value.Trim();
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена товара не может быть отрицательной.");
                _price = value;
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество товара не может быть отрицательным.");
                _quantity = value;
            }
        }

        // Метод вывода информации о товаре
        public void PrintInfo()
        {
            Console.WriteLine("Товар: {0}, Цена: {1:F2} руб., Количество: {2} шт.", Name, Price, Quantity);
        }

        // Переопределение ToString для удобного вывода
        public override string ToString()
        {
            return string.Format("{0} | Цена: {1:F2} руб. | Кол-во: {2} шт.", Name, Price, Quantity);
        }
    }
}
