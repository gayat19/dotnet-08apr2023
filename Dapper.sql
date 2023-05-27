create database dbSample27May23

use dbSample27May23

create table Employees
(id int primary key,
Name varchar(20),
Age int)

create proc proc_InsertEmployee(@id int,@name varchar(20),@age int)
as 
insert into Employees values(@id,@name,@age)

exec proc_InsertEmployee 102,'Somu',21

select * from Employees

Select * from Employees


create proc proc_GetAllEmployees
as
  Select * from Employees

  exec proc_GetAllEmployees