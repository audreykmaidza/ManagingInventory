using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarDom.Models
{
    public partial class MarDomContext : DbContext
    {
        public MarDomContext()
        {
        }

        public MarDomContext(DbContextOptions<MarDomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GoodsMovements> GoodsMovements { get; set; }
        public virtual DbSet<MovementTypes> MovementTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StorageLocations> StorageLocations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoodsMovements>(entity =>
            {
                entity.HasKey(e => e.IdgoodsMovements);

                entity.Property(e => e.IdgoodsMovements).HasColumnName("IDGoodsMovements");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdmovementType).HasColumnName("IDMovementType");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

                entity.Property(e => e.IdstorageLocationFrom).HasColumnName("IDStorageLocationFrom");

                entity.Property(e => e.IdstorageLocationTo).HasColumnName("IDStorageLocationTo");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.HasOne(d => d.IdmovementTypeNavigation)
                    .WithMany(p => p.GoodsMovements)
                    .HasForeignKey(d => d.IdmovementType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodsMovements_MovementTypes");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.GoodsMovements)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodsMovements_Produts");

                entity.HasOne(d => d.IdstorageLocationFromNavigation)
                    .WithMany(p => p.GoodsMovementsIdstorageLocationFromNavigation)
                    .HasForeignKey(d => d.IdstorageLocationFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodsMovements_StorageLocations");

                entity.HasOne(d => d.IdstorageLocationToNavigation)
                    .WithMany(p => p.GoodsMovementsIdstorageLocationToNavigation)
                    .HasForeignKey(d => d.IdstorageLocationTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodsMovements_StorageLocations1");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.GoodsMovements)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoodsMovements_Users");
            });

            modelBuilder.Entity<MovementTypes>(entity =>
            {
                entity.HasKey(e => e.IdmovementType);

                entity.Property(e => e.IdmovementType).HasColumnName("IDMovementType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PK_Produts");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitOfMeasurement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Idstock);

                entity.Property(e => e.Idstock).HasColumnName("IDStock");

                entity.Property(e => e.Idproduct).HasColumnName("IDProduct");

                entity.Property(e => e.IdstorageLocation).HasColumnName("IDStorageLocation");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Produts");

                entity.HasOne(d => d.IdstorageLocationNavigation)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.IdstorageLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_StorageLocations");
            });

            modelBuilder.Entity<StorageLocations>(entity =>
            {
                entity.HasKey(e => e.IdstorageLocation);

                entity.Property(e => e.IdstorageLocation).HasColumnName("IDStorageLocation");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
