using Microsoft.EntityFrameworkCore;
using server_travel.Entities;
using server_travel.Interfaces;
using server_travel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options
    => options.SerializerSettings.ReferenceLoopHandling
    = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            //policy.WithOrigins("https://24h.com.vn");
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        }
        );
}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelApiContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("travel_api"))

    );

builder.Services.AddTransient<IManageTouristSpot, ManageTourestSpotService>();
builder.Services.AddScoped<IUpLoadService, UploadService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(
//Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
//    RequestPath = "/MyImages"
//});
//app.UseDirectoryBrowser(new DirectoryBrowserOptions
//{
//    FileProvider = new PhysicalFileProvider(
//Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
//    RequestPath = "/MyImages"
//});

app.MapControllers();

app.Run();
