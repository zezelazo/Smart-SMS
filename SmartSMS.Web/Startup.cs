using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartSMS.Web.Data;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web {
  public class Startup {
    private readonly IConfigurationRoot _config;

    public Startup(IHostingEnvironment env) {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddEnvironmentVariables();
      _config = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services) {
      services.AddSingleton(_config);
      services.AddDbContext<SmartSmsContext>(ServiceLifetime.Scoped);
      services.AddTransient<SmartSmsDbInitializer>();

      services.AddScoped<LookUpsData>();
      services.AddScoped<GenericRepository<Student>, StudentsRepository>();
      services.AddScoped<GenericRepository<MessageDefinition>,MessageDefinitionsRepository>();

      services.AddScoped<GenericRepository<Level>>();


      services.AddLogging();

      //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<SmartSmsContext>();

      services.AddMvc().AddJsonOptions(opt=>opt.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore );
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,SmartSmsDbInitializer seeder) {
      if (env.IsDevelopment()) {
        loggerFactory.AddConsole(LogLevel.Information);
        loggerFactory.AddDebug(LogLevel.Information);
        app.UseDatabaseErrorPage();
        app.UseDeveloperExceptionPage();        
      } else {
        loggerFactory.AddDebug(LogLevel.Error);
      }

      app.UseDefaultFiles();
      app.UseStaticFiles();
      
      
      //seeder.Seed().Wait();
      app.UseMvc();
    }
  }
}
