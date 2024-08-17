create table Users
(
    Id int identity(1,1) primary key,
    Name nvarchar(250),
    Email nvarchar(250),
    Login nvarchar(250) unique not null,
    Password nvarchar(250) not null,
    Birth date   
)

create table Authors
(
Id int identity(1,1) primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
RealName nvarchar(50),
BirthYear int,
Country nvarchar(25) not null,
WritingLanguage nvarchar(25) not null
)

create table Genres
(
Id int identity(1,1) primary key,
Name nvarchar(50) not null
)

create table Books
(
Id int identity(1,1) primary key,
AuthorId int foreign key references Authors(Id) not null,
GenreId int foreign key references Genres(Id) not null,
Title nvarchar(50) not null,
)

create table BookScores
(
    Id int identity(1,1) primary key,
    UserId int foreign key references Users(Id) not null,
    BookId int foreign key references Books(Id) not null,
    Score int check (Score <= 10 and Score >= 0) not null
)

insert into Authors values
('Ernest','Hemingway',null,1899,'USA','USA'),
('John','Steinbeck',null,1902,'USA','USA'),
('Stanisław','Lem',null,1921,'PL','PL'),
('Joseph','Conrad','Józef Korzeniowski',1857,'PL','EN'),
('Stephen','King',null,1947,'USA','USA');

insert into Genres values
('społeczno-obyczajowa'),
('sensacyjna'),
('kryminalna'),
('fantastyczno-naukowa'),
('fantasy'),
('marynistyczna'),
('drogi'),
('wojenna'),
('historyczna'),
('horror');

insert into Books
values
(3, 4, 'Solaris'),
(2, 1, 'Na wschód od Edenu'),
(1, 8, 'Komu bije dzwon'),
(1, 2, 'Mieć i nie mieć'),
(1, 1, 'Słońce też wschodzi'),
(4, 6, 'Jądro ciemności'),
(4, 6, 'Lord Jim'),
(5, 10, 'Sklepik z marzeniami'),
(5, 10, 'Lśnienie');

--drop table BookScores;
--drop table Books;
--drop table Authors;
--drop table Genres;
--drop table Users;

--alter schema Literature transfer Books;