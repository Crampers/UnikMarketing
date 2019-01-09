﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnikMarketing.Domain;

namespace UnikMarketing.Data.EntityFramework.Migrations
{
    [DbContext(typeof(MarketingContext))]
    partial class MarketingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnikMarketing.Domain.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FloorId");

                    b.Property<int?>("PriceId");

                    b.Property<int?>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("PriceId");

                    b.HasIndex("SizeId");

                    b.ToTable("Criteria");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CriteriaId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CriteriaId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Range<decimal>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Range<decimal>");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Range<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Range<int>");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Note");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("UnikMarketing.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("CriteriaId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("CriteriaId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Criteria", b =>
                {
                    b.HasOne("UnikMarketing.Domain.Range<int>", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId");

                    b.HasOne("UnikMarketing.Domain.Range<decimal>", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId");

                    b.HasOne("UnikMarketing.Domain.Range<decimal>", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Location", b =>
                {
                    b.HasOne("UnikMarketing.Domain.Criteria")
                        .WithMany("Locations")
                        .HasForeignKey("CriteriaId");
                });

            modelBuilder.Entity("UnikMarketing.Domain.Request", b =>
                {
                    b.HasOne("UnikMarketing.Domain.User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UnikMarketing.Domain.User", b =>
                {
                    b.HasOne("UnikMarketing.Domain.Criteria", "Criteria")
                        .WithMany()
                        .HasForeignKey("CriteriaId");
                });
#pragma warning restore 612, 618
        }
    }
}
