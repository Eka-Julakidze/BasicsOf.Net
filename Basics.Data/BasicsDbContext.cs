using Basics.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Data
{
    public class BasicsDbContext : DbContext
    {
        public BasicsDbContext(DbContextOptions<BasicsDbContext> options)
            : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
    }
}
