using Enee.IoC.Architecture;
using FluentMigrator;
using Microsoft.Extensions.Options;

namespace Capacitaciones.Data.Migrations;
[Migration(202404111625)]
public class AgregarTablaUsuarios : Migration
{
    private readonly DbSettings _dbSettings;

    public AgregarTablaUsuarios(IOptions<DbSettings> dbSetting)
    {
        _dbSettings = dbSetting.Value;
    }

    public override void Up()
    {
        var schema = _dbSettings.SchemaTables;

        Create.Table("Usuarios").InSchema(schema)
            .WithIdColumn() // El sistema genera automáticamente un nombre para la restricción de la clave primaria
            .WithColumn("Nombre").AsString(100).NotNullable()
            .WithColumn("Apellido").AsString(100).NotNullable()
            .WithColumn("Email").AsString(150).NotNullable().Unique()
            .WithColumn("Password").AsString(200).NotNullable()
            .WithColumn("FechaRegistro").AsDateTime().NotNullable()
            .WithColumn("Estado").AsString(50).NotNullable()
            .WithAuditableFields(); // Para añadir campos como CreatedDate, ModifiedDate, etc.
    }

    public override void Down()
    {
        var schema = _dbSettings.SchemaTables;

        Delete.Table("Usuarios").InSchema(schema);
    }
}
