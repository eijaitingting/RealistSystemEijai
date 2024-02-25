using Microsoft.AspNetCore.Authentication.Cookies;
using ReaList.Library.DataAccess.Admin;
using ReaList.Library.DataAccess.Agents;
using ReaList.Library.DataAccess.Complaints;
using ReaList.Library.DataAccess.Customers;
using ReaList.Library.DataAccess.Notifications;
using ReaList.Library.DataAccess.Properties;
using ReaList.Library.DataAccess.Subscriptions;
using ReaList.Library.DataAccess.Testimonials;
using ReaList.Library.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IAdminAccountDataAccess, AdminAccountDataAccess>();
builder.Services.AddSingleton<IGetAllAgentDataAccess, GetAllAgentDataAccess>();
builder.Services.AddSingleton<IGetAllCustomersDataAccess, GetAllCustomersDataAccess>();
builder.Services.AddSingleton<IGetAllPropertiesDataAccess, GetAllPropertiesDataAccess>();
builder.Services.AddSingleton<IGetAllComplaintDataAccess, GetAllComplaintDataAccess>();
builder.Services.AddSingleton<IGetAllTestimonialDataAccess, GetAllTestimonialDataAccess>();
builder.Services.AddSingleton<IGetAllNotificationDataAccess, GetAllNotificationDataAccess>();
builder.Services.AddSingleton<IGetAllSubscriptionDataAccess, GetAllSubscriptionDataAccess>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { options.Cookie.Name = "sample_crudss"; });

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
