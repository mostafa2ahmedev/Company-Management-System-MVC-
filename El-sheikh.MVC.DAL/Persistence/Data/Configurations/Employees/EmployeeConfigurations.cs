using El_sheikh.MVC.DAL.Common.Enums;
using El_sheikh.MVC.DAL.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Data.Configurations.Employees
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(E => E.Email).HasColumnType("varchar(50)");
            builder.Property(E => E.PhoneNumber).HasColumnType("varchar(20)");
            builder.Property(e => e.Gender).HasConversion(
              gender => gender.ToString(),
              gender => (Gender) Enum.Parse(typeof(Gender), gender))
                .HasColumnType("varchar(20)");

            builder.Property(E => E.EmployeeType).HasConversion(
                EmpType => EmpType.ToString(),
                EmpType => (EmployeeType)Enum.Parse(typeof(EmployeeType), EmpType))
                .HasColumnType("varchar(20)");

            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETUTCDATE()");


        }
    }
}
