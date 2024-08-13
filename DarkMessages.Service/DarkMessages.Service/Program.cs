
using DarkMessages.Service.Hub;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var builder2 = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);


var baseUrl = "ConectionString:";
IConfiguration configuration = builder2.Build();

GlobalVariables.DataSource = configuration[$"{baseUrl}DataSource"]!;
GlobalVariables.InitialCatalog = configuration[$"{baseUrl}InitialCatalog"]!;
GlobalVariables.UserID = configuration[$"{baseUrl}UserID"]!;
GlobalVariables.Password = configuration[$"{baseUrl}Password"]!;
GlobalVariables.ConnectTimeout = Convert.ToInt32(configuration[$"{baseUrl}ConnectTimeout"]!);
GlobalVariables.Encrypt = Convert.ToBoolean(configuration[$"{baseUrl}Encrypt"]!);
GlobalVariables.TrustServerCertificate = Convert.ToBoolean(configuration[$"{baseUrl}TrustServerCertificate"]!);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/myHub");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.Run();



public static class GlobalVariables
{
    public static string DataSource { get; set; }
    public static string InitialCatalog { get; set; }
    public static string UserID { get; set; }
    public static string Password { get; set; }
    public static int ConnectTimeout { get; set; }
    public static bool Encrypt { get; set; }
    public static bool TrustServerCertificate { get; set; }
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<ChatHub>("/myHub");
        });
    }
}


