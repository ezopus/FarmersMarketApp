using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddControllersWithViews(options =>
{
	options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());

});

builder.Services.AddAntiforgery();

builder.Services.AddRazorPages();

// Building starts here, configure beforehand
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

await app.SeedRolesAsync();
await app.EnsureAdminRole();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "areas",
	pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
