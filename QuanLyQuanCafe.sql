Create database QuanlyQuanCafe9
Go

Use QuanlyQuanCafe9
Go

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillDetail

create Table [Tables]
(
	id Int IDENTITY PRIMARY KEY,
	[name] NVARCHAR(100) default N'Empty',
	[status] NVARCHAR(100) default N'None Booking'   -- 0: Trong | 1: co nguoi| 
)
GO

create Table [Account]
(	
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) not null	,
	[Password] nvarchar(100) not null,
	type int not null default 0
)
GO

create Table [FoodCategory]
(
	id Int IDENTITY PRIMARY KEY,
	[name] NVARCHAR(100) not null default N'Empty',
)
GO

create Table [Food]
(
	id Int IDENTITY PRIMARY KEY,
	[name] NVARCHAR(100) not null default N'Empty',
	idCategory int not null,
	price float not null default 0,

	foreign key (idCategory) references dbo.[FoodCategory](id)
)
GO

create table Bill
(
	id Int IDENTITY PRIMARY KEY,
	DateCheckIn smalldatetime Not null,
	DateCheckOut smalldatetime,
	idTable int not null,
	[status] int not null default 0, -- 1: da thanh toan && 0: chua thanh toan
	discount int default 0,
	totalPrice int default 0
	Foreign key (idTable) references dbo.[Tables](id)
)
go

create table BillDetail
(
	id Int IDENTITY PRIMARY KEY,
	idBill int not null,
	idfood int not null,
	[count] int not null default 0

	Foreign key (idBill) references dbo.[Bill](id),
	Foreign key (idfood) references dbo.[Food](id)
)

ALTER TABLE Bill
ADD discount int default 0;

insert into dbo.Account(UserName, DisplayName, [Password], [type])
values(N'Admin', N'Linh',N'1',1)
insert into dbo.Account(UserName, DisplayName, [Password], [type])
values(N'staff1', N'staff1',N'1',0)
insert into dbo.Account(UserName, DisplayName, [Password], [type])
values(N'staff2', N'staff2',N'1',0)
go

create proc USP_GetAccountByUserName
@userName nvarchar(100)
as
begin
	select * from Account where UserName = @userName
end
go

exec USP_GetAccountByUserName @userName = N''

DECLARE @i int = 1
while @i <= 10
begin
INSERT dbo.[Tables]
([name])
values(N'Table ' + cast(@i as nvarchar(100)))
set @i = @i + 1
end

-- add food
insert dbo.FoodCategory([name]) values(N'Sweet food')

insert  dbo.Food([name], idCategory, price) values(N'flan cake', 1, 49000)
insert dbo.Food([name], idCategory, price) values(N'Tiramisu', 1, 49000)
insert dbo.Food([name], idCategory, price) values(N'Cookies', 1, 39000)
insert dbo.Food([name], idCategory, price) values(N'Macaron', 1, 49000)
insert dbo.Food([name], idCategory, price) values(N'Mousse cake', 1, 59000)
insert dbo.Food([name], idCategory, price) values(N'Muffin và cupcake', 1, 69000)
insert dbo.Food([name], idCategory, price) values(N'Chocolate tart', 1, 49000)
insert dbo.Food([name], idCategory, price) values(N'Cheesecake', 1, 49000)
insert dbo.Food([name], idCategory, price) values(N'Nama Chocolate', 1, 59000)
insert dbo.FoodCategory([name]) values(N'Water')
insert dbo.Food([name], idCategory, price) values(N'Espresso', 2, 59000)
insert dbo.Food([name], idCategory, price) values(N'Cappuccino', 2, 59000)
insert dbo.Food([name], idCategory, price) values(N'Latte Cafe', 2, 59000)
insert dbo.Food([name], idCategory, price) values(N'Traditional Cafe ', 2, 59000)
insert dbo.Food([name], idCategory, price) values(N'Latte Macchiato ', 2, 59000)
insert dbo.Food([name], idCategory, price) values(N'Mocha Cafe ', 2, 59000)

insert dbo.Bill(DateCheckIn,DateCheckOut, idTable, [status]) values(GETDATE(),GETDATE(),1,0)
insert dbo.Bill(DateCheckIn,DateCheckOut, idTable, [status]) values(GETDATE(),GETDATE(),2,0)

insert dbo.BillDetail(idBill, idfood, [count]) values(1,5,1)
insert dbo.BillDetail(idBill, idfood, [count]) values(2,1,2)
insert dbo.BillDetail(idBill, idfood, [count]) values(2,6,2)
insert dbo.BillDetail(idBill, idfood, [count]) values(1,3,1)
select * from [Tables] where [name] = 'Table 1'
select * from Bill where idTable = 7
select * from BillDetail
select * from Account
select * from Food
select * from FoodCategory

select f.[name], bd.[count], f.price   from BillDetail bd 
inner join Bill b  on bd.idBill = b.id
inner join Food f on f.id = bd.idfood 
where bd.idBill = 1 and bd.idfood = 5

select * from Food f inner join FoodCategory fc 
on f.idCategory = fc.id where fc.[name] = 'Water' and f.[name] = 'Latte Cafe'
select * from BillDetail

DELETE FROM Bill WHERE id = 3 ;

select * from BillDetail bd 
inner join (Bill b inner join Tables t on b.idTable = t.id) on bd.idBill = b.id
inner join Food f on f.id = bd.idfood
where b.idTable = 2 and b.status = 0

