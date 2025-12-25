using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Student
    {// Скрытые поля
        private string _fullName;
        private string _gender; // "м" или "ж"
        private int _birthYear;

        // Статические поля для подсчёта
        private static int _totalBoys = 0;
        private static int _totalGirls = 0;

        // Конструктор
        public Student(string fullName, string gender, int birthYear)
        {
            _fullName = fullName.Trim();
            _gender = gender.Trim().ToLower();

            if (_gender == "м" || _gender == "мальчик")
            {
                _gender = "м";
                _totalBoys++;
            }
            else if (_gender == "ж" || _gender == "девочка")
            {
                _gender = "ж";
                _totalGirls++;
            }
            else
            {
                throw new ArgumentException("Пол должен быть указан как 'м' или 'ж'");
            }

            _birthYear = birthYear;
        }

        // Свойства
        public string FullName
        {
            get => _fullName;
            set => _fullName = value.Trim();
        }

        public string Gender
        {
            get => _gender;
        }

        public int BirthYear
        {
            get => _birthYear;
            set => _birthYear = value;
        }

        // Статические свойства для получения количества
        public static int TotalBoys => _totalBoys;
        public static int TotalGirls => _totalGirls;

        // Метод вывода информации об ученике
        public void PrintInfo()
        {
            string genderText = Gender == "м" ? "мальчик" : "девочка";
            Console.WriteLine($"Ф.И.О.: {FullName}, Пол: {genderText}, Год рождения: {BirthYear}");
        }

        // Статический метод для сброса счётчиков (на всякий случай)
        public static void ResetCounters()
        {
            _totalBoys = 0;
            _totalGirls = 0;
        }
    }
}
