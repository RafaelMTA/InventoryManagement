using IM.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var allowCors = "_allowCors";

builder.Services
    .AddAutoMapperConfiguration()
    .AddCorsOriginOptions(configuration, allowCors)
    .AddServiceOptions(configuration)
    .AddAuthenticationService(configuration)
    .AddInfrastructure(configuration)
    .AddRepositories()
    .AddServices()
    .AddSwagger()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
