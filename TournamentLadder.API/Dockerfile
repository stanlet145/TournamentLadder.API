FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

WORKDIR /src/TournamentLadder.API
RUN dotnet publish TournamentLadder.API.csproj -c Release -o /app/publish

FROM build AS tests
WORKDIR /src/TournamentLadder.Tests
RUN dotnet test

FROM build AS update-database
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef database udpate --project TournamentLadder.Infrastructure --startup-project TournamentLadder.API

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=update-database /src/TournamentLadder.API/dbo.TournamentLadder.db .
COPY --from=update-database /app/publish .
ENTRYPOINT ["dotnet","TournamentLadder.API.dll"]
