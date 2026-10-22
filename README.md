# ToDoList

Aplicação desktop para gerenciamento de tarefas, desenvolvida com WPF e .NET 10. O sistema permite cadastrar, consultar, editar, concluir e excluir tarefas, além de organizar os itens por categorias personalizadas.

## Funcionalidades

- Listagem das tarefas cadastradas.
- Cadastro de tarefas com:
  - título;
  - descrição;
  - data de vencimento;
  - prioridade baixa, média ou alta;
  - categoria.
- Edição de tarefas existentes.
- Marcação de tarefas como concluídas.
- Exclusão de tarefas com confirmação.
- Cadastro de categorias com nome e cor personalizada.
- Persistência local em banco SQLite.
- Categoria inicial `Geral`, criada automaticamente no banco.

## Tecnologias utilizadas

- **C#**
- **.NET 10**
- **WPF (Windows Presentation Foundation)**
- **Entity Framework Core 10**
- **SQLite**
- **MahApps.Metro** para componentes e estilo da janela principal
- **MVVM**, com ViewModels, comandos e data binding do WPF

## Requisitos

- Windows, pois o projeto utiliza `net10.0-windows` e WPF.
- Visual Studio com suporte ao .NET 10 e à carga de trabalho de desenvolvimento para desktop com .NET; ou o SDK do .NET 10 instalado.
- Git, caso o projeto seja obtido pelo repositório remoto.

## Como executar

### Visual Studio

1. Clone o repositório:

   ```powershell
   git clone https://github.com/J0A0Natan/ToDoList.git
   cd ToDoList
   ```

2. Abra `ToDoList.slnx` no Visual Studio.
3. Restaure os pacotes NuGet, se necessário.
4. Defina o projeto `ToDoList` como projeto de inicialização.
5. Execute com `F5` ou `Ctrl+F5`.

### .NET CLI

Na raiz do repositório, execute:

```powershell
dotnet restore ToDoList\ToDoList.csproj
dotnet build ToDoList\ToDoList.csproj
dotnet run --project ToDoList\ToDoList.csproj
```

A execução deve ser feita em um ambiente Windows com os componentes necessários para WPF instalados.

## Persistência de dados

O banco é configurado em `ToDoList/Context/AppDbContext.cs` com a seguinte conexão SQLite:

```text
DataSource=todoapp.db
```

O arquivo `todoapp.db` está localizado no diretório do projeto e armazena as tarefas e categorias. O contexto também insere a categoria padrão `Geral`, com a cor `#3498db`.

Como o banco é local, os dados ficam associados ao ambiente em que a aplicação é executada. Faça uma cópia do arquivo `todoapp.db` caso precise preservar ou transportar os dados.

## Organização do projeto

```text
ToDoList/
├── Commands/
│   └── RelayCommand.cs          # Comandos reutilizáveis para o binding do WPF
├── Context/
│   └── AppDbContext.cs           # Contexto do Entity Framework Core e configuração do SQLite
├── Models/
│   ├── Categoria.cs              # Modelo de categoria
│   └── Tarefa.cs                 # Modelo de tarefa e enumeração de prioridade
├── Services/
│   ├── ITarefaService.cs         # Contrato das operações de tarefas e categorias
│   └── TarefaService.cs          # Implementação das operações de persistência
├── Views/
│   ├── MainWindow.xaml           # Janela principal
│   ├── MainPageView.xaml         # Listagem e ações das tarefas
│   ├── AdicionarTarefaView.xaml   # Formulário de nova tarefa
│   ├── EditarTarefaView.xaml      # Formulário de edição
│   └── CadastrarCategoriaView.xaml# Formulário de categoria
├── ViewsModels/
│   ├── MainPageViewModel.cs
│   ├── AdicionarTarefaViewModel.cs
│   ├── EditarTarefaViewModel.cs
│   └── CadastrarCategoriaViewModel.cs
├── todoapp.db                    # Banco SQLite local
└── ToDoList.csproj               # Configuração do projeto e dependências
```

## Arquitetura e fluxo principal

A aplicação utiliza uma separação baseada em MVVM:

- As **Views** definem a interface em XAML e controlam a navegação entre as páginas.
- Os **ViewModels** expõem propriedades e comandos para o data binding e notificam alterações à interface.
- `TarefaService` centraliza as operações de inclusão, consulta, atualização e exclusão.
- `AppDbContext` representa o banco por meio do Entity Framework Core.
- `Tarefa` possui relacionamento com `Categoria` por meio de `CategoriaId`.

Ao iniciar, `MainWindow` carrega `MainPage`, que consulta as tarefas e categorias. A partir dela, o usuário pode adicionar, editar ou excluir tarefas. Os formulários de tarefa também permitem abrir o cadastro de categorias.

## Modelo de dados

### Tarefa

- `Id`: identificador.
- `Titulo`: título da tarefa.
- `Descricao`: descrição opcional.
- `DataCriacao`: preenchida automaticamente com a data e hora atuais.
- `DataVencimento`: data opcional de vencimento.
- `Concluida`: indica se a tarefa foi concluída.
- `Prioridade`: `Baixa`, `Media` ou `Alta`.
- `CategoriaId`: referência à categoria associada.

### Categoria

- `Id`: identificador.
- `Nome`: nome da categoria.
- `Cor`: cor em formato hexadecimal.

## Estado atual e possíveis evoluções

O projeto já possui o fluxo básico de gerenciamento de tarefas funcionando com persistência local. Não foram identificados projetos de testes automatizados ou uma camada de migrations no conteúdo analisado.

Possíveis evoluções:

- adicionar testes unitários e de integração;
- melhorar validações de campos e mensagens de erro;
- substituir valores nulos por tipos anuláveis nos ViewModels quando aplicável;
- adicionar filtros por status, prioridade e categoria;
- implementar migrations formais do Entity Framework Core;
- separar a configuração do banco da implementação dos ViewModels;
- preparar um processo de publicação e distribuição da aplicação.

## Licença

Nenhuma licença específica foi identificada no conteúdo analisado do repositório.
