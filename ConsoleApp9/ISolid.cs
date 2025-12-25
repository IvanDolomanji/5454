using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public interface ISolid
    {
        double Volume();         // Объём
        double SurfaceArea();    // Площадь поверхности
        string GetName();        // Название тела (добавлено для вывода)
        string GetParameters();  // Параметры тела в строковом виде
    }
}
