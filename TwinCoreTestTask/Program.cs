using Hangfire;
using TwinCoreTestTask.DataBase.Utils;
using TwinCoreTestTask.Infrastructure.Utils;
using TwinCoreTestTask.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext();
builder.Services.AddServices();

builder.Services.ConfigureAuth();
builder.Services.ConfigureBruteForceProtection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHangfireDashboard();
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}

ServicesProviderExtensions.AddBackgroundJobs();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html"); // This is missing!

await app.RunAsync();
