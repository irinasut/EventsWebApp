using EventsApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EventsContext");
// Add services to the container.
builder.Services.AddRazorPages();
// Add a database service
builder.Services.AddDbContext<EventsContext>(
    options => options.UseSqlite(connectionString));
// add an authentication service
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// middlware
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
