using Microsoft.EntityFrameworkCore;
using UniversityBackend;
using UniversityBackend.DataAcces;
using UniversityBackend.Sevices;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Serilog;

//Use serilog



var builder = WebApplication.CreateBuilder(args);

//Config serilog

builder.Host.UseSerilog((hotsBuilderCtx, loggerConf) =>
{
    loggerConf.WriteTo.Console().WriteTo.Debug().ReadFrom.Configuration(hotsBuilderCtx.Configuration);
});

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
//Localization 

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

var supportedCultures = new[] { "en-US", "es-Es", "fr-FR" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0]).AddSupportedCultures(supportedCultures);


builder.Services.AddSwaggerGen();
//Swagger ocn JWT
builder.Services.AddSwaggerGen(option =>
{
    //Security
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme({
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
        },
         new string[]{}
        }
    }) ;
});
//Add Authorization

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("UserPolicy", policy => policy.RequireClaim("UserOnly", "User"));
});
//JWT

builder.Services.AddJwtTokenServices(builder.Configuration);

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

//Login serilog
app.UseSerilogRequestLogging();
app.UseRequestLocalization(localizationOptions);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Usa cors

app.UseCors("CorsPolicy");


app.Run();
