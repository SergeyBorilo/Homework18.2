using Microsoft.EntityFrameworkCore;
using University.Application;
using University.Infrastructure;
using University.Persistence;
using University.Persistence.UniversityDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddUniversityDbContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UniversityDbContext>();

    context.Database.Migrate();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
