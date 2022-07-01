
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("choresDb")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TodoContext>();
    context.Database.Migrate();
    if (!context.Chores.Any()){
        context.Chores.AddRange(
            new Chore { Title = "Clean up the house", Person = "Liam" },
            new Chore { Title = "Take out the trash", Person = "Aria" },
            new Chore { Title = "Mow the lawn", Person = "Liam" },
            new Chore { Title = "Wash the dishes", Person = "Aria" }
        );
        context.SaveChanges();
    }
}


app.MapGet("/chores", async (TodoContext db) => await db.Chores.ToListAsync());

app.Run();