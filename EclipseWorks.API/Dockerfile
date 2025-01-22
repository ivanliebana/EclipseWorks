#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EclipseWorks.API/EclipseWorks.API.csproj", "EclipseWorks.API/"]
COPY ["EclipseWorks.DTO/EclipseWorks.DTO.csproj", "EclipseWorks.DTO/"]
COPY ["EclipseWorks.Infrastructure/EclipseWorks.Infrastructure.csproj", "EclipseWorks.Infrastructure/"]
COPY ["EclipseWorks.Core/EclipseWorks.Core.csproj", "EclipseWorks.Core/"]
COPY ["EclipseWorks.Services/EclipseWorks.Services.csproj", "EclipseWorks.Services/"]
COPY ["EclipseWorks.Helper/EclipseWorks.Helper.csproj", "EclipseWorks.Helper/"]
RUN dotnet restore "./EclipseWorks.API/EclipseWorks.API.csproj"
COPY . .
WORKDIR "/src/EclipseWorks.API"
RUN dotnet build "./EclipseWorks.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EclipseWorks.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EclipseWorks.API.dll"]