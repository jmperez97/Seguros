create database seguros
go

use seguros
go

create table TipoCubrimientos
(
 idTipoCubirmiento int not null identity primary key,
 tipo varchar(50),
 porcentage int not null
)
create table Riesgo
(
 idRiesgo int not null identity  primary key,
 nivel varchar(50)
)

create table Polizas
(
idPoliza int not null identity  primary key,
nombre varchar(50) not null,
descripcion varchar(max),
InicioVigencia date,
periodo int,
idRiesgo int FOREIGN KEY REFERENCES Riesgo(idRiesgo)

)
create table PolizasXTipos
(
idPolizasXRiesgos int not null identity  primary key,
idPoliza int FOREIGN KEY REFERENCES Polizas(idPoliza),
idTipoCubirmiento int FOREIGN KEY REFERENCES TipoCubrimientos(idTipoCubirmiento)
)
