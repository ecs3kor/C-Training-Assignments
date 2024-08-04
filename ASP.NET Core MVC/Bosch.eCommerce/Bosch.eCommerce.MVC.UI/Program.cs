using Bosch.eCommerce.DAL;
using Bosch.eCommerce.Models;
using Bosch.eCommerce.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;
using Bosch.Security;
using Microsoft.AspNetCore.Identity;
using Bosch.eCommerce.MVC.UI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});
string? ConStr = builder.Configuration.GetConnectionString("BoschECommerceConStr");
string? SecurityConStr = builder.Configuration.GetConnectionString("BoschSecurityConStr");

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ECommerceDBContext>(options =>
{
    options.UseSqlServer(ConStr);
});
builder.Services.AddDbContext<BoschSecurityContext>(options =>
{
    options.UseSqlServer(SecurityConStr);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<BoschSecurityContext>();

builder.Services.Configure<RazorPaySettings>(builder.Configuration.GetSection("Razorpay"));
builder.Services.AddControllersWithViews(configure =>
{
    configure.Filters.Add(new GlobalFilter());
});
builder.Services.AddTransient<ICommonRepository<Category>,CommonRepository<Category>>();
builder.Services.AddTransient<ICommonRepository<Product>, CommonRepository<Product>>();
builder.Services.AddTransient<ICommonRepository<Customer>, CommonRepository<Customer>>();
builder.Services.AddTransient<ICommonRepository<Cart>, CommonRepository<Cart>>();
builder.Services.AddTransient<ICommonRepository<CartItem>, CommonRepository<CartItem>>();
builder.Services.AddTransient<ICommonRepository<Invoice>, CommonRepository<Invoice>>();
builder.Services.AddTransient<IGenerateCart, GenerateCart>();

builder.Services.AddAutoMapper(Assembly.Load(new AssemblyName("Bosch.eCommerce.MVC.UI")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");





app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Customer" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
//Creating Users  - This block will get executed everytime the application starts/restarts. We are seeding the users
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    string adminUser = "admin@ecommerce.com";
    string adminPassword = "Welcome@123";
    if (await userManager.FindByEmailAsync(adminUser) == null)
    {
        var user = new IdentityUser(adminUser) { UserName = adminUser, Email = adminUser };
        await userManager.CreateAsync(user, adminPassword);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}


app.Run();
