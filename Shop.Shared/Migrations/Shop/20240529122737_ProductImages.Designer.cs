﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Shared.Data;

#nullable disable

namespace Shop.Shared.Migrations.Shop
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20240529122737_ProductImages")]
    partial class ProductImages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Shared.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shop.Shared.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Shop.Shared.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Shop.Shared.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                            Name = "Glossier - Beauty Kit",
                            Price = 100m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "A kit provided by Curology, containing skin care products",
                            Name = "Curology - Skin Care Kit",
                            Price = 50m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "A kit provided by Curology, containing skin care products",
                            Name = "Cocooil - Organic Coconut Oil",
                            Price = 20m,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
                            Name = "Schwarzkopf - Hair Care and Skin Care Kit",
                            Price = 50m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Skin Care Kit, containing skin care and hair care products",
                            Name = "Skin Care Kit",
                            Price = 30m,
                            Quantity = 85
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Air Pods - in-ear wireless headphones",
                            Name = "Air Pods",
                            Price = 100m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "On-ear Golden Headphones - these headphones are not wireless",
                            Name = "On-ear Golden Headphones",
                            Price = 40m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "On-ear Black Headphones - these headphones are not wireless",
                            Name = "On-ear Black Headphones",
                            Price = 40m,
                            Quantity = 300
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
                            Name = "Sennheiser Digital Camera with Tripod",
                            Price = 600m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "Canon Digital Camera - High quality digital camera provided by Canon",
                            Name = "Canon Digital Camera",
                            Price = 500m,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "Gameboy - Provided by Nintendo",
                            Name = "Nintendo Gameboy",
                            Price = 100m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            Description = "Very comfortable black leather office chair",
                            Name = "Black Leather Office Chair",
                            Price = 50m,
                            Quantity = 212
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 2,
                            Description = "Very comfortable pink leather office chair",
                            Name = "Pink Leather Office Chair",
                            Price = 50m,
                            Quantity = 112
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Description = "Very comfortable lounge chair",
                            Name = "Lounge Chair",
                            Price = 70m,
                            Quantity = 90
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            Description = "Very comfortable Silver lounge chair",
                            Name = "Silver Lounge Chair",
                            Price = 120m,
                            Quantity = 95
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            Description = "White and blue Porcelain Table Lamp",
                            Name = "Porcelain Table Lamp",
                            Price = 15m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 2,
                            Description = "Office Table Lamp",
                            Name = "Office Table Lamp",
                            Price = 20m,
                            Quantity = 73
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Description = "Comfortable Puma Sneakers in most sizes",
                            Name = "Puma Sneakers",
                            Price = 100m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Description = "Colorful trainsers - available in most sizes",
                            Name = "Colorful Trainers",
                            Price = 150m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "Blue Nike Trainers - available in most sizes",
                            Name = "Blue Nike Trainers",
                            Price = 200m,
                            Quantity = 70
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 4,
                            Description = "Colorful Hummel Trainers - available in most sizes",
                            Name = "Colorful Hummel Trainers",
                            Price = 120m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 4,
                            Description = "Red Nike Trainers - available in most sizes",
                            Name = "Red Nike Trainers",
                            Price = 200m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 4,
                            Description = "Birkenstock Sandles - available in most sizes",
                            Name = "Birkenstock Sandles",
                            Price = 50m,
                            Quantity = 150
                        });
                });

            modelBuilder.Entity("Shop.Shared.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Beauty"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Furniture"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shoes"
                        });
                });

            modelBuilder.Entity("Shop.Shared.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ContentMD5")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("StorageContainers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Image1.png",
                            ProductId = 1,
                            StorageContainers = "[0]"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Image2.png",
                            ProductId = 2,
                            StorageContainers = "[0]"
                        });
                });

            modelBuilder.Entity("Shop.Shared.Entities.Product", b =>
                {
                    b.HasOne("Shop.Shared.Entities.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Shared.Entities.ProductImage", b =>
                {
                    b.HasOne("Shop.Shared.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Shared.Entities.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
