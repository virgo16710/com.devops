FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["com.devops.csproj", "./"]
RUN dotnet restore "com.devops.csproj"

COPY . .
RUN dotnet build "com.devops.csproj" -c Release -o /app/build
RUN dotnet publish "com.devops.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "com.devops.dll"]
