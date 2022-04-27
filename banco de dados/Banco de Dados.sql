-- drop database bdConverte;
create database bdConverte;
use bdConverte;

create table tbCaps (
 cod_desc varchar(20) not null,
 Nome varchar (50) not null,
 Cor varchar (20) not null,
 Pesominimo int not null,
 Pesomedio int not null,
 Pesomaximo int not null,
 Ativo varchar(1) default "s",
 constraint pk_peso primary key (cod_desc) 
 );
  
 create table tblogin(
 cod_user int auto_increment not null,
 nome varchar(100) not null,
 login varchar (50) not null,
 senha varchar (30) not null,
 adm varchar (1) not null,
 Ativo varchar(1) default "s",
 constraint pk_cod_user primary key (cod_user)
 );
 
 create table tbRegistro(
 cod_reg int auto_increment not null,
 cod_desc varchar(20) not null,
 peso varchar(20) not null,
 quantidade varchar(20) not null,
 constraint pk_cod_reg primary key (cod_reg),
 constraint fk_cod_desc foreign key(cod_desc) references tbCaps(cod_desc)
 );
 
INSERT INTO tblogin (nome, login, senha, adm) VALUES("samuel melo da silva", "samuel.silva", "samuel21", "s");
INSERT INTO tblogin (nome, login, senha, adm) VALUES("Etec Sylverinho", "adeus.etec", "etec1234", "n");

select *from  tblogin;

insert into tbCaps (cod_desc,  Nome, Cor,  Pesominimo,  Pesomedio, Pesomaximo) VALUES 
("PI.169.00.0055", "BCAA 2400MG - 1CAPS", "INCOLOR", 669, 719, 769),
("PI.34.00.0055", "CHAROMIUM PICOLINATE - 1CAPS", "ESCARLATE", 404, 435, 465),
("PI.180.00.0055", "COLAGEM MAX TITAN - 1CAPS", "INCOLOR", 578, 622, 666),
("PI.128.00.0055", "CREA CAPS - 1CAPS", "AMARELA", 811, 872, 933),
("PI.325.00.0055", "M- TOR LEUCINE - 1CAPS", "INCOLOR", 488, 525, 562),
("PI.394.00.0055", "MULTIMAX COMPLEX - 1CAPS", "VD ESC/CL", 920, 989, 1058),
("PI.474.00.0055", "MULTIMAX FEMME  - 1CAPS", "ESCARLATE", 594, 638, 682);
