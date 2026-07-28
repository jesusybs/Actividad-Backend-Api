# Usa la imagen oficial de .NET SDK 9.0 para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia el archivo .csproj y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia todo el resto del código y compila
COPY . .
RUN dotnet publish -c Release -o /app/out

# Usa la imagen de tiempo de ejecución de .NET 9.0 para el contenedor final
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "BackendApi.dll"]