using Enee.IoC.Architecture;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace Capacitaciones.Data.Migrations;

[Migration(202404111620)]
public class AgregarTablaCapacitacion : Migration
{
    private readonly DbSettings _dbSettings;

    public AgregarTablaCapacitacion(IOptions<DbSettings> dbSetting)
    {
        _dbSettings = dbSetting.Value;
    }

    public override void Up()
    {
        var schema = _dbSettings.SchemaTables;

        Create.Table("Capacitacion").InSchema(schema)
            .WithIdColumn("Id") // Columna ID autoincremental
            .WithColumn("CodigoCapacitacion").AsString(50).NotNullable()
            .WithColumn("NombreCorto").AsString(100).NotNullable()
            .WithColumn("NombreLargo").AsString(200).NotNullable()
            .WithColumn("Descripcion").AsString(int.MaxValue).Nullable()
            .WithColumn("EnteCapacitador").AsString(100).NotNullable()
            .WithColumn("Modalidad").AsString(50).NotNullable()
            .WithColumn("Lugar").AsString(200).Nullable()
            .WithColumn("Horario").AsString(100).Nullable()
            .WithColumn("FechaInicioRegistro").AsDateTime().NotNullable()
            .WithColumn("FechaFinRegistro").AsDateTime().NotNullable()
            .WithColumn("Estado").AsString(50).NotNullable()
            .WithAuditableFields(); // Para añadir campos como CreatedDate, ModifiedDate, etc.
    }

    public override void Down()
    {
        var schema = _dbSettings.SchemaTables;

        Delete.Table("Capacitacion").InSchema(schema);
    }
}
