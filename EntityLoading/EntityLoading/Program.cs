using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLoading
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (LibraryEntities entities = new LibraryEntities())
            //{
            //    entities.Database.Log = Console.WriteLine;
            //    var data = entities.AUTHORS_BOOKS.ToList();
            //
            //    foreach (var i in data)
            //    {
            //        Console.WriteLine(i.AUTHORS.Name + "  " + i.BOOKS.Name);
            //    }
            //}

            //Безотсложная загрузка
            //using (LibraryEntities entities = new LibraryEntities())
            //{
            //    entities.Database.Log = Console.WriteLine;
            //    var data = entities.AUTHORS_BOOKS.Include("AUTHORS").Include("BOOKS").ToList();
            //
            //    foreach(var i in data)
            //    {
            //        Console.WriteLine(i.AUTHORS.Name+"  "+i.BOOKS.Name);
            //    }
            //}
            //
            //Явная загрузка
            //using (LibraryEntities entities = new LibraryEntities())
            //{
            //    entities.Configuration.LazyLoadingEnabled = false;
            //
            //    var data = entities.AUTHORS_BOOKS.FirstOrDefault();
            //
            //    entities.Entry(data).Reference(a => a.AUTHORS).Load();
            //    entities.Entry(data).Reference(a => a.BOOKS).Load();
            //
            //    Console.WriteLine(data.AUTHORS.Name + "  " + data.BOOKS.Name);
            //    
            //}

            //using (LibraryEntities entities = new LibraryEntities())
            //{
            //    entities.Configuration.LazyLoadingEnabled = false;
            //
            //    entities.Database.Log = Console.WriteLine;
            //
            //    var data = entities.AUTHORS.FirstOrDefault();
            //
            //    entities.Entry(data).Collection("AUTHORS_BOOKS").Load();
            //
            //    foreach (var i in data.AUTHORS_BOOKS)
            //        Console.WriteLine(i.Id);
            //
            //}

            Console.ReadLine();
        }
    }
}
