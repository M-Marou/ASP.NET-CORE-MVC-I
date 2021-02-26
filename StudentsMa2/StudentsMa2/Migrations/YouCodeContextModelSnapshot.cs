﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentsMa2.Data;

namespace StudentsMa2.Migrations
{
    [DbContext(typeof(YouCodeContext))]
    partial class YouCodeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentsMa2.Models.YouCode.ClassModel", b =>
                {
                    b.Property<string>("className")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("className");

                    b.ToTable("StudentClass");
                });

            modelBuilder.Entity("StudentsMa2.Models.YouCode.StudentModel", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("className")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentCIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentClassclassName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentID");

                    b.HasIndex("studentClassclassName");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentsMa2.Models.YouCode.StudentModel", b =>
                {
                    b.HasOne("StudentsMa2.Models.YouCode.ClassModel", "studentClass")
                        .WithMany("Students")
                        .HasForeignKey("studentClassclassName");

                    b.Navigation("studentClass");
                });

            modelBuilder.Entity("StudentsMa2.Models.YouCode.ClassModel", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}