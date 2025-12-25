using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    // Абстрактный базовый класс: Населённый пункт
    public abstract class Settlement
    {
        private string _name;

        protected Settlement(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым.");
                _name = value.Trim();
            }
        }

        // Виртуальный метод вывода общей информации
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Населённый пункт: {Name}");
        }

        // Абстрактный метод — должен быть переопределён в потомках
        public abstract double PopulationDensity();
    }
}

