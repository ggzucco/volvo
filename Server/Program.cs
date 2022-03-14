using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using volvo.DBC.EFCoreSqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SqliteContext>(options => options.UseSqlite("Data Source=VolvoDb.db;", b => b.MigrationsAssembly("volvo.Server")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

SqliteContext context = new SqliteContext(new DbContextOptions<SqliteContext>());
context.Database.Migrate();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
