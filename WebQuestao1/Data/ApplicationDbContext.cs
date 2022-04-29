using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebQuestao1.Models;

namespace WebQuestao1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<WebQuestao1.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<WebQuestao1.Models.Candidato> Candidato { get; set; }

        public DbSet<WebQuestao1.Models.Cargo> Cargo { get; set; }

        public DbSet<WebQuestao1.Models.LinguaEstrangeira> LinguaEstrangeira { get; set; }

        public DbSet<WebQuestao1.Models.CandidatoIdioma> CandidatoIdioma { get; set; }

        public DbSet<WebQuestao1.Models.NumberSequence> NumberSequence { get; set; }


    }
}
