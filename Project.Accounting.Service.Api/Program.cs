using Project.Accounting.Service.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorConfig();
builder.Services.AddMediatrConfig();
builder.Services.AddRepositoriesDependecyInjection();
builder.Services.AddMediatrDependecyInjection();
builder.Services.AddServicesDependecyInjection();
builder.Services.AddBrokerConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
