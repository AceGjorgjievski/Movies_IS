FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Movies.Web/Movies.Web.csproj", "Movies.Web/"]
RUN dotnet restore "Movies.Web/Movies.Web.csproj"
COPY . .
WORKDIR "/src/Movies.Web"
RUN dotnet build "Movies.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movies.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movies.Web.dll"]
