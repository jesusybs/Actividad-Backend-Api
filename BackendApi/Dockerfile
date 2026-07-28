# Usa la imagen oficial de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo .csproj y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia todo el resto del código y compila
COPY . .
RUN dotnet publish -c Release -o /app/out

# Usa la imagen de tiempo de ejecución de .NET para el contenedor final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Asegúrate de que el nombre "BackendApi.dll" coincida con tu proyecto
ENTRYPOINT ["dotnet", "BackendApi.dll"]