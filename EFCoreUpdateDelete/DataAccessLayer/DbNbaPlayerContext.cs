using EFCoreUpdateDelete.BusinessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreUpdateDelete.DataAccessLayer
{
    class DbNbaPlayerContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true)
        });
        public DbSet<NbaPlayer> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(@"Server=.;Database=NbaPlayerDB;Trusted_Connection=True;");
        }
    }
}
