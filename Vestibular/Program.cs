using Microsoft.EntityFrameworkCore;
using Vestibular.DependencyInjection;
using Vestibular.Repository;

var builder = WebApplication.CreateBuilder(args);

// Container / Serviços.
builder.Services.AddDbContext<VestibularDbContext>(options => options.UseSqlite("Data Source=../Vestibular.Repository/Vestibular.db"));
Register.RegisterRepositories(builder.Services);
builder.Services.AddControllers();

// Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
