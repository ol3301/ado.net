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
        static List<Good> goods1;
        static List<Good> goods2;
        static void init()
        {
            goods1 = new List<Good>()
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
            goods2 = new List<Good>()
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
            //заполняем списки
            init();
            IEnumerable<Good> data = goods1.Concat(goods2);

            //1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.
            var res = from c in data
                      where c.Price > 1000
                      select c;

            //2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen, 
            //цена которых превышает 1000 грн.
            res = from c in data
                  where c.Price > 100
                  where c.Category != "Kitchen"
                  select c;

            //3) Вывести название товара и его категорию, который имеет максимальную цену.
            double maxp = (from c in data select c).Max(x=>x.Price);
            var res1 = (from c in data
                   select new
                   {
                       c.Title,
                       c.Category,
                       c.Price
                   }).First(x=>x.Price == maxp);

            //4) Вычислить среднее значение всех цен товаров.
            double avg = (from c in data select c).Average(x=>x.Price);

            //5) Вывести список категорий без повторений.
            var cats = (from c in data select c.Category).Distinct();

            //6) Вывести названия тех товаров, цены которых совпадают.
            var innerquery = from c in data select c.Price;
            res = from c in data
                  where innerquery.Contains(c.Price)
                  select c;

            //7) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по
            //названию
            res = (from c in data
                   orderby c.Title
                   select c);

            //8) Проверить, содержит ли категория Car товары, с ценой от 1000 до 2000 грн
            res = from c in data
                  where c.Category == "Car"
                  where c.Price >= 1000
                  where c.Price <= 2000
                  select c;

            //9) Посчитать суммарное количество товаров категорий Сar и Mobile.
            int count = data.Count(x=>x.Category=="Car" || x.Category=="Mobile");

            //10) Вывести список категорий и количество товаров каждой категории
            var res2 = from c in data
                       group c by c.Category into ca
                       select new { Category = ca.Key, count = ca.Count()};



            //задание 2
            int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
            int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
            IEnumerable<int> values3 = values1.Concat(values2);

            //1) Посчитать среднее значение четных элементов, которые больше 10
            var avg1 = (from c in values3
                         where c % 2 == 0
                         where c > 3
                         select c).Average();

            //2) Выбрать только уникальные элементы из массивов values1 и values2.
            var unique = (from c in values3
                          select c).Distinct();

            //3) Найти максимальный элемент массива values2, который есть в массиве values1.
            var maxev = (from c in values2
                       where (from i in values1 select i).Contains(c)
                       select c).Max();

            //4) Посчитать сумму элементов массивов values1 и values2, которые попадают
            //в диапазон от 5 до 15.
            var sum = (from c in values3
                       where c >= 5
                       where c <= 15
                       select c).Sum();

            //5) Отсортировать элементы массивов values1 и values2 по убыванию.
            var desc = from c in values3
                       orderby c descending
                       select c;
            Console.Read();
        }
    }
}
