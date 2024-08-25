using gls_assignment.Configurations;
using gls_assignment.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DbServiceOptions>(builder.Configuration.GetSection("DbServiceOptions"));
// Add the service and inject options into it
builder.Services.AddTransient<IDbService, DbService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Indextest}/{id?}");

app.Run();
