using GrpcServer;
using GrpcServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<bankContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=bank;Username=postgres;Password=kamila0109"));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserAPIService>();
app.MapGet("/", () => "GrpcServer");

app.Run();
