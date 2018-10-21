using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
    class Program
    {
        static List<Good> g1 = new List<Good>();
        static List<Good> g2 = new List<Good>();

        static void init()
        {
            g1 = new List<Good>()
{
new Good()
{ Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
new Good()
{ Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
new Good()
{ Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
new Good()
{ Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
new Good()
{ Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" }
};
            g2 = new List<Good>()
{
new Good()
{ Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
new Good()
{ Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
new Good()
{ Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
new Good()
{ Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
new Good()
{ Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
};
        }

        static void Main(string[] args)
        {
            //заполняем наши списки
            init();

            var data = g1.Concat(g2);

        }
    }
}
