FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TournamentLadder.API/TournamentLadder.API.csproj", "TournamentLadder.API/"]
RUN dotnet restore "TournamentLadder.API/TournamentLadder.API.csproj"
COPY . .
WORKDIR "/src/TournamentLadder.API"
RUN dotnet build "TournamentLadder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TournamentLadder.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TournamentLadder.API.dll"]
