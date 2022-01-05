using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Person_Processor.Model;

namespace Person_Processor.DataAccess
{
    public class PersonContext : DbContext
    {
        private string _connectionString = string.Empty;

        public DbSet<Person_SocialMedia> Person_SocialMedia { get; set; }
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }
        public PersonContext()
        {

        }

        public PersonContext(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
