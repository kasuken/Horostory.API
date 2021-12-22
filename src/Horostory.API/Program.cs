using Horostory.API;
using Horostory.API.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo()
{
    Description = "Horostory API",
    Title = "Horostory API",
    Version = "v1",
    Contact = new OpenApiContact()
    {
        Name = "Emanuele Bartolesi",
        Url = new Uri("https://github.com/kasuken")
    }
}));
builder.Services.AddCors(options => options.AddPolicy("AnyOrigin", o => o.AllowAnyOrigin()));

builder.Services.AddScoped<IHorostoryService, KudosmediaHorostoryService>();

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.RegisterRoutes();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Horostory API v1");
    c.RoutePrefix = string.Empty;
});

app.Run();