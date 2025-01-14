using Sip_Dashboard_disconnected.Interfcaes;
using Sip_Dashboard_disconnected.Repositories;
using Sip_Dashboard_disconnected.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISipDashboardServices, Sip_DashboardServices>();
builder.Services.AddScoped<ISipDashboardRepositiories, Sip_DasboradRepositiore>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();


app.UseAuthorization();

app.MapControllers();

app.Run();
