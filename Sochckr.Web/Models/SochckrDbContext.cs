using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sochckr.Web.Models
{
    public class SochckrDbContext : DbContext
    {
        public SochckrDbContext()
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<BrokenLink> BrokenLinks { get; set; }
    }
}