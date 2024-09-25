using Transport.WebAppMvc;

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices.RegisterServices(builder.Services, builder.Configuration);
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
//pattern: "{area=Admin}/{controller=Product}/{action=Index}/{id?}");
//pattern: "{controller=DashBoard}/{action=Index}/{id?}");
pattern: "{area=Account}/{controller=Login}/{action=Index}/{id?}");


app.Run();
