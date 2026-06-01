using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

class MainPageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    public ObservableCollection<Categoria> Categorias { get; set; } = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand CmdExcluirTarefa { get; }
    public ICommand CmdAlterarConcluida { get; }

    public MainPageViewModel()
    {
        ObterTarefasCategorias();

        CmdExcluirTarefa = new RelayCommand(ExcluirTarefa);
        CmdAlterarConcluida = new RelayCommand(AlterarConcluida);
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

    public void ExcluirTarefa()
    {
        if (TarefaSelecionada != null)
        {
            var resultado = MessageBox.Show("Deseja realmente excluir esta tarefa?", "Atenção", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                using var db = new AppDbContext();
                db.Tarefas.Remove(TarefaSelecionada);
                db.SaveChanges();
                MessageBox.Show($"{TarefaSelecionada.Titulo} excluida");
                ObterTarefasCategorias();
            }
        }
    }

    public void AlterarConcluida()
    {
        if (TarefaSelecionada != null)
        {
            using var db = new AppDbContext();
            db.Tarefas.Update(TarefaSelecionada);
            db.SaveChanges();
        }
    }

    private Tarefa _tarefaSelecionada;
    public Tarefa TarefaSelecionada
    {
        get => _tarefaSelecionada;
        set
        {
            if (_tarefaSelecionada != value)
            {
                _tarefaSelecionada = value;
                OnPropertyChanged();
            }
        }
    }

    private bool _concluida;
    public bool Concluida
    {
        get => _concluida;
        set
        {
            if (_concluida != value)
            {
                _concluida = value;
                OnPropertyChanged();
            }
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
