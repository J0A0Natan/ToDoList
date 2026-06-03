using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

internal class EditarTarefaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public IEnumerable<Prioridade> OpcoesPrioridade { get; set; } // { get; set; } -> permite que seja setado o valor de fora da classe
    public List<Categoria> OpcoesCategoria { get; set; } = new();

    public ICommand SalvarTarefaCmd { get; }

    private Tarefa _tarefa;

    public EditarTarefaViewModel(Tarefa tarefa)
    {
        OpcoesPrioridade = Enum.GetValues(typeof(Prioridade)).Cast<Prioridade>();
        ObterCategorias();

        _tarefa = tarefa;

        Titulo = _tarefa.Titulo;
        Descricao = _tarefa.Descricao ?? string.Empty;
        DataVencimento = _tarefa.DataVencimento ?? DateTime.Now;
        PrioridadeSelecionada = _tarefa.Prioridade;
        CategoriaSelecionada = _tarefa.Categoria;

        SalvarTarefaCmd = new RelayCommand(SalvarTarefa);
    }

    public void ObterCategorias()
    {
        using var db = new AppDbContext();
        var categorias = db.Categorias;

        OpcoesCategoria.Clear();
        foreach (var cat in categorias)
        {
            OpcoesCategoria.Add(cat);
        }
    }

    private void SalvarTarefa()
    {
        _tarefa.Titulo = Titulo;
        _tarefa.Descricao = Descricao;
        _tarefa.DataVencimento = DataVencimento;
        _tarefa.Prioridade = PrioridadeSelecionada;
        _tarefa.Categoria = CategoriaSelecionada;

        using var db = new AppDbContext();
        db.Tarefas.Update(_tarefa);
        db.SaveChanges();
    }

    private string _titulo;
    public string Titulo
    {
        get => _titulo;
        set
        {
            if (_titulo != value)
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }
    }

    private string _descricao;
    public string Descricao
    {
        get => _descricao;
        set
        {
            if (_descricao != value)
            {
                _descricao = value;
                OnPropertyChanged();
            }
        }
    }

    private DateTime _dataVencimento;
    public DateTime DataVencimento
    {
        get => _dataVencimento;
        set
        {
            if (_dataVencimento != value)
            {
                _dataVencimento = value;
                OnPropertyChanged();
            }
        }
    }

    private Prioridade _prioridadeSelecionada;
    public Prioridade PrioridadeSelecionada
    {
        get => _prioridadeSelecionada;
        set
        {
            _prioridadeSelecionada = value;
            OnPropertyChanged();
        }
    }

    private Categoria _categoriaSelecionada;
    public Categoria CategoriaSelecionada
    {
        get => _categoriaSelecionada;
        set
        {
            if (_categoriaSelecionada != value)
            {
                _categoriaSelecionada = value;
                OnPropertyChanged();
            }
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
