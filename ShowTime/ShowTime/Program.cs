using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Services;
using ShowTime.Components;
using ShowTime.DataAccess;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;
using ShowTime.DataAccess.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ShowTimeContext");

builder.Services.AddDbContext<ShowTimeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<ILineupService, LineupService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IFestivalService, FestivalService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<ITicketService, TicketService>();

builder.Services.AddTransient<IRepository<Festival>, FestivalRepository>();
builder.Services.AddTransient<IFestivalRepository, FestivalRepository>();
builder.Services.AddTransient<IRepository<Artist>, ArtistRepository>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<IRepository<Lineup>, LineupRepository>();
builder.Services.AddTransient<ILineupRepository, LineupRepository>();
builder.Services.AddTransient<IRepository<User>, BaseRepository<User>>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRepository<Booking>, BookingRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<IRepository<Ticket>, TicketRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();

builder.Services.AddRazorComponents()
.AddInteractiveServerComponents()
.AddInteractiveWebAssemblyComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
    (options =>
    {
        options.Cookie.Name = "auth-token";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Redirect("/");
});


app.Run();
