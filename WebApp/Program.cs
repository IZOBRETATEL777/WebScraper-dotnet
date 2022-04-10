using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddScoped<ISearchItemService, SearchItemServiceImpl>();
builder.Services.AddScoped<IResutlSorting, ResutlSortingServiceImpl>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
);
app.MapControllerRoute(
    name: "search",
    pattern: "{controller=Search}/{action=SearchItem}"
);

app.Run();
