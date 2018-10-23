using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo
{
    class Program
    {
       static void Main(string[] args)
        {
            using (UserContext context = new UserContext())
            {
                context.Users.Add(new User { name = "Oleg", age = 18 });
                context.Users.Add(new User { name = "Test", age = 20 });
                context.SaveChanges();
            }



            Console.ReadLine();
        }
    }
}
