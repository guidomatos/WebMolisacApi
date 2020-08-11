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
	--TipoUsuario: 0=No existe,1=Clave Incorrecta,2=Inactivo,3=Activo

	/*variables de entrada*/
	declare @ClaveEncriptada varchar(100) = ''
	set @ClaveEncriptada = (select dbo.fn_EncriptarClave(@Clave))

	/*Variables de salida*/
	declare @Result int = 0
	declare @Mensaje varchar(50) = ''
	declare @TipoUsuario int = 0

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
                set @Result = 1
                set @Mensaje = 'Usuario OK'
                set @TipoUsuario = 4
            end
            else
            begin
                set @Result = 1
                set @Mensaje = 'Usuario Inactivo'
                set @TipoUsuario = 3 
            end
        end
        else
        begin
            set @Result = 0
            set @Mensaje = 'Clave secreta incorrecta'
            set @TipoUsuario = 1
        end
    end
    else
    begin
        set @Result = 0
        set @Mensaje = 'El usuario no existe'
        set @TipoUsuario = 0
    end


	select 
    @Result as Result, 
    @Mensaje as Mensaje, 
    @Codigo as Codigo, 
    @TipoUsuario as TipoUsuario

end
go