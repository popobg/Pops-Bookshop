using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Models.Entities;

namespace Pops_bookshop.Areas.Identity.Data
{
    public class BookshopDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookshopDbContext(DbContextOptions<BookshopDbContext> options)
        : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // if a book is delete,
            // all the reviews related to this book will be deleted.
            builder.Entity<Review>()
                .HasOne(r => r.BookReviewed)
                .WithMany(b => b.Reviews)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // if a user is delete,
            // all the reviews related to this user will be deleted.
            builder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(b => b.Reviews)
                .HasForeignKey(c => c.ReviewerId)
                .OnDelete(DeleteBehavior.Cascade);

            // if a user is delete,
            // the orders related to this user are not deleted.
            // buyerId is just set to null.
            builder.Entity<Order>()
                .HasOne(r => r.Buyer)
                .WithMany(b => b.Orders)
                .HasForeignKey(c => c.BuyerId)
                .OnDelete(DeleteBehavior.SetNull);

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "1",
                Firstname = "Helena",
                Lastname = "Yamasaki",
                UserName = "helena@gmail.com",
                NormalizedUserName = "HELENA@GMAIL.COM",
                Email = "helena@gmail.com",
                NormalizedEmail = "HELENA@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Helena.123"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new ApplicationUser
            {
                Id = "2",
                Firstname = "Pauline",
                Lastname = "Bouyssou",
                UserName = "pauline@gmail.com",
                NormalizedUserName = "PAULINE@GMAIL.COM",
                Email = "pauline@gmail.com",
                NormalizedEmail = "PAULINE@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Pauline.123"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new ApplicationUser
            {
                Id = "3",
                Firstname = "Nolan",
                Lastname = "De Puydt",
                UserName = "nolan@gmail.com",
                NormalizedUserName = "NOLAN@GMAIL.COM",
                Email = "nolan@gmail.com",
                NormalizedEmail = "NOLAN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Nolan.123"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            },
            new ApplicationUser
            {
                Id = "4",
                Firstname = "Kevin",
                Lastname = "Osei Yaw",
                UserName = "kevin@gmail.com",
                NormalizedUserName = "KEVIN@GMAIL.COM",
                Email = "kevin@gmail.com",
                NormalizedEmail = "KEVIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Kevin.123"),
                SecurityStamp = Guid.NewGuid().ToString("D")
            });

            builder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Le Sang de la cité",
                    Description = "Super bouquin",
                    Price = 16.90,
                    ISBN = "9782373051025"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Citadins de demain",
                    Description = "Excellent bouquin",
                    Price = 15.90,
                    ISBN = "978-2-37305-101-8"
                },
                new Book()
                {
                    Id = 3,
                    Title = "Trois Lucioles",
                    Description = "Bouquin inouï",
                    Price = 16.99,
                    ISBN = "9782373051094"

                });

            builder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    Name = "Guillaume Chamanadjian",
                    Biography = "Homme stylé"
                },
                new Author()
                {
                    Id = 2,
                    Name = "Claire Duvivier",
                    Biography = "Femme stylée"
                });

            builder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Policier"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Fantastique"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Aventure"
                });
        }
    }
}
