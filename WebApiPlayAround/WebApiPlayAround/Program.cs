using WebApiPlayAround;
using WebApiPlayAround.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSqlServer<ExampleDbContext>("Server=localhost;Database=CancellationTokenDemo;Trusted_Connection=True;TrustServerCertificate=True");
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

// app.UseMiddleware<TaskCanceledExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
