using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using binary_transaction_in_asp.net_mvc_core.Models;

#nullable disable

namespace binary_transaction_in_asp.net_mvc_core.Models
{
    public partial class dbsContext : DbContext
    {
        public dbsContext()
        {
        }

        public dbsContext(DbContextOptions<dbsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=dbs;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AFB3EC0D6C623A8E");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("empName");

                entity.Property(e => e.EmpSalary)
                    .HasMaxLength(47)
                    .IsUnicode(false)
                    .HasColumnName("empSalary");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.StudentCity)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("studentCity");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("studentName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<binary_transaction_in_asp.net_mvc_core.Models.College> College { get; set; }
    }
}
