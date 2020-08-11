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