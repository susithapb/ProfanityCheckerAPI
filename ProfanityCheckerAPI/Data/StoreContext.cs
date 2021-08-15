using Microsoft.EntityFrameworkCore;
using ProfanityCheckerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfanityCheckerAPI.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<ProfanityDocument> ProfanityDocuments { get; set; }   
        public DbSet<Document> Documents { get; set; }
        public DbSet<BadWord> BadWords { get; set; }
        
        
    }
}
