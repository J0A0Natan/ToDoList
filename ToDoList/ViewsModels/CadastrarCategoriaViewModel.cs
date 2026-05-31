using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewsModels;

class CadastrarCategoriaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler CadastroCategoriaConcluido;

    public ICommand CmdCadastrar { get; }

    public CadastrarCategoriaViewModel()
    {
        CmdCadastrar = new RelayCommand(CadastrarCategoria);
    }

    public void CadastrarCategoria()
    {
        if (Nome != null && Cor != null)
        {
            Categoria categoria = new()
            {
                Nome = Nome,
                Cor = Cor
            };

            using var db = new AppDbContext();
            db.Categorias.Add(categoria);
            db.SaveChanges();

            CadastroCategoriaConcluido?.Invoke(this, EventArgs.Empty);
        }
    }

    private string _nome;
    public string Nome
    {
        get => _nome;
        set
        {
            if (_nome != value)
            {
                _nome = value;
                OnPropertyChanged();
            }
        }
    }

    private string _cor;
    public string Cor
    {
        get => _cor;
        set
        {
            if (_cor != value)
            {
                _cor = value;
                OnPropertyChanged();
            }
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
