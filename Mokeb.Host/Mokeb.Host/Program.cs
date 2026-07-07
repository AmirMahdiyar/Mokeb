using Microsoft.EntityFrameworkCore;
using Mokeb.DI;
using Mokeb.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
    });
}).UseKestrel();

builder.Services.AddControllers();
builder.Services.MokebDependencyInjection(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<Mokeb.Host.Exceptions.GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MokebDbContext>();
    db.Database.Migrate();
}
app.UseExceptionHandler();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
