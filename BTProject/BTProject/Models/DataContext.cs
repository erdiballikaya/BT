using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTProject.Models;

namespace BTProject.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<SignInUser> SignInUser { get; set; }
        public DbSet<Movie> Movie { get; set; }

    }
}
