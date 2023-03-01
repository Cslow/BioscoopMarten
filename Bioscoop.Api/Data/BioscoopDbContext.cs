using Bioscoop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bioscoop.Api.Data
{
    public class BioscoopDbContext:DbContext
    {
        public BioscoopDbContext(DbContextOptions<BioscoopDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Add movies
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "Ant-Man and the Wasp: Quantumania",
                Description = "In Ant-Man and the Wasp: Quantumania keren superheldenpartners Scott Lang (Paul Rudd) en Hope van Dyne (Evangeline Lilly) terug op het grote doek om hun avonturen als Ant-Man en The Wasp voort te zetten.\r\n\r\nSamen met Hope’s ouders Hank Pym (Michael Douglas) en Janet van Dyne (Michelle Pfeiffer) verkennen ze de Quantum Realm, waarbij er vreemde nieuwe wezens op hun pad komen. Zo beginnen ze aan een avontuur dat ze voorbij de grenzen zal brengen van wat ze voor mogelijk hielden. In Ant-Man and the Wasp: Quantumania is Jonathan Majors te zien als Kang. De film wordt geregisseerd door Peyton Reed; Kevin Feige en Stephen Broussard zijn de producenten.",
                ImageURL = "/Images/Movies/ant-man.jpg",
                PlayTime = 124,
                MinimumAge = 12
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 2,
                Title = "Babylon",
                Description = "Babylon, geschreven en geregisseerd door Damien Chazelle met Brad Pitt, Margot Robbie en Diego Calva in de hoofdrol, is een origineel verhaal dat zich afspeelt in het Los Angeles van de jaren 1920.\r\n\r\nOok o.a. Jovan Adepo, Li Jun Li en Jean Smart spelen in deze film over de opkomst en ondergang van diverse personages in een tijdperk van decadentie in het vroege Hollywood.",
                ImageURL = "/Images/Movies/Babylon.jpg",
                PlayTime = 188,
                MinimumAge = 16
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 3,
                Title = "Puss in boots: The last wish",
                Description = "Dit najaar keert onze geliefde, melk drinkende, roekeloze, onbevreesde katachtige terug. Voor het eerst in ruim tien jaar presenteert DreamWorks Animation weer een nieuw avontuur in het Shrek-universum.\r\n\r\nBeleef dit jaar elk avontuur alsof het je laatste is. Voor het eerst in ruim tien jaar presenteert DreamWorks Animation weer een nieuw avontuur in het Shrek-universum met de terugkeer van onze geliefde, melk drinkende, roekeloze, onbevreesde katachtige in Puss in Boots: The Last Wish. In de originele versie zullen Antonio Banderas en Salma Hayek terugkeren in de rol van Puss in Boots en Kitty Soft Pawas.",
                ImageURL = "/Images/Movies/PussInBootsTwo.jpg",
                PlayTime = 105,
                MinimumAge = 6
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 4,
                Title = "Avatar: The way of water",
                Description = "Avatar: The Way of Water vertelt het verhaal van de familie Sully (Jake, Neytiri en hun kinderen) en de problemen waar ze tegenaan lopen, de moeite die ze doen om elkaar te beschermen, de gevechten die ze moeten aangaan om in leven te blijven en de tragedies die ze te verduren krijgen.",
                ImageURL = "/Images/Movies/AvatarTheWayOfTheWater.jpg",
                PlayTime = 192,
                MinimumAge = 12
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 5,
                Title = "The Whale",
                Description = "The Whale is een aangrijpend drama met een fenomenale comeback van acteur Brendan Fraser (The Mummy Trilogy, Crash) als vader, die probeert opnieuw contact te maken met zijn vervreemde tienerdochter, gespeeld door rising star Sadie Sink (Stranger Things).",
                ImageURL = "/Images/Movies/TheWhale.jpg",
                PlayTime = 117,
                MinimumAge = 12
            });

            //Add Rooms
            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 1,
                Name = "Zaal 1",
                Seats = 120,
                Rows = 8,
                WheelchairFriendly = true
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 2,
                Name = "Zaal 2",
                Seats = 120,
                Rows = 8,
                WheelchairFriendly = true
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 3,
                Name = "Zaal 3",
                Seats = 120,
                Rows = 8,
                WheelchairFriendly = true
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 4,
                Name = "Zaal 4",
                Seats = 60,
                Rows = 6,
                WheelchairFriendly = true
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 5,
                Name = "Zaal 5",
                Seats = 50,
                Rows = 4,
                WheelchairFriendly = false
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 6,
                Name = "Zaal 6",
                Seats = 50,
                Rows = 4,
                WheelchairFriendly = false
            });

            //Add Shows
            modelBuilder.Entity<Show>().HasData(new Show
            {
                Id = 1,
                MovieId = 3,
                RoomId = 2,
                StartDateTime = DateTime.Now
            });

            //Add Tickets
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 1,
                Code = 000001,
                ShowId = 1,
                RowNumber = 1,
                SeatNumber = 1,
                Price = 9.00
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 2,
                Code = 000002,
                ShowId = 1,
                RowNumber = 1,
                SeatNumber = 2,
                Price = 9.00
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = 3,
                Code = 000003,
                ShowId = 1,
                RowNumber = 1,
                SeatNumber = 3,
                Price = 9.00
            });
        }

        public DbSet<Movie> Movies { get; set;}
        public DbSet<Room> Rooms { get; set;}
        public DbSet<Show> Shows { get; set;}
        public DbSet<Ticket> Tickets { get; set; }
    }
}
