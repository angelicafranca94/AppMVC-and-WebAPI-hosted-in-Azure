using AutoMapper;
using FiapSchoolSystem.API.Contracts;
using FiapSchoolSystem.API.Services;
using FiapSchoolSystem.Infra;
using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



string dbConnectionString = builder.Configuration["ConnectionString:DefaultConnection"];

// Inject IDbConnection, with implementation from SqlConnection class.
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();


builder.Services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiap System School API");
        c.InjectStylesheet("/swagger/custom.css");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
