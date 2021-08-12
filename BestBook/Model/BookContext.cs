using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hastprogrammet.Model
{
    public partial class HorseContext : DbContext
    {
        public HorseContext()
        {
        }

        public HorseContext(DbContextOptions<HorseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=HorseProgram;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Book__AuthorID__29572725");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Book__GenreID__2A4B4B5E");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Review__BookID__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
