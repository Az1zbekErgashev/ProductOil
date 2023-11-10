using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Repository;
using ProductOil.Repository.Enum;
using ProductOil.Servis;
using ProductOil.Servis.Auth;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5069/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asfsafsasafjsafjksafksafsafsafsafasfasfafasfsafasfsafsafassaf"))
    };
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IGenericRepository<Team>, TeamRepository>();
builder.Services.AddScoped<IGenericRepository<OilCompany>, OilCompanyRepository>();
builder.Services.AddScoped<IGenericRepository<OilNews>, OilNewsRepository>();
builder.Services.AddScoped<IGenericRepository<Contact>, ContactRepository>();
builder.Services.AddScoped<IGenericRepository<NeftekorCertified>, NeftekorCertifiedRepository>();
builder.Services.AddScoped<IGenericRepository<Location>, LocationRepository>();
builder.Services.AddScoped<IGenericRepository<FeedBack>, FeedBackRepository>();
builder.Services.AddScoped<IGenericRepository<Exemples>, ExemplesRepository>();
builder.Services.AddScoped<IGenericRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IGenericRepository<BenefitOil>, BenefitOilRepository>();
builder.Services.AddScoped<IGenericRepository<OilProduct>, OilProductRepository>();

builder.Services.AddScoped<ICategoriyRepository, CategoriyRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
