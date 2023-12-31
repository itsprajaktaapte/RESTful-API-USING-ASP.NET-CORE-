

using Microsoft.EntityFrameworkCore;
using MyWebApp.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

// dependency injection
builder.Services.AddDbContext<CustomerDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDataConnection")));

// add services here

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
else 
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
//very imp step
app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/", () => "Hello World!");
app.Run();
