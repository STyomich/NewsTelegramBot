using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Category", "Date", "Description", "ImageUrl", "ShortDescription", "SourceUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "NURE", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The students of the National University of Radio Electronics (NURE) have won the regional robotics competition with their innovative robot design. This achievement highlights the university’s commitment to fostering tech talent.", "https://studentrobotics.org/images/content/blog/sr2024/sr2024-photo.large.jpg", "NURE students have won the prestigious robotics competition.", "https://example.com/news1", "NURE Students Win Robotics Competition" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "NURE", new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The National University of Radio Electronics will be the venue for a highly anticipated international conference on Artificial Intelligence, where industry leaders will discuss the future of AI.", "https://nure.ua/wp-content/uploads/stend_turkie.jpg", "NURE is set to host a major AI conference in 2025.", "https://example.com/news2", "NURE to Host International Conference on AI" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "NURE", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The new data science lab at NURE will provide students with hands-on experience in AI, machine learning, and big data analysis, helping them stay at the forefront of technological advancements.", "https://nure.ua/wp-content/uploads/2018/11/mvi_9054.00_06_09_04.nepodvizhnoe-izobrazhenie007.jpg", "A new lab dedicated to data science has been inaugurated at NURE.", "https://example.com/news3", "NURE Opens New Data Science Lab" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Sports", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The local football team has made history by winning the national championship in a thrilling match that saw them defeat the defending champions in the final game.", "https://bloximages.chicago2.vip.townnews.com/tucsonlocalmedia.com/content/tncms/assets/v3/editorial/8/c7/8c7d45fc-906f-11e4-8243-378dc0b49f44/54a320f614807.image.jpg?resize=400%2C300", "The local football team has clinched the national championship title.", "https://example.com/news6", "Local Team Wins National Football Championship" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "IT", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "A well-known tech giant has launched a new suite of cloud services designed to streamline business operations, offering enhanced storage and analytics capabilities.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTny-6_VzUcMNrn6asUK-SPi0EcF6MQzPpu8g&s", "A leading tech company has launched new cloud services aimed at businesses.", "https://example.com/news11", "Tech Giant Launches New Cloud Services" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
