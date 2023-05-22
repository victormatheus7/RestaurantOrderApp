#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RestaurantOrderApp.API/RestaurantOrderApp.API.csproj", "RestaurantOrderApp.API/"]
COPY ["RestaurantOrderApp.Infrastructure/RestaurantOrderApp.Infrastructure.csproj", "RestaurantOrderApp.Infrastructure/"]
COPY ["RestaurantOrderApp.Application/RestaurantOrderApp.Application.csproj", "RestaurantOrderApp.Application/"]
COPY ["RestaurantOrderApp.Domain/RestaurantOrderApp.Domain.csproj", "RestaurantOrderApp.Domain/"]
RUN dotnet restore "RestaurantOrderApp.API/RestaurantOrderApp.API.csproj"
COPY . .
WORKDIR "/src/RestaurantOrderApp.API"
RUN dotnet build "RestaurantOrderApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestaurantOrderApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestaurantOrderApp.API.dll"]