using FarmersMarketApp.Web.Extensions;
using FarmersMarketApp.Web.ModelBinders;
using FarmersMarketApp.Web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddControllersWithViews(options =>
{
	options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());

});


// Add email sender service
builder.Services.AddTransient<IEmailSender, EmailSender>();

// Configure EmailSettings from appsettings.json
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection
("EmailSettings"));

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

app.UseStatusCodePagesWithReExecute("/Error/{0}");

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
