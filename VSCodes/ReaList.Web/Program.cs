using ReaList.Library.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using ReaList.Library.DataAccess.AgentAccount;
using ReaList.Library.DataAccess.CustomerAccount;
using ReaList.Library.DataAccess.Property;
using ReaList.Library.DataAccess.Testimony;
using ReaList.Library.DataAccess.Complaint;
using ReaList.Library.DataAccess.Booking;
using ReaList.Library.DataAccess.AdminAccount;
using ReaList.Library.DataAccess.Subscription;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IAgentAccountDataAccess, AgentAccountDataAccess>();
builder.Services.AddSingleton<ICustomerAccountDataAccess, CustomerAccountDataAccess>();
builder.Services.AddSingleton<IAdminAccountDataAccess, AdminAccountDataAccess>();
builder.Services.AddSingleton<IPropertyDataAccess, PropertyDataAccess>();
builder.Services.AddSingleton<ITestimonyDataAccess, TestimonyDataAccess>();
builder.Services.AddSingleton<IComplaintDataAccess, ComplaintDataAccess>();
builder.Services.AddSingleton<IBookingDataAccess, BookingDataAccess>();
builder.Services.AddSingleton<ISubscriptionDataAccess, SubscriptionDataAccess>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { options.Cookie.Name = "sample_crudss";});

// File upload configuration
builder.Services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Login}/{id?}");
});

app.Run();
