
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

periodo int,
idRiesgo int FOREIGN KEY REFERENCES Riesgo(idRiesgo),
precio money

)
create table PolizasXTipos
(
idPolizasXRiesgos int not null identity  primary key,
idPoliza int FOREIGN KEY REFERENCES Polizas(idPoliza),
idTipoCubirmiento int FOREIGN KEY REFERENCES TipoCubrimientos(idTipoCubirmiento)
)


create table usuarios(
idUsuario int identity primary key not null,
login varchar(50),
password varchar(max)
)

create table Clientes
(
idCliente int identity not null primary key,
Nombre varchar(50),
Cedula varchar(12),
Telefono varchar(13)

)

create table ClientesXpoliza
(
idUsuariosXpoliza int not null identity primary key,
idPoliza int FOREIGN KEY REFERENCES Polizas(idPoliza),
idCliente int FOREIGN KEY REFERENCES Clientes(idCliente),
InicioVigencia date,
estado bit
)

insert into TipoCubrimientos values('Terremoto',100)
insert into TipoCubrimientos values('Incendio',100)
insert into TipoCubrimientos values('Robo',75)
insert into TipoCubrimientos values('Perdida',90)


insert into Riesgo values ('Bajo')
insert into Riesgo values ('Medio')
insert into Riesgo values ('Medio-alto')
insert into Riesgo values ('Alto')

Insert into usuarios values ('Prueba1','123')
Insert into usuarios values ('Prueba2','123')