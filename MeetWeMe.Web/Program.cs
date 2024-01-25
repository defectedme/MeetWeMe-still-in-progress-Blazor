using MeetWeMe.Web.Models;
using MeetWeMe.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAutoMapper(typeof(UserProfile));




builder.Services.AddHttpClient<IUsersServices, UsersServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7066");

});

builder.Services.AddHttpClient<ICategoriesServices, CategoriesServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7066");

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
