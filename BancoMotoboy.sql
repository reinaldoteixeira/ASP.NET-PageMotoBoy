create database bd_motoboy;

use bd_motoboy;

create table motoboys
(id				int				identity,
nome			varchar(50)		not null,
placa			varchar(8)		not null,
telefone		varchar(20)		null,
primary key(id));


create table solicitacao
(id				int				identity,
nome			varchar(50)		not null,
endereco		varchar(50)		not null,
motoboy			int				null,
distancia		decimal(7,2)	null,
preco_viagem	decimal(7,2)	null,
situacao		int				null,
data			date			null,
hora			time			null,
primary key(id),
foreign key(motoboy) references motoboys(id));




create table usuarios
(id				int				identity,
nome			varchar(50)		not null,
senha			varchar(20)		not null,
primary key(id));


create table configuracao
(id				int				identity,
preco_km		decimal(7,2)	null,
primary key(id));