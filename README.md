```
> 🌐 Projeto : Gerenciador de Carteira Digital 💳 

> 📅 Ano de Conclusão: 2025

> 👨‍💻 Desenvolvido por: Tiago Daltro Duarte

```

# 1. 📖 **Sobre o Projeto**

Este projeto é uma **API RESTful** desenvolvida com foco no gerenciamento de carteiras digitais. Foi construída utilizando as tecnologias **ASP.NET Core**, **Entity Framework Core** e **PostgreSQL**, com base em uma **arquitetura limpa e em 3 camadas**, seguindo os princípios do **SOLID** para garantir modularidade, manutenibilidade e escalabilidade.

A API permite que usuários se cadastrem, criem carteiras digitais, adicionem saldo, realizem transferências entre carteiras e acompanhem todo o histórico de movimentações. Também conta com **autenticação e autorização**, garantindo que apenas usuários autenticados possam acessar os recursos sensíveis da aplicação.

---

# 2. 🧪 Como Executar Localmente

### 2.1 - Configuração do ambiente e execução da aplicação

### Instale as Dependências
1. **PostgreSQL**  
2. **.NET 8 SDK**  
3. **Git**  

### 2.2  **Clone o repositório:**

   ```bash
   git clone https://github.com/Ti7801/DigitalWalletManagerAPI.git
   cd gerenciador-carteira-digital
   ```

### 2.3 **Configure o `appsettings.json`:**
   
   ### Configuração do Banco de Dados
   Por padrão, a aplicação irá utilizar o banco de dados de nome `DigitalWalletApi`.


   A seguinte *connection string* está configurada no arquivo `src/DigitalWalletManagerAPI/appsettings.json`:  

   ```json
     "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=DigitalWalletApi;Username=postgres;Password=******"
      },
   ```
   No `ConnectionStrings` utilize a senha que você definiu na instalação do PostgreeSQL, em sua máquina.

   Se deseja utilizar outro banco de dados, é necessário substituir a *connection string* padrão.



### 2.4 Migrations
Neste projeto foi utilizado o **EF Core** para gerenciar as *migrations*.  
Para criar o banco de dados e aplicar as *migrations* necessárias, execute o seguinte comando:

1. Navegue para a pasta source com o comando:  
   ```bash
   cd src/
   ```
2. Aplique as *migrations* utilizando o comando:  
   ```bash
   dotnet ef database update --context AppDbContext --project BibliotecaData --startup-project DigitalWalletManagerAPI
   ```

### 2.5 Executando a Aplicação
1. Navegue para `/src/DigitalWalletManagerAPI/`.  
2. Compile a solução com o comando:  
   ```bash
   dotnet build
   ```
3. Execute a solução com o comando:  
   ```bash
   dotnet run
   ```

---

## 3. 🚀 Funcionalidades

A seguir estão listadas as principais funcionalidades implementadas na aplicação:

- ✅ **Cadastro de usuários:** criação de contas de forma segura para utilização da API.
- 🔐 **Autenticação e autorização:** controle de acesso aos recursos protegidos, garantindo segurança.
- 💼 **Cadastro e leitura de carteiras digitais:** cada usuário pode ter uma ou mais carteiras registradas.
- ➕ **Adição de saldo às carteiras:** funcionalidade para adicionar crédito a uma carteira específica.
- 🔁 **Realização de transferências e listagem de transferências:** permite transferir valores entre carteiras e consultar o histórico completo de movimentações realizadas.

---

## 4. 🧰 Tecnologias Utilizadas

O projeto foi desenvolvido com o uso das seguintes tecnologias:

- **ASP.NET Core 8.0** – framework principal da API.
- **Entity Framework Core** – ORM utilizado para comunicação com o banco de dados.
- **PostgreSQL** – sistema de gerenciamento de banco de dados relacional.
- **Arquitetura em 3 camadas (Presentation, Business, Data)** – separação de responsabilidades.
- **Princípios SOLID** – para garantir código limpo e desacoplado.
- **Clean Architecture** – organização clara entre camadas e responsabilidades.

---

## 5. 📁 Estrutura do Projeto

A estrutura segue uma separação clara de responsabilidades entre as camadas:

```
📦 PROJETO
├── 📂 BibliotecaBusiness
│   ├── Abstractions         # Interfaces e contratos da camada de negócio
│   ├── DTOs                 # Objetos de transferência de dados
│   ├── Exceptions           # Exceções personalizadas
│   ├── Models               # Modelos de domínio
│   └── Services             # Implementações das regras de negócio
├── 📂 BibliotecaData
│   ├── Data                 # DbContext e configuração de acesso ao banco
│   ├── Migrations           # Migrações do EF Core
│   └── TableConfig          # Configurações específicas de cada tabela
├── 📂 DigitalWalletManagerAPI
│   ├── Controllers          # Endpoints da API
│   └── Services             # Camada de serviço utilizada pelos controllers
```

---

## 6. 🧠 Arquitetura

A aplicação está organizada com foco na **Clean Architecture**, que promove uma separação forte entre as camadas, garantindo baixo acoplamento. Essa arquitetura permite:

- Fácil manutenção e testes isolados;
- Reaproveitamento de código;
- Independência da tecnologia de infraestrutura;
- Aplicação de **princípios SOLID**, como Inversão de Dependência e Responsabilidade Única.

---

## 7. 🛠️ Padrões e Boas Práticas

O projeto foi desenvolvido com atenção especial às boas práticas de desenvolvimento:

- 📦 **DTOs (Data Transfer Objects)** para evitar exposição direta dos modelos de domínio.
- ❗ **Exceções personalizadas** para cada cenário de erro da regra de negócio.
- 🔁 **Interfaces (abstrações)** para garantir que as implementações possam ser facilmente substituídas ou testadas.
- 🧪 **Facilidade para testes unitários** devido à separação clara entre lógica de negócio e camada de apresentação.
- 🔒 **Segurança com autenticação e autorização** aplicadas via middleware e policies.

---



## 8. 🧾 Exemplo de Script para Popular o Banco

O projeto acompanha um arquivo `.txt` com um exemplo de script para popular a base de dados com usuários, carteiras e transferências simuladas.

---

## 9. 🤝 Contribuição

Contribuições são bem-vindas! Se você quiser reportar um bug, sugerir melhorias ou colaborar com o código, sinta-se à vontade para abrir uma _issue_ ou _pull request_.

---

## 10. 📫 Contato

Caso tenha dúvidas, sugestões ou deseje colaborar de alguma forma, estou à disposição!

**E-mail**: [tiagodaltro19@gmail.com]  
**LinkedIn**: [https://www.linkedin.com/in/tiago-daltro-35241622a/]

---
