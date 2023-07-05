CREATE DATABASE Library;
USE Library;

CREATE TABLE tblLogin(
ID int NOT NULL IDENTITY(1,1) primary key,
Username varchar(150) not null,
Password varchar(150) not null
);

insert into tblLogin (Username,Password) values ('Anna','123');
insert into tblLogin (Username,Password) values ('Bella','234');

select * from tblLogin;

CREATE TABLE tblNewBook(
BID int NOT NULL IDENTITY(1,1) primary key,
BName varchar(250) not null,
BAuthor varchar(250) not null,
BPublisher varchar(250) not null,
BDate varchar(250) not null,
BPrice bigint not null,
BQuantity bigint not null
);



select * from tblNewBook;

CREATE TABLE tblNewStudent(
StuID int NOT NULL IDENTITY(1,1) primary key,
SName varchar(250) not null,
Enroll varchar(250) not null,
Dep varchar(250) not null,
Sem varchar(250) not null,
Contact bigint not null,
Email varchar(250) not null
);

select * from tblNewStudent;



CREATE TABLE tblIBook(
ID int NOT NULL IDENTITY(1,1) primary key,
std_enroll varchar(250) not null,
std_name varchar(250) not null,
std_dep varchar(250) not null,
std_sem varchar(250) not null,
std_contact bigint not null,
std_email varchar(250) not null,
book_name varchar(250) not null,
book_issue_date varchar(250) not null ,
book_return_date varchar(250)
);


DROP TABLE tblIBook;

select * from tblIBook;