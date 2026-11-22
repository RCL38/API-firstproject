using Repositories;
using Services;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repositories;
using Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<storeDBContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=storeDB;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();