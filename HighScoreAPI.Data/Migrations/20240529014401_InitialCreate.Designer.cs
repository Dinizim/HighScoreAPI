﻿// <auto-generated />
using HighScoreAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HighScoreAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240529014401_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HighScoreAPI.Domain.Models.Game", b =>
                {
                    b.Property<int>("Game_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Game_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Game_Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HighScoreAPI.Domain.Models.Player", b =>
                {
                    b.Property<int>("Player_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Player_Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Player_Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("HighScoreAPI.Domain.Models.highscore", b =>
                {
                    b.Property<int>("HighScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HighScoreId"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("HighScoreId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("HighScores");
                });

            modelBuilder.Entity("HighScoreAPI.Domain.Models.highscore", b =>
                {
                    b.HasOne("HighScoreAPI.Domain.Models.Game", "Game")
                        .WithMany("HighScores")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighScoreAPI.Domain.Models.Player", "Player")
                        .WithMany("HighScores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HighScoreAPI.Domain.Models.Game", b =>
                {
                    b.Navigation("HighScores");
                });

            modelBuilder.Entity("HighScoreAPI.Domain.Models.Player", b =>
                {
                    b.Navigation("HighScores");
                });
#pragma warning restore 612, 618
        }
    }
}
