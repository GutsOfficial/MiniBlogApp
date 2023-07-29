using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IBlogRepository, EfBlogRepository>();
builder.Services.AddTransient<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BlogContext>(options => {
    
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BlogDatabase;Trusted_Connection=True;", b=>b.MigrationsAssembly("BlogAppWebUI"));
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
app.UseStatusCodePages();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
