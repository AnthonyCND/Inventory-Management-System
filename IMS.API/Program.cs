
using IMS.Application.Interfaces;
using IMS.Application.Services;
using IMS.Infrastructure;
using IMS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(IMS.Application.Mapping.ApplicationMapping).Assembly,
    typeof(IMS.Infrastructure.Mapping.Mapper).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
