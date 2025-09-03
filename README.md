# 🎬 MovieApi

API RESTful desenvolvida em **C# .NET 8** para gerenciamento de filmes, cinemas e endereços, com suporte a relacionamentos entre entidades, validações, documentação via Swagger e arquitetura organizada em **MVC**.  

## 🚀 Tecnologias utilizadas

- **.NET 8**  
- **Entity Framework Core**  
- **SQL Server**  
- **AutoMapper**  
- **Data Annotations** (validações e restrições)  
- **Swagger** (documentação da API)  

## 🏗️ Funcionalidades

- CRUD completo (`GET`, `POST`, `PUT`, `PATCH`, `DELETE`)  
- Relacionamentos entre entidades:  
  - **1:1** → `Cinema` possui um único `Address`  
  - **1:N** → Um `Cinema` pode exibir vários `Movies`  
  - **N:N** → Filmes podem estar em mais de um `Cinema`  
- Utilização de **DTOs** (Data Transfer Objects) para entrada e saída de dados  
- Conversão de entidades com **AutoMapper** e **Profiles**  
- Configuração de banco de dados com **DbContext**  
- Controle de migrações com **Migrations**  
