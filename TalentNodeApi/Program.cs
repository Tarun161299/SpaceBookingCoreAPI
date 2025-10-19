using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TalentNodeApi;
using System.IO;
using TalentNode.Infrastructure;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // 🔹 Configure logging
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
    builder.Logging.AddEventLog(); // Logs also go to Windows Event Viewer on Plesk
    
    // 🔹 Add services
    builder.Services.AddControllers();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Message Service", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    });

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:7054",
                ValidAudience = "https://localhost:7054",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xxxxxxxsssssssdddddddaaaaaaaaaaaaaa"))
            };
        });

    builder.Services.AddTalentNodeDI(builder.Configuration);

    var app = builder.Build();

    app.UseCors("AllowAll");

    // 🔹 Global middleware to catch runtime exceptions and log to file
    app.Use(async (context, next) =>
    {
        try
        {
            await next();
        }
        catch (Exception ex)
        {
            var logPath = Path.Combine(app.Environment.ContentRootPath, "logs", "app_log.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);

            await File.AppendAllTextAsync(logPath,
                $"[{DateTime.UtcNow:O}] Runtime error: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");

            throw; // rethrow so IIS still returns 500
        }
    });

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }
   
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseStaticFiles();

    app.MapControllers();
    app.MapFallbackToFile("index.html");
    app.Run();
}
catch (Exception ex)
{
    // 🔹 Write to console (stdout logs if enabled in web.config)
    Console.WriteLine($"❌ Application failed to start: {ex}");

    // 🔹 Also log startup errors to file
    Directory.CreateDirectory("logs");
    File.AppendAllText("logs/startup_errors.txt",
        $"{DateTime.Now:O} - Application failed to start: {ex}{Environment.NewLine}");

    throw; // rethrow so IIS still knows it failed
}
