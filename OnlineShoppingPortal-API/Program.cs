using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShoppingPortal_API.Data;
using OnlineShoppingPortal_API.Controllers;
using OnlineShoppingPortal_API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Program.cs, is the place where you need to register your services and dependencies 
// after the builder.Services.AddRazorPages(); and middleware after var app = builder.Build();.

// Add services to the container.
// dependency injection
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")).EnableSensitiveDataLogging();
});
//builder.Services.AddDbContextPool<DataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")).EnableSensitiveDataLogging());

builder.Services.AddCors(options => options.AddPolicy(name: "ShoppingOrigins",
    policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }));
/*
 *  using AddScoped() method because we want the instance to be alive and available 
 *  for the entire scope of the given HTTP request. For another new HTTP request, 
 *  a new instance of Repository class will be provided and it will be available 
 *  throughout the entire scope of that HTTP request.
 */
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISegmentRepository, SegmentRepository>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( x =>
{
    x.RequireHttpsMetadata = false; // no depth checking
    x.SaveToken = true;
    // match issuers, sign in key, validations 
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        // should match the key input
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("randomwordfortoken")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});



var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

// need CORS above the auth pipeline
app.UseCors("ShoppingOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
