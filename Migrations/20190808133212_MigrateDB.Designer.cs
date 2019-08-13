﻿// <auto-generated />
using EFDataApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDataApp.Migrations
{
    [DbContext(typeof(MobileContext))]
    [Migration("20190808133212_MigrateDB")]
    partial class MigrateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDataApp.Models.Student", b =>
                {
                    b.Property<int>("Id_student")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Imie");

                    b.Property<string>("Kod_pocztowy");

                    b.Property<string>("Miejscowosc");

                    b.Property<string>("Nazwisko");

                    b.Property<string>("Password");

                    b.Property<string>("Ulica");

                    b.HasKey("Id_student");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFDataApp.Models.Student_Oceny", b =>
                {
                    b.Property<int>("Id_oceny")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_student");

                    b.Property<int>("Ocena");

                    b.Property<string>("Ocena_slownie");

                    b.HasKey("Id_oceny");

                    b.HasIndex("Id_student");

                    b.ToTable("Student_Oceny");
                });

            modelBuilder.Entity("EFDataApp.ViewModels.RegisterModel", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Email");

                    b.ToTable("RegisterModel");
                });

            modelBuilder.Entity("EFDataApp.Models.Student_Oceny", b =>
                {
                    b.HasOne("EFDataApp.Models.Student", "Student")
                        .WithMany("Student_Oceny")
                        .HasForeignKey("Id_student")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
