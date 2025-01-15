using Enee.IoC.Architecture;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace Capacitaciones.Data.Migrations;
[Migration(202404111635)]
public class AgregarTablaSolicitudesCapacitacion : Migration
{
    private readonly DbSettings _dbSettings;

    public AgregarTablaSolicitudesCapacitacion(IOptions<DbSettings> dbSetting)
    {
        _dbSettings = dbSetting.Value;
    }

    public override void Up()
    {
        var schema = _dbSettings.SchemaTables;

        Create.Table("Solicitudes_Capacitacion").InSchema(schema)
            .WithIdColumn() // Columna ID autoincremental
            .WithColumn("Dependencia").AsString(100).NotNullable()
            .WithColumn("Nombre_Capacitacion").AsString(200).NotNullable()
            .WithColumn("Descripcion").AsString(int.MaxValue).Nullable()
            .WithColumn("Id_Usuario").AsGuid().NotNullable().ForeignKey("Usuarios", "Id") // Relación con la tabla Usuarios
            .WithColumn("Fecha_Solicitud").AsDateTime().NotNullable()
            .WithAuditableFields(); // Para añadir campos como CreatedDate, ModifiedDate, etc.
    }

    public override void Down()
    {
        var schema = _dbSettings.SchemaTables;

        Delete.Table("Solicitudes_Capacitacion").InSchema(schema);
    }
}
