using Microsoft.EntityFrameworkCore;
using ProjetFinalBD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BD1_BengalsCincinnati_TP1Context>(
   options => {
   options.UseSqlServer(builder.Configuration.GetConnectionString("BD1_BengalsCincinnati_TP1"));
       options.UseLazyLoadingProxies();
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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Players}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
