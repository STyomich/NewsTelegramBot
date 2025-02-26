﻿// <auto-generated />
using System;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250225103321_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Category = "NURE",
                            Date = new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The students of the National University of Radio Electronics (NURE) have won the regional robotics competition with their innovative robot design. This achievement highlights the university’s commitment to fostering tech talent.",
                            ImageUrl = "https://studentrobotics.org/images/content/blog/sr2024/sr2024-photo.large.jpg",
                            ShortDescription = "NURE students have won the prestigious robotics competition.",
                            SourceUrl = "https://example.com/news1",
                            Title = "NURE Students Win Robotics Competition"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Category = "NURE",
                            Date = new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The National University of Radio Electronics will be the venue for a highly anticipated international conference on Artificial Intelligence, where industry leaders will discuss the future of AI.",
                            ImageUrl = "https://nure.ua/wp-content/uploads/stend_turkie.jpg",
                            ShortDescription = "NURE is set to host a major AI conference in 2025.",
                            SourceUrl = "https://example.com/news2",
                            Title = "NURE to Host International Conference on AI"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            Category = "NURE",
                            Date = new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The new data science lab at NURE will provide students with hands-on experience in AI, machine learning, and big data analysis, helping them stay at the forefront of technological advancements.",
                            ImageUrl = "https://nure.ua/wp-content/uploads/2018/11/mvi_9054.00_06_09_04.nepodvizhnoe-izobrazhenie007.jpg",
                            ShortDescription = "A new lab dedicated to data science has been inaugurated at NURE.",
                            SourceUrl = "https://example.com/news3",
                            Title = "NURE Opens New Data Science Lab"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            Category = "Sports",
                            Date = new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The local football team has made history by winning the national championship in a thrilling match that saw them defeat the defending champions in the final game.",
                            ImageUrl = "https://bloximages.chicago2.vip.townnews.com/tucsonlocalmedia.com/content/tncms/assets/v3/editorial/8/c7/8c7d45fc-906f-11e4-8243-378dc0b49f44/54a320f614807.image.jpg?resize=400%2C300",
                            ShortDescription = "The local football team has clinched the national championship title.",
                            SourceUrl = "https://example.com/news6",
                            Title = "Local Team Wins National Football Championship"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            Category = "IT",
                            Date = new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A well-known tech giant has launched a new suite of cloud services designed to streamline business operations, offering enhanced storage and analytics capabilities.",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTny-6_VzUcMNrn6asUK-SPi0EcF6MQzPpu8g&s",
                            ShortDescription = "A leading tech company has launched new cloud services aimed at businesses.",
                            SourceUrl = "https://example.com/news11",
                            Title = "Tech Giant Launches New Cloud Services"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
