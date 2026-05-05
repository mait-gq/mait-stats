FROM mcr.microsoft.com/dotnet/aspnet:10.0.6 AS base
WORKDIR /app
EXPOSE 8080

USER app

FROM mcr.microsoft.com/dotnet/sdk:10.0.6 AS build
WORKDIR /src
COPY ["mait.stats.csproj", "."]
RUN dotnet restore "mait.stats.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mait.stats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mait.stats.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mait.stats.dll"]
