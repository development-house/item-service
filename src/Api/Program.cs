using MediatR;
using Api.Items;
using Application.Items.Commands;
using Repository.MariaDb;
using Repository.PostgreSql;
using Domain;
using Application;
using System.Reflection;
using Domain.Items;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateItemCommandHandler).Assembly);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMariaDb(builder.Configuration);
builder.Services.AddPgSql(builder.Configuration);
builder.Services.AddScoped<IItemRepository, PgRepository>();
var app = builder.Build();
// Configure the HTTP request pipeline.
//app.UseExceptionHandler();
app.UseStatusCodePages();
if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}
if (builder.Configuration.GetValue<bool>("EnableSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapItemApi();
app.Run();