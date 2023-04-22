create database dbProduct22Apr2023
go

use dbProduct22Apr2023
go

create table Products
(id int identity(101,1) primary key,
name varchar(50),
price float)
go

create or alter proc proc_InsertProduct(@pname varchar(50), @pprice float, @pid int out)
as
  Insert into Products(name,price) values(@pname,@pprice)
  set @pid = @@IDENTITY
go

exec proc_InsertProduct 'Pen', 12.5
exec proc_InsertProduct 'Pencil', 5.75
exec proc_InsertProduct 'Eraser', 3
go

create proc proc_GetAllProducts
as
 select * from Products
go