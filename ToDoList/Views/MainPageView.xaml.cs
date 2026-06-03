using System.Windows;
using System.Windows.Controls;
using ToDoList.Services;
using ToDoList.ViewsModels;

namespace ToDoList.Views;

/// <summary>
/// Interaction logic for MainPage.xaml
/// </summary>
public partial class MainPage : Page
{
    private MainPageViewModel _vm;
    private AppDbContext _appDbContext;

    public MainPage()
    {
        InitializeComponent();

        _appDbContext = new();

        _vm = new(_appDbContext);

        DataContext = _vm;

        Loaded += MainPage_Loaded;
    }

    private void BtnEditar_Click(object sender, RoutedEventArgs e)
    {
        if (_vm.TarefaSelecionada != null)
        {
            EditarTarefaView view = new(_vm.TarefaSelecionada, _appDbContext);
            this.NavigationService.Navigate(view);
        }
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        _vm.ObterTarefasCategorias();
    }

    private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
    {
        AdicionarTarefaView view = new(_appDbContext);
        this.NavigationService.Navigate(view);
    }
}
