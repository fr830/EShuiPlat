using EShuiPlat.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.EntityFrameWork.SQLSERVER
{
  public   class DBContextSQLSERVER:DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TestDB;Integrated Security=True");
        }
    }
}
