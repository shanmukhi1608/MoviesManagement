using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesManagement.Models
{
    public class MoviesManagementContext:DbContext
    {
        public MoviesManagementContext(DbContextOptions<MoviesManagementContext> options) : base(options) { }

        public DbSet<MoviesManagement> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesManagement>(entity =>
            {

                entity.Property(e => e.movie_title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.movie_language)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.movie_date_release)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.movie_ori_country)
                .IsRequired()
                .HasMaxLength(50);

            });
        }
    }
}
