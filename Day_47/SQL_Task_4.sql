
--1.
create function GetZodiac(@BirthDate datetime)
returns varchar(100)
begin
declare @zodiac varchar(100)
IF (MONTH(@BirthDate) = 1 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 2 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Aquarius'
IF (MONTH(@BirthDate) = 2 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 3 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac ='Pisces'
IF (MONTH(@BirthDate) = 3 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 4 AND DATEPART(DAY,@BirthDate) <= 19) set @zodiac = 'Aries'
IF (MONTH(@BirthDate) = 4 AND DATEPART(DAY,@BirthDate) >= 20) OR (MONTH(@BirthDate) = 5 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Taurus'
IF (MONTH(@BirthDate) = 5 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 6 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Gemini'
IF (MONTH(@BirthDate) = 6 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 7 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Cancer'
IF (MONTH(@BirthDate) = 7 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 8 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Leo'
IF (MONTH(@BirthDate) = 8 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 9 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Virgo'
IF (MONTH(@BirthDate) = 9 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 10 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Libra'
IF (MONTH(@BirthDate) = 10 AND DATEPART(DAY,@BirthDate)  >= 21) OR (MONTH(@BirthDate) = 11 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Scorpio'
IF (MONTH(@BirthDate) = 11 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 12 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac ='Sagittarius'
IF (MONTH(@BirthDate) = 12 AND DATEPART(DAY,@BirthDate) >= 21) OR (MONTH(@BirthDate) = 1 AND DATEPART(DAY,@BirthDate) <= 20) set @zodiac = 'Capricorn'
RETURN @zodiac
end

--1.
select count(CustomerID),dbo.GetZodiac(BirthDate) from Customers group by dbo.GetZodiac(BirthDate)

select DATEPART(YEAR,BirthDate),Count(CustomerID) from Customers where dbo.GetZodiac(BirthDate) = 'Scorpio'group by DATEPART(YEAR,BirthDate)


--2.
select *, case 
when Currency = 'USD' then Amount * 3.0
when Currency = 'EUR' then Amount * 3.3
when Currency = 'GBP' then Amount * 4
end as AmountInGel 
from transactions


--3.
create function GetFibbonacci(@nth int)
returns int as
begin

declare @result int
declare @first int
declare @second int
set @first = 1
set @second = 1
set @result = 0
while @nth > 0

begin

set  @result = @first + @second
set @first = @second
set @second = @result
set @nth = @nth - 1

end

return @result

end


--4.
create function GetFactorial(@num int)
returns int
begin
declare @count int = 1
declare @fact int = 1
while @count <= @num
begin
set @fact = @fact * @count
set @count = @count + 1
end
return @fact
end

--print dbo.GetFactorial(6)

--5
create function GetDivisorsCount(@num int)
returns int as
begin

declare @temp int = 1
declare @counter int = 0

while @temp <= @num
begin
if(@num % @temp = 0)
begin
set @counter = @counter + 1
end
set @temp = @temp + 1;
end
return @counter
end

--print dbo.GetDivisorsCount(50)

--6.
create function GetStatus( @x int, @y int)
returns table as
return 
(
select  

case when Amount < @x then 'Low'
     when Amount < @x - @y then 'Medium'
     else 'High'
   end
   as Status,CustomerID

from Deposits
)
