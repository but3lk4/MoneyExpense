﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyExpense.Models;

namespace MoneyExpense.Migrations
{
    [DbContext(typeof(ExpenseDBContext))]
    partial class ExpenseDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyExpense.Models.ExpenseReport", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<DateTime>("ExpenseDate");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.HasKey("ItemId");

                    b.ToTable("ExpenseReport");
                });
#pragma warning restore 612, 618
        }
    }
}
