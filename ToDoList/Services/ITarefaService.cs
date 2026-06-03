using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

internal interface ITarefaService
{
    public ObservableCollection<Tarefa> ObterTarefas();
    public ObservableCollection<Categoria> ObterCategorias();
    public void AdicionarTarefa(Tarefa tarefa);
    public void AtualizarTarefa(Tarefa tarefa);
    public void ExcluirTarefa(Tarefa tarefa);
}
