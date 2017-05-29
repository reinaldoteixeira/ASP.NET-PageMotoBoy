create database bd_motoboy;

use bd_motoboy;

create table motoboys
(id				int				identity,
nome			varchar(50)		not null,
usuario			int				null,
placa			varchar(8)		not null,
telefone		varchar(20)		null,
primary key(id));

select * from motoboys;


create table solicitacao
(id				int				identity,
nome			varchar(50)		not null,
endereco		varchar(50)		not null,
motoboy			int				null,
distancia		decimal(7,2)	null,
preco_viagem	decimal(7,2)	null,
situacao		int				null,
data			date			null,
hora			int				null,
minutos			int				null,
primary key(id),
foreign key(motoboy) references motoboys(id));

select * from solicitacao;



create table usuarios
(id				int				identity,
nome			varchar(50)		not null,
senha			varchar(20)		not null,
motoboy			bit				not null,
primary key(id));

insert into usuarios values('adm','123',1);

select * from usuarios;



create table configuracao
(id				int				identity,
preco_fixo		decimal(7,2)	null,
Apartir			decimal(7,2)	null,
preco_km		decimal(7,2)	null,
primary key(id));


insert into configuracao values (0,0,0);

select * from configuracao where id = 1; 


