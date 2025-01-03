﻿// <auto-generated />
using System;
using GameBib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameBib.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241208120024_GiveUserRole")]
    partial class GiveUserRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GameBib.Data.Classes.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<float>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Journey above the clouds.",
                            Name = "Sky Quest",
                            Rating = 4.5f,
                            ReleaseDate = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Explore a mystical forest.",
                            Name = "Mystic Forest",
                            Rating = 4.3f,
                            ReleaseDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Space exploration game.",
                            Name = "Galactic Adventure",
                            Rating = 4.7f,
                            ReleaseDate = new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Description = "Deep dive into dungeons.",
                            Name = "Dungeon Crawl",
                            Rating = 4f,
                            ReleaseDate = new DateTime(2020, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Description = "Epic fantasy MMORPG.",
                            Name = "World of Warcraft",
                            Rating = 4.8f,
                            ReleaseDate = new DateTime(2004, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Description = "Fantasy RPG with dragons.",
                            Name = "The Elder Scrolls V: Skyrim",
                            Rating = 4.9f,
                            ReleaseDate = new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Description = "Open-world adventure.",
                            Name = "Zelda: Breath of the Wild",
                            Rating = 4.9f,
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Description = "Ancient mysteries await.",
                            Name = "Mystic Ruins",
                            Rating = 4.2f,
                            ReleaseDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Description = "Underwater exploration.",
                            Name = "Ocean Explorer",
                            Rating = 4f,
                            ReleaseDate = new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Description = "Build and manage a city.",
                            Name = "City Builder",
                            Rating = 4.3f,
                            ReleaseDate = new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            Description = "Strategic space battles.",
                            Name = "Space Commander",
                            Rating = 4.1f,
                            ReleaseDate = new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            Description = "Manage your farm.",
                            Name = "Farm Life",
                            Rating = 4.4f,
                            ReleaseDate = new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            Description = "Challenging puzzle game.",
                            Name = "Puzzle Quest",
                            Rating = 4.2f,
                            ReleaseDate = new DateTime(2021, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            Description = "Survive in the desert.",
                            Name = "Desert Survival",
                            Rating = 3.8f,
                            ReleaseDate = new DateTime(2018, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            Description = "Defend the castle.",
                            Name = "Castle Defender",
                            Rating = 4f,
                            ReleaseDate = new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 16,
                            Description = "Adventure in the jungle.",
                            Name = "Jungle Hunt",
                            Rating = 3.9f,
                            ReleaseDate = new DateTime(2017, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 17,
                            Description = "Protect the galaxy.",
                            Name = "Galaxy Rangers",
                            Rating = 4.5f,
                            ReleaseDate = new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 18,
                            Description = "Futuristic city RPG.",
                            Name = "Cyber City",
                            Rating = 4.1f,
                            ReleaseDate = new DateTime(2019, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 19,
                            Description = "Conquer the peaks.",
                            Name = "Mountain Climber",
                            Rating = 3.8f,
                            ReleaseDate = new DateTime(2021, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 20,
                            Description = "Sail the seas as a pirate.",
                            Name = "Pirate Seas",
                            Rating = 4.2f,
                            ReleaseDate = new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 21,
                            Description = "Explore a haunted mansion.",
                            Name = "Haunted Mansion",
                            Rating = 3.7f,
                            ReleaseDate = new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 22,
                            Description = "Survive on a deserted island.",
                            Name = "Island Escape",
                            Rating = 4.3f,
                            ReleaseDate = new DateTime(2018, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 23,
                            Description = "Intense PvP battles.",
                            Name = "Battle Arena",
                            Rating = 4.2f,
                            ReleaseDate = new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 24,
                            Description = "Journey through space.",
                            Name = "Space Odyssey",
                            Rating = 4.6f,
                            ReleaseDate = new DateTime(2017, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 25,
                            Description = "Strategy game set in medieval times.",
                            Name = "Medieval Conquest",
                            Rating = 4f,
                            ReleaseDate = new DateTime(2019, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 26,
                            Description = "Lead a robot rebellion.",
                            Name = "Robot Revolution",
                            Rating = 4.1f,
                            ReleaseDate = new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 27,
                            Description = "Adventure with dragons.",
                            Name = "Dragon Kingdom",
                            Rating = 4.7f,
                            ReleaseDate = new DateTime(2018, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 28,
                            Description = "Embark on a Viking adventure.",
                            Name = "Viking Quest",
                            Rating = 4.5f,
                            ReleaseDate = new DateTime(2017, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 29,
                            Description = "Defend Earth from aliens.",
                            Name = "Alien Invasion",
                            Rating = 3.9f,
                            ReleaseDate = new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 30,
                            Description = "Command your empire to victory.",
                            Name = "War of Empires",
                            Rating = 4.6f,
                            ReleaseDate = new DateTime(2020, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GameBib.Data.Classes.GameGenre", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GameGenre");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 1,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 4
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 5,
                            GenreId = 7
                        },
                        new
                        {
                            GameId = 5,
                            GenreId = 8
                        },
                        new
                        {
                            GameId = 6,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 6,
                            GenreId = 8
                        },
                        new
                        {
                            GameId = 7,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 8,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 9,
                            GenreId = 6
                        },
                        new
                        {
                            GameId = 10,
                            GenreId = 4
                        },
                        new
                        {
                            GameId = 11,
                            GenreId = 4
                        },
                        new
                        {
                            GameId = 12,
                            GenreId = 6
                        },
                        new
                        {
                            GameId = 13,
                            GenreId = 5
                        },
                        new
                        {
                            GameId = 14,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 15,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 16,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 17,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 17,
                            GenreId = 4
                        },
                        new
                        {
                            GameId = 29,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 18,
                            GenreId = 4
                        },
                        new
                        {
                            GameId = 27,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 21,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 22,
                            GenreId = 6
                        },
                        new
                        {
                            GameId = 25,
                            GenreId = 7
                        },
                        new
                        {
                            GameId = 19,
                            GenreId = 5
                        },
                        new
                        {
                            GameId = 20,
                            GenreId = 8
                        },
                        new
                        {
                            GameId = 26,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 24,
                            GenreId = 7
                        },
                        new
                        {
                            GameId = 28,
                            GenreId = 8
                        },
                        new
                        {
                            GameId = 30,
                            GenreId = 4
                        },
                        new
                        {
                            GameId = 23,
                            GenreId = 1
                        });
                });

            modelBuilder.Entity("GameBib.Data.Classes.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 7,
                            Name = "MMORPG"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("GameBib.Data.Classes.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastFailedLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("RememberToken")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FailedLoginAttempts = 0,
                            HashedPassword = "hTSwo4NvamAXyfyJzmxrogRNH4z6RBSNelE6HLsZaDY=:UX2ct1A+95e0e1iaELmGeQ==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 7, 13, 0, 22, 938, DateTimeKind.Local).AddTicks(4249),
                            Name = "Michel",
                            RememberToken = "cs8QBLk4QN",
                            UserName = "Miesvors"
                        },
                        new
                        {
                            Id = 2,
                            FailedLoginAttempts = 1,
                            HashedPassword = "p5vYtDRj/lPy4zlKXg9yHDj6PLTa+izdcG1JNR3DoK0=:3uQthBdSD+s098hCe9OUIA==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 8, 8, 0, 22, 944, DateTimeKind.Local).AddTicks(2995),
                            Name = "Laura",
                            RememberToken = "PlzMJefXvc",
                            UserName = "LauSky"
                        },
                        new
                        {
                            Id = 3,
                            FailedLoginAttempts = 0,
                            HashedPassword = "EKeBITJ1ii2o20mX5hQW6gdl0lTafQ1CoNztdmVUx4k=:uXvm6ayyGFeWcccF/mNl9Q==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 6, 13, 0, 22, 950, DateTimeKind.Local).AddTicks(5210),
                            Name = "Tom",
                            RememberToken = "eb9SOpiIdg",
                            UserName = "Tomster"
                        },
                        new
                        {
                            Id = 4,
                            FailedLoginAttempts = 2,
                            HashedPassword = "c58ZI8PhF00MpjYLMEfj9p27cbEuDhNrhXC4oS7kRTY=:uTrgerQockpFYv9Oml8QQA==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 8, 12, 30, 22, 956, DateTimeKind.Local).AddTicks(4203),
                            Name = "Emma",
                            RememberToken = "mZrj3jCclM",
                            UserName = "EmStar"
                        },
                        new
                        {
                            Id = 5,
                            FailedLoginAttempts = 0,
                            HashedPassword = "Tx5BqR5S/Icmw7hisgK2yZo0rqNXRO5Htve/LT8yQjo=:4ZK1o0SIVkj4Y8zzX3CLQA==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 8, 3, 0, 22, 962, DateTimeKind.Local).AddTicks(1071),
                            Name = "James",
                            RememberToken = "k2q49OS5ia",
                            UserName = "JimmyBoy"
                        },
                        new
                        {
                            Id = 6,
                            FailedLoginAttempts = 3,
                            HashedPassword = "qyY0OKumyDHDVTpF93cDYuF8NCiYZ4P7S9mI5ir1lt8=:QFzTeJXkGOcft8etdc9aZw==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 5, 13, 0, 22, 967, DateTimeKind.Local).AddTicks(9015),
                            Name = "Sophia",
                            RememberToken = "5KgMHDvES2",
                            UserName = "Sophs"
                        },
                        new
                        {
                            Id = 7,
                            FailedLoginAttempts = 0,
                            HashedPassword = "swAuLMmmByEQo7w1MwNFghSX/u/4Ci7Z5Q6l2H46e1E=:BOLokPD1s5BsQPyxxwhYgQ==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 8, 5, 0, 22, 974, DateTimeKind.Local).AddTicks(1222),
                            Name = "Liam",
                            RememberToken = "VieWlMeOiZ",
                            UserName = "Liamster"
                        },
                        new
                        {
                            Id = 8,
                            FailedLoginAttempts = 1,
                            HashedPassword = "xiPKPwkxed9vAVV/XamfF4wbXocOuZBMN0pGnlKQ7N4=:fk2s7xt4W9+/E8pX+BorXw==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 1, 13, 0, 22, 979, DateTimeKind.Local).AddTicks(8030),
                            Name = "Olivia",
                            RememberToken = "hkHneBDnDs",
                            UserName = "Livvy"
                        },
                        new
                        {
                            Id = 9,
                            FailedLoginAttempts = 0,
                            HashedPassword = "+4Zp/CCtLcgNhj60c2aTQaE2+aay6mcEKRM62mX4Iws=:NE1jy/Km4Q4vLUDpaLg+iQ==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 11, 24, 13, 0, 22, 985, DateTimeKind.Local).AddTicks(5344),
                            Name = "Ethan",
                            RememberToken = "ySDhO7xvwv",
                            UserName = "Ethanator"
                        },
                        new
                        {
                            Id = 10,
                            FailedLoginAttempts = 2,
                            HashedPassword = "tKOVQNfj68BpOuZAZ78NUH8IdWhfiJWaXyjmOUQWspc=:GBtExL/ph39sPAetBIiC0Q==:10000:SHA512",
                            LastFailedLogin = new DateTime(2024, 12, 7, 10, 0, 22, 991, DateTimeKind.Local).AddTicks(2422),
                            Name = "Ava",
                            RememberToken = "JXl9Ts4A2x",
                            UserName = "AvaQueen"
                        });
                });

            modelBuilder.Entity("GameBib.Data.Classes.UserGames", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGames");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            GameId = 1
                        },
                        new
                        {
                            UserId = 2,
                            GameId = 2
                        },
                        new
                        {
                            UserId = 3,
                            GameId = 3
                        },
                        new
                        {
                            UserId = 4,
                            GameId = 4
                        },
                        new
                        {
                            UserId = 5,
                            GameId = 5
                        },
                        new
                        {
                            UserId = 6,
                            GameId = 6
                        },
                        new
                        {
                            UserId = 7,
                            GameId = 7
                        },
                        new
                        {
                            UserId = 8,
                            GameId = 8
                        },
                        new
                        {
                            UserId = 9,
                            GameId = 9
                        },
                        new
                        {
                            UserId = 10,
                            GameId = 10
                        });
                });

            modelBuilder.Entity("GameBib.Data.Classes.GameGenre", b =>
                {
                    b.HasOne("GameBib.Data.Classes.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameBib.Data.Classes.Genre", "Genre")
                        .WithMany("GameGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("GameBib.Data.Classes.UserGames", b =>
                {
                    b.HasOne("GameBib.Data.Classes.Game", "Game")
                        .WithMany("UserGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameBib.Data.Classes.User", "User")
                        .WithMany("UserGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameBib.Data.Classes.Game", b =>
                {
                    b.Navigation("GameGenres");

                    b.Navigation("UserGames");
                });

            modelBuilder.Entity("GameBib.Data.Classes.Genre", b =>
                {
                    b.Navigation("GameGenres");
                });

            modelBuilder.Entity("GameBib.Data.Classes.User", b =>
                {
                    b.Navigation("UserGames");
                });
#pragma warning restore 612, 618
        }
    }
}
