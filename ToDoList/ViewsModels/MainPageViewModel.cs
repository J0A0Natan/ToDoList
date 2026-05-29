using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
//using ToDoList.Data;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

class MainPageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainPageViewModel()
    {
        ObterTarefas();
    }

    private AppDbContext ObterTarefas()
    {
        using var db = new AppDbContext();
        var tarefas = db.Tarefas;

        Tarefas.Clear();
        foreach (var tarefa in tarefas)
        {
            Tarefas.Add(tarefa);
        }

        return db;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
