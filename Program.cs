using BooksStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BooksStoreDbContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:BooksStoreConnection"]));
builder.Services.AddScoped<IBooksStoreRepository, EFBooksStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<MyCart>(sp => MySessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this 
    // for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("genpage",
                         "{genre}/{bookPage:int}",
                    new { Controller = "Home", action = "Index" });
    endpoints.MapControllerRoute("page", "{bookPage:int}",
        new { Controller = "Home", action = "Index", bookPage = 1 });
    endpoints.MapControllerRoute("genre", "{genre}",
        new { Controller = "Home", action = "Index", bookPage = 1 });
    endpoints.MapControllerRoute("pagination", "Books/Page{bookPage}",
        new { Controller = "Home", action = "Index", bookPage = 1 });
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulated(app);

app.Run();
