using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace SpoopyWebAPI;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddSession();
        services.AddHttpLogging((options) => {
            options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.Request;
        });
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = "SpoopyWebAPI",
                Description = "An ASP.NET Core Web API for managing Spoopy DiscordBot",
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            options.RoutePrefix = string.Empty;            
        });

        app.UseHttpLogging();

        app.UseHttpsRedirection();

        app.UseSession();

        app.UseRouting();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }

    
}

