using AppointMed.API.Installers;
using AppointMed.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.InstallServicesInAssembly();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var swaggerOptions = new SwaggerOptions();
    builder.Configuration.GetSection(nameof(swaggerOptions)).Bind(swaggerOptions);
    app.UseSwagger(options => { options.RouteTemplate = swaggerOptions.JsonRoute; });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
    });
}

//Create Identity Roles
using (var serviceScope = app.Services.CreateScope())
{
    await serviceScope.CreateIdentityRoles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
