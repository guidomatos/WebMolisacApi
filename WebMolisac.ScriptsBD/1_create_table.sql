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

declare @sqlForeignKey varchar(max) = ''
SELECT @sqlForeignKey = @sqlForeignKey + ' ' +
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Promocion')

exec (@sqlForeignKey)
go

declare @sqlForeignKey varchar(max) = ''
SELECT @sqlForeignKey = @sqlForeignKey + ' ' +
    'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
    '].[' + OBJECT_NAME(parent_object_id) + 
    '] DROP CONSTRAINT [' + name + ']'
FROM sys.foreign_keys
WHERE referenced_object_id = object_id('Slider')

exec (@sqlForeignKey)
go

-- declare @sqlForeignKey varchar(max) = ''
-- SELECT @sqlForeignKey = @sqlForeignKey + ' ' +
--     'ALTER TABLE [' +  OBJECT_SCHEMA_NAME(parent_object_id) +
--     '].[' + OBJECT_NAME(parent_object_id) + 
--     '] DROP CONSTRAINT [' + name + ']'
-- FROM sys.foreign_keys
-- WHERE referenced_object_id = object_id('Comprobante')

-- exec (@sqlForeignKey)
-- go


if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Usuario' AND TABLE_SCHEMA = 'dbo')
begin
    drop table Usuario
end
go

if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Promocion' AND TABLE_SCHEMA = 'dbo')
begin
    drop table Promocion
end
go

if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Slider' AND TABLE_SCHEMA = 'dbo')
begin
    drop table Slider
end
go

-- if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Comprobante' AND TABLE_SCHEMA = 'dbo')
-- begin
--     drop table Comprobante
-- end
-- go

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


create table Promocion
(
    PromocionId int not null identity(1,1),
    Nombre varchar(50) NOT NULL,
    Descripcion varchar(100) NULL,
    Imagen varchar(100) NULL,
    Activo bit NOT NULL,
    UsuarioCreacion varchar(50) NULL,
    FechaCreacion datetime NULL,
    UsuarioModificacion varchar(50) NULL,
    FechaModificacion datetime NULL
)

ALTER TABLE Promocion
ADD CONSTRAINT PK_Promocion PRIMARY KEY (PromocionId)
go

ALTER TABLE Promocion
ADD CONSTRAINT DF_Promocion_Activo DEFAULT 1 for Activo
go


create table Slider
(
    SliderId int not null identity(1,1),
    Nombre varchar(50) NOT NULL,
    Titulo varchar(50) NOT NULL,
    Descripcion varchar(100) NULL,
    Imagen varchar(100) NULL,
    Activo bit NOT NULL,
    UsuarioCreacion varchar(50) NULL,
    FechaCreacion datetime NULL,
    UsuarioModificacion varchar(50) NULL,
    FechaModificacion datetime NULL
)

ALTER TABLE Slider
ADD CONSTRAINT PK_Slider PRIMARY KEY (SliderId)
go

ALTER TABLE Slider
ADD CONSTRAINT DF_Slider_Activo DEFAULT 1 for Activo
go


-- create table Comprobante
-- (
--     ComprobanteId int not null identity(1,1),
--     RucEmisor varchar(11) NOT NULL,
--     TipoComprobante char(3) NOT NULL,
--     NumeroComprobante varchar(20) NOT NULL,
--     TipoDocumentoReceptor char(3) NOT NULL,
--     NumeroDocumentoReceptor varchar(20) NOT NULL,
--     FechaEmision date NOT NULL,
--     MontoTotal DECIMAL(18,2) NOT NULL,
--     Activo bit NOT NULL,
--     UsuarioCreacion varchar(50) NULL,
--     FechaCreacion datetime NULL,
--     UsuarioModificacion varchar(50) NULL,
--     FechaModificacion datetime NULL
-- )

-- ALTER TABLE Comprobante
-- ADD CONSTRAINT PK_Comprobante PRIMARY KEY (ComprobanteId)
-- go

-- ALTER TABLE Comprobante
-- ADD CONSTRAINT DF_Comprobante_Activo DEFAULT 1 for Activo
-- go