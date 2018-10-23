using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }

    class UserContext : DbContext
    {
        public UserContext() : base("EntityDemo") { }

        public DbSet<User> Users { get; set; }
    }
}
