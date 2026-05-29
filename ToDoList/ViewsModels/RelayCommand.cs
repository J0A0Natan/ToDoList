using System.Windows.Input;

namespace ToDoList.ViewsModels;

// RelayCommand serve para facilitar a criação de comandos para a interface do usuário, permitindo que as ações sejam vinculadas a métodos específicos no ViewModel.
// Ele implementa a interface ICommand, que é usada para definir comandos em WPF.
// O RelayCommand aceita um Action para a execução do comando e um Func<bool> opcional para determinar se o comando pode ser executado.
// Isso permite uma separação clara entre a lógica de negócios e a interface do usuário, promovendo um design mais limpo e testável.
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
    public void Execute(object parameter) => _execute();
    public event EventHandler CanExecuteChanged;
}
