using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToDoList.ViewsModels;

namespace ToDoList.Views;

/// <summary>
/// Interaction logic for AdicionarTarefaView.xaml
/// </summary>
public partial class AdicionarTarefaView : Page
{
    public AdicionarTarefaView()
    {
        InitializeComponent();
        AdicionarTarefaViewModel vm = new();
        DataContext = vm;

        // Quando a tarefa for adicionada com sucesso, volta para a página anterior
        vm.AdicionarTareConcluido += (s, e) => NavigationService.GoBack();
    }

    private void BtnVoltar_Click(object sender, RoutedEventArgs e)
    {
        if (this.NavigationService.CanGoBack) this.NavigationService.GoBack();
    }
}
