using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Core.Entities; // Assuming the UserData entity is in the Core.Entities namespace
using Application.Services;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Services
{
    public class BotService
    {
        private readonly ITelegramBotClient _bot;
        private readonly NewsService _newsService;
        private readonly UserDataService _userDataService;

        public BotService(ITelegramBotClient bot, NewsService newsService, UserDataService userDataService)
        {
            _bot = bot;
            _newsService = newsService;
            _userDataService = userDataService;
        }

        public Task OnError(Exception exception, HandleErrorSource source)
        {
            Console.WriteLine($"Error: {exception.Message}");
            return Task.CompletedTask;
        }

        public async Task OnMessage(Message msg, UpdateType type)
        {
            if (msg.Text == "/start")
            {
                var keyboard = new InlineKeyboardMarkup(new[]
                {
                    new[] { InlineKeyboardButton.WithCallbackData("Sports", "category_Sports") },
                    new[] { InlineKeyboardButton.WithCallbackData("IT", "category_IT") },
                    new[] { InlineKeyboardButton.WithCallbackData("NURE", "category_NURE") }
                });

                await _bot.SendMessage(msg.Chat.Id, "Welcome to NewsBot! Pick a category:", replyMarkup: keyboard);
            }
            else if (msg.Text == "/userData")
            {
                // Fetch all user data
                var allUserData = await _userDataService.GetAllUserDataAsync();

                if (allUserData.Any())
                {
                    // Format the user data for the message
                    var userDataMessage = "💼 *User Data:*\n\n";
                    foreach (var user in allUserData)
                    {
                        userDataMessage += $"User ID: {user.Id}\n" +
                                           $"Nickname: {user.UserNickname ?? "N/A"}\n" +
                                           $"Last Request: {user.DateOfLastRequest}\n\n";
                    }

                    await _bot.SendMessage(msg.Chat.Id, userDataMessage, parseMode: ParseMode.Markdown);
                }
                else
                {
                    await _bot.SendMessage(msg.Chat.Id, "No user data available.");
                }
            }

            // Add/update user request time
            await UpdateUserRequestTimeAsync(msg.From.Username);
        }

        public async Task OnUpdate(Update update)
        {
            if (update.CallbackQuery != null) // User clicked a button
            {
                var query = update.CallbackQuery;

                if (query.Data.StartsWith("category_")) // User selected a category
                {
                    string category = query.Data.Replace("category_", "");

                    // Fetch 10 recent news items for the selected category
                    var newsList = await _newsService.GetTenNewsByCategoryAsync(category);

                    if (newsList.Count == 0)
                    {
                        await _bot.SendMessage(query.Message.Chat.Id, $"No news found for {category}.");
                        return;
                    }

                    // Generate a numbered list of news with buttons
                    var newsMessage = $"📰 *Top 10 {category} news:*\n\n";
                    var keyboardButtons = new List<InlineKeyboardButton[]>();

                    foreach (var (news, index) in newsList.Select((n, i) => (n, i + 1)))
                    {
                        newsMessage += $"{index}. {news.Title}\n {news.ShortDescription}\n\n";
                        keyboardButtons.Add(new[] { InlineKeyboardButton.WithCallbackData($"{index}", $"news_{news.Id}") });
                    }

                    var keyboard = new InlineKeyboardMarkup(keyboardButtons);

                    await _bot.SendMessage(query.Message.Chat.Id, newsMessage, replyMarkup: keyboard, parseMode: ParseMode.Markdown);
                    await _bot.AnswerCallbackQuery(query.Id);
                }
                else if (query.Data.StartsWith("news_")) // User clicked a news number
                {
                    Guid newsId = Guid.Parse(query.Data.Replace("news_", ""));
                    var news = await _newsService.GetNewsByIdAsync(newsId);

                    if (news != null)
                    {
                        string message = $"📰 *{news.Title}*\n\n{news.Description} \n\n Source: {news.SourceUrl}";

                        // Send the message with the image
                        await _bot.SendPhoto(
                            chatId: query.Message.Chat.Id,
                            photo: news.ImageUrl,
                            caption: message,
                            parseMode: ParseMode.Markdown
                        );
                    }
                    else
                    {
                        await _bot.SendMessage(query.Message.Chat.Id, "News article not found.");
                    }

                    await _bot.AnswerCallbackQuery(query.Id);
                }

                // Add/update user request time
                await UpdateUserRequestTimeAsync(query.From.FirstName);
            }
        }

        private async Task UpdateUserRequestTimeAsync(string userNickname)
        {
            // Search for the user by nickname
            var userData = await _userDataService.GetUserDataByNicknameAsync(userNickname);

            if (userData != null)
            {
                // Update the user's last request date to now
                userData.DateOfLastRequest = DateTime.UtcNow;
                await _userDataService.UpdateUserDataAsync(userData);
            }
            else
            {
                // Create new user data if it doesn't exist
                userData = new UserData
                {
                    UserNickname = userNickname,
                    DateOfLastRequest = DateTime.UtcNow
                };
                await _userDataService.AddUserDataAsync(userData);
            }
        }
    }
}
