using BackendApi.Models; // para reconocer tu AppDbContext BD
using Microsoft.EntityFrameworkCore; //para usar UseSqlServer BD

var builder = WebApplication.CreateBuilder(args);
//lunes27
//BD builder.Services...
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirVue", policy =>
    {
        policy
        .WithOrigins("http://localhost:5173")//cambiar dependiendo el puerto ejemp: 5230, 5289, 5208
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//para conectar con la base de datos configurada en appsettings.json BD
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//lunes27 mapear controlls
app.UseCors("PermitirVue");


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
