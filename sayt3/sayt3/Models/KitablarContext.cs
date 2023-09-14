using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sayt3.Models
{
    public partial class KitablarContext : DbContext
    {
        public KitablarContext()
        {
        }

        public KitablarContext(DbContextOptions<KitablarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Janr> Janrs { get; set; } = null!;
        public virtual DbSet<Kitab> Kitabs { get; set; } = null!;
        public virtual DbSet<Statuss> Statusses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Yazici> Yazicis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WINDOWS-2LNKPMJ;Database=Kitablar;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.HasOne(d => d.FavoriteKitab)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.FavoriteKitabId)
                    .HasConstraintName("FK__Favorite__Favori__02FC7413");

                entity.HasOne(d => d.FavoriteUser)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.FavoriteUserId)
                    .HasConstraintName("FK__Favorite__Favori__02084FDA");
            });

            modelBuilder.Entity<Janr>(entity =>
            {
                entity.ToTable("Janr");

                entity.Property(e => e.JanrAd).HasMaxLength(20);
            });

            modelBuilder.Entity<Kitab>(entity =>
            {
                entity.ToTable("Kitab");

                entity.Property(e => e.KitabAd).HasMaxLength(20);

                entity.Property(e => e.KitabMelumat).HasMaxLength(150);

                entity.Property(e => e.KitabSekil)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.KitabJanr)
                    .WithMany(p => p.Kitabs)
                    .HasForeignKey(d => d.KitabJanrId)
                    .HasConstraintName("FK__Kitab__KitabJanr__4E88ABD4");

                entity.HasOne(d => d.KitabYazici)
                    .WithMany(p => p.Kitabs)
                    .HasForeignKey(d => d.KitabYaziciId)
                    .HasConstraintName("FK__Kitab__KitabYazi__4D94879B");
            });

            modelBuilder.Entity<Statuss>(entity =>
            {
                entity.ToTable("Statuss");

                entity.Property(e => e.StatussAd).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserAd).HasMaxLength(20);

                entity.Property(e => e.UserLogin).HasMaxLength(20);

                entity.Property(e => e.UserPassword).HasMaxLength(20);

                entity.Property(e => e.UserSoyad).HasMaxLength(20);

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .HasConstraintName("FK__Users__UserStatu__5EBF139D");
            });

            modelBuilder.Entity<Yazici>(entity =>
            {
                entity.ToTable("Yazici");

                entity.Property(e => e.YaziciAd).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
