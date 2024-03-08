﻿// <auto-generated />
using Dependancy_Injection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dependancy_Injection.Migrations
{
    [DbContext(typeof(DBContextClass))]
    partial class DBContextClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dependancy_Injection.Model.Country", b =>
                {
                    b.Property<int>("t01f01")
                        .HasColumnType("int");

                    b.Property<string>("t01f02")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("t01f03")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("country");
                });
#pragma warning restore 612, 618
        }
    }
}
