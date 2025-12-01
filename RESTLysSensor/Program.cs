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
if (useDB)
{
	var optionsBuilder = new DbContextOptionsBuilder<LightSensorDBContext>();
	optionsBuilder.UseSqlServer(LysSensorLib.Secret.ConnectionString);
	LightSensorDBContext _dbContext = new(optionsBuilder.Options);
	//_dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.LightData");
	_repo = new LightSensorRepositoryDB(_dbContext);
}
else
{
	Console.WriteLine("Please Connect the Database");
}

builder.Services.AddSingleton<ILightSensorRepositoryDB>(_repo);

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

//app.UseCors("allowAnythingFromZealand");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

