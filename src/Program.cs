using ShijiMiddlewareTask.MockDatabase;
using ShijiMiddlewareTask.ServiceCollections;


var builder = WebApplication.CreateBuilder(args);

// Default CORS.
builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(p =>
    {
        p.AllowAnyMethod();
        p.AllowAnyHeader();
        p.AllowAnyOrigin();
    });
});

// Add services to the container.
// I grouped my service collections per module to clean the Program.cs class and make it more readable
builder.Services.AddUserServices();
builder.Services.AddSingleton<Database>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Cors must be on top of every other middleware.
app.UseCors();

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