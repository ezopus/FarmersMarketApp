﻿// <auto-generated />
using System;
using FarmersMarketApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241029192637_FarmPropertiesPhoneSetToNullAndOpenClosedChangedToTime")]
    partial class FarmPropertiesPhoneSetToNullAndOpenClosedChangedToTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Physical address of application user.");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("First name of application user.");

                    b.Property<bool>("IsFarmer")
                        .HasColumnType("bit")
                        .HasComment("Flag to show if user is a farmer or not.");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Last name of application user.");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Category name.");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Meat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dairy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Grain"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fats"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fruits"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Vegetables"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sweets"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fish"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Eggs"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Drinks"
                        });
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.CategoryFarmer", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier.");

                    b.Property<Guid>("FarmerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Farmer identifier.");

                    b.HasKey("CategoryId", "FarmerId");

                    b.HasIndex("FarmerId");

                    b.ToTable("CategoriesFarmers");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Farm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of farm");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Physical address of farm.");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("City where farm is located or close to.");

                    b.Property<TimeOnly?>("CloseHours")
                        .HasColumnType("time")
                        .HasComment("Closing hours of farm operations.");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Email address of farm for enquiries.");

                    b.Property<Guid>("FarmerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of farmer who owns current farm.");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit")
                        .HasComment("Flag to check if farm is open for business.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Farm name.");

                    b.Property<TimeOnly?>("OpenHours")
                        .HasColumnType("time")
                        .HasComment("Opening hours of farm operations.");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Phone number of farm visible to general public.");

                    b.HasKey("Id");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique order identifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time on which order is placed.");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique customer identifier");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2")
                        .HasComment("Expected date and time on which order is going to be delivered.");

                    b.Property<decimal?>("TotalDiscount")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Total discount if applicable.");

                    b.Property<double>("TotalNetWeight")
                        .HasColumnType("float")
                        .HasComment("Total net weight of all items in order.");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Total price of order including discounts.");

                    b.Property<int>("TotalUnitItems")
                        .HasColumnType("int")
                        .HasComment("Total number of units of products contained in order.");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique payment identifier.");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique customer identifier.");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit")
                        .HasComment("Flag is payment is successful.");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique order identifier.");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Total payment amount.");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time on which payment is made.");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int")
                        .HasComment("Type of payment method used.");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of each product.");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Unique barcode of product.");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier of product.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Description of product in free text format.");

                    b.Property<decimal?>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Percentage of discount.");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Expiration date of product.");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of farm where product is made.");

                    b.Property<Guid>("FarmerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of farmer who produces current product.");

                    b.Property<bool>("HasDiscount")
                        .HasColumnType("bit")
                        .HasComment("Flag if product has active discount.");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image url of product.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Product name.");

                    b.Property<double>("NetWeight")
                        .HasColumnType("float")
                        .HasComment("Weight of product in kilograms");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Specific origin of product if applicable");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of product for one unit.");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2")
                        .HasComment("Production date of product.");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Amount of products in each unit.");

                    b.Property<int?>("Season")
                        .HasColumnType("int")
                        .HasComment("Specific season for product if applicable");

                    b.Property<double>("ShippingWeight")
                        .HasColumnType("float")
                        .HasComment("Weight of product with container");

                    b.Property<int>("UnitType")
                        .HasColumnType("int")
                        .HasComment("Type of unit which product is distributed in - box, carton, bottle, etc.");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.HasIndex("FarmerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.ProductOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique order identifier.");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique product identifier.");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsOrders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Farmer", b =>
                {
                    b.HasBaseType("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser");

                    b.Property<bool>("AcceptsDeliveries")
                        .HasColumnType("bit")
                        .HasComment("Flag to show if farmer is currently accepting deliveries.");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Company address for billing and shipping purposes.");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Company name of farmer for billing purposes.");

                    b.Property<string>("CompanyRegistrationNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Company registration number for VAT and tax purposes.");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasProducts")
                        .HasColumnType("bit")
                        .HasComment("Flag to show if farmer has any products for sale.");

                    b.HasIndex("FarmId")
                        .IsUnique()
                        .HasFilter("[FarmId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Farmer");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.CategoryFarmer", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("CategoriesFarmers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Farmer", "Farmer")
                        .WithMany("CategoriesFarmers")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Payment", "Payment")
                        .WithOne("Order")
                        .HasForeignKey("FarmersMarketApp.Infrastructure.Data.Models.Order", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Payment", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Farm", "Farm")
                        .WithMany("Products")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Farmer", "Farmer")
                        .WithMany("Products")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.ProductOrder", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Order", "Order")
                        .WithMany("ProductsOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("ProductsOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Farmer", b =>
                {
                    b.HasOne("FarmersMarketApp.Infrastructure.Data.Models.Farm", "Farm")
                        .WithOne("Farmer")
                        .HasForeignKey("FarmersMarketApp.Infrastructure.Data.Models.Farmer", "FarmId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("CategoriesFarmers");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Farm", b =>
                {
                    b.Navigation("Farmer")
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Order", b =>
                {
                    b.Navigation("ProductsOrders");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Payment", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Product", b =>
                {
                    b.Navigation("ProductsOrders");
                });

            modelBuilder.Entity("FarmersMarketApp.Infrastructure.Data.Models.Farmer", b =>
                {
                    b.Navigation("CategoriesFarmers");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
