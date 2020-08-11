use DB_MOLISAC
go

CREATE OR ALTER PROCEDURE dbo.ValidarLogin
/****************************************************************
Nombre: ValidarLogin
Objetivo: Validar acceso de usuario
Autor: Guido Matos Camones
Fecha Creación: 10/08/2020
Notas:
***************************************************************
exec dbo.ValidarLogin 'gmatos', '123456'
****************************************************************/
(
@Codigo varchar(50),
@Clave varchar(50)
)
as
begin
	--TipoResultado: 0=No existe,1=Clave Incorrecta,2=Inactivo,3=Activo

	/*variables de entrada*/
	declare @ClaveEncriptada varchar(100) = ''
	set @ClaveEncriptada = (select dbo.fn_EncriptarClave(@Clave))

	/*Variables de salida*/
	declare @Resultado int = 0
	declare @Mensaje varchar(50) = ''
	declare @TipoResultado int = 0

	if exists (	select 1 from Usuario where Codigo = @Codigo)
    begin
        if exists (select 1 from Usuario where Codigo = @Codigo and Clave = @ClaveEncriptada)
        begin
            declare @Activo2 bit = 0			
            select @Activo2 = Activo
            from Usuario 
            where Codigo = @Codigo and Clave = @ClaveEncriptada
        
            if @Activo2 = 1
            begin
                set @Resultado = 1
                set @Mensaje = 'Usuario OK'
                set @TipoResultado = 4
            end
            else
            begin
                set @Resultado = 1
                set @Mensaje = 'Usuario Inactivo'
                set @TipoResultado = 3 
            end
        end
        else
        begin
            set @Resultado = 0
            set @Mensaje = 'Clave secreta incorrecta'
            set @TipoResultado = 1
        end
    end
    else
    begin
        set @Resultado = 0
        set @Mensaje = 'El usuario no existe'
        set @TipoResultado = 0
    end


	select 
    @Resultado as Resultado, 
    @Mensaje as Mensaje, 
    @Codigo as CodigoUsuario, 
    @TipoResultado as TipoResultado

end
go

create or alter procedure dbo.ObtenerDatosSesion
/****************************************************************
Nombre: ValidarLogin
Objetivo: Validar acceso de usuario
Autor: Guido Matos Camones
Fecha Creación: 10/08/2020
Notas:
***************************************************************
exec dbo.ObtenerDatosSesion 'gmatos'
****************************************************************/
(
@Codigo varchar(50)
)
as
begin
	declare @FechaActual datetime = (select dbo.fn_ObtenerFechaActual())

	declare @UsuarioId int = 0;
	select @UsuarioId = UsuarioId from Usuario where Codigo = @Codigo and Activo = 1

	select
	u.UsuarioId,
	u.Codigo, 
	u.Clave
	from Usuario u
	where UsuarioId = @UsuarioId

end

go


create or alter procedure dbo.RegistrarPromocion
/****************************************************************
Nombre: RegistrarPromocion
Objetivo: Registrar promociones
Autor: Guido Matos Camones
Fecha Creación: 11/08/2020
Notas:
***************************************************************
exec dbo.RegistrarPromocion @Nombre='2 x 1 Arroz'
****************************************************************/
(
@Nombre varchar(50),
@Descripcion varchar(100) = NULL,
@Imagen varchar(100) = NULL,
@UsuarioCreacion varchar(50) = NULL
)
as
begin
begin try

	declare @FechaActual datetime = (select dbo.fn_ObtenerFechaActual())

    set @Nombre = ISNULL(LTRIM(RTRIM(@Nombre)),'');
    set @Descripcion = ISNULL(LTRIM(RTRIM(@Descripcion)),'');
    set @Imagen = ISNULL(LTRIM(RTRIM(@Imagen)),'');
    set @UsuarioCreacion = ISNULL(LTRIM(RTRIM(@UsuarioCreacion)),'');

    declare @PromocionId int=0;

	-- BEGIN TRANSACTION TRAN_GUARDAR_PROMOCION

		INSERT INTO Promocion
		(
		Nombre,
        Descripcion,
        Imagen,
        UsuarioCreacion,
        FechaCreacion
		)
		VALUES
		(
		@Nombre,
        @Descripcion,
        @Imagen,
        @UsuarioCreacion,
        @FechaActual
		)

		SET @PromocionId = @@IDENTITY;
		
    -- COMMIT TRANSACTION TRAN_GUARDAR_PROMOCION

	SELECT @PromocionId

end try
begin catch
    
    print 'ERROR_MESSAGE() ' + convert(varchar(max),ERROR_MESSAGE())
    print 'ERROR_LINE() ' + convert(varchar(max),ERROR_LINE())

    -- if (@@TRANCOUNT > 0) ROLLBACK TRANSACTION TRAN_GUARDAR_PROMOCION
    SELECT -1

end catch
end
go

create or alter procedure dbo.ActualizarPromocion
/****************************************************************
Nombre: ActualizarPromocion
Objetivo: Actualizar promociones
Autor: Guido Matos Camones
Fecha Creación: 11/08/2020
Notas:
***************************************************************
exec dbo.ActualizarPromocion @PromocionId = 1, @Nombre='2 x 1 Arroz'
****************************************************************/
(
@PromocionId int,
@Nombre varchar(50),
@Descripcion varchar(100) = NULL,
@Imagen varchar(100) = NULL,
@UsuarioModificacion varchar(50) = NULL
)
as
begin
begin try

	declare @FechaActual datetime = (select dbo.fn_ObtenerFechaActual())

    set @Nombre = ISNULL(LTRIM(RTRIM(@Nombre)),'');
    set @Descripcion = ISNULL(LTRIM(RTRIM(@Descripcion)),'');
    set @Imagen = ISNULL(LTRIM(RTRIM(@Imagen)),'');
    set @UsuarioModificacion = ISNULL(LTRIM(RTRIM(@UsuarioModificacion)),'');

	-- BEGIN TRANSACTION TRAN_ACTUALIZAR_PROMOCION

		UPDATE Promocion
		SET 
        Nombre = @Nombre,
        Descripcion = @Descripcion,
        Imagen = @Imagen,
        UsuarioModificacion = @UsuarioModificacion,
        FechaModificacion = @FechaActual
        WHERE
        PromocionId = @PromocionId

    -- COMMIT TRANSACTION TRAN_ACTUALIZAR_PROMOCION

	SELECT @PromocionId

end try
begin catch
    
    print 'ERROR_MESSAGE() ' + convert(varchar(max),ERROR_MESSAGE())
    print 'ERROR_LINE() ' + convert(varchar(max),ERROR_LINE())

    -- if (@@TRANCOUNT > 0) ROLLBACK TRANSACTION TRAN_ACTUALIZAR_PROMOCION
    SELECT -1

end catch
end
go

create or alter procedure dbo.EliminarPromocion
/****************************************************************
Nombre: EliminarPromocion
Objetivo: Eliminar promociones
Autor: Guido Matos Camones
Fecha Creación: 11/08/2020
Notas:
***************************************************************
exec dbo.EliminarPromocion @PromocionId = 1
****************************************************************/
(
@PromocionId int,
@UsuarioModificacion varchar(50) = NULL
)
as
begin
begin try

	declare @FechaActual datetime = (select dbo.fn_ObtenerFechaActual())

    set @UsuarioModificacion = ISNULL(LTRIM(RTRIM(@UsuarioModificacion)),'');

	-- BEGIN TRANSACTION TRAN_ELIMINAR_PROMOCION

		UPDATE Promocion
		SET 
        Activo = 0,
        UsuarioModificacion = @UsuarioModificacion
        WHERE
        PromocionId = @PromocionId

    -- COMMIT TRANSACTION TRAN_ELIMINAR_PROMOCION

	SELECT @PromocionId

end try
begin catch
    
    print 'ERROR_MESSAGE() ' + convert(varchar(max),ERROR_MESSAGE())
    print 'ERROR_LINE() ' + convert(varchar(max),ERROR_LINE())

    -- if (@@TRANCOUNT > 0) ROLLBACK TRANSACTION TRAN_ELIMINAR_PROMOCION
    SELECT -1

end catch
end
go

create or alter procedure dbo.ObtenerPromociones
/****************************************************************
Nombre: ObtenerPromociones
Objetivo: Mostrar todas las promociones activas
Autor: Guido Matos Camones
Fecha Creación: 11/08/2020
Notas:
***************************************************************
exec dbo.ObtenerPromociones
****************************************************************/
as
begin

    SELECT
    PromocionId,
    Nombre,
    Descripcion,
    Imagen
    FROM Promocion
    WHERE
    Activo = 1

end
go


create or alter procedure dbo.ObtenerPromocion
/****************************************************************
Nombre: ObtenerPromocion
Objetivo: Mostrar datos de una promoción
Autor: Guido Matos Camones
Fecha Creación: 11/08/2020
Notas:
***************************************************************
exec dbo.ObtenerPromocion @PromocionId = 1
****************************************************************/
(
@PromocionId int
)
as
begin

    SELECT
    PromocionId,
    Nombre,
    Descripcion,
    Imagen
    FROM Promocion
    WHERE
    PromocionId = @PromocionId

end
go