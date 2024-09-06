# ColoradoCrud Project

Este projeto é composto por duas partes: uma **API** e uma **aplicação web**. Siga os passos abaixo para configurar e executar ambas as partes.

## 1. Clonando os Repositórios

Clone os repositórios da API e da aplicação web localmente.

### Clone da API
```bash
git clone https://github.com/seu-usuario/ColoradoCrud.Api.git
```

## 2. Configuração da ConnectionString

Após clonar os repositórios, será necessário configurar a ConnectionString no arquivo appsettings.json da API.

### appsettings.json
```bash
"ConnectionStrings": {
  "ColoradoConnection": "Server=SEU_SERVIDOR;Database=ColoradoCrudDb;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```

## 3. Rodar Migrations

Antes de rodar o projeto, você precisará aplicar as migrations para configurar o banco de dados.

Navegue até o diretório da API no terminal.
Execute o comando abaixo para aplicar as migrations:


```bash
dotnet ef database update
```


Isso criará as tabelas necessárias no banco de dados.

> **Nota**: Já existe um usuário admin criado pela migration. Use as seguintes credenciais para acessar a aplicação como administrador:
> - **Usuário**: `admin`
> - **Senha**: `Colorado@01`


