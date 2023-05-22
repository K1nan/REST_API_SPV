using Microsoft.EntityFrameworkCore;
using SPV_REST.Models;
using System;

namespace SPV_REST.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; } = null!;
 
    }
}

