using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Film
    {
        // Скрытые поля
        private string _title;
        private DateTime _releaseDate;
        private string _genre;

        // Конструктор
        public Film(string title, DateTime releaseDate, string genre)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
        }

        // Свойства с проверкой
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название фильма не может быть пустым.");
                _title = value.Trim();
            }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Жанр не может быть пустым.");
                _genre = value.Trim();
            }
        }

        // Метод вывода полной информации о фильме
        public void PrintInfo()
        {
            Console.WriteLine("Фильм: {0}", Title);
            Console.WriteLine("  Дата выхода: {0:dd.MM.yyyy}", ReleaseDate);
            Console.WriteLine("  Жанр: {0}", Genre);
        }

        // Переопределение ToString для удобного вывода в списке
        public override string ToString()
        {
            return string.Format("{0} ({1:yyyy}) — {2}", Title, ReleaseDate, Genre);
        }
    }
}
