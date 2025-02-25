using Application.Services;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

// Load configuration
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

string? botToken = config["Telegram:BotToken"];
string? connectionString = config["Database:ConnectionString"];
if (string.IsNullOrEmpty(botToken))
    throw new InvalidOperationException("Bot token is not configured. Please set the 'Telegram:BotToken' configuration value in appsettings.json.");

// Application
var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Configure DbContext with a connection string (replace with your actual connection string)
                    services.AddDbContext<DataContext>(options =>
                       options.UseSqlServer(connectionString));

                    // Register your other services
                    services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(botToken));

                    // Register other services
                    services.AddScoped<NewsService>();  // Add NewsService
                    services.AddScoped<BotService>();   // Add BotService as Scoped
                    services.AddScoped<UserDataService>(); // Add UserDataService
                })
                .Build();

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient(botToken, cancellationToken: cts.Token);

var botService = host.Services.GetRequiredService<BotService>();
var me = await bot.GetMe();
bot.OnError += botService.OnError;
bot.OnMessage += botService.OnMessage;
bot.OnUpdate += botService.OnUpdate;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); // stop the bot