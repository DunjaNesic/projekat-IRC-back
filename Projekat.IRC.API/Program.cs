using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.DataAccessLayer;
using Projekat.IRC.BusinessLogic;
using Projekat.IRC.Logging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ModelsContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton<ILoggger, ConsoleLogger>();
builder.Services.AddTransient<IOpremaLogic, OpremaLogic>();
builder.Services.AddTransient<IProstorijaLogic, ProstorijaLogic>();
builder.Services.AddTransient<ITipOpremeLogic, TipOpremeLogic>();
builder.Services.AddTransient<IZaposleniLogic, ZaposleniLogic>();
builder.Services.AddTransient<IZaduzenjeLogic, ZaduzenjeLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
