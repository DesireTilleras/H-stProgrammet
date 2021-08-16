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

        public virtual DbSet<Horse> Horses { get; set; }
        public virtual DbSet<Economy> Economies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=HorseProgramDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Economy>(entity =>
            {
                entity.HasOne(d => d.Horse)
                    .WithMany(p => p.Economies)
                    .HasForeignKey(d => d.HorseId)
                    .HasConstraintName("FK__Book__AuthorID__29572725");

               });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
