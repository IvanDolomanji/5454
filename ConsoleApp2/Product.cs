using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Product
    {
        // Скрытые поля
        private string _name;
        private double _price;
        private int _quantity;

        // Конструктор, принимающий поля класса
        public Product(string name, double price, int quantity)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
        }

        // Свойства для доступа к полям
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        // Метод, выводящий информацию об объекте
        public void PrintInfo()
        {
            Console.WriteLine($"Наименование: {Name}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Количество: {Quantity} шт.");
        }

        // Метод, возвращающий стоимость товара (цена * количество)
        public double GetCost()
        {
            return Price * Quantity;
        }
    }
}

