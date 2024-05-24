using ControlInventario.Core.Helpers;
using ControlInventario.Core.Repositories;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Datos.ControlInventarioObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ControlInventario.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

IConfigurationSection appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
AppSettings appSettings = appSettingsSection.Get<AppSettings>();

builder.Services.AddDbContext<PostgresContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ControlInventarioDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["accessToken"];

            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/notificationshub")))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.UseRequestUser();

app.MapControllers();

app.Run();
