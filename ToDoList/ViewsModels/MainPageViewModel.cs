using System.Collections.ObjectModel;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

class MainPageViewModel
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();


    public MainPageViewModel()
    {
        ObterTarefas();
    }

    public void ObterTarefas()
    {
        using var db = new AppDbContext();
        var tarefas = db.Tarefas;

        Tarefas.Clear();
        foreach (var tarefa in tarefas)
        {
            Tarefas.Add(tarefa);
        }
    }
}
