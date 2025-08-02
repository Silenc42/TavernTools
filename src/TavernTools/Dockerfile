FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN apt-get update && apt-get install -y --no-install-recommends ca-certificates

USER $APP_UID

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["TavernTools/TavernTools.csproj", "TavernTools/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["GuildStashCore/GuildStashCore.csproj", "GuildStashCore/"]
COPY ["PersistenceSupabase/PersistenceSupabase.csproj", "PersistenceSupabase/"]
RUN dotnet restore "TavernTools/TavernTools.csproj"
COPY . .
WORKDIR "/src/TavernTools"
RUN dotnet build "./TavernTools.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TavernTools.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TavernTools.dll"]
