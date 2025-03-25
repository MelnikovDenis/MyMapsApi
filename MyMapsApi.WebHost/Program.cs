using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using MyMapsApi.App.Implements;
using MyMapsApi.App.Implements.TokenService.Options;
using MyMapsApi.Controllers.Extensions.ServiceCollection;
using MyMapsApi.Infra.PostgreSql;
using MyMapsApi.WebHost.Extensions.ApplicationBuilder;
using MyMapsApi.WebHost.Extensions.ServiceCollection;
using MyMapsApi.WebHost.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"{nameof(JwtTokenServiceOptions)}.json");

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomValidateModelAttribute>();
});
builder.Services.AddAppLayer(builder.Configuration);
builder.Services.AddInfraLayer(builder.Configuration);
builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddJwt(builder.Configuration);

builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true);

var app = builder.Build();

app.UseCustomExceptionHandler();

if (!app.Environment.IsDevelopment())
{
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
}

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