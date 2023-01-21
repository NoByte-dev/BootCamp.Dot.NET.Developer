#region Build Services
using Microsoft.EntityFrameworkCore;
using pottencial_payment.Domain.AppSettings;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Domain.Interface.Services;
using pottencial_payment.Domain.Services;
using pottencial_payment.Infrastructure.Context;
using pottencial_payment.Infrastructure.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseQueryStrings= true);
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add
        (new JsonStringEnumConverter()));
#endregion
#region Swagger Config
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                        new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "pottencial_payment",
                            Version = "v1",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Thalys Augusto" },
                        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    swagger.IncludeXmlComments(xmlPath);
}
);
#endregion
#region AppSettings

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);

#endregion
#region Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion
#region Service / Repository

builder.Services.AddScoped<IVendedorService, VendedorService>();
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();

builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();

#endregion
#region DbContext

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(appSetting.SqlServerConnection);
    options.UseLazyLoadingProxies();
});

#endregion
#region AppConfiguration
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
#endregion