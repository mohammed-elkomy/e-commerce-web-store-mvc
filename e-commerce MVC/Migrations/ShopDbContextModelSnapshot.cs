﻿// <auto-generated />
using ECommerce.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ECommerce.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce.Models.Database.Ads", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("AppearedCount")
                        .HasColumnName("appeared_count");

                    b.Property<byte[]>("Enabled")
                        .IsRequired()
                        .HasColumnName("enabled")
                        .HasMaxLength(1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnName("image")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ads");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("ParentId")
                        .HasColumnName("parent_id");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("ECommerce.Models.Database.ItemTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("TagId")
                        .HasColumnName("tag_id");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("ProductId", "TagId")
                        .IsUnique()
                        .HasName("UNIQUE_IDS");

                    b.ToTable("itemTag");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnName("message")
                        .HasColumnType("text");

                    b.Property<bool>("Read")
                        .HasColumnName("read");

                    b.Property<string>("SenderEmail")
                        .IsRequired()
                        .HasColumnName("sender_email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnName("sender_name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnName("subject")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Category")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Image1")
                        .HasColumnName("image1")
                        .IsUnicode(false);

                    b.Property<string>("Image2")
                        .HasColumnName("image2")
                        .IsUnicode(false);

                    b.Property<string>("Image3")
                        .HasColumnName("image3")
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("OnSale")
                        .HasColumnName("on_sale")
                        .HasColumnType("binary(1)");

                    b.Property<double>("Price")
                        .HasColumnName("price");

                    b.Property<double?>("SaleInfo")
                        .HasColumnName("sale_info");

                    b.Property<int>("SoldCount")
                        .HasColumnName("sold_count");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<byte[]>("Arrived")
                        .IsRequired()
                        .HasColumnName("arrived")
                        .HasColumnType("binary(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("sales");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("ECommerce.Models.Database.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .IsUnicode(false);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<bool>("NewsSubscription");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Visacard");

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Categories", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Categories", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_categories_categories");
                });

            modelBuilder.Entity("ECommerce.Models.Database.ItemTag", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Products", "Product")
                        .WithMany("ItemTag")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_itemTag_products");

                    b.HasOne("ECommerce.Models.Database.Tags", "Tag")
                        .WithMany("ItemTag")
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_itemTag_tags");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Products", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Categories", "CategoryNavigation")
                        .WithMany("Products")
                        .HasForeignKey("Category")
                        .HasConstraintName("FK_products_categories");
                });

            modelBuilder.Entity("ECommerce.Models.Database.Sales", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Products", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_sales_products");

                    b.HasOne("ECommerce.Models.Database.Users", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_sales_users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ECommerce.Models.Database.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ECommerce.Models.Database.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Models.Database.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ECommerce.Models.Database.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
