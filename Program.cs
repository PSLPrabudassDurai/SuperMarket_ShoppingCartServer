using Microsoft.AspNetCore.ResponseCompression;
using SuperMarket_ShoppingCart.Shared.Models;
using SuperMarket_ShoppingCartServer.BusinessLayer;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
//builder.Services.AddResponseCompression(options =>
//{
//    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
//    {
//                    MediaTypeNames.Application.Octet,
//                    WasmMediaTypeNames.Application.Wasm,
//                });
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemDetails, ItemDetailsBusinessLayer>();
builder.Services.AddScoped<IShoppingDetails, ShoppingDetailsBusinessLayer>();
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
