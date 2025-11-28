using LysSensorLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<LightSensorRepositoryDB>();

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

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //Download NuGet package Swashbuckle.AspNetCore
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allowAnythingFromZealand");

app.UseAuthorization();

app.MapControllers();

app.Run();

