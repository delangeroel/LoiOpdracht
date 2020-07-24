Combobox binding foreign key
https://stackoverflow.com/questions/20509957/how-to-bind-a-combobox-with-foreign-key-in-wpf-mvvm
https://docs.telerik.com/devtools/wpf/controls/radcombobox/features/selection

---------------------------------------------------------------------------
- SQL software laden  (Let op sqlLite zet de database gewoon in een folder)
---------------------------------------------------------------------------
Tabellen of bestanden maken
1, Connection class en zelf bouwen
2. Entity Framework 6
3. Entity Framework Core (is de laatste)


>Menu Tools
>Nu het package manager
>Package manager console
Op het prompt kun je commando's intoetsen. Het volgende commanda laad het Entity Framework in je applciatie.
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer


In plaats hiervan kun je ook een inmemory optie of de sqlserver gebruiken:
PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite
PM> Install-Package Microsoft.EntityFrameworkCore.Inmemory

---------------------------------------------------------------------------
- creeren van een model
---------------------------------------------------------------------------
Een model is een class dat een object (klant, order e.d.) beschrijft. Al deze gegevens wil je opslaan.
Entity Framework core vereist dat je deze objecten in een Context class zet zodat het weet wat het moet doen.
Er zijn minimaal 2 vereisten:
- een context (deze bevat de tabellen en de naam van de database)
- de tabellen die je wilt opslaan (minimaal 1)

Nadat je dit gemaakt hebt moet je de tabellen maken 


---------------------------------------------------------------------------
- creeren van een database         SQLite
---------------------------------------------------------------------------
Initieel de software laden
>Menu Tools
>Nu het package manager
>Package manager console
PM> Install-Package Microsoft.EntityFrameworkCore.Tools

---------------------------------------------------------------------------
- Database voorzien van de laatste tabellen
---------------------------------------------------------------------------

En vervolgens bij elke update van de tabellen
>Menu Tools
>Nu het package manager
>Package manager console
PM> get-help NuGet    (bij vragen)

PM> Add-Migration  InitialCreate -Context  MyContext
PM> Update-Database -c MyContext

Daarna
PM>Add-Migration
PM> Update-Database -c MyContext


insert into [WpfStefEFC].[dbo].speler values('Speler1','s1','w1','1')
insert into [WpfStefEFC].[dbo].speler values('Speler2','s2','w2','1')
insert into [WpfStefEFC].[dbo].speler values('Speler3','s3','w3','1')
insert into [WpfStefEFC].[dbo].speler values('Speler4','s4','w4','1')
insert into [WpfStefEFC].[dbo].speler values('Speler5','s5','w5','1')
insert into [WpfStefEFC].[dbo].speler values('Speler6','s6','w6','0')
insert into [WpfStefEFC].[dbo].speler values('Speler7','s7','w7','0')

insert into [WpfStefEFC].[dbo].coach values('Coach1','Harry','1')
insert into [WpfStefEFC].[dbo].coach values('Coach2','Roel','1')
insert into [WpfStefEFC].[dbo].coach values('Coach3','Tia','1')
insert into [WpfStefEFC].[dbo].coach values('Coach4','v4','1')

insert into LoiOpdracht.[dbo].Team values('t1','Team1','Tennis',2,1,2)
insert into LoiOpdracht.[dbo].Team values('t2','Team2','Schaken',2,2,3)
insert into LoiOpdracht.[dbo].Team values('t3','Team3','Vissen',3,3,4)
insert into LoiOpdracht.[dbo].Team values('t4','Team4','Hardlopen',2,4,5)

---------------------------------------------------------------------------
-- Modelling
---------------------------------------------------------------------------
https://docs.microsoft.com/en-us/ef/core/modeling/
Definieer je eigen object (lees tabellen)

Relaties tussen tabellen (1:1, 1:N, N:M)
https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key

Statusveld conversie, of ook enum conversie
https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions

---------------------------------------------------------------------------
-- Database connectie maken
---------------------------------------------------------------------------

  public class MyContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=WindowsFormsApp3;trusted_connection=true;Integrated Security=True;");
            //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Url)
                .IsUnique();
        }

    }
---------------------------------------------------------------------------
-- Ouderwetse database connectie maken
---------------------------------------------------------------------------        
        SqlDataReader rdr = null;
        SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from Customers", conn);
        rdr = cmd.ExecuteReader();
        
        conn.Close();


---------------------------------------------------------------------------
-- Controle numerieke invoer
---------------------------------------------------------------------------
 //string input = KeyComboFld.Text;
            //if (string.IsNullOrEmpty(input)) input = "0";
            //Boolean isNumeric = Regex.IsMatch(input, @"^\d+$");
            //KeyId = 0;
            //if (!isNumeric)
            //{
            //    MessageBox.Show("Veld niet numeriek, invoer stopt", "Invoer", MessageBoxButtons.OK);
            //    return false;
            //}
            // KeyId = Int32.Parse(input);



get-help NuGet
PM> Add-Migration  InitialCreate -Context  MyContext
PM> Update-Database -c MyContext



USE [WindowsFormsApp3]
drop table team
drop table Speler
drop table Posts
drop table Coach
drop table Blogs
drop table __EFMigrationsHistory

USE [WindowsFormsApp3]
drop table team
drop table Speler
drop table Posts
drop table Coach
drop table Blogs
drop table reviews
drop table users
drop table __EFMigrationsHistory

insert into Speler (naam) values('ik1')
insert into Speler (naam) values('ik2')
insert into Speler (naam) values('ik3')

insert into Coach  (Voornaam, naam, Active) values ('Roel', 'De Lange1', 1)
insert into Coach  (Voornaam, naam, Active) values ('Desiree', 'De Lange2', 1)
insert into Coach  (Voornaam, naam, Active) values ('Wesley', 'De Lange3', 1)
insert into Coach  (Voornaam, naam, Active) values ('Stefan', 'De Lange4', 1)


---------------------------------------------------------------------------
-- Foutcontrole strategie                       
---------------------------------------------------------------------------
Idee:

- Start save in scherm

- Vervolgens save in 
  try:  save in controller
  catch toon fouten

---------------------------------------------------------------------------
-- Binding                     
---------------------------------------------------------------------------
{Binding}                       Current DataContext
{Binding Path=NameOfProperty}   default path of binding
{Binding propertyNameOfProperty}
{Binding Path=Text, ElementName=txtValue}  