using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.Context;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

internal class AdicionarTarefaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler AdicionarTareConcluido;

    public IEnumerable<Prioridade> OpcoesPrioridade { get; set; }
    public List<Categoria> OpcoesCategoria { get; set; } = new();

    public ICommand AdicionarTarefaCmd { get; }

    private ITarefaService _tarefaService;

    public AdicionarTarefaViewModel()
    {
        _tarefaService = new TarefaService(new AppDbContext());

        AdicionarTarefaCmd = new RelayCommand(AdicionarTarefa);

        OpcoesPrioridade = Enum.GetValues(typeof(Prioridade)).Cast<Prioridade>();
        PrioridadeSelecionada = Prioridade.Media;

        DataVencimento = DateTime.UtcNow;

        ObterCategorias();

        CategoriaSelecionada = OpcoesCategoria.First();
    }

    public void ObterCategorias()
    {
        var categorias = _tarefaService.ObterCategorias();
        OpcoesCategoria.Clear();
        foreach (var c in categorias) OpcoesCategoria.Add(c);
    }

    public void AdicionarTarefa()
    {
        if (Titulo != null && Descricao != null)
        {
            var tarefa = new Tarefa()
            {
                Titulo = Titulo,
                Descricao = Descricao,
                DataVencimento = DataVencimento,
                Prioridade = PrioridadeSelecionada,
                CategoriaId = CategoriaSelecionada.Id
            };

            _tarefaService.AdicionarTarefa(tarefa);

            // Notifica a view que a tarefa foi adicionada para que ela possa voltar para a página anterior
            AdicionarTareConcluido?.Invoke(this, EventArgs.Empty);
        }
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
