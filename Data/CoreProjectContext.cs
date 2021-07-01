using CoreProject.Models;
using Microsoft.EntityFrameworkCore;
using CoreProject.Models.Entities;
using System;

namespace CoreProject.Data
{
    public class CoreProjectContext : DbContext
    {
        public CoreProjectContext()
        {
        }

        public CoreProjectContext(DbContextOptions<CoreProjectContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
