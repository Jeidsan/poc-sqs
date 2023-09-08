using SQS.Model;
using Microsoft.AspNetCore.Mvc;
using SQS.Producer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Service>();

var app = builder.Build();

app.MapPost("/", async ([FromServices] Service service, [FromBody] Notification notification) =>
{
    return await service.SendMessage(notification);
});

app.Run();
