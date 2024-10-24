
using System.Reflection;
using TodoApp.MVC.Contracts;
using TodoApp.MVC.Services;
using TodoApp.MVC.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Add Api 

builder.Services.AddHttpClient<IClient, Client>
(c => c.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value));

// Auto Mapper 
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add Services

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




