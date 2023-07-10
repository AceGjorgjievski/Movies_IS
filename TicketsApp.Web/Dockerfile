FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["TicketsApp.Web/TicketsApp.Web.csproj", "TicketsApp.Web/"]
RUN dotnet restore "TicketsApp.Web/TicketsApp.Web.csproj"
COPY . .
WORKDIR "/src/TicketsApp.Web"
RUN dotnet build "TicketsApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketsApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketsApp.Web.dll"]
