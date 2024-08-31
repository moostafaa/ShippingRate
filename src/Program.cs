using FastEndpoints;
using ShippinRate;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Managers", x => x.RequireRole("Manager").RequireClaim("ManagerId"));
builder.Services.AddTransient<ShippingRateProvider>();

var app = builder.Build();
app.UseFastEndpoints();
app.UseAuthorization().UseAuthorization();
app.Run();
