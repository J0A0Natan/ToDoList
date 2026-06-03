using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services;

public class AppDbContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=todoapp.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed: cria uma categoria padrão já no banco
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Geral", Cor = "#3498db" }
        );
    }
}
