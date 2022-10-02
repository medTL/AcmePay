using System.Text.Json.Serialization;
using AcmePay;
using AcmePay.BL.Renders;
using AcmePay.Data.Entity;
using AcmePay.Data.Repositories.PaymentMethodRepositories;
using AcmePay.Data.Repositories.PaymentRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5200");
// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        var enumConverter = new JsonStringEnumConverter();
        options.JsonSerializerOptions.Converters.Add(enumConverter);
    });

builder.Services.AddDbContext<AcmeContext>(options =>
    options.UseInMemoryDatabase("AcmePayDb"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS",
        opt =>
        {
            opt.AllowAnyOrigin().AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services
    .AddScoped<IPaymentMethodRepository, PaymentMethodRepository>()
    .AddScoped<IPaymentRepository, PaymentRepository>()
    .AddRenders();

// Api documentation services
builder.Services.AddApiVersioning(
    options => { options.ReportApiVersions = true; });
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
        options.SubstitutionFormat = "V.v";
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AcmeContext>();
    SeedData.Initialize(dbContext);
}

app.MapControllers();

app.UseCors("CORS");

app.Run();