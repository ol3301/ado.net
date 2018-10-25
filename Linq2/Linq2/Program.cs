using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2
{
    class Program
    {
        public class Person

        {

            public string Name { get; set; }

            public int Age { get; set; }

            public string City { get; set; }

        }
        class Emploee
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int age { get; set; }
            public int depid { get; set; }
        }

        class Department
        {
            public int id {get;set;}
            public string country {get;set;}
            public string City {get;set;}
        }

        static void task1()
        {
            List<Person> person = new List<Person>()
            {
                new Person{Name="Andrey",Age=24,City="Kyiv"},
                new Person{Name="Liza",Age=18,City="Moscow"},
                new Person{Name="Oleg",Age=15,City="London"},
                new Person{Name="Sergey",Age=55,City="Kyiv"},
                new Person{Name="Sergey",Age=32,City="Kyiv"}
            };

            var data = from c in person
                       where c.Age > 25
                       select c;

            data = from c in person
                   where c.City != "Kyiv"
                   select c;

            var name = from c in person
                       where c.City == "Kyiv"
                       select new
                       {
                           c.Name
                       };

            data = from c in person
                   where c.Name == "Sergey"
                   where c.Age > 35
                   select c;

            data = from c in person
                   where c.City == "Moscow"
                   select c;


        }
        static void task2()
        {
            string s = "ol.kyzy@gmail.com" ;

            if (s.CheckEmail(@"\w*@\w*"))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
        static void task3()
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){id = 1, country="Ukraine",City="Donetsk"},
                new Department(){id = 2, country="Ukraine",City="Kyiv"},
                new Department(){id = 3, country="France",City="Paris"},
                new Department(){id = 4, country="Russia",City="Moscow" }
            };

            List<Emploee> emploees = new List<Emploee>()
            {
                new Emploee(){id=1,firstname="Tamara",lastname="Ivanova",age=22,depid=2},
                new Emploee(){id=2,firstname="Nicita",lastname="Larin",age=33,depid=1},
                new Emploee(){id=3,firstname="Alica",lastname="Ivanova",age=43,depid=3},
                new Emploee(){id=4,firstname="Lida",lastname="Marusyc",age=22,depid=2},
                new Emploee(){id=5,firstname="Lida",lastname="Voron",age=36,depid=4},
                new Emploee(){id=6,firstname="Ivan",lastname="Kalyta",age=22,depid=2},
                new Emploee(){id=7,firstname="Nikita",lastname="Krotov",age=27,depid=4 } 
            };

            var nodonetsk = from c in emploees
                            join dep in departments on c.depid equals dep.id
                            where dep.country == "Ukraine"
                            where dep.City != "Donetsk"
                            select new
                            {
                                c.firstname,
                                c.lastname
                            };

            var countries = (from c in departments
                             select c).Distinct();

            foreach (var i in countries)
                Console.WriteLine(i.country);

            var data = (from c in emploees
                        where c.age > 25
                        select c).Take(3);

            var data1 = from c in emploees
                        join dep in departments on c.depid equals dep.id
                        where dep.City == "Kyiv"
                        where c.age > 23
                        select new
                        {
                            c.firstname,
                            c.lastname,
                            c.age
                        };

            var sort = (from c in emploees
                       join dep in departments on c.depid equals dep.id
                       where dep.country == "Ukraine"
                       orderby c.firstname, c.lastname
                       select c).ToList();

            var sort1 = (from c in emploees
                         orderby c.age descending
                         select c).ToList();

            var group = from c in emploees
                        group c by c.age into em
                        select new
                        {
                            em.Key,
                            Count = em.Count()
                        };
        }
        static void Main(string[] args)
        {
            //task1();
            //task2();
            task3();
            Console.Read();
        }
    }
}
