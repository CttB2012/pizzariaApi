using Repositorios;
using Repositorios.Interfaces;
using Services;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Injecao da Entidade Cliente
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

//Injecao da Entidade Pedido
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

//Injecao da Entidade EnderecoCliente
builder.Services.AddScoped<IEnderecoClienteService, EnderecoClienteService>();
builder.Services.AddScoped<IEnderecoClienteRepositorio, EnderecoClienteRepositorio>();

//Injecao da Entidade Categoria
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();




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
