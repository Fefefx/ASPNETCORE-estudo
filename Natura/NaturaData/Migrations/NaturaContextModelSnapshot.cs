﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NaturaData;

namespace NaturaData.Migrations
{
    [DbContext(typeof(NaturaContext))]
    partial class NaturaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NaturaDomain.Model.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("NaturaDomain.Model.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Categoryid");

                    b.Property<int>("amount");

                    b.Property<string>("name");

                    b.Property<int>("size");

                    b.Property<int>("unity");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("NaturaDomain.Model.Product", b =>
                {
                    b.HasOne("NaturaDomain.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid");
                });
#pragma warning restore 612, 618
        }
    }
}