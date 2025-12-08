using LysSensorLib;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using RESTLysSensor.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

const bool useDB = true;
ILightSensorRepositoryDB _repo;
IAlarmRepositoryDB _alarmRepo;
IPiDataRepositoryDB _piDataRepo;
if (useDB)
{
	var optionsBuilder = new DbContextOptionsBuilder<LightSensorDBContext>();
    var optionsBuilder2 = new DbContextOptionsBuilder<AlarmDBContext>();
    var optionsBuilder3 = new DbContextOptionsBuilder<PiDataDBContext>();

    optionsBuilder.UseSqlServer(LysSensorLib.Secret.ConnectionString);
    optionsBuilder2.UseSqlServer(LysSensorLib.Secret.ConnectionString);
    optionsBuilder3.UseSqlServer(LysSensorLib.Secret.ConnectionString);
    LightSensorDBContext _dbContext = new(optionsBuilder.Options);
    AlarmDBContext _alarmDbContext = new(optionsBuilder2.Options);
    PiDataDBContext _piDataDbContext = new(optionsBuilder3.Options);
    //_dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.LightData");
    _repo = new LightSensorRepositoryDB(_dbContext);
    _alarmRepo = new AlarmRepositoryDB(_alarmDbContext);
    _piDataRepo = new PiDataRepositoryDB(_piDataDbContext);
}
else
{
	Console.WriteLine("Please Connect the Database");
}

builder.Services.AddSingleton<ILightSensorRepositoryDB>(_repo);
builder.Services.AddSingleton<IAlarmRepositoryDB>(_alarmRepo);
builder.Services.AddSingleton<IPiDataRepositoryDB>(_piDataRepo);

builder.Services.AddCors(options =>

{
    options.AddPolicy("allowAnythingFromZealand",
        builder =>
            builder.WithOrigins("http://zealand.dk")
                .AllowAnyHeader()
                .AllowAnyMethod());
    options.AddPolicy("allowGetPut",
        builder =>
            builder.AllowAnyOrigin()
            .WithMethods("GET", "PUT")
            .AllowAnyHeader());
    options.AddPolicy("allowAnything", // similar to * in Azure
        builder =>
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

var app = builder.Build();

app.MapOpenApi();
//Download NuGet package Swashbuckle.AspNetCore
app.UseSwagger();
app.UseSwaggerUI();

// app.UseCors("allowAnythingFromZealand");
app.UseCors("allowAnything");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

