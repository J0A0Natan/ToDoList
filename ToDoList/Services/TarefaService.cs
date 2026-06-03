using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.Services;

internal class TarefaService : ITarefaService, IDisposable
{
    private AppDbContext db;

    public TarefaService(AppDbContext dbContext)
    {
        db = dbContext;
    }

    public void Dispose()
    {
        db.Dispose();
    }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        db.Tarefas.Add(tarefa);
        db.SaveChanges();
    }

    public void AdicionarCategoria(Categoria categoria)
    {
        db.Categorias.Add(categoria);
        db.SaveChanges();
    }

    public void AtualizarTarefa(Tarefa tarefa)
    {
        db.Tarefas.Update(tarefa);
        db.SaveChanges();
    }

    public void ExcluirTarefa(Tarefa tarefa)
    {
        db.Tarefas.Remove(tarefa);
        db.SaveChanges();
    }

    public ObservableCollection<Tarefa> ObterTarefas()
    {
        var tarefas = db.Tarefas.ToList();

        //[.. tarefas] -> operador de espalhamento, ele pega cada item da coleção e adiciona na nova coleção
        ObservableCollection<Tarefa> tarefasRetorno = [.. tarefas];

        return tarefasRetorno;
    }

    public ObservableCollection<Categoria> ObterCategorias()
    {
        var categorias = db.Categorias.ToList();

        //[.. tarefas] -> operador de espalhamento, ele pega cada item da coleção e adiciona na nova coleção
        ObservableCollection<Categoria> categoriasRetorno = [.. categorias];

        return categoriasRetorno;
    }
}
