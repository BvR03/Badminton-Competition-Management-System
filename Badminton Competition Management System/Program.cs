using DAL;
using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using LogicLayer;
using BCM.InfrastructureLayer;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddScoped<ISeasonRepo, SeasonRepo>();
builder.Services.AddScoped<SeasonService>();
builder.Services.AddScoped<ITeamRepo, TeamRepo>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<ISeasonalTeamRepo, SeasonalTeamRepo>();
builder.Services.AddScoped<SeasonalTeamService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IMatchRepo, MatchRepo>();
builder.Services.AddScoped<MatchService>();
builder.Services.AddScoped<EmailHandler>();





var config = builder.Configuration;
var env = builder.Environment;
var connectionString = env.IsDevelopment()
    ? config.GetConnectionString("LocalConnection")
    : config.GetConnectionString("DefaultConnection");
DAL.DatabaseManager.SetConnectionString(connectionString);
var EmailPassword = builder.Configuration["EmailHost:EmailPW"];
LogicLayer.EmailService.SetEmailPassword(EmailPassword);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/plain";

            var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
            var error = exceptionFeature?.Error;

            if (error != null)
            {
                try
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(error, "An unhandled exception occurred.");

                    var emailService = context.RequestServices.GetRequiredService<EmailService>();
                    await Task.Run(() =>
                    {
                        emailService.SetUpEmail(
                            "Unhandled Exception in BCM",
                            "bvrhelpdesk3@gmail.com",
                            $"Exception: {error.Message}\n\nStackTrace:\n{error.StackTrace}"
                        );
                    });
                }
                catch (Exception innerEx)
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(innerEx, "Error while sending failure email.");
                }
            }

            context.Response.Redirect("/Error");
        });

    });

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
