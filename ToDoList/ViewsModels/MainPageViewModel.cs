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
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    public ObservableCollection<Categoria> Categorias { get; set; } = new();

    public ICommand CmdExcluirTarefa { get; }
    public ICommand CmdAlterarConcluida { get; }

    private ITarefaService _tarefaService;

    public MainPageViewModel(AppDbContext appDbContext)
    {
        _tarefaService = new TarefaService(appDbContext);

        CmdExcluirTarefa = new RelayCommand(ExcluirTarefa);
        CmdAlterarConcluida = new RelayCommand(AlterarConcluida);
    }

    public void ObterTarefasCategorias()
    {
        Tarefas.Clear();
        var tarefas = _tarefaService.ObterTarefas();
        foreach (var t in tarefas) Tarefas.Add(t);

        Categorias.Clear();
        var categorias = _tarefaService.ObterCategorias();
        foreach (var c in categorias) Categorias.Add(c);
    }

    private void ExcluirTarefa()
    {
        if (TarefaSelecionada != null)
        {
            var resultado = MessageBox.Show("Deseja realmente excluir esta tarefa?", "Atenção", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                _tarefaService.ExcluirTarefa(TarefaSelecionada);
                MessageBox.Show($"{TarefaSelecionada.Titulo} excluida");
                ObterTarefasCategorias();
            }
        }
    }

    private void AlterarConcluida()
    {
        if (TarefaSelecionada != null)
        {
            _tarefaService.AtualizarTarefa(TarefaSelecionada);
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
