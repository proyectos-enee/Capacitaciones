// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Enee.IoC.Architecture.Auth.Models;

namespace Capacitaciones.Api.Extensions.Cors;

public static class CorsExtension
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
