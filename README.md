# Gestão Residencial

Projeto backend desenvolvido seguindo os princípios do **Clean Code** e **Domain-Driven Design (DDD)**. O sistema é estruturado em camadas, adotando o **padrão repositório**, garantindo uma separação clara de responsabilidades e facilitando a manutenção e evolução do código.

## Estrutura do Projeto

O projeto está dividido em quatro principais camadas:

- **GestaoGastoResidencial.Api**:  
  Camada de entrada (API), contendo os controllers que expõem os endpoints para consumo externo.

- **GestaoGastoResidencial.App**:  
  Contém os **Casos de Uso** e DTOs (Data Transfer Objects), responsáveis pela lógica de aplicação e orquestração das operações sobre os dados.

- **GestaoGastoResidencial.Domain**:  
  Define as entidades de negócio, enums, interfaces e repositórios, representando o núcleo do domínio do sistema.

- **GestaoGastoResidencial.Infra**:  
  Implementações de repositórios e contexto do banco de dados, incluindo migrações e configuração de persistência.

## Principais Tecnologias

- **.NET 8**
- **Entity Framework Core**
- **SQL Server / Banco relacional** (configurável via appsettings)
- **Arquitetura DDD**
- **Padrão Repository**
- **Clean Code**
