﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using casa_do_codigo.Models;

namespace casadocodigo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20171114121159_addEntityOrderUser")]
    partial class addEntityOrderUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("casa_do_codigo.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.Property<int?>("orderUserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("orderUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("casa_do_codigo.Models.OrderUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("OrdersUsers");
                });

            modelBuilder.Entity("casa_do_codigo.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("casa_do_codigo.Models.Order", b =>
                {
                    b.HasOne("casa_do_codigo.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");

                    b.HasOne("casa_do_codigo.Models.OrderUser", "orderUser")
                        .WithMany("Orders")
                        .HasForeignKey("orderUserId");
                });
        }
    }
}
