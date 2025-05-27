using DAL;
using InterfaceLayer;
using InterfaceLayer.DALInterfaces;
using LogicLayer;

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
