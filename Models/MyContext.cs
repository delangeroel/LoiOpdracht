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
            //optionsBuilder.UseSqlServer("server=LAPTOP-K8D9UMK9\\SQLEXPRESS;database=LoiOpdracht;trusted_connection=true;Integrated Security=True;");
            optionsBuilder.UseSqlServer("server=.;database=LoiOpdracht;trusted_connection=true;Integrated Security=True;");
            //optionsBuilder.UseSqlite("DataSource=D:\\Temp\\LoiOpdracht.db;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Speler>()
                .HasData(new Speler[] {
                new Speler { SpelerId=1, Naam = "Speler1",Straatnaam = "S1",Woonplaats = "W1",Aktief = true},
                new Speler { SpelerId=2,Naam = "Speler2", Straatnaam = "S2", Woonplaats = "W2", Aktief = true },
                new Speler { SpelerId=3,Naam = "Speler3", Straatnaam = "S3", Woonplaats = "W3", Aktief = true },
                new Speler { SpelerId=4,Naam = "Speler4", Straatnaam = "S4", Woonplaats = "W4", Aktief = true },
                new Speler { SpelerId=5,Naam = "Speler5", Straatnaam = "S5", Woonplaats = "W5", Aktief = true },
                new Speler { SpelerId=6,Naam = "Speler6", Straatnaam = "S6", Woonplaats = "W6", Aktief = true },
                new Speler { SpelerId=7,Naam = "Speler7", Straatnaam = "S7", Woonplaats = "W7", Aktief = true }
                }) ;

            modelBuilder.Entity<Coach>()
            .HasData(new Coach[] {
                new Coach {  CoachId=1, Naam = "Coach1", Voornaam = "S1",Active = true },
                new Coach {  CoachId=2, Naam = "Coach2", Voornaam = "S2", Active = true },
                new Coach {  CoachId=3, Naam = "Coach3", Voornaam = "S3", Active = true },
                new Coach {  CoachId=4, Naam = "Coach4", Voornaam = "S4", Active = true }
            });

            modelBuilder.Entity<Team>()
                .HasData(new Team[] {
                    new Team { TeamId=1, Naam = "t1", TeamNaam = "Team1", SoortSport = "Tennis", CoachId = 2, SpelerId = 1, Speler2Id = 2},
                    new Team { TeamId=2, Naam = "t2", TeamNaam = "Team2", SoortSport = "Schaken", CoachId = 2, SpelerId = 2, Speler2Id = 3 },
                    new Team { TeamId=3, Naam = "t3", TeamNaam = "Team3", SoortSport = "Vissen", CoachId = 2, SpelerId = 3, Speler2Id = 4 },
                    new Team { TeamId=4, Naam = "t4", TeamNaam = "Team4", SoortSport = "Hardlopen", CoachId = 2, SpelerId = 4, Speler2Id = 5 }
                });
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
