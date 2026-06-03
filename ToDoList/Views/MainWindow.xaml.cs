using System.Windows;
using ToDoList.Views;
using MahApps.Metro.Controls;

namespace ToDoList;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();
        main.Content = new MainPage();
    }
}
