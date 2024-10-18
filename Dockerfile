# Este est�gio � usado para construir o projeto de servi�o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BabyName.csproj", "."]

# Restaura as depend�ncias
RUN dotnet restore "./BabyName.csproj"
COPY . .

# Instalar dotnet-ef e adicionar ao PATH
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Compila o projeto
RUN dotnet build "./BabyName.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Este est�gio � usado para publicar o projeto de servi�o que ser� copiado para o est�gio final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BabyName.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Este est�gio � usado em produ��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BabyName.dll"]
