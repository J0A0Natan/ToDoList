using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
