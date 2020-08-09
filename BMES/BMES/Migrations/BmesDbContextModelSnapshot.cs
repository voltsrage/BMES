﻿// <auto-generated />
using System;
using BMES.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BMES.Migrations
{
    [DbContext(typeof(BmesDbContext))]
    partial class BmesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BMES.Models.Address.AddressModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<long?>("CustomerModelId");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CustomerModelId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BMES.Models.Cart.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartStatus");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("UniqueCartId");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BMES.Models.Cart.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CartId");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<long>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BMES.Models.Customer.CustomerModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<long>("PersonId");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BMES.Models.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddressId");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<long>("CustomerId");

                    b.Property<long?>("DeliveryAddressId");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<decimal>("OrderItemTotal");

                    b.Property<int>("OrderStatus");

                    b.Property<decimal>("OrderTotal");

                    b.Property<decimal>("ShippingCharge");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BMES.Models.Orders.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<long>("OrderId");

                    b.Property<long>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BMES.Models.Products.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandStatus");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Meta_description");

                    b.Property<string>("Meta_keywords");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("BMES.Models.Products.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryStatus");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Meta_description");

                    b.Property<string>("Meta_keywords");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BMES.Models.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BrandId");

                    b.Property<long>("CategoryId");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("Image_url");

                    b.Property<bool>("Is_bestseller");

                    b.Property<bool>("Is_featured");

                    b.Property<string>("Meta_description");

                    b.Property<string>("Meta_keywords");

                    b.Property<string>("Model");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("Old_price");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductStatus");

                    b.Property<int>("QuantityInStock");

                    b.Property<decimal>("Sale_price");

                    b.Property<string>("Sku");

                    b.Property<string>("Slug");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BMES.Models.Shared.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("BMES.Models.Address.AddressModel", b =>
                {
                    b.HasOne("BMES.Models.Customer.CustomerModel")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerModelId");
                });

            modelBuilder.Entity("BMES.Models.Cart.CartItem", b =>
                {
                    b.HasOne("BMES.Models.Cart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BMES.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BMES.Models.Customer.CustomerModel", b =>
                {
                    b.HasOne("BMES.Models.Shared.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BMES.Models.Orders.Order", b =>
                {
                    b.HasOne("BMES.Models.Customer.CustomerModel", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BMES.Models.Address.AddressModel", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId");
                });

            modelBuilder.Entity("BMES.Models.Orders.OrderItem", b =>
                {
                    b.HasOne("BMES.Models.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BMES.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BMES.Models.Products.Product", b =>
                {
                    b.HasOne("BMES.Models.Products.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BMES.Models.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
