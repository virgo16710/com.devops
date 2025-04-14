FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solución y proyectos
COPY ["com.devops.sln", "."]
COPY ["com.devops.Api/com.devops.API.csproj", "com.devops.Api/"]
COPY ["com.devops.Aplicacion/com.devops.Aplicacion.csproj", "com.devops.Aplicacion/"]
COPY ["com.devops.Modelos/com.devops.Modelos.csproj", "com.devops.Modelos/"]
COPY ["com.devops.Persistencia/com.devops.Persistencia.csproj", "com.devops.Persistencia/"]
COPY ["com.devops.Tests/com.devops.Tests.csproj", "com.devops.Tests/"]
# Restaurar dependencias
RUN dotnet restore "com.devops.sln"

# Copiar todo el código
COPY . .

# Build
WORKDIR "/src/com.devops.Api"
RUN dotnet build "com.devops.API.csproj" -c Release -o /app/build

# Publish
RUN dotnet publish "com.devops.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "com.devops.API.dll"]

