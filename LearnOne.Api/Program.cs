using AutoMapper.Extensions.ExpressionMapping;
using LearnOne.Data;
using LearnOne.Data.Repositories.Implements;
using LearnOne.Data.Repositories.Interfaces;
using LearnOne.Domain.Dtos;
using LearnOne.Domain.ObjectValues;
using LearnOne.Infastructure.Services.Implements;
using LearnOne.Infastructure.Services.Interfaces;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddOData(opt =>
{
    opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(5000).AddRouteComponents("odata", GetEdmModel());
    opt.TimeZone = TimeZoneInfo.Utc;
});
var executingAssembly = Assembly.GetExecutingAssembly();
var entryAssembly = Assembly.GetEntryAssembly();
var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddExpressionMapping();
}, executingAssembly, entryAssembly);
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ICtyRepository, CtyRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use odata route debug, /$odata
app.UseODataRouteDebug();
// Add OData /$query middleware
app.UseODataQueryRequest();
// Add the OData Batch middleware to support OData $Batch
app.UseODataBatching();
// Use odata route debug, /$odata
app.UseODataRouteDebug();
// Add OData /$query middleware
app.UseODataQueryRequest();
// Add the OData Batch middleware to support OData $Batch
app.UseODataBatching();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.ComplexType<Ward>();
    odataBuilder.EntityType<CityDto>().HasKey(entity => new { entity.Id });
    odataBuilder.EntitySet<CityDto>("City");
    odataBuilder.EntityType<DistrictDto>().HasKey(entity => new { entity.Id });
    odataBuilder.EntitySet<DistrictDto>("Districts");
    return odataBuilder.GetEdmModel();
}