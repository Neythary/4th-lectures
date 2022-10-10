using Buecher_6700970.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// notwendig für die Dependency Injection -> Konfiguriert die Art der Dependency Injection
// erzeugt pro HTTP-Anfrage eine neue Instanz der Klasse
builder.Services.AddScoped<IKonfigurationsLeser, KonfigurationsLeser>();
builder.Services.AddScoped<KonfigurationsLeser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
