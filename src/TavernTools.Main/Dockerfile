FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN apt-get update && apt-get install -y --no-install-recommends ca-certificates

USER $APP_UID

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
#COPY other projects?
COPY ["TavernTools.Main/TavernTools.Main.csproj", "TavernTools.Main/"]
RUN dotnet restore "TavernTools.Main/TavernTools.Main.csproj"
COPY . .
WORKDIR "/src/TavernTools.Main"
RUN dotnet build "./TavernTools.Main.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TavernTools.Main.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TavernTools.Main.dll"]
