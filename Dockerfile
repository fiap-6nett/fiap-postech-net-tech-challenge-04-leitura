FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7100

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo .sln
COPY Contato.Leitura.sln . 

# Copia os projetos necessários
COPY Contato.Leitura.Application/Contato.Leitura.Application.csproj Contato.Leitura.Application/
COPY Contato.Leitura.Domain/Contato.Leitura.Domain.csproj Contato.Leitura.Domain/
COPY Contato.Leitura.Infra/Contato.Leitura.Infra.csproj Contato.Leitura.Infra/
COPY Contato.Leitura.Web/Contato.Leitura.Web.csproj Contato.Leitura.Web/

# Restaura os pacotes
RUN dotnet restore Contato.Leitura.sln

# Copia o restante dos arquivos
COPY . .

# Compila o projeto
WORKDIR /src/Contato.Leitura.Web
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contato.Leitura.Web.dll"]

# rodar o comando
# docker run -d -p 7100:7100 --name api-leitura-container -e ASPNETCORE_ENVIRONMENT=Development api-leitura