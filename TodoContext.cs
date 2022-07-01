using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


internal class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {
        
    }

    public DbSet<Chore> Chores { get; set; }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Chore>().HasData(
            new Chore { Id = 1, Title = "Clean up the house", Person = "Liam" },
            new Chore { Id = 2, Title = "Take out the trash", Person = "Aria" },
            new Chore { Id = 3, Title = "Mow the lawn", Person = "Liam" },
            new Chore { Id = 4, Title = "Wash the dishes", Person = "Aria" }
        );
    }
    #endregion
}

public class Chore
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    [Required]
    public string Person { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime DoneDate { get; set; }
}