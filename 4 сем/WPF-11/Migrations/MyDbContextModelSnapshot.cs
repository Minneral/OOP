﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPF_11.Core;

#nullable disable

namespace WPF_11.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WPF_11.MVVM.Model.Student", b =>
                {
                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId1")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.HasIndex("SubjectId");

                    b.HasIndex("SubjectId1");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WPF_11.MVVM.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WPF_11.MVVM.Model.SubjectStudent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SubjectStudents");
                });

            modelBuilder.Entity("WPF_11.MVVM.Model.Student", b =>
                {
                    b.HasOne("WPF_11.MVVM.Model.Subject", null)
                        .WithMany("Listeners")
                        .HasForeignKey("SubjectId");

                    b.HasOne("WPF_11.MVVM.Model.Subject", null)
                        .WithMany("Students")
                        .HasForeignKey("SubjectId1");
                });

            modelBuilder.Entity("WPF_11.MVVM.Model.Subject", b =>
                {
                    b.Navigation("Listeners");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
