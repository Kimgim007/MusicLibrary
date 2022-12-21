using DataBase.DbEntity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.MyDbContext
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<SingerTag> SingerTags { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionsString = "Server=(localdb)\\MSSQLLocalDB;Database=MusicLibary;Trusted_Connection=True;";

            if (optionsBuilder.IsConfigured == false)
            {

                optionsBuilder.UseSqlServer(connectionsString);

            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Singer>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.SingerId);
                entityTypeBuilder.Property(q => q.FirstName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.LastName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.BirthDay).IsRequired();
                entityTypeBuilder.HasIndex(x => x.Nickname).IsUnique();

                entityTypeBuilder.HasMany(q => q.SingerTags).WithOne(q => q.Singer).HasForeignKey(q => q.SingerId);
                entityTypeBuilder.HasMany(q => q.AudioFiles).WithMany(q => q.Singers).UsingEntity(q => q.ToTable("AudioFileSinger"));

            });

            modelBuilder.Entity<Tag>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.TagId);
                entityTypeBuilder.Property(q => q.TagName).IsRequired().HasMaxLength(50);

                entityTypeBuilder.HasMany(q => q.SingerTags).WithOne(q => q.Tag).HasForeignKey(q => q.TagId);
                entityTypeBuilder.HasMany(q => q.AudioFiles).WithMany(q => q.Tags).UsingEntity(q=>q.ToTable("AudioFileTag"));

            });

            modelBuilder.Entity<SingerTag>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.SingerTagId);
            });

            modelBuilder.Entity<AudioFile>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q=>q.AudioFileId);
            });

            //modelBuilder.Entity<AudioFile>().HasMany(q => q.Singers).WithMany(q => q.AudioFiles);
            //modelBuilder.Entity<AudioFile>().HasMany(q => q.Tags).WithMany(q => q.AudioFiles);
        }
    }
}
