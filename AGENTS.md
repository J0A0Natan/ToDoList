# AGENTS.md — ToDoList

## Projeto

WPF .NET 10 (`net10.0-windows`), MVVM, MahApps.Metro 2.4.11, EF Core + SQLite.

## Comandos

```powershell
dotnet build        # compila
dotnet run          # executa (deve estar em ToDoList/)
```

Não há testes, linter ou formatador configurados.

## Arquitetura

| Diretório         | Finalidade                            |
|-------------------|---------------------------------------|
| `Models/`         | `Tarefa`, `Categoria`, enum `Prioridade` |
| `Views/`          | Pages WPF (`Page`) + `MainWindow` (`MetroWindow`) |
| `ViewsModels/`    | ViewModels + `RelayCommand` customizado |
| `Services/`       | `AppDbContext` (SQLite)               |
| `Commands/`       | vazio — comandos ficam nos ViewModels |

- Navegação via `Frame` + `NavigationService` (WPF Pages).
- `AppDbContext` é instanciado com `using` dentro de cada método — *não* usa DI.
- Banco SQLite local: `todoapp.db` (gerado na pasta de saída).
- Categoria padrão "Geral" semeada via `HasData` no `OnModelCreating`.
- Idioma da UI: **pt-br** — nomes de views, botões, labels e mensagens em português.

## Convenções

- `ViewsModels/` (com "s" — não "ViewModels").
- Namespace raiz `ToDoList`.
- ViewModels são `internal` ou `class` sem modificador; não seguem padrão único.
- `RelayCommand` não é genérico — usa `Action` e `Func<bool>`, sem `CommandParameter` tipado.
- Projeto no formato `.slnx` (solution XML).