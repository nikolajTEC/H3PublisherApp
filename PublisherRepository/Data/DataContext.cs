using Core.Objects;
using Microsoft.EntityFrameworkCore;
using REST_API.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PublisherRepository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Cover)
                .WithOne(c => c.Book)
                .HasForeignKey<Covers>(x => x.BookId);

            modelBuilder.Entity<ArtistCover>()
            .HasKey(ac => new { ac.ArtistsId, ac.CoversId });

            modelBuilder.Entity<ArtistCover>()
                .HasOne(ac => ac.Artist)
                .WithMany(a => a.ArtistCovers)
                .HasForeignKey(ac => ac.ArtistsId);

            modelBuilder.Entity<ArtistCover>()
                .HasOne(ac => ac.Cover)
                .WithMany(c => c.ArtistCovers)
                .HasForeignKey(ac => ac.CoversId);

            modelBuilder.Entity<Authors>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Covers>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Covers>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Artists>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Artists>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<ArtistCover> ArtistCovers { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Covers> Covers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
