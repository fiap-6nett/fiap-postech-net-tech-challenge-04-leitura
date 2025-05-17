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
# docker build -t api-leitura:1.0 .

# Imagens
# docker images
# docker rmi nome-da-imagem:tag 

# Container
# docker ps
# docker stop (id)
# docker rm (id)

# Rodar o container da aplicação
# docker run -d -p 7100:7100 --name api-leitura-container -e ASPNETCORE_ENVIRONMENT=Development --network api-network api-leitura:1.0

# Rodar o container do banco de dados
# docker run -d -p 27017:27017 --name mongo-db -e ASPNETCORE_ENVIRONMENT=Development --network api-network rafaelssouza108/mongo:7.0

# Inserir um registro no MongoDB
# docker exec -it mongo-db mongosh

# db.contatos.insertOne({
#   _id: "f35a1e8d-92cd-4b5a-9d61-91c7412f95bd",
#   Nome: "João da Silva",
#   Telefone: "99999-0000",
#   Email: "joao@email.com",
#   Ddd: "11"
# });

# show dbs
# show collections
# db.contatos.find().pretty()
# db.contatos.countDocuments()

# Infos do Mongo
# mongodb://127.0.0.1:27017

# Docker Compose
# docker-compose up

# Exemplo se atualizar a api 
# docker build -t api-leitura:1.0 .
# docker-compose up -d --build leitura-api

# Refaz mais rápido, porém apagando o volume
# docker compose down
# docker compose up -d

# Refaz sem perder o volume
# docker compose stop
# docker compose restart
