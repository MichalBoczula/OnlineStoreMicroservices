﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStoreMicroservices.ShoppingCart.Context;

namespace OnlineStoreMicroservices.ShoppingCart.Migrations
{
    [DbContext(typeof(ShoppingCartDbContext))]
    [Migration("20221008161640_UpdatedModel2")]
    partial class UpdatedModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.BasketProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingBasketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingBasketId");

                    b.ToTable("BasketProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Quantity = 1,
                            ShoppingBasketId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Quantity = 1,
                            ShoppingBasketId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Quantity = 1,
                            ShoppingBasketId = 1
                        });
                });

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.DiscountCoupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntegrationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActual")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DiscountCoupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 10,
                            Code = "ten",
                            IntegrationId = "e0cfebf1-5fa6-49d0-a726-c5c4b2ce3de9",
                            IsActual = true
                        },
                        new
                        {
                            Id = 2,
                            Amount = 20,
                            Code = "twenty",
                            IntegrationId = "3ed3adc6-7416-4d63-9048-9d1b92554c21",
                            IsActual = true
                        },
                        new
                        {
                            Id = 3,
                            Amount = 30,
                            Code = "thirty",
                            IntegrationId = "fd918135-bcf1-4310-8b20-81365ad80862",
                            IsActual = true
                        });
                });

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Boots one",
                            Price = 100m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Boots two",
                            Price = 150m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Boots three",
                            Price = 200m
                        });
                });

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.ShoppingBasket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountCouponId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingBaskets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiscountCouponId = "",
                            Total = 450m
                        });
                });

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.BasketProduct", b =>
                {
                    b.HasOne("OnlineStoreMicroservices.ShoppingCart.Models.Product", "ProductRef")
                        .WithMany("BasketProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStoreMicroservices.ShoppingCart.Models.ShoppingBasket", "ShoppingBasketRef")
                        .WithMany("BasketProducts")
                        .HasForeignKey("ShoppingBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductRef");

                    b.Navigation("ShoppingBasketRef");
                });

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.Product", b =>
                {
                    b.Navigation("BasketProducts");
                });

            modelBuilder.Entity("OnlineStoreMicroservices.ShoppingCart.Models.ShoppingBasket", b =>
                {
                    b.Navigation("BasketProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
