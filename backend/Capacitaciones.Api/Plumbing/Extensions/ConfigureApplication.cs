using Carter;
using Enee.IoC.Architecture.Auth;
using Enee.IoC.Architecture.Extensions;
using Oakton;

namespace Capacitaciones.Api.Plumbing.Extensions;

public static class ConfigureApplication
{
    public static async Task<int> UseServer(
        this WebApplication app,
        string[] args,
        string? optionsFile = null
    )
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHttpsRedirection();
        }

        //Manejo de excepciones
        app.UseExceptionHandler();

        //Transaccionalidad
        app.UseMiddleware<UnitOfWorkMiddleware>();


        // Usa la autenticación y autorización
        app.UseCors("default");
        app.UseAuthentication();
        app.UseAuthorization();

        // app.MapControllers(); // Comentado por Minimal API
        app.MapCarter(); // <-- Minimal API

        app.MapGet(
                "/mi-prueba",
                async () =>
                {
                    return "Hola";
                }
            )
            .Access();

        return await app.RunOaktonCommands(args);
    }
}
