using InquiryPlate.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=.;Database=Inquiry_Db;Integrated Security=True;");
});

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


#region auto apply migration
using (IServiceScope scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        await context?.Database.MigrateAsync();
        DBInitializer.Initialize(context);
    }
    catch (Exception)
    {
    }
}

#endregion

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=InquiryPlate}/{action=Index}");

app.Run();
