FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo .sln
COPY Contato.Atualizar.sln . 

# Copia os projetos necessários
COPY Contato.Atualizar.Web/Contato.Atualizar.Web.csproj Contato.Atualizar.Web/
COPY Contato.Atualizar.Application/Contato.Atualizar.Application.csproj Contato.Atualizar.Application/
COPY Contato.Atualizar.Domain/Contato.Atualizar.Domain.csproj Contato.Atualizar.Domain/
COPY Contato.Atualizar.Infra/Contato.Atualizar.Infra.csproj Contato.Atualizar.Infra/

# Restaura os pacotes
RUN dotnet restore Contato.Atualizar.sln

# Copia o restante dos arquivos
COPY . .

# Compila o projeto
WORKDIR /src/Contato.Atualizar.Web
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contato.Atualizar.Web.dll"]
