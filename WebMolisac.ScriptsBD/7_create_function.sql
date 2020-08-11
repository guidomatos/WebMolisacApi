use DB_MOLISAC
go

create or alter function dbo.fn_EncriptarClave
/****************************************************************
Nombre: fn_EncriptarClave
Objetivo: Encriptar clave de usuario
Autor: Guido Matos Camones
Fecha Creación: 10/08/2020
Notas:
***************************************************************
select dbo.fn_EncriptarClave('1234')
****************************************************************/
(
	@ClaveSecreta varchar(50)
)
returns varchar(100)
as
begin

	declare @resultado varchar(100) = '';

	set @resultado = UPPER(master.dbo.fn_varbintohexsubstring(0, HashBytes('SHA1', @ClaveSecreta), 1, 0))

	return @resultado

end
go