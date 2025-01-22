using EclipseWorks.API.Filters;
using EclipseWorks.API.Lazy;
using EclipseWorks.Helper;
using EclipseWorks.Infrastructure;
using EclipseWorks.Infrastructure.ServiceExtension;
using EclipseWorks.Services;
using EclipseWorks.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddLazyResolution();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskCommentService, TaskCommentService>();
builder.Services.AddScoped<IOperationLogService, OperationLogService>();

builder.Services.AddDIServices(builder.Configuration);

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new CustomAuthorizationFilter());
    config.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddCors(policy =>
{
    policy.AddPolicy(APIConstants.APIDefaultCorsPolicy, builder =>
     builder.WithOrigins("https://localhost:7261")
      .SetIsOriginAllowed((host) => true) // this for using localhost address
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration["JwtIssuer"],
                            ValidAudience = builder.Configuration["JwtAudience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"]))
                        };
                    });

#region LOCALIZATION

builder.Services.AddLocalization();

var supportedCultures = new[]
{
    new System.Globalization.CultureInfo("pt-BR"),
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Environment.SetEnvironmentVariable(SecurityConstants.EclipseWorksPasswordHashPepper, "EclipseWorksSaltAndPepper");

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DbContextClass>();
    dataContext.Database.Migrate();
}

//app.UseHttpsRedirection();

#region LOCALIZATION

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

#endregion

app.UseAuthorization();

app.UseCors(APIConstants.APIDefaultCorsPolicy);

app.MapControllers();

app.Run();
