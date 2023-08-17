using Camunda.Worker;
using Camunda.Worker.Client;
using CamundaWorker.DataAccess.SQL.Context;
using CamundaWorker.DataAccess.SQL.Repository;
using CamundaWorker.Worker;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExternalTaskClient(client => {
    client.BaseAddress = new Uri(builder.Configuration.GetSection("Camunda:BaseAddress").Value);
});

builder.Services.AddCamundaWorker("PaymentRetrival")
                .AddHandler<PaymentHandler>();

builder.Services.AddDbContextPool<Recharge_DBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

//dependency injection
builder.Services.AddSingleton<Recharge_DBContext>();
builder.Services.AddScoped<RechargeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
