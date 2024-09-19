using PinewoodTechTaskAPI.Config;

var builder = WebApplication.CreateBuilder(args);
var config = new Config();
// Add services to the container.
builder.Configuration.Bind("AppConfig", config);

builder.Services.AddServices(config);

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

app.Run();
