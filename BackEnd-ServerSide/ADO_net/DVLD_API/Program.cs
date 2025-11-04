
using DVLD_DataAccessLayer_EF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//********************************************************
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React default port
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//********************************************************

// Add services to the container.
builder.Services.AddDbContext<DVLD_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DVLD")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add file logging
var path = System.AppContext.BaseDirectory;
builder.Logging.AddFile(Path.Combine(path, "logs/DVLD_API.log")); // Logs will be saved here

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//********************************************************

// Configure the HTTP pipeline
app.UseCors("AllowReactApp"); // Enable CORS
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//********************************************************



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
