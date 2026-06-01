namespace ToDoList.Models;

internal class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public DateTime? DataVencimento { get; set; }
    public bool Concluida { get; set; } = false;
    public Prioridade Prioridade { get; set; } = Prioridade.Media;

    public int CategoriaId { get; set; } = 1;
    public Categoria Categoria { get; set; } = null!;
}

public enum Prioridade { Baixa, Media, Alta }
