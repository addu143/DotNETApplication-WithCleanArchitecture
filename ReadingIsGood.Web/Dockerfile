
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.Web/ReadingIsGood.Web.csproj", "ReadingIsGood.Web/"]
COPY ["ReadingIsGood.Infrastructure/ReadingIsGood.Infrastructure.csproj", "ReadingIsGood.Infrastructure/"]
COPY ["ReadingIsGood.Core/ReadingIsGood.Core.csproj", "ReadingIsGood.Core/"]
RUN dotnet restore "ReadingIsGood.Web/ReadingIsGood.Web.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.Web"
RUN dotnet build "ReadingIsGood.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadingIsGood.Web.dll"]
