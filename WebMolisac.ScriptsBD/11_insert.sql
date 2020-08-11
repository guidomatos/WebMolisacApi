use DB_MOLISAC
go


-----------------------------------
--SuperAdmin
-----------------------------------
declare @UsuarioIdSuperAdmin int=0;
declare @UsuarioCodigoSuperAdmin varchar(50)='gmatos';

select @UsuarioIdSuperAdmin = UsuarioId from Usuario where Codigo = @UsuarioCodigoSuperAdmin and Activo = 1

if (ISNULL(@UsuarioIdSuperAdmin,0)=0)
begin

	insert into Usuario
	(
	Codigo,
	Clave
	) 
	values 
	(
	@UsuarioCodigoSuperAdmin,
	(select dbo.fn_EncriptarClave('123456'))
	)

	set @UsuarioIdSuperAdmin = @@IDENTITY

end

go