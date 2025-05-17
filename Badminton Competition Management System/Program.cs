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
builder.Services.AddScoped<PlayerLogic>();
builder.Services.AddScoped<IPlayerData, PlayerData>();
builder.Services.AddScoped<ISeasonData, SeasonData>();
builder.Services.AddScoped<SeasonLogic>();




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
