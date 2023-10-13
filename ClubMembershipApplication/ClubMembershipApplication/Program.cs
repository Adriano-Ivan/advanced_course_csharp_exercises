

using ClubMembershipApplication.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container..
var connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db{builder.Configuration.GetConnectionString("DefaultConnection")}";

// Database
builder.Services.AddDbContext<ClubMembershipDbContext>(options =>
    options.UseSqlite(connectionString));


var app = builder.Build();

app.Run();
