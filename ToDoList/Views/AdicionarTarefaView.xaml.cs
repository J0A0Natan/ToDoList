using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToDoList.Services;
using ToDoList.ViewsModels;

namespace ToDoList.Views;

/// <summary>
/// Interaction logic for AdicionarTarefaView.xaml
/// </summary>
public partial class AdicionarTarefaView : Page
{
    private AdicionarTarefaViewModel _vm;
    public AdicionarTarefaView()
    {
        InitializeComponent();
        _vm = new();
        DataContext = _vm;

        // Quando a tarefa for adicionada com sucesso, volta para a página anterior
        _vm.AdicionarTareConcluido += (s, e) => NavigationService.GoBack();

        Loaded += AdicionarTarefaView_Loaded;
    }

    private void AdicionarTarefaView_Loaded(object sender, RoutedEventArgs e)
    {
        _vm.ObterCategorias();
    }

    private void BtnVoltar_Click(object sender, RoutedEventArgs e)
    {
        if (this.NavigationService.CanGoBack) this.NavigationService.GoBack();
    }

    private void BtnCadastrarCategoria_Click(object sender, RoutedEventArgs e)
    {
        CadastrarCategoriaView view = new();
        this.NavigationService.Navigate(view);
    }
}
