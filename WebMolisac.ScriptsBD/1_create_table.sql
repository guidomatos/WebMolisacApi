use DB_MOLISAC
go

declare @sqlForeignKey varchar(max) = ''
SELECT @sqlForeignKey = @sqlForeignKey + ' ' +
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Usuario')

exec (@sqlForeignKey)
go


if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Usuario' AND TABLE_SCHEMA = 'dbo')
begin
    drop table Usuario
end
go

create table Usuario
(
    UsuarioId int not null identity(1,1),
    Codigo varchar(50) NOT NULL,
    Clave varchar(100) NOT NULL,
    Activo bit NOT NULL
)

ALTER TABLE Usuario
ADD CONSTRAINT PK_Usuario PRIMARY KEY (UsuarioId)
go

ALTER TABLE Usuario
ADD CONSTRAINT DF_Usuario_Activo DEFAULT 1 for Activo
go