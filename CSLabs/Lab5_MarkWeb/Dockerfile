FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lab5_MarkWeb/Lab5_MarkWeb.csproj", "Lab5_MarkWeb/"]
RUN dotnet restore "Lab5_MarkWeb/Lab5_MarkWeb.csproj"
COPY . .
WORKDIR "/src/Lab5_MarkWeb"
RUN dotnet build "Lab5_MarkWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab5_MarkWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab5_MarkWeb.dll"]
