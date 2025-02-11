# Base

## 🚀 Funcionalidades

- **Arquitetura Limpa**: Separação de responsabilidades com camadas distintas de Domínio, Aplicação, Infraestrutura e Apresentação.
- **Programação Assíncrona**: Operações não bloqueantes para melhorar o desempenho e a escalabilidade.

## 🏗 Arquitetura

Segue os princípios da **Arquitetura Limpa**, garantindo um código manutenível e testável:

- **Camada de Domínio**: Encapsula a lógica de negócio e entidades principais.
- **Camada de Aplicação**: Lida com casos de uso, comandos, consultas e orquestra interações entre Domínio e Infraestrutura.
- **Camada de Infraestrutura**: Gerencia persistência de dados, serviços externos e implementa interfaces de repositório.
- **Camada Web**: Disponibiliza UI ao usuário e a interação com o sistema.

## 📦 Começando

### Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Git](https://git-scm.com/downloads)

### Instalação

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/MarcosMuriloPJ/Base
   cd Base
   ```

2. **Navegue para o projeto Web:**

   ```bash
   cd Base.Web
   ```

3. **Restaure as dependências:**

   ```bash
   dotnet restore
   ```

### Executando a Aplicação

**Execute o projeto Web:**

```bash
dotnet run
```

## 🔧 Configuração

### Migrations

**Entity Framework CLI commands**

```Database e Sobrecarga
dotnet ef migrations add StartInitial --project ./src/Base.Infrastructure/Base.Infrastructure.csproj --startup-project ./src/Base.Web/Base.Web.csproj
dotnet ef migrations add StartUserSeed --project ./src/Base.Infrastructure/Base.Infrastructure.csproj --startup-project ./src/Base.Web/Base.Web.csproj
dotnet ef database update --project ./src/Base.Infrastructure/Base.Infrastructure.csproj --startup-project ./src/Base.Web/Base.Web.csproj
```

### appsettings.json

Configure as definições da sua aplicação em `appsettings.json` e `appsettings.Development.json`:

## 🛡 Licença

Este projeto está licenciado sob a Licença MIT.

## 📫 Contato

Para qualquer dúvida ou feedback, por favor, entre em contato através do email marcosmurilo.ti@gmail.com

Obrigado e um abraço!
