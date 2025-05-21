using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.DbContext;
using Pharmacy.WebApi.StartupExtension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.configureServices(builder.Configuration);
 
var app = builder.Build();

//Seed data



// ������� Seeder ���� scope
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await IdentityInitializer.SeedAdminUserAsync(services);
}

// Configure the HTTP request pipeline.


//Use Swagger

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
