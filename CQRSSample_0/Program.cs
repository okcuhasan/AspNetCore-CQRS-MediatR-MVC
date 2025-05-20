using CQRSSample_0.CQRS.Handlers.CategoryHandlers.Modify;
using CQRSSample_0.CQRS.Handlers.CategoryHandlers.Read;
using CQRSSample_0.Models.ContextClasses;
using CQRSSample_0.Repositories.Abstracts;
using CQRSSample_0.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<MyContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CQRSSampleConnection")));

/* constructor hell problem may occur without using mediatr */
//builder.Services.AddScoped<GetCategoryQueryHandler>();
//builder.Services.AddScoped<GetCategoryByIDQueryHandler>();
//builder.Services.AddScoped<CreateCategoryCommandHandler>();
//builder.Services.AddScoped<UpdateCategoryCommandHandler>();
//builder.Services.AddScoped<RemoveCategoryCommandHandler>();

// mediatr
builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=CategoryList}/{id?}");

app.Run();
