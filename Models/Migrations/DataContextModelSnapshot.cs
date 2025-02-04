﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_reference.Seed.Data;

#nullable disable

namespace net_reference.Models.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("net_reference.Seed.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameNId")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("cast([Id] as varchar(5)) + ' ' + [Name]");

                    b.Property<string>("NameNTeamId")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("cast([TeamId] as varchar(5)) + ' ' + [Name]");

                    b.Property<int>("PlayerPositionId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerPositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Player");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Vinicius JR",
                            PlayerPositionId = 1,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Pedri",
                            PlayerPositionId = 2,
                            TeamId = 2
                        });
                });

            modelBuilder.Entity("net_reference.Seed.Models.PlayerPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("PlayerPositions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "",
                            Name = "Left Wing"
                        },
                        new
                        {
                            Id = 2,
                            Details = "",
                            Name = "Striker"
                        });
                });

            modelBuilder.Entity("net_reference.Seed.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("MarketValue")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("RivalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RivalId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "El mejor equipo del mundo",
                            MarketValue = 100000,
                            Name = "Real Madrid"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Podría ser mejor",
                            MarketValue = 100,
                            Name = "Barcelona",
                            RivalId = 1
                        });
                });

            modelBuilder.Entity("net_reference.Models.Players", b =>
                {
                    b.HasBaseType("net_reference.Seed.Models.Player");

                    b.HasDiscriminator().HasValue("Players");
                });

            modelBuilder.Entity("net_reference.Seed.Models.Player", b =>
                {
                    b.HasOne("net_reference.Seed.Models.PlayerPosition", "PlayerPosition")
                        .WithMany()
                        .HasForeignKey("PlayerPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("net_reference.Seed.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerPosition");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("net_reference.Seed.Models.Team", b =>
                {
                    b.HasOne("net_reference.Seed.Models.Team", "Rival")
                        .WithMany()
                        .HasForeignKey("RivalId");

                    b.Navigation("Rival");
                });
#pragma warning restore 612, 618
        }
    }
}
