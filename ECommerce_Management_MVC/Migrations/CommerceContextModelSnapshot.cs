﻿// <auto-generated />
using System;
using ECommerce_Management_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce_Management_MVC.Migrations
{
    [DbContext(typeof(CommerceContext))]
    partial class CommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biling_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("default_shipping_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetailss");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Order_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shipping_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.product_category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("category_id")
                        .HasColumnType("int");

                    b.Property<int?>("product_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("category_id");

                    b.HasIndex("product_id");

                    b.ToTable("Product_Categories");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.OrderDetail", b =>
                {
                    b.HasOne("ECommerce_Management_MVC.Models.Orders", "Order")
                        .WithMany("orderDetails")
                        .HasForeignKey("OrderId");

                    b.HasOne("ECommerce_Management_MVC.Models.Product", "Products")
                        .WithMany("orderDetails")
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Orders", b =>
                {
                    b.HasOne("ECommerce_Management_MVC.Models.Customers", "customer")
                        .WithMany("Order")
                        .HasForeignKey("Customer_Id");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.product_category", b =>
                {
                    b.HasOne("ECommerce_Management_MVC.Models.category", "categories")
                        .WithMany("product_Categories")
                        .HasForeignKey("category_id");

                    b.HasOne("ECommerce_Management_MVC.Models.Product", "products")
                        .WithMany("productCategories")
                        .HasForeignKey("product_id");

                    b.Navigation("categories");

                    b.Navigation("products");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Customers", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Orders", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.Product", b =>
                {
                    b.Navigation("orderDetails");

                    b.Navigation("productCategories");
                });

            modelBuilder.Entity("ECommerce_Management_MVC.Models.category", b =>
                {
                    b.Navigation("product_Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
