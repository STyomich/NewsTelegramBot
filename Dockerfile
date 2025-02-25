# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the solution and project files
COPY NewsTelegramBot.sln . 
COPY NewsTelegramBot/NewsTelegramBot.csproj NewsTelegramBot/
COPY Application/Application.csproj Application/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/

# Restore dependencies for all projects
RUN dotnet restore NewsTelegramBot.sln

# Copy the rest of the source code
COPY . .

# Build and publish the application in release mode
RUN dotnet publish NewsTelegramBot/NewsTelegramBot.csproj -c Release -o /out

# Use the official ASP.NET Core Runtime image to run the application (includes both .NET and ASP.NET Core runtimes)
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Set the working directory in the container
WORKDIR /app

# Copy the published app from the build container
COPY --from=build /out ./

# Define the entry point for the application
ENTRYPOINT ["dotnet", "NewsTelegramBot.dll"]
