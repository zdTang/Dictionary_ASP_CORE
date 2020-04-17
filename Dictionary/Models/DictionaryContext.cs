using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Dictionary.Models
{
    public partial class DictionaryContext : DbContext
    {
        public DictionaryContext()
        {
        }

        public DictionaryContext(DbContextOptions<DictionaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<BasicWords> BasicWords { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<EnWords> EnWords { get; set; }
        public virtual DbSet<LevelOneClass> LevelOneClass { get; set; }
        public virtual DbSet<LevelTwoClass> LevelTwoClass { get; set; }
        public virtual DbSet<WordType> WordType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    /*=======================================
            //     https://stackoverflow.com/questions/45796776/get-connectionstring-from-appsettings-json-instead-of-being-hardcoded-in-net-co/45845041
            //     ================================================*/
            //    //optionsBuilder.UseSqlServer("Data Source=192.168.1.8;Initial Catalog=Dictionary;User ID=sa;Password=123456");

            //    /* Tang:Instantiate a configuration object, and assign several properties*/
            //    IConfigurationRoot configuration = new ConfigurationBuilder()
            //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //        .AddJsonFile("appsettings.json")
            //        .Build();
            //    /* Tang:Specify Connection string here*/
            //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BasicWords>(entity =>
            {
                entity.HasKey(e => e.Word);

                entity.Property(e => e.Word)
                    .HasColumnName("word")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClassOneId).HasColumnName("classOneID");

                entity.Property(e => e.ClassTwoId).HasColumnName("classTwoID");

                entity.Property(e => e.Explain)
                    .HasColumnName("explain")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryDiscription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnWords>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Explain)
                    .HasColumnName("explain")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Word)
                    .HasColumnName("word")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LevelOneClass>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LevelOneClassAbb).HasMaxLength(30);

                entity.Property(e => e.LevelOneClassDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LevelOneClassId).HasColumnName("LevelOneClassID");
            });

            modelBuilder.Entity<LevelTwoClass>(entity =>
            {
                entity.HasKey(e => new { e.LevelOneClassId, e.LevelTwoClassId });

                entity.Property(e => e.LevelOneClassId).HasColumnName("LevelOneClassID");

                entity.Property(e => e.LevelTwoClassId).HasColumnName("LevelTwoClassID");

                entity.Property(e => e.LevelTwoClassAbb)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LevelTwoClassDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WordType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
