using Microsoft.EntityFrameworkCore;
using RentalHub.Application;
using RentalHub.Application.Interfaces;
using RentalHub.Repository;
using RentalHub.Repository.Contexts;
using RentalHub.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentalHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Repositories DI

builder.Services.AddScoped<IRentalHubRepository, RentalHubRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ILocadoraRepository, LocadoraRepository>();
builder.Services.AddScoped<IMontadoraRepository, MontadoraRepository>();
builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<ILogVeiculoRepository, LogVeiculoRepository>();

#endregion

#region Services DI

builder.Services.AddScoped<IRentalHubService, RentalHubService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<ILocadoraService, LocadoraService>();
builder.Services.AddScoped<IMontadoraService, MontadoraService>();
builder.Services.AddScoped<IModeloService, ModeloService>();
builder.Services.AddScoped<ILogVeiculoService, LogVeiculoService>();

#endregion

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
