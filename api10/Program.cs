using api10.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MiPoliticaCORS",
       policy =>
       {
           policy.AllowAnyHeader()
           .AllowAnyOrigin()
           .AllowAnyMethod();
       });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
}

);


var app = builder.Build();

//Enable CORS
//app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
//app.UseCors(policy => policy.WithHeaders(HeaderNames.CacheControl));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MiPoliticaCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
