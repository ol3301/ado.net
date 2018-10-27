using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzMobilki
{
    /// <summary>
    /// Разширяет тип decimal
    /// </summary>
    public static class DecimalHelper
    {
        //Добавляет метод Contains. 
        public static bool Contains(this decimal me,decimal you)
        {
            string s1 = me.ToString();
            string s2 = you.ToString();

            return s1.Contains(s2);
        }
    }
}
