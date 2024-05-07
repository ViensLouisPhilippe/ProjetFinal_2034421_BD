Use [master]
go
Create DATABASE [BD1_BengalsCincinnati_TP1]
go
Exec sp_Configure filestream_access_level, 2 Reconfigure

alter database BD1_BengalsCincinnati_TP1
add filegroup FG_Images Contains Filestream;
go
alter database [BD1_BengalsCincinnati_TP1]
add file (
	name = FG_Images,
	FileName = 'C:\EspaceLabo\FG_Images'
)
to FileGroup FG_Images
go