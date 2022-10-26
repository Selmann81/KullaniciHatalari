using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options) : base(options)

        {

        }
        public DbSet<Hatalar> Hata { get; set; }
    }
}


