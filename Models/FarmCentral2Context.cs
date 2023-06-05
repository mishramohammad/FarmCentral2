using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FarmCentral2.Models
{
    public partial class FarmCentral2Context : DbContext
    {
        public FarmCentral2Context()
        {
        }

        public FarmCentral2Context(DbContextOptions<FarmCentral2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Farmers> Farmers { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-B41IIIGC;Database=FarmCentral2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EId)
                    .HasName("PK__Employee__D9519B455A69FC96");

                entity.Property(e => e.EId).HasColumnName("eId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasColumnName("EName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Esurname)
                    .HasColumnName("ESurname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eusername)
                    .IsRequired()
                    .HasColumnName("EUsername")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Farmers>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__Farmers__D9F8227C3EB75C5C");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.Femail)
                    .IsRequired()
                    .HasColumnName("FEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fpassword)
                    .HasColumnName("FPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fsurname)
                    .IsRequired()
                    .HasColumnName("FSurname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fusername)
                    .IsRequired()
                    .HasColumnName("FUsername")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__4701761D395EFBF0");

                entity.Property(e => e.ProductId).HasColumnName("product_Id");

                entity.Property(e => e.FarmerId).HasColumnName("farmer_id");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfProduct)
                    .IsRequired()
                    .HasColumnName("Type_of_Product")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
