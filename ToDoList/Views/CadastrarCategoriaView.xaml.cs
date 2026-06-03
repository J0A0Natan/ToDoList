using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToDoList.ViewsModels;

namespace ToDoList.Views
{
    /// <summary>
    /// Interação lógica para CadastrarCategoriaView.xam
    /// </summary>
    public partial class CadastrarCategoriaView : Page
    {
        public CadastrarCategoriaView()
        {
            InitializeComponent();
            CadastrarCategoriaViewModel vm = new();
            DataContext = vm;

            vm.CadastroCategoriaConcluido += (s, e) => NavigationService.GoBack();
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack) this.NavigationService.GoBack();
        }
    }
}
