using HealthCareBackend.Models;
using HealthCareBackend.Repositories;
using HealthCareBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add logging configuration for better troubleshooting
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services and repositories
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<PatientRegistrationService>();
builder.Services.AddScoped<PatientRegistrationRepository>();
builder.Services.AddScoped<MasterTableRepository>();
builder.Services.AddScoped<MasterTableService>();
builder.Services.AddScoped<PatientDetailService>();
builder.Services.AddScoped<PatientDetailsRepository>();
builder.Services.AddScoped<PatientProfilePictureRepository>();
builder.Services.AddScoped<PatientProfilePictureService>();
builder.Services.AddScoped<DoctorRegistrationService>();
builder.Services.AddScoped<DoctorRegistrationRepository>();

// Configure DbContext with the correct connection string
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddCors(b =>
{
    b.AddPolicy("policyCors", p =>
    {
        p.AllowAnyOrigin();
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("policyCors");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
