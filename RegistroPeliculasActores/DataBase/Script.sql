create table Peliculas(
PeliculaId int identity(1,1) primary key,
Nombre varchar(80),
FechaEstreno date,
Actor varchar(80)
);

create table Actores(
ActorId int identity(1,1) primary key,
Nombre varchar(80)
);

create table PeliculasActores(
PeliculaId int identity(1,1) primary key,
ActorId int identity(1,1) primary key
);