using Microsoft.EntityFrameworkCore;
using Policy.Application.DTO;
using Policy.Application.Interface;
using Policy.Application.Mapping;
using Policy.Infrastructure.Data;
using Policy.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddHttpClient<CustomerClient>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["CustomerAddress"] ?? "https://localhost:7047");
});

builder.Services.AddScoped<IPolicyService, PolicyService>();
builder.Services.AddScoped<IPolicyTypeService, PolicyTypeService>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();