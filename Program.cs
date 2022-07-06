
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("todoDb")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.InitializeDatabase();
}

//app.UseHttpsRedirection();

app.MapGet("/chores", async (TodoContext db) =>
    await db.Chores.Select(c => new { c.Id, c.Title, c.IsDone }).ToListAsync());

app.Run();