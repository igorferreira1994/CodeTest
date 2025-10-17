using CodeTest.Application.Service;
using CodeTest.Domain;
using CodeTest.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICnabRepository, CnabRepository>();
builder.Services.AddScoped<ICnabParser, CnabParser>();
builder.Services.AddScoped<ICnabService, CnabService>();
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Upload}/{id?}");
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API CNAB v1");
    options.InjectStylesheet("/swagger-custom.css");
    options.InjectJavascript("/swagger-custom.js");
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();