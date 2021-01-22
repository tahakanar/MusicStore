using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Data
{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext()
            :base("Default")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            { 
                var entity = modelBuilder.Entity<Genre>();
            
                entity
                    .Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsRequired();
                entity
                    .HasIndex(p => p.Name);

                entity
                    .HasMany(p => p.Albums)
                    .WithRequired(p => p.Genre)
                    .HasForeignKey(p => p.GenreId)
                    .WillCascadeOnDelete(false);

            }
            {
                var entity = modelBuilder.Entity<Artist>();

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsRequired();
                entity
                    .HasIndex(p => p.Name);

                entity
                    .HasMany(p => p.Albums)
                    .WithRequired(p => p.Artist)
                    .HasForeignKey(p => p.ArtistId)
                    .WillCascadeOnDelete(false);

            }
            {
                var entity = modelBuilder.Entity<Album>();

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsRequired();
                entity
                    .HasIndex(p => p.Name);

                entity
                    .Property(p => p.Price)
                    .HasColumnType("smallmoney");


            }

            base.OnModelCreating(modelBuilder);
        }



        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
    }
}