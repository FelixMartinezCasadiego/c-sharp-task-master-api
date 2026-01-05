using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName?.Replace(".", "_"));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskMaster API",
        Version = "v1",
        Description = "API para gestionar tareas"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi().AllowAnonymous();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


