# 📬 Projeto de Atualização Assíncrona de Contatos

Este projeto tem como objetivo realizar a **atualização assíncrona de dados de contato**, utilizando **RabbitMQ** como mecanismo de mensageria para envio das informações a uma fila de processamento.

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- RabbitMQ
- ASP.NET Core (Web API)
- Docker (opcional para execução local de infraestrutura)

---

## 🧩 Objetivo

O projeto foi desenvolvido como parte do **FIAP Tech Challenge**, no contexto do curso de **Arquitetura de Sistemas .NET**. A proposta visa aplicar conceitos de:

- Arquitetura orientada a eventos
- Mensageria assíncrona com RabbitMQ
- Boas práticas de design e desacoplamento

---

## 🛠️ Funcionalidades

- Envio de dados de contato para uma fila RabbitMQ
- Processamento desacoplado da atualização de dados
- Estrutura preparada para escalabilidade e manutenibilidade

---

## ⚙️ Como Executar

### Pré-requisitos

- .NET 8 SDK
- RabbitMQ (local ou em container)
- Docker (opcional)
- Para acessar via docker - Executar os comandos
  - docker build -t contato.atualizar.web .
  - docker run -it -p 8080:8080 --rm contato.atualizar.web
