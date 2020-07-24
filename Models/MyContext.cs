using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoiOpdracht.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Speler> Speler { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=LoiOpdracht;trusted_connection=true;Integrated Security=True;");
            //optionsBuilder.UseSqlite("DataSource=D:\\Temp\\LoiOpdracht.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Team>().HasMany<Coach>(s => s.Coach);
            //modelBuilder.Entity<Team>().Property(o => o.Coach).HasColumnName("FK");
            //entity.Property(o => o.CreatedAt).HasDefaultValueSql("DATEADD(HOUR, +3, GETUTCDATE())");

            //entity.HasForeignKey(o => o.).HasConstraintName("Fk_Order_User);


            //modelBuilder.Entity<Team>().Property(p => p.Coach);

            //modelBuilder.Entity<Blog>().HasIndex(b => b.Url).IsUnique();

            //modelBuilder.Entity<Team>().OwnsOne(e => e.Coach).WithOwner(e => e.CoachId);
            //.HasForeignKey(p => p.AuthorFK);

            //modelBuilder.Entity<Team>(entity =>
            //{
            //    entity.HasOne(e => e.Speler1).WithMany(a => a.SpelerId).HasForeignKey(e => e.Speler1).HasConstraintName("FK_Speler1");
            //    entity.HasOne(e => e.Speler2).WithMany(x => x.SpelerId).HasForeignKey(e => e.Speler2).HasConstraintName("FK_Speler2");
            //});

            //modelBuilder.Entity<Team>().HasOne<Coach>(c => c.Coach);
            //modelBuilder.Entity<Team>().HasOne<Speler>(c => c.Speler1);


            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            //base.OnModelCreating(modelBuilder);

        }
    }
}
