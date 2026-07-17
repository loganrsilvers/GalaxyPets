using GalaxyPets.Components;
using GalaxyPets.Data;
using GalaxyPets.Services; // Partner's services
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. YOUR Database Service
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. PARTNER'S Business Logic Services
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<PetService>();
builder.Services.AddSingleton<ClosetService>();
builder.Services.AddSingleton<ShopService>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<MessageService>();

var app = builder.Build();

// ... (Rest of the pipeline remains the same)
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();