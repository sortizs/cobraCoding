using Microsoft.EntityFrameworkCore;
using CobraCoding.Data;

var specificOrigins = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CobraCodingContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CobraDb")));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(specificOrigins, policy => policy
                                            .AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedCars.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(specificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

