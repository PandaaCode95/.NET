using Microsoft.EntityFrameworkCore;
using UniversityBackend.DataAcces;
using UniversityBackend.Sevices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//1. Todo: Conexion with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
Console.WriteLine(connectionString);
//2.Add Contexto
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));  
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
// add custom service
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CursoService>();
builder.Services.AddScoped<ICategory, CategoryService>();
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

//Usa cors

app.UseCors("CorsPolicy");


app.Run();
