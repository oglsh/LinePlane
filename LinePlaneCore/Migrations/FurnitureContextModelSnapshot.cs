﻿// <auto-generated />
using LinePlaneCore.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LinePlaneCore.Migrations
{
    [DbContext(typeof(FurnitureContext))]
    partial class FurnitureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LinePlaneCore.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_IdMeasurements")
                        .HasColumnType("int");

                    b.Property<string>("_Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_IdMeasurements");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("LinePlaneCore.Measurements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("_Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Width")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Measurments");
                });

            modelBuilder.Entity("LinePlaneCore.Room", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_IdTipeFurniture")
                        .HasColumnType("int");

                    b.Property<string>("_NameRoom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_Id");

                    b.HasIndex("_IdTipeFurniture");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("LinePlaneCore.TipeFurniture", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FurnitureTipeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_IdFurniture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_Id");

                    b.ToTable("TipeFurnitures");
                });

            modelBuilder.Entity("LinePlaneCore.Furniture", b =>
                {
                    b.HasOne("LinePlaneCore.Measurements", "_Measurements")
                        .WithMany()
                        .HasForeignKey("_IdMeasurements")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_Measurements");
                });

            modelBuilder.Entity("LinePlaneCore.Room", b =>
                {
                    b.HasOne("LinePlaneCore.TipeFurniture", "_TipeFurniture")
                        .WithMany()
                        .HasForeignKey("_IdTipeFurniture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_TipeFurniture");
                });
#pragma warning restore 612, 618
        }
    }
}
