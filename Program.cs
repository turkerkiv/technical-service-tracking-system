using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;
using technical_service_tracking_system.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TsDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLDefault"));
});

builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<ICustomerProductRepository, EFCustomerProductRepository>();
builder.Services.AddScoped<IFaultTypeRepository, EFFaultTypeRepository>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IRequestInterventionRepository, EFRequestInterventionRepository>();
builder.Services.AddScoped<IRoleRepository, EFRoleRepository>();
builder.Services.AddScoped<IServiceRequestRepository, EFServiceRequestRepository>();
builder.Services.AddScoped<ISpareItemRepository, EFSpareItemRepository>();
builder.Services.AddScoped<ISpareItemUseActivityRepository, EFSpareItemUseActivityRepository>();
builder.Services.AddScoped<IStatusRepository, EFStatusRepository>();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
