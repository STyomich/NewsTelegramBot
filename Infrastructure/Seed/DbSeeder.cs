using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed
{
    public class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(
           new News { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Category = "NURE", Title = "NURE Students Win Robotics Competition", ShortDescription = "NURE students have won the prestigious robotics competition.", Description = "The students of the National University of Radio Electronics (NURE) have won the regional robotics competition with their innovative robot design. This achievement highlights the university’s commitment to fostering tech talent.", Date = new DateTime(2025, 2, 20), ImageUrl = "https://studentrobotics.org/images/content/blog/sr2024/sr2024-photo.large.jpg", SourceUrl = "https://example.com/news1" },
           new News { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Category = "NURE", Title = "NURE to Host International Conference on AI", ShortDescription = "NURE is set to host a major AI conference in 2025.", Description = "The National University of Radio Electronics will be the venue for a highly anticipated international conference on Artificial Intelligence, where industry leaders will discuss the future of AI.", Date = new DateTime(2025, 2, 19), ImageUrl = "https://nure.ua/wp-content/uploads/stend_turkie.jpg", SourceUrl = "https://example.com/news2" },
           new News { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Category = "NURE", Title = "NURE Opens New Data Science Lab", ShortDescription = "A new lab dedicated to data science has been inaugurated at NURE.", Description = "The new data science lab at NURE will provide students with hands-on experience in AI, machine learning, and big data analysis, helping them stay at the forefront of technological advancements.", Date = new DateTime(2025, 2, 15), ImageUrl = "https://nure.ua/wp-content/uploads/2018/11/mvi_9054.00_06_09_04.nepodvizhnoe-izobrazhenie007.jpg", SourceUrl = "https://example.com/news3" },
           new News { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Category = "Sports", Title = "Local Team Wins National Football Championship", ShortDescription = "The local football team has clinched the national championship title.", Description = "The local football team has made history by winning the national championship in a thrilling match that saw them defeat the defending champions in the final game.", Date = new DateTime(2025, 2, 18), ImageUrl = "https://bloximages.chicago2.vip.townnews.com/tucsonlocalmedia.com/content/tncms/assets/v3/editorial/8/c7/8c7d45fc-906f-11e4-8243-378dc0b49f44/54a320f614807.image.jpg?resize=400%2C300", SourceUrl = "https://example.com/news6" },
           new News { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Category = "IT", Title = "Tech Giant Launches New Cloud Services", ShortDescription = "A leading tech company has launched new cloud services aimed at businesses.", Description = "A well-known tech giant has launched a new suite of cloud services designed to streamline business operations, offering enhanced storage and analytics capabilities.", Date = new DateTime(2025, 2, 14), ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTny-6_VzUcMNrn6asUK-SPi0EcF6MQzPpu8g&s", SourceUrl = "https://example.com/news11" }
       );
        }
    }
}