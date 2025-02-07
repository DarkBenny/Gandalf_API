using Gandalf.Admin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddHttpClient<CategoryService>(options =>
{
    options.BaseAddress = new Uri("http://localhost:5211");
});

builder.Services.AddScoped<ProductService>();
builder.Services.AddHttpClient<ProductService>(options =>
{
    options.BaseAddress = new Uri("http://localhost:5211");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
