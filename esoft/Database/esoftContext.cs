using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using esoft.Models;
using System.IO;
using System.Text.Json;
using esoft.Model;
using System.Text.Json.Serialization;

namespace esoft.Database
{
    public partial class esoftContext : DbContext
    {
        public esoftContext()
        {
        }

        public esoftContext(DbContextOptions<esoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Listofcoefficient> Listofcoefficient { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Performer> Performer { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Useraccount> Useraccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                var jsonString = File.ReadAllText("databasedata.json");
                DatabaseConnect databaseConnect = JsonSerializer.Deserialize<DatabaseConnect>(jsonString);
                optionsBuilder.UseNpgsql($"Host={databaseConnect.Host};Port={databaseConnect.Port};Database={databaseConnect.Database};Username={databaseConnect.Username};Password={databaseConnect.Password}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listofcoefficient>(entity =>
            {
                entity.HasKey(e => e.Manager)
                    .HasName("listofcoefficient_pkey");

                entity.ToTable("listofcoefficient");

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(50);

                entity.Property(e => e.Coefficientofcosttimetc).HasColumnName("coefficientofcosttimetc");

                entity.Property(e => e.Coefficientofnatureofworkci).HasColumnName("coefficientofnatureofworkci");

                entity.Property(e => e.Coefficientoftaskcomplexityde).HasColumnName("coefficientoftaskcomplexityde");

                entity.Property(e => e.Forconvertedintocashtb).HasColumnName("forconvertedintocashtb");

                entity.Property(e => e.Minimumwagegm).HasColumnName("minimumwagegm");

                entity.Property(e => e.Taskcomplexitydi).HasColumnName("taskcomplexitydi");

                entity.Property(e => e.Timetocompletethetaskti).HasColumnName("timetocompletethetaskti");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithOne(p => p.Listofcoefficient)
                    .HasForeignKey<Listofcoefficient>(d => d.Manager)
                    .HasConstraintName("listofcoefficient_manager_fkey");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("manager_pkey");

                entity.ToTable("manager");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(30);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(30);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnName("patronymic")
                    .HasMaxLength(30);

                entity.HasOne(d => d.LoginNavigation)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.Login)
                    .HasConstraintName("manager_login_fkey");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("performer_pkey");

                entity.ToTable("performer");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasMaxLength(20);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(30);

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasColumnName("manager")
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(30);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnName("patronymic")
                    .HasMaxLength(30);

                entity.HasOne(d => d.LoginNavigation)
                    .WithOne(p => p.Performer)
                    .HasForeignKey<Performer>(d => d.Login)
                    .HasConstraintName("performer_login_fkey");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Performer)
                    .HasForeignKey(d => d.Manager)
                    .HasConstraintName("performer_manager_fkey");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Taskid).HasColumnName("taskid");

                entity.Property(e => e.Aboutoftask)
                    .IsRequired()
                    .HasColumnName("aboutoftask")
                    .HasMaxLength(100);

                entity.Property(e => e.Dateofcompletion)
                    .HasColumnName("dateofcompletion")
                    .HasColumnType("date");

                entity.Property(e => e.Natureofthetask)
                    .IsRequired()
                    .HasColumnName("natureofthetask")
                    .HasMaxLength(50);

                entity.Property(e => e.Periodofexecution)
                    .HasColumnName("periodofexecution")
                    .HasColumnType("date");

                entity.Property(e => e.Taskcomplexity).HasColumnName("taskcomplexity");

                entity.Property(e => e.Taskname)
                    .IsRequired()
                    .HasColumnName("taskname")
                    .HasMaxLength(50);

                entity.Property(e => e.Taskperformer)
                    .HasColumnName("taskperformer")
                    .HasMaxLength(50);

                entity.Property(e => e.Taskstatus)
                    .IsRequired()
                    .HasColumnName("taskstatus")
                    .HasMaxLength(20);

                entity.Property(e => e.Timetocompletethetask).HasColumnName("timetocompletethetask");

                entity.HasOne(d => d.TaskperformerNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Taskperformer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("task_taskperformer_fkey");
            });

            modelBuilder.Entity<Useraccount>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("useraccount_pkey");

                entity.ToTable("useraccount");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Accountstatus).HasColumnName("accountstatus");

                entity.Property(e => e.Datetimeauthorized).HasColumnName("datetimeauthorized");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
