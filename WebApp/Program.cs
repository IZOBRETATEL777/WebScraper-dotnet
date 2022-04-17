using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddScoped<ISearchItemService, SearchItemServiceImpl>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Search}/{action=SearchPage}"
);
app.MapControllerRoute(
    name: "search",
    pattern: "{controller=Result}/{action=ResultPage}"
);

app.Run();
