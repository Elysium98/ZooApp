// <auto-generated />
using System;
using Bissoft.Interview.Data;
using Bissoft.Interview.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bissoft.Interview.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220921074309_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Bissoft.Interview.Data.Entities.AnimalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<AType>("AnimalType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Type");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("DateOfBirth");

                    b.HasKey("Id");

                    b.ToTable("Animal");
                });
#pragma warning restore 612, 618
        }
    }
}
