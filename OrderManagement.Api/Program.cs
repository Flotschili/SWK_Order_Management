using OrderManagement.Api.BackgroundServices;
using OrderManagement.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddSingleton<IOrderManagementLogic, OrderManagementLogic>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(builder =>
        builder.AddDefaultPolicy(policy =>
            policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

builder.Services.AddOpenApiDocument(options =>
    options.PostProcess = document => document.Info.Title = "Order Management API");

builder.Services.AddHostedService<ScheduledUpdateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseOpenApi();
app.UseSwaggerUi3(settings => settings.Path = "/swagger");
app.UseReDoc(settings => settings.Path = "/redoc");


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
