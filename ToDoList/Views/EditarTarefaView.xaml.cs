using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewsModels;

namespace ToDoList.Views;

/// <summary>
/// Interaction logic for EditarTarefaView.xaml
/// </summary>
public partial class EditarTarefaView : Page
{
    public EditarTarefaView(Tarefa tarefa, AppDbContext appDbContext)
    {
        InitializeComponent();
        EditarTarefaViewModel vm = new(tarefa, appDbContext);
        DataContext = vm;

        vm.SalvarTarefaConcluido += (s, e) => this.NavigationService.GoBack();
    }

    private void BtnVoltar_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (this.NavigationService.CanGoBack) this.NavigationService.GoBack();
    }

    private void BtnCadastrarCategoria_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
