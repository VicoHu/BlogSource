using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCoreWebAPI.Models
{
    public partial class StudentManangeSystemContext : DbContext
    {
        public StudentManangeSystemContext()
        {
        }

        public StudentManangeSystemContext(DbContextOptions<StudentManangeSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<StudentDetail> StudentDetail { get; set; }
        public virtual DbSet<TeacherDetail> TeacherDetail { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=StudentManangeSystem;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("permission");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("student_detail");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("img_url");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(11);

                entity.Property(e => e.TeacherUserId).HasColumnName("teacher_user_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentDetail)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_detail_class");

                entity.HasOne(d => d.TeacherUser)
                    .WithMany(p => p.StudentDetail)
                    .HasForeignKey(d => d.TeacherUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_detail_teacher_detail");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.StudentDetail)
                    .HasForeignKey<StudentDetail>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_detail_student_detail");
            });

            modelBuilder.Entity<TeacherDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("teacher_detail");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(11);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.TeacherDetail)
                    .HasForeignKey<TeacherDetail>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_teacher_detail_teacher_detail");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsEnable).HasColumnName("isEnable");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20);

                entity.Property(e => e.PermissionCode).HasColumnName("permission_code");

                entity.HasOne(d => d.PermissionCodeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PermissionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_permission");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
