# Projeto de Gerenciamento de Tarefas

Este projeto consiste em um sistema de gerenciamento de tarefas, com duas classes principais: `UsuarioController` e `TarefasController`. O código está escrito em C# usando o framework ASP.NET Core.

#### UsuarioController
A classe `UsuarioController` gerencia operações relacionadas aos usuários, como cadastro, atualização, exclusão, login e obtenção de tarefas associadas a um usuário.

##### Métodos:
- ***GetAll:** Obtém todos os usuários cadastrados.
- **Get:** Obtém um usuário com base no ID fornecido.
- **Create:** Cria um novo usuário.
- **Update:** Atualiza as informações de um usuário.
- **Delete:** Exclui um usuário com base no ID fornecido.
- **GetUsuariosToTarefa:** Obtém a lista de tarefas associadas a um usuário.
- **Login:** Realiza a autenticação de um usuário com base no nome de usuário e senha fornecidos.

#### TarefasController
A classe `TarefasController` gerencia operações relacionadas às tarefas, como cadastro, atualização, exclusão e obtenção de tarefas com diferentes filtros.

##### Métodos:
- **GetAll:** Obtém todas as tarefas cadastradas.
- **Get:** Obtém uma tarefa com base no ID fornecido.
- **Create:** Cria uma nova tarefa.
- **Update:** Atualiza as informações de uma tarefa.
- **Delete:** Exclui uma tarefa com base no ID fornecido.
- **GetTarefasToConluidas:** Obtém todas as tarefas concluídas.
- **GetTarefasToNaoConluidas:** Obtém todas as tarefas não concluídas.
- **PeriodoConclusao:** Obtém tarefas dentro de um determinado período de conclusão.
- **PeriodoVencimento:** Obtém tarefas dentro de um determinado período de vencimento.
- **Usuario:** Obtém o usuário associado a uma determinada tarefa.

#### Configuração

Certifique-se de configurar corretamente o contexto da API (`ApiContext`) ao instanciar os controladores, para que as operações de banco de dados sejam realizadas adequadamente.

```csharp
// Exemplo de configuração do contexto
var apiContext = new ApiContext(/* Configurações de conexão com o banco de dados */);
var usuarioController = new UsuarioController(apiContext);
var tarefasController = new TarefasController(apiContext);
```

#### Configuração do Banco de Dados
Certifique-se de configurar corretamente o contexto da API (`ApiContext`) para utilizar o banco de dados MySQL. Adicione a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=NomeDoSeuBanco;User=SeuUsuario;Password=SuaSenha;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```
#### Observação
Certifique-se de criar o banco de dados antes de executar o projeto, utilizando as migrações do Entity Framework Core:

    dotnet ef migrations add InitialCreate
    dotnet ef database update

Este é um projeto básico que pode ser expandido com recursos adicionais, autenticação, autorização e melhorias de segurança, dependendo dos requisitos específicos do sistema.
