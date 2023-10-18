﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizWebApp.DatabaseServices;

#nullable disable

namespace QuizWebApp.Migrations
{
    [DbContext(typeof(WQuizzDBContext))]
    partial class WQuizzDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuizWebApp.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerContent = "Berlin",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 2,
                            AnswerContent = "Orleans",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 3,
                            AnswerContent = "Paris",
                            IsCorrect = true,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 4,
                            AnswerContent = "Brussels",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 5,
                            AnswerContent = "Houston",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 6,
                            AnswerContent = "New York",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 7,
                            AnswerContent = "Dallas",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 8,
                            AnswerContent = "Washington, D.C",
                            IsCorrect = true,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 9,
                            AnswerContent = "Kyoto",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 10,
                            AnswerContent = "Tokyo",
                            IsCorrect = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 11,
                            AnswerContent = "Okinawa",
                            IsCorrect = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 12,
                            AnswerContent = "Yokohama",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 13,
                            AnswerContent = "Copenhagen",
                            IsCorrect = true,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 14,
                            AnswerContent = "Arhus",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 15,
                            AnswerContent = "Aalborg",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 16,
                            AnswerContent = "Frederiksberg",
                            IsCorrect = false,
                            QuestionId = 4
                        },
                        new
                        {
                            Id = 17,
                            AnswerContent = "U",
                            IsCorrect = true,
                            QuestionId = 5
                        },
                        new
                        {
                            Id = 18,
                            AnswerContent = "Ur",
                            IsCorrect = false,
                            QuestionId = 5
                        },
                        new
                        {
                            Id = 19,
                            AnswerContent = "Ua",
                            IsCorrect = false,
                            QuestionId = 5
                        },
                        new
                        {
                            Id = 20,
                            AnswerContent = "An",
                            IsCorrect = false,
                            QuestionId = 5
                        },
                        new
                        {
                            Id = 21,
                            AnswerContent = "H",
                            IsCorrect = false,
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 22,
                            AnswerContent = "He",
                            IsCorrect = true,
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 23,
                            AnswerContent = "Hl",
                            IsCorrect = false,
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 24,
                            AnswerContent = "Hx",
                            IsCorrect = false,
                            QuestionId = 6
                        },
                        new
                        {
                            Id = 25,
                            AnswerContent = "M",
                            IsCorrect = false,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 26,
                            AnswerContent = "Ma",
                            IsCorrect = false,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 27,
                            AnswerContent = "Mg",
                            IsCorrect = true,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 28,
                            AnswerContent = "Na",
                            IsCorrect = false,
                            QuestionId = 7
                        },
                        new
                        {
                            Id = 29,
                            AnswerContent = "G",
                            IsCorrect = false,
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 30,
                            AnswerContent = "Go",
                            IsCorrect = false,
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 31,
                            AnswerContent = "Au",
                            IsCorrect = true,
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 32,
                            AnswerContent = "Ar",
                            IsCorrect = false,
                            QuestionId = 8
                        },
                        new
                        {
                            Id = 33,
                            AnswerContent = "S",
                            IsCorrect = false,
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 34,
                            AnswerContent = "Si",
                            IsCorrect = false,
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 35,
                            AnswerContent = "Ar",
                            IsCorrect = false,
                            QuestionId = 9
                        },
                        new
                        {
                            Id = 36,
                            AnswerContent = "Ag",
                            IsCorrect = true,
                            QuestionId = 9
                        });
                });

            modelBuilder.Entity("QuizWebApp.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionContent = "What is the capital of France?",
                            QuestionImgUrl = "https://static.vecteezy.com/system/resources/previews/008/726/860/original/map-of-france-outline-map-illustration-free-vector.jpg",
                            QuizId = 1
                        },
                        new
                        {
                            Id = 2,
                            QuestionContent = "What is the capital of the USA?",
                            QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Map_of_USA_with_state_names.svg/langhu-800px-Map_of_USA_with_state_names.svg.png",
                            QuizId = 1
                        },
                        new
                        {
                            Id = 3,
                            QuestionContent = "What is the capital of Japan?",
                            QuestionImgUrl = "https://cdn.pixabay.com/photo/2013/05/22/18/00/japan-112722_1280.jpg",
                            QuizId = 1
                        },
                        new
                        {
                            Id = 4,
                            QuestionContent = "What is the capital of Denmark?",
                            QuestionImgUrl = "https://static.vecteezy.com/system/resources/previews/019/476/194/original/denmark-map-in-europe-zoom-version-icons-showing-denmark-location-and-flags-vector.jpg",
                            QuizId = 1
                        },
                        new
                        {
                            Id = 5,
                            QuestionContent = "What is the chemical symbol of Uranium",
                            QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/HEUraniumC.jpg/1200px-HEUraniumC.jpg",
                            QuizId = 2
                        },
                        new
                        {
                            Id = 6,
                            QuestionContent = "What is the chemical symbol of Helium?",
                            QuestionImgUrl = "https://static.wikia.nocookie.net/fortnite/images/d/da/Balloons_%28Old%29_-_Item_-_Fortnite.png/revision/latest?cb=20200717131102",
                            QuizId = 2
                        },
                        new
                        {
                            Id = 7,
                            QuestionContent = "What is the chemical symbol of Magnesium?",
                            QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/CSIRO_ScienceImage_2893_Crystalised_magnesium.jpg",
                            QuizId = 2
                        },
                        new
                        {
                            Id = 8,
                            QuestionContent = "What is the chemical symbol of Gold?",
                            QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/6/69/Gold_nugget_%28Australia%29_4_%2816848647509%29.jpg",
                            QuizId = 2
                        },
                        new
                        {
                            Id = 9,
                            QuestionContent = "What is the chemical symbol of Silver?",
                            QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Silver_crystal.jpg/1200px-Silver_crystal.jpg",
                            QuizId = 2
                        });
                });

            modelBuilder.Entity("QuizWebApp.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryType")
                        .HasColumnType("int");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<float>("Popularity")
                        .HasColumnType("real");

                    b.Property<string>("QuizName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryType = 2,
                            Difficulty = 0,
                            IsApproved = true,
                            Popularity = 100f,
                            QuizName = "Capital Cities around the World",
                            Rating = 100f,
                            ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Prague_%286365119737%29.jpg/1920px-Prague_%286365119737%29.jpg"
                        },
                        new
                        {
                            Id = 2,
                            CategoryType = 1,
                            Difficulty = 1,
                            IsApproved = true,
                            Popularity = 78f,
                            QuizName = "Chemical Symbols",
                            Rating = 71f,
                            ThumbnailUrl = "https://i.pinimg.com/originals/de/54/d3/de54d3e8700cbb87d534844531ae5b71.png"
                        },
                        new
                        {
                            Id = 3,
                            CategoryType = 5,
                            Difficulty = 2,
                            IsApproved = true,
                            Popularity = 54f,
                            QuizName = "Retro Gaming",
                            Rating = 50f,
                            ThumbnailUrl = "https://as2.ftcdn.net/v2/jpg/05/59/01/05/1000_F_559010542_cXULDCcdcVwWCcf0DcE7V3QhCQO44Ryh.jpg"
                        },
                        new
                        {
                            Id = 4,
                            CategoryType = 5,
                            Difficulty = 2,
                            IsApproved = true,
                            Popularity = 82f,
                            QuizName = "Bionicle Lore",
                            Rating = 91f,
                            ThumbnailUrl = "https://biosector01.com/w/images/bs01/0/0e/Toa_Mata_Sets.jpg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizWebApp.Models.Answer", b =>
                {
                    b.HasOne("QuizWebApp.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizWebApp.Models.Question", b =>
                {
                    b.HasOne("QuizWebApp.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizWebApp.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizWebApp.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
