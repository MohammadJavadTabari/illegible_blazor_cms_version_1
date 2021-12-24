using Blazored.SessionStorage;
using illShop.Shared.BasicObjects.JWT;
using illShop.Shared.BasicServices;
using illShop.Shared.Repositories.Product;
using KernelLogic.DataBaseObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

#region Service Container Builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Database=DESKTOP-M1RD6KK;Initial Catalog=illShop;Trusted_Connection=True;");
});
builder.Services.AddDbContext<IDentityContext>(options =>
{
    options.UseSqlServer("Database=DESKTOP-M1RD6KK;Initial Catalog=illShop.Identity;Trusted_Connection=True;");
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("IllegibleCors", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("X-Pagination"));
});
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<ITokenExtension, TokenExtension>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IDentityContext>();

#region IDentity with jwt

var jwtSetting = new JwtSetting();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = jwtSetting.ValidateIssuer,
        ValidateAudience = jwtSetting.ValidateAudience,
        ValidateLifetime = jwtSetting.ValidateLifetime,
        ValidateIssuerSigningKey = jwtSetting.ValidateIssuerSigningKey,
        ValidIssuer = jwtSetting.ValidIssuer,
        ValidAudience = jwtSetting.ValidAudience,
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecuritySignInKey)),
    };
});

#endregion

#endregion

#region appConfigs
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseCors("IllegibleCors");
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

#endregion