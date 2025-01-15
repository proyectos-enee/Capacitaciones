using Enee.IoC.Architecture;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace Capacitaciones.Data.Migrations;


[Migration(202404111630)]
public class AgregarTablaRegistroCapacitacion : Migration
{
    private readonly DbSettings _dbSettings;

    public AgregarTablaRegistroCapacitacion(IOptions<DbSettings> dbSetting)
    {
        _dbSettings = dbSetting.Value;
    }

    public override void Up()
    {
        var schema = _dbSettings.SchemaTables;

        Create.Table("Registro_Capacitacion").InSchema(schema)
            .WithIdColumn() // Columna ID
            .WithColumn("Id_Capacitacion").AsGuid().NotNullable().ForeignKey("Capacitacion", "Id") // Relación con la tabla Capacitacion
            .WithColumn("Id_Usuario").AsGuid().NotNullable().ForeignKey("Usuarios", "Id") // Relación con la tabla Usuarios
            .WithColumn("Fecha_Registro").AsDateTime().NotNullable()
            .WithAuditableFields(); // Para añadir campos como CreatedDate, ModifiedDate, etc.
    }

    public override void Down()
    {
        var schema = _dbSettings.SchemaTables;

        Delete.Table("Registro_Capacitacion").InSchema(schema);
    }
}
