using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using EfcDataAccess;
using EfcDataAccess.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderDao, OrderEfcDao>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
builder.Services.AddScoped<IAddressDao, AddressEfcDao>();
builder.Services.AddScoped<IAddressLogic, AddressLogic>();
builder.Services.AddScoped<ICustomerDao, CustomerEfcDao>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();


builder.Services.AddDbContext<PaddlerNationContext>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

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