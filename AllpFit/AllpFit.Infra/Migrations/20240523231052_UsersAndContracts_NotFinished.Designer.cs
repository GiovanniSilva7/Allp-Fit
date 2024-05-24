﻿// <auto-generated />
using System;
using AllpFit.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllpFit.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240523231052_UsersAndContracts_NotFinished")]
    partial class UsersAndContracts_NotFinished
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AllpFit.Library.Entities.Contract", b =>
                {
                    b.Property<Guid>("IdContract")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("IdContractType")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("IdStatus")
                        .HasColumnType("tinyint unsigned");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdContract");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("contracts", "users");
                });

            modelBuilder.Entity("AllpFit.Library.Entities.User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<byte>("IdStatus")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdUser");

                    b.ToTable("users", "users");
                });

            modelBuilder.Entity("AllpFit.Library.Entities.Contract", b =>
                {
                    b.HasOne("AllpFit.Library.Entities.User", "User")
                        .WithOne("Contract")
                        .HasForeignKey("AllpFit.Library.Entities.Contract", "IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_contracts_users_IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllpFit.Library.Entities.User", b =>
                {
                    b.Navigation("Contract")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
