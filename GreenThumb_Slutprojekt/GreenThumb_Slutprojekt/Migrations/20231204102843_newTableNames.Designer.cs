﻿// <auto-generated />
using GreenThumb_Slutprojekt.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb_Slutprojekt.Migrations
{
    [DbContext(typeof(GreenThumbDbContext))]
    [Migration("20231204102843_newTableNames")]
    partial class newTableNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GardenModelPlantModel", b =>
                {
                    b.Property<int>("GardensId")
                        .HasColumnType("int");

                    b.Property<int>("PlantsPlantId")
                        .HasColumnType("int");

                    b.HasKey("GardensId", "PlantsPlantId");

                    b.HasIndex("PlantsPlantId");

                    b.ToTable("GardenModelPlantModel");
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.GardenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.InstructionModel", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"), 1L, 1);

                    b.Property<string>("CareDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("care_description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.HasKey("InstructionId");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.PlantModel", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("PlantId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("GardenId")
                        .HasColumnType("int")
                        .HasColumnName("garden_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.HasIndex("GardenId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GardenModelPlantModel", b =>
                {
                    b.HasOne("GreenThumb_Slutprojekt.Models.GardenModel", null)
                        .WithMany()
                        .HasForeignKey("GardensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenThumb_Slutprojekt.Models.PlantModel", null)
                        .WithMany()
                        .HasForeignKey("PlantsPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.InstructionModel", b =>
                {
                    b.HasOne("GreenThumb_Slutprojekt.Models.PlantModel", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.UserModel", b =>
                {
                    b.HasOne("GreenThumb_Slutprojekt.Models.GardenModel", "Garden")
                        .WithOne("UserModel")
                        .HasForeignKey("GreenThumb_Slutprojekt.Models.UserModel", "GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.GardenModel", b =>
                {
                    b.Navigation("UserModel")
                        .IsRequired();
                });

            modelBuilder.Entity("GreenThumb_Slutprojekt.Models.PlantModel", b =>
                {
                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}
