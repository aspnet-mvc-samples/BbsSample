using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BbsSample.Models
{
    public class BbsDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}