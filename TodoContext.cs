using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


internal class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {
        
    }

    public DbSet<Chore> Chores { get; set; }

    
}

public class Chore
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Title { get; set; }
    [Required, MaxLength(50)]
    public string Person { get; set; }
    public bool IsDone => DoneDate.HasValue;
    public DateTime? DueDate { get; set; }
    public DateTime? DoneDate { get; set; }
}