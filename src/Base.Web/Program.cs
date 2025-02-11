using Base.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

ConfigureCors(builder.Services);

// Adicionando dependências do projeto
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromMinutes(30);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

ConfigurePipeline(app);

app.Run();

// Configuração de CORS
void ConfigureCors(IServiceCollection services)
{
  services.AddCors(options =>
  {
    options.AddPolicy("AllowAll", policy =>
      {
        policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
      });
  });
}

// Configuração do pipeline de middleware
void ConfigurePipeline(WebApplication app)
{
  app.UseHttpsRedirection();
  app.UseCors("AllowAll");

  app.UseSession();
  app.UseRouting();

  app.MapStaticAssets();

  app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Login}/{action=Index}/{id?}")
      .WithStaticAssets();
}
