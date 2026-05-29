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
        MainPageViewModel vm = new();
        DataContext = vm;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AdicionarTarefaView view = new();
        this.NavigationService.Navigate(view);
    }
}
