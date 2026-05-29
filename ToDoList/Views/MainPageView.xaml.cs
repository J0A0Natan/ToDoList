using System.Windows;
using System.Windows.Controls;
using ToDoList.ViewsModels;

namespace ToDoList.Views;

/// <summary>
/// Interaction logic for MainPage.xaml
/// </summary>
public partial class MainPage : Page
{
    private MainPageViewModel _vm;
    public MainPage()
    {
        InitializeComponent();
        _vm = new();
        DataContext = _vm;
        Loaded += MainPage_Loaded;
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        _vm.ObterTarefas();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AdicionarTarefaView view = new();
        this.NavigationService.Navigate(view);
    }
}
