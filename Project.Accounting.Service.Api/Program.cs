using Project.Accounting.Service.Api.Config;
using Project.Accounting.Service.Api.CustomMiddleware.Implements;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<TimeOutExceptionHandler>();
builder.Services.AddExceptionHandler<DefaultExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorConfig();
builder.Services.AddMediatrConfig();
builder.Services.AddRepositoriesDependecyInjection();
builder.Services.AddMediatrDependecyInjection();
builder.Services.AddServicesDependecyInjection();
builder.Services.AddBrokerConfiguration(builder.Configuration);
builder.Services.AddSettingsConfiguration(builder.Configuration);
builder.Services.AddAuthenticationConfig(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(opt => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();