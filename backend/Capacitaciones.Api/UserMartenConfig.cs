using Marten;

namespace ContratosGeneracion.Api;

public class UserMartenConfig : IConfigureMarten
{
    public void Configure(IServiceProvider services, StoreOptions options)
    {
        Console.WriteLine("Extendiendo configuración Marten : UserMartenConfig");
        options.Logger(new ConsoleMartenLogger());
        //options.SetApplicationProject(typeof(CicloPagoR).Assembly);


        //options.Projections.LiveStreamAggregation<CicloPagoR>();
        // options.Schema.For<CicloPagoResumidoDocumento>()
        //     .FullTextIndex("spanish", documento => documento.MesTexto, documento => documento.Anio);
    }
}
