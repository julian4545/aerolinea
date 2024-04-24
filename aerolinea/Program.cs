using aerolinea.dbcontext;
using aerolinea.Repositories;
using aerolinea.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AgriversoDbcontext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<ITripulacionService, TripulacionService>();
builder.Services.AddScoped<IVueloRepo, VueloRepositories>();
// Repite esto para cada servicio y repositorio necesario.


builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<ITripulacionRepo, TripulacionRepositories>();


builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IReservaRepo, ReservaRepository>();


builder.Services.AddScoped<IPasajeroService, PasajeroService>();
builder.Services.AddScoped<IPasajeroRepo, PasajeroRepository>();



builder.Services.AddScoped<IAvionService, AvionService>();
builder.Services.AddScoped<IAvionRepo, AvionRepository>();


builder.Services.AddScoped<IAsientoService, AsientoService>();
builder.Services.AddScoped<IAsientoRepo, AsientoRepository>();






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
