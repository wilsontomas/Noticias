
create database Noticias
use Noticias
create table Categoria(
IdCategoria int not null primary key identity(1,1),
NombreCategoria varchar(100) not null
)

create table Pais(
IdPais int not null primary key identity(1,1),
NombrePais varchar(100) not null
)


insert into Categoria (NombreCategoria) values ('Deportes');
insert into Categoria (NombreCategoria) values ('Musica');
insert into Categoria (NombreCategoria) values ('Peliculas');
insert into Categoria (NombreCategoria) values ('Arte');
insert into Categoria (NombreCategoria) values ('Tecnologia');
insert into Categoria (NombreCategoria) values ('Politica');

insert into Pais (NombrePais) values ('Rep Dominicana');
insert into Pais (NombrePais) values ('Estados Unidos');
insert into Pais (NombrePais) values ('Panama');
insert into Pais (NombrePais) values ('Peru');
insert into Pais (NombrePais) values ('Colombia');
insert into Pais (NombrePais) values ('Argentina');
insert into Pais (NombrePais) values ('Venezuela');
insert into Pais (NombrePais) values ('Chile');
insert into Pais (NombrePais) values ('Mexico');
insert into Pais (NombrePais) values ('Suiza');
insert into Pais (NombrePais) values ('Alemania');
insert into Pais (NombrePais) values ('Rusia');
insert into Pais (NombrePais) values ('Japon');
insert into Pais (NombrePais) values ('China');

select * from Pais
create table ArticulosNoticias(
IdNoticias int not null primary key identity(1,1),
Titulo varchar(max) not null,
Articulo varchar(max) not null,
Fecha datetime default getdate(),
CategoriaId int not null foreign key references Categoria(IdCategoria),
PaisId int not null foreign key references Pais(IdPais),
)

insert into ArticulosNoticias (Titulo,Articulo,CategoriaId, PaisId) values ('Mart�nez y De Jes�s ganan dos en inicio del Clasificatorio Norceca', 'Los dominicanos Oscar Mart�nez y Hayerling de Jes�s derrot� 2-0 (21-16, 21-16) a Criforth Lobos y Daniel Dyner, de Costa Rica, en el  inicio del Clasificatorio NORCECA de Voleibol de Playa, que se escenifica hasta el pr�ximo domingo en el litoral de Punta Cana, Higuey. En su segunda presentaci�n de la justa dedicada al empresario Ernesto Veloz, Mart�nez y De Jes�s, el binomio �A� de Rep�blica Dominicana, dio cuenta id�ntico marcador de R�o V�ctor y Levi Leonce, de Santa Luc�a . La pareja �B� de Qusiqueya, conformada por Rayner Sarmiento y Deivy Ram�rez del pa�s tropez� con  los cubanos Noslen D�az y Luis Reyes, quien es lo superaron f�cilmente 21-8, 21-10.',1,1);
insert into ArticulosNoticias (Titulo,Articulo,CategoriaId, PaisId) values ('Miderec anuncia plan deportes gratuito durante las vacaciones, iniciar� en el Distrito','El ministro de Deportes y Recreaci�n, Francisco Camacho, anunci� la puesta en marcha de �Programas de deportes gratuitos� durante las vacaciones escolares en todas las instalaciones del Centro Ol�mpico Juan Pablo Duarte, que iniciar� como un plan piloto para cinco mil atletas-estudiantes del Distrito Nacional. Indic� que las actividades se desarrollar�n de 3:00 a 6:00 de la tarde y los participantes tendr�n garantizados todos los protocolos de bioseguridad para protegerlos de la pandemia del Covid-19. Las inscripciones para el mismo comenzar�n el lunes 5 de este mes. Camacho sentenci� que los miles de ni�os y j�venes recibir�n pr�cticas en las disciplinas voleibol, baloncesto, softbol, b�isbol, boxeo, karate, taekwondo, f�tbol, judo, atletismo, lucha ol�mpica, ajedrez, wushu, entre otras disciplinas.',2,1)


create procedure ObtenerNoticias
as set nocount on
begin
 select a.IdNoticias,a.Titulo,a.Articulo,a.Fecha, a.PaisId,a.CategoriaId from ArticulosNoticias a
end

create procedure ObtenerNoticiasModel
as set nocount on
begin
	select a.IdNoticias, a.Titulo, a.Articulo, a.Fecha,c.NombreCategoria, p.NombrePais from ArticulosNoticias a inner join Categoria c on a.CategoriaId=c.IdCategoria inner join Pais p on a.PaisId = p.IdPais
end
create procedure ObtenerNoticiasPorPais
(@idpais int)
as set nocount on
begin
select a.IdNoticias, a.Titulo, a.Articulo, a.Fecha,c.NombreCategoria, p.NombrePais from ArticulosNoticias a inner join Categoria c on a.CategoriaId=c.IdCategoria inner join Pais p on a.PaisId = p.IdPais where a.PaisId=@idpais

end

create procedure ObtenerNoticiasPorCategoria
(@idcategoria int)
as set nocount on
begin
select a.IdNoticias, a.Titulo, a.Articulo, a.Fecha,c.NombreCategoria, p.NombrePais from ArticulosNoticias a inner join Categoria c on a.CategoriaId=c.IdCategoria inner join Pais p on a.PaisId = p.IdPais where a.CategoriaId=@idcategoria
end

create procedure InsertarNoticia
(@Titulo varchar(max),@Articulo varchar(max),@CategoriaId int,@PaisId int)
as set nocount on
begin
insert into ArticulosNoticias (Titulo,Articulo,CategoriaId, PaisId) values (@Titulo, @Articulo, @CategoriaId, @PaisId)
end

create procedure EditarNoticia
(@IdNoticias int,@Titulo varchar(max),@Articulo varchar(max),@CategoriaId int,@PaisId int)
as set nocount on
begin
update ArticulosNoticias set Titulo =@Titulo, Articulo=@Articulo, CategoriaId=@CategoriaId, PaisId=@PaisId where IdNoticias = @IdNoticias;
end


create procedure EliminarNoticia
(@IdNoticia int)
as set nocount on
begin
delete from ArticulosNoticias where IdNoticias = @IdNoticia
end

create procedure ObtenerPais
as set nocount on
begin
select p.IdPais,p.NombrePais from Pais p
end

create procedure ObtenerCategoria
as set nocount on
begin
select c.IdCategoria,c.NombreCategoria from Categoria c
end

create procedure ObtenerNoticiaPorId
(@IdNoticia int)
as set nocount on
begin
select a.IdNoticias, a.Titulo, a.Articulo, a.Fecha,c.NombreCategoria, p.NombrePais 
from ArticulosNoticias a inner join Categoria c on a.CategoriaId=c.IdCategoria
 inner join Pais p on a.PaisId = p.IdPais where a.IdNoticias=@IdNoticia
	end

create procedure ObtenerNoticiaPorBusqueda
(@termino varchar(255))
as set nocount on
begin
select a.IdNoticias, a.Titulo, a.Articulo, a.Fecha,c.NombreCategoria, p.NombrePais 
from ArticulosNoticias a inner join Categoria c on a.CategoriaId=c.IdCategoria 
inner join Pais p on a.PaisId = p.IdPais where a.Titulo like '%'+@termino+'%' or a.Articulo like '%'+@termino+'%';
end

