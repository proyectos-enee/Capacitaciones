using FluentMigrator.Builders.Create.Table;

namespace Capacitaciones.Data;

public static class MigrationHelpers
{
    /// <summary>
    /// Metodo de extensión para crear Id de la tabla
    /// </summary>
    /// <param name="tableWithColumnSyntax"></param>
    /// <returns></returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(
        this ICreateTableWithColumnSyntax tableWithColumnSyntax
    )
    {
        return tableWithColumnSyntax
            .WithColumn("Id")
            .AsGuid()
            .NotNullable()
            .PrimaryKey()
            .WithColumnDescription("Llave primaria de la tabla");
    }

    /// <summary>
    /// Metodo de extensión para crear Id de la tabla, que permite
    /// elegir el nombre de la primary key
    /// </summary>
    /// <param name="tableWithColumnSyntax">Referencia a la tabla que se está construyendo, cargada de forma implícita por .net</param>
    /// <param name="primaryKeyName">Nombre asignado a la clave primaria</param>
    /// <returns></returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(
        this ICreateTableWithColumnSyntax tableWithColumnSyntax,
        string primaryKeyName
    )
    {
        return tableWithColumnSyntax
            .WithColumn("Id")
            .AsGuid()
            .NotNullable()
            .PrimaryKey(primaryKeyName)
            .WithColumnDescription("Llave primaria de la tabla");
    }

    /// <summary>
    /// Metodo de extensión que crea las columnnas de auditoria
    /// </summary>
    /// <param name="tableWithColumnSyntax"></param>
    /// <returns></returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax WithAuditableFields(
        this ICreateTableWithColumnSyntax tableWithColumnSyntax
    )
    {
        return tableWithColumnSyntax
            .WithColumn("CreatedBy")
            .AsString(256)
            .NotNullable()
            .WithDefaultValue("system")
            .WithColumnDescription("Registra el usuario que creo el registro")
            .WithColumn("CreatedDate")
            .AsDateTime()
            .WithDefaultValue(DateTime.UtcNow)
            .NotNullable()
            .WithColumnDescription("Registra la fecha que creo el registro")
            .WithColumn("UpdatedBy")
            .AsString(256)
            .Nullable()
            .WithColumnDescription("Registra el usuario que actualizo el registro")
            .WithColumn("UpdatedDate")
            .AsDateTime()
            .Nullable()
            .WithColumnDescription("Registra la fecha en que actualizo el registro")
            .WithColumn("DeletedBy")
            .AsString(256)
            .Nullable()
            .WithColumnDescription("Registra el usuario que elimino el registro")
            .WithColumn("DeletedDate")
            .AsDateTime()
            .Nullable()
            .WithColumnDescription("Registra la fecha en que elimino el registro");
    }

    /// <summary>
    /// Metodo de extencion que permite crear la columna de traducciones
    /// </summary>
    /// <param name="tableWithColumnSyntax"></param>
    /// <returns></returns>
    public static ICreateTableColumnOptionOrWithColumnSyntax WithTranslations(
        this ICreateTableWithColumnSyntax tableWithColumnSyntax
    )
    {
        return tableWithColumnSyntax
            .WithColumn("Translations")
            .AsString(int.MaxValue)
            .WithColumnDescription(
                "Json necesario para definir las traducciones de las columnas"
            )
            .Nullable();
    }
}
