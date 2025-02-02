using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Infrastructure.Data;
using Antra.CRMApp.Infrastructure.Repository;
using Antra.CRMApp.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dependency injection for repository
builder.Services.AddControllersWithViews();
builder.Services.AddSqlServer<CrmDbContext>(builder.Configuration.GetConnectionString("OnlineCRM"));
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepositoryAsync>();
builder.Services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();
builder.Services.AddScoped<IVendorRepositoryAsync, VendorRepositoryAsync>();



//dependency injection for services
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IRegionServiceAsync, RegionServiceAsync>();
builder.Services.AddScoped<ICategoryServiceAsync, CategoryServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddScoped<IShipperServiceAsync, ShipperServiceAsync>();
builder.Services.AddScoped<IVendorServiceAsync, VendorServiceAsync>();

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

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.Use(async (context, next) => {
//    await context.Response.WriteAsync("This is middleware 1 \n");
//      next();
//    await context.Response.WriteAsync("Response from middleware 1 \n");
//});
//app.Use(async (context, next) => {
//    await context.Response.WriteAsync("This is middleware 2 \n");
//    next();

//    await context.Response.WriteAsync("Response from middleware 2 \n");
//});
//app.Use(async (context, next) => {
//    await context.Response.WriteAsync("This is middleware 3 \n");
//    next();

//    await context.Response.WriteAsync("Response from middleware 3 \n");
//});

//app.Run(async context => {
//    await context.Response.WriteAsync("this is run middlware");
//});
app.Run();
