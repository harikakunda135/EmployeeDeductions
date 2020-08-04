using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeDeductions.Models
{
    public partial class EmployeeDetailsContext : DbContext
    {
        public EmployeeDetailsContext()
        {
        }

        public EmployeeDetailsContext(DbContextOptions<EmployeeDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<TypeDiscountRules> TypeDiscountRules { get; set; }
        public virtual DbSet<TypePayrollDetails> TypePayrollDetails { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.employee_number)
                    .HasName("EmployeeDetails_pk");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.dependent1_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dependent2_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dependent3_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dependent4_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dependent5_name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.employee_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.paycheck_deductions).HasColumnType("money");

                entity.Property(e => e.paycheck_salary).HasColumnType("money");
            });

            modelBuilder.Entity<TypeDiscountRules>(entity =>
            {
                entity.HasKey(e => e.discount_type_id)
                    .HasName("TypeDiscountRules_pk");

                entity.Property(e => e.discount).HasColumnType("numeric(4, 4)");

                entity.Property(e => e.discount_description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.discount_rule)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePayrollDetails>(entity =>
            {
                entity.HasKey(e => e.payroll_type_id)
                    .HasName("TypePayrollDetails_pk");

                entity.Property(e => e.dependent_yearly_deductions).HasColumnType("money");

                entity.Property(e => e.employee_category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.employee_yearly_deductions).HasColumnType("money");

                entity.Property(e => e.salary_per_paycheck).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

