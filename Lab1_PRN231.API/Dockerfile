#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Lab1_PRN231.API/Lab1_PRN231.API.csproj", "Lab1_PRN231.API/"]
COPY ["Lab1_PRN231.Service/Lab1_PRN231.Service.csproj", "Lab1_PRN231.Service/"]
COPY ["Lab1_PRN231.Repository/Lab1_PRN231.Repository.csproj", "Lab1_PRN231.Repository/"]
RUN dotnet restore "./Lab1_PRN231.API/Lab1_PRN231.API.csproj"
COPY . .
WORKDIR "/src/Lab1_PRN231.API"
RUN dotnet build "./Lab1_PRN231.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Lab1_PRN231.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab1_PRN231.API.dll"]