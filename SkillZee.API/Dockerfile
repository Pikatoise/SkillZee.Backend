FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["SkillZee.API/SkillZee.API.csproj", "SkillZee.API/"]
COPY ["SkillZee.Infrastructure/SkillZee.Infrastructure.csproj", "SkillZee.Infrastructure/"]
COPY ["SkillZee.Domain/SkillZee.Domain.csproj", "SkillZee.Domain/"]
RUN dotnet restore "./SkillZee.API/SkillZee.API.csproj"
COPY . .
WORKDIR "/src/SkillZee.API"
RUN dotnet build "./SkillZee.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SkillZee.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillZee.API.dll"]