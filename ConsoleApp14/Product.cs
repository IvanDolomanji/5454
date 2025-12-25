using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Product
    {
        // Скрытые поля
        private string _name;               // Наименование
        private DateTime _productionDate;   // Дата производства
        private int _shelfLifeDays;         // Срок годности в днях
        private double _price;              // Цена

        // Конструктор с параметрами
        public Product(string name, DateTime productionDate, int shelfLifeDays, double price)
        {
            Name = name;
            ProductionDate = productionDate;
            ShelfLifeDays = shelfLifeDays;
            Price = price;
        }

        // Свойства с проверкой
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Наименование не может быть пустым.");
                _name = value.Trim();
            }
        }

        public DateTime ProductionDate
        {
            get { return _productionDate; }
            set { _productionDate = value; }
        }

        public int ShelfLifeDays
        {
            get { return _shelfLifeDays; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Срок годности не может быть отрицательным.");
                _shelfLifeDays = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена не может быть отрицательной.");
                _price = value;
            }
        }

        // Метод вычисления даты истечения срока годности
        public DateTime ExpirationDate()
        {
            return ProductionDate.AddDays(ShelfLifeDays);
        }

        // Метод проверки, заканчивается ли срок годности в течение ближайших 30 суток
        public bool IsExpiringSoon(int daysThreshold = 30)
        {
            DateTime today = DateTime.Today;
            DateTime expiration = ExpirationDate();
            return expiration >= today && expiration <= today.AddDays(daysThreshold);
        }

        // Метод вывода информации об объекте
        public void PrintInfo()
        {
            Console.WriteLine("Товар: {0}", Name);
            Console.WriteLine("  Дата производства: {0:dd.MM.yyyy}", ProductionDate);
            Console.WriteLine("  Срок годности: {0} дней", ShelfLifeDays);
            Console.WriteLine("  Дата окончания срока: {0:dd.MM.yyyy}", ExpirationDate());
            Console.WriteLine("  Цена: {0:F2} руб.", Price);
        }

        // Переопределение ToString для списка
        public override string ToString()
        {
            return string.Format("{0} | Произв.: {1:dd.MM.yyyy} | Окончание: {2:dd.MM.yyyy} | Цена: {3:F2} руб.",
                Name, ProductionDate, ExpirationDate(), Price);
        }
    }
}
