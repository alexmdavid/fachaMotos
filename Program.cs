using fachaMotos.Data;
using fachaMotos.Repositories;
using fachaMotos.Repositories.IRepositories;
using fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
using fachaMotos.Services.fachaMotos.Services;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using fachaMotos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using fachaMotos.Services.IServices;
using fachaMotos.Repositories.fachaMotos.Repositories;
using fachaMotos.Services.IServices.fachaMotos.Services;
using fachaMotos.IRepositories;
using fachaMotos.IServices;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
})
.AddGoogle("Google", options =>
{
    options.ClientId = config["Authentication:Google:ClientId"];
    options.ClientSecret = config["Authentication:Google:ClientSecret"];
    options.SignInScheme = "External"; 
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(xmlPath);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Ejemplo: 'Authorization: Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new string[] { }
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBikeRepository, BikeRepository>();
builder.Services.AddScoped<IBikeService, BikeService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IUserFavoritosRepository, UserFavoritosRepository>();
builder.Services.AddScoped<IUserFavoritosService, UserFavoritosService>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddSingleton<CloudinaryService>();

builder.Services.AddScoped<IComentarioBlogRepository, ComentarioBlogRepository>();
builder.Services.AddScoped<IComentarioBlogService, ComentarioBlogService>();

builder.Services.AddScoped<IComentarioBlogReactionRepository, ComentarioBlogReactionRepository>();
builder.Services.AddScoped<IComentarioBlogReactionService, ComentarioBlogReactionService>();

builder.Services.AddScoped<IReviewReactionRepository, ReviewReactionRepository>();
builder.Services.AddScoped<IReviewReactionService, ReviewReactionService>();

builder.Services.AddScoped<IAuthService, AuthService>();




//mis hermosas cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});







var app = builder.Build();

app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FachaMotos API V1");
    c.RoutePrefix = "swagger"; 
});


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
