using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Simoja.Data;
using Simoja.Repository;
using Simoja.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var services = builder.Services;

// Add CoRS
services.AddCors();

// Add DbContext
services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDB"));
});

// Add Service to DI Container
{
    services.AddScoped<IJenisKegiatan, JenisKegiatanService>();
    services.AddScoped<IStatusKelola, StatusKelolaService>();
    services.AddScoped<IPihakAngkut, PihakAngkutService>();
    services.AddScoped<IClient, ClientService>();
    services.AddScoped<IAddressRepo, AddressService>();
    services.AddScoped<IDetailAngkut, DetailAngkutService>();
    services.AddScoped<IKendaraan, KendaraanService>();
    services.AddScoped<ILokasiAngkut, LokasiAngkutService>();
}

services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})

.AddCookie(options => {
    options.LoginPath = "/login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = false;
    options.AccessDeniedPath = "/account/denied";
})

.AddOpenIdConnect(options => {
    options.ClientId = "simoja";
    options.ClientSecret = "simojaSecretBodoAmat2022$";

    options.RequireHttpsMetadata = false;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.SaveTokens = true;

    // Use the authorization code flow.
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;

    // retrieve the identity provider's configuration and spare you from setting
    // the different endpoints URIs or the token validation paramsimojaSecretBodoAmat2022eters explicitly.
    options.Authority = "https://localhost:6001/";

    options.Scope.Add("email");
    options.Scope.Add("roles");
    // options.Scope.Add("profile");

    // Disable the built-in JWT claims mapping feature.
    options.MapInboundClaims = false;

    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
      
});

services.AddHttpClient();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
