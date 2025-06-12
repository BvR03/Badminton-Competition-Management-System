using DAL;
using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using LogicLayer;
using BCM.InfrastructureLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//  Add this line to fix the error
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
builder.Services.AddScoped<EmailPasswordService>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
