using Gerenciamento.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
string StringConection = "Host=ep-frosty-truth-a4z5gatv-pooler.us-east-1.aws.neon.tech;Port=5432;Pooling=true;Database=verceldb;User Id=default;Password=LoIZmW0BiPJ7";

// Add services to the container.
builder.WebHost.UseUrls($"http://*:{port}");
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>(opt => 
    opt.UseNpgsql(StringConection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x =>
{
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
