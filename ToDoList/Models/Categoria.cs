namespace ToDoList.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cor { get; set; } = "#3498db"; // hex da cor

    internal ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}
