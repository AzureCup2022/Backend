using AzureBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=database.db"));

var app = builder.Build();

// Create DB
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    if (context.Database.EnsureCreated())
    {
        ////Was created -> populate with data
        //// Add cities
        //context.Cities.Add(new City
        //{
        //    Id = 0,
        //    Name = "Prague",
        //    Longitude = 50.073658,
        //    Latitude = 14.418540,
        //    DefaultZoom = 11
        //});
        //context.Cities.Add(new City
        //{
        //    Id = 1,
        //    Name = "Paris",
        //    Longitude = 48.864716,
        //    Latitude = 2.349014,
        //    DefaultZoom = 10
        //});

        //// Add Overlay data
        //context.Overlays.Add(MockParser.GetSafetyMock());
        //context.Overlays.Add(MockParser.GetPollutionMock());

    }
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
