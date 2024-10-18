
using BabyName.Installers;
using BabyName.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSettings(builder.Configuration);
builder.Services.AddServiceConfigurations(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();