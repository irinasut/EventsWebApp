using EventsApp.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EventsContext");
// Add services to the container.
builder.Services.AddRazorPages();
// Add a database service
builder.Services.AddDbContext<EventsContext>(
    options => options.UseSqlite(connectionString));
// Add an authentication service
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
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middlware
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
