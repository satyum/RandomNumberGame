# Use the official ASP.NET Core Runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy the project file and restore as distinct layers
COPY ["RandomNumberGame/RandomNumberGame.csproj", "RandomNumberGame/"]
RUN dotnet restore "RandomNumberGame/RandomNumberGame.csproj"

# Copy the remaining source code
COPY . .

# Build the application
WORKDIR "/src/RandomNumberGame"
RUN dotnet build "RandomNumberGame.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RandomNumberGame.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RandomNumberGame.dll"]

