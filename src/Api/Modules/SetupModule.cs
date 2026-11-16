using System.Text.Json.Serialization;
using Api.Modules.Errors;

namespace Api.Modules;

public static class SetupModule
{
    public static IServiceCollection SetupServices(this IServiceCollection services)
    {
        services.AddControllers(options => options.Filters.Add<ValidationExceptionFilter>()).AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(
                new JsonStringEnumConverter(allowIntegerValues: false)));

        services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        return services;
    }
}
