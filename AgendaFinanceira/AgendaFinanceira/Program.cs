using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Infraestrutura.Repositories;
using AgendaFinanceira.Infraestrutura.Services;
using AgendaFinanceira.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IContasRepository, ContasRepository>();
builder.Services.AddTransient<ICategoriasRepository, CategoriaRepository>();
builder.Services.AddTransient<ITransacoesRepository, TransacoesRepository>();
builder.Services.AddTransient<IDespesasRepository, DespesasRepository>();
builder.Services.AddTransient<IReceitaRepository, ReceitaRepository>();
builder.Services.AddHttpClient<CotacaoService>();

builder.Services.AddTransient<IMetasFinanceirasRepository, MetasFinanceirasRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "MyPolicy",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
