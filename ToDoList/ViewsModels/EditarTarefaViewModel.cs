using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

internal class EditarTarefaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler SalvarTarefaConcluido;

    public IEnumerable<Prioridade> OpcoesPrioridade { get; set; } // { get; set; } -> permite que seja setado o valor de fora da classe
    public List<Categoria> OpcoesCategoria { get; set; } = new();

    public ICommand SalvarTarefaCmd { get; }

    private ITarefaService _tarefaService;

    private Tarefa _tarefa;
    
    public EditarTarefaViewModel(Tarefa tarefa, AppDbContext appDbContext)
    {
        OpcoesPrioridade = Enum.GetValues(typeof(Prioridade)).Cast<Prioridade>();

        _tarefaService = new TarefaService(appDbContext);

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
        var categorias = _tarefaService.ObterCategorias();
        OpcoesCategoria.Clear();
        foreach (var c in categorias) OpcoesCategoria.Add(c);
    }

    public void SalvarTarefa()
    {
        _tarefa.Titulo = Titulo;
        _tarefa.Descricao = Descricao;
        _tarefa.DataVencimento = DataVencimento;
        _tarefa.Prioridade = PrioridadeSelecionada;
        _tarefa.Categoria = CategoriaSelecionada;

        _tarefaService.AtualizarTarefa(_tarefa);

        SalvarTarefaConcluido?.Invoke(this, EventArgs.Empty);
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
