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
    /// Interaction logic for AdicionarTarefaView.xaml
    /// </summary>
    public partial class AdicionarTarefaView : Page
    {
        public AdicionarTarefaView()
        {
            InitializeComponent();
            AdicionarTarefaViewModel vm = new();
            DataContext = vm;

            vm.AdicionarTareConcluido += (s, e) => NavigationService.GoBack();
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack) this.NavigationService.GoBack();
        }
    }
}
