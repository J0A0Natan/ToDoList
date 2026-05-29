using System.Collections.ObjectModel;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

class MainPageViewModel
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    public ObservableCollection<Categoria> Categorias { get; set; } = new();


    public MainPageViewModel()
    {
        ObterTarefasCategorias();
    }

    public void ObterTarefasCategorias()
    {
        using var db = new AppDbContext();
        var tarefas = db.Tarefas;
        var categorias = db.Categorias;

        Tarefas.Clear();
        foreach (var tarefa in tarefas)
        {
            Tarefas.Add(tarefa);
        }

        Categorias.Clear();
        foreach (var categoria in categorias)
        {
            Categorias.Add(categoria);
        }
    }
}
