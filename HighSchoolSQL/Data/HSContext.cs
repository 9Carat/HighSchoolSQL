using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HighSchoolSQL.Models;

namespace HighSchoolSQL.Data
{
    public partial class HSContext : DbContext
    {
        public HSContext()
        {
        }

        public HSContext(DbContextOptions<HSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvgMinMaxGrade> AvgMinMaxGrades { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; } = null!;
        public virtual DbSet<LastMonthsGrade> LastMonthsGrades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-OTLQCEKC; Initial Catalog=HighSchool; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvgMinMaxGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("avg_min_max_grade");

                entity.Property(e => e.AverageGrade).HasColumnName("average_grade");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.MaxGrade).HasColumnName("max_grade");

                entity.Property(e => e.MinGrade).HasColumnName("min_grade");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.FkStudId).HasColumnName("FK_stud_id");

                entity.Property(e => e.FkTeacherId).HasColumnName("FK_teacher_id");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.GradeDate)
                    .HasColumnType("date")
                    .HasColumnName("grade_date");

                entity.HasOne(d => d.FkStud)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FkStudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stud_id_REF_stud_id");

                entity.HasOne(d => d.FkTeacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FkTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_teacher_id-REF-staff_id");
            });

            modelBuilder.Entity<CourseTeacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CourseTeacher");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<LastMonthsGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("last_months_grades");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.GradeDate)
                    .HasColumnType("date")
                    .HasColumnName("grade_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudId);

                entity.ToTable("Student");

                entity.Property(e => e.StudId).HasColumnName("stud_id");

                entity.Property(e => e.Class)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.PersonalNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("personal_number");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.EmploymentStartDate)
                    .HasColumnType("date")
                    .HasColumnName("employment_start_date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.StaffRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("staff_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
