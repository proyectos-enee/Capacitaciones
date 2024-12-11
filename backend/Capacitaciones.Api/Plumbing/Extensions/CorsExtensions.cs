using Enee.IoC.Architecture.Auth.Models;

namespace Capacitaciones.Api.Plumbing.Extensions;

public static class CorsExtensions
{
    public static string[] GetCorsOrigins(this AuthSettings authSetting)
    {
        return authSetting.CorsOrigins.Split(',');
    }

    public static IServiceCollection AddDefaultCors(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var authSettings = configuration
            .GetRequiredSection(AuthSettings.ConfigurationSectionName)
            .Get<AuthSettings>();

        return services.AddCors(options =>
        {
            options.AddPolicy(
                "default",
                builder =>
                {
                    builder
                        .WithOrigins(authSettings.GetCorsOrigins())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                }
            );
        });
    }
}
