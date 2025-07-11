# 🧮 Calculadora de Custos para Lanchonetes

> Projeto desenvolvido para ajudar pequenos empreendedores, especialmente donos de hamburguerias, a calcular preços de venda com base em insumos, receitas e custos fixos/variáveis.

---

## 📌 Funcionalidades

* Cadastro de insumos e ingredientes
* Registro de custos fixos e variáveis
* Cadastro de receitas (lanches, combos etc.)
* Cálculo automático de preço ideal, margem de lucro e lucro líquido
* Interface clara para análise financeira do produto

---

## 🚀 Tecnologias Utilizadas

* C#
* .NET 8
* Entity Framework
* SQL Server
* Docker
* Git/GitHub

---

## 🧠 Motivação

Este sistema nasceu da minha experiência como ex-dono de uma hamburgueria. Gerenciar precificação com planilhas era confuso e ineficiente. Com esse projeto, transformei essa dor real em uma ferramenta funcional e acessível.

---

## 📷 Screenshots

Em breve...

---

## 🛠️ Como rodar o projeto localmente

### Pré-requisitos

* [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
* [SQL Server LocalDB](https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
* [Docker](https://www.docker.com/) (opcional)

### Rodando com Docker

```bash
docker-compose up -d
```

### Rodando localmente sem Docker

```bash
dotnet restore
dotnet ef database update
dotnet run
```

A aplicação estará disponível em: `https://localhost:5001`

---

## 📁 Estrutura do Projeto

```
CalculadoraCustos/
├── Controllers/
├── Models/
├── Services/
├── Data/
├── Migrations/
├── Program.cs
├── Startup.cs
└── appsettings.json
```

---

## 🤝 Contribuindo

Pull requests são bem-vindos! Para mudanças maiores, abra uma issue primeiro para discutirmos o que você gostaria de modificar.

---

## 📄 Licença

Esse projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---

### Autor

**Filipe Magalhães**
📧 [7filipe093@gmail.com](mailto:7filipe093@gmail.com)
🔗 [LinkedIn](https://linkedin.com/in/filipemagalhãesdev)
🌐 [Portfólio](https://portfolio-filipe-magalhaes-dev.onrender.com)
