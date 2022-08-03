using Microsoft.EntityFrameworkCore;
using RestApiProje.Context;
using RestApiProje.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddDbContext<BooksDbManager>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BooksDbConnectionString")));
builder.Services.AddDbContext<ClientsDbManager>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ClientsDbConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
