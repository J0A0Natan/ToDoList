using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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

    public AdicionarTarefaViewModel()
    {
        AdicionarTarefaCmd = new RelayCommand(AdicionarTarefa);

        OpcoesPrioridade = Enum.GetValues(typeof(Prioridade)).Cast<Prioridade>();
        PrioridadeSelecionada = Prioridade.Media;

        DataVencimento = DateTime.UtcNow;

        ObterCategorias();

        CategoriaSelecionada = OpcoesCategoria.First();
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

            using var db = new AppDbContext();
            db.Tarefas.Add(tarefa);

            db.SaveChanges();

            // Notifica a view que a tarefa foi adicionada para que ela possa voltar para a página anterior
            AdicionarTareConcluido?.Invoke(this, EventArgs.Empty);
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
