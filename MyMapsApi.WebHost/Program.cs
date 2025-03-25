using MyMapsApi.App.Implements;
using MyMapsApi.App.Implements.TokenService.Options;
using MyMapsApi.Controllers.Extensions.ServiceCollection;
using MyMapsApi.Infra.PostgreSql;
using MyMapsApi.WebHost.Extensions.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"{nameof(JwtTokenServiceOptions)}.json");

builder.Services.AddControllers();
builder.Services.AddAppLayer(builder.Configuration);
builder.Services.AddInfraLayer(builder.Configuration);
builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddJwt(builder.Configuration);

var app = builder.Build();

app.UseCors(options => options.SetIsOriginAllowed(_ => true)
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();