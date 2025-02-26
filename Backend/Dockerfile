# Usamos la imagen oficial de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo de solución y los archivos de proyecto
COPY *.sln ./
COPY Backend/*.csproj Backend/
COPY Core/*.csproj Core/
COPY Application/*.csproj Application/
COPY Infrastructure/*.csproj Infrastructure/
COPY Tests/*.csproj Tests/
RUN dotnet restore

# Copiar el resto del código fuente y compilar
COPY . .
WORKDIR /app/Backend
RUN dotnet publish -c Release -o /out

# Segunda fase: ejecutar la aplicación con una imagen más ligera
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Backend.dll"]
