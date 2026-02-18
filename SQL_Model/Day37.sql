--List categories that never had any order shipped to USA, but had at least 5 total orders worldwide, ordered by freight.
select c.CategoryName, count(*) as TotalOrders, sum(o.Freight) as TotalFreight
from Categories as c inner join Products as p on c.CategoryID = p.CategoryID
inner join [Order Details] as od on p.ProductID = od.ProductID
inner join Orders o on od.OrderID = o.OrderID
where o.ShipCountry != 'USA' 
group by c.CategoryName
having count(*) >= 5
order by TotalFreight desc;


--List each employee along with the total number of orders they handled only for customers whose company name starts with the letter 'A'.
select (e.FirstName + ' ' + e.LastName) as FullName, c.CompanyName, count(*) as TotalOrders
from Employees as e inner join Orders o on e.EmployeeID = o.EmployeeID
inner join Customers c on o.CustomerID = c.CustomerID  
where c.CompanyName like 'A%'
group by e.FirstName + ' ' + e.LastName, c.CompanyName
order by TotalOrders desc;


--Version 1
SELECT e2.FirstName as Employee, e1.FirstName as 'Reports To'
from Employees E1 inner join Employees E2
on e1.EmployeeID = e2.ReportsTo;

--Vesrion 2
SELECT concat(e2.FirstName, ' Reports To ', e1.FirstName) as Reporting
from Employees E1 inner join Employees E2
on e1.EmployeeID = e2.ReportsTo;






-- alter procedure procbegin1
-- AS
-- BEGIN 
--     declare @i int;
--     set @i = 10;
--     if(@i > 5)
--     begin
--         print 'i = ' + convert (varchar, @i);
--         select @i as i;
--     end
-- end

-- execute procbegin1;

-- CREATE PROCEDURE p2 
-- @num1 INT,
-- @num2 INT
-- as BEGIN
--     declare @sum int;
--     set @sum = @num1 + @num2;
--     Select @sum as Sum;
-- end

-- execute p2 10, 20;



-- alter procedure p_GetCarInventory
-- @catid INT, 
-- @totalInv decimal(10, 2) output
-- as 
-- BEGIN
--     -- declare @totalInv int;
--     select @totalInv = Sum(UnitsInStock * UnitPrice)
--     from products
--     where CategoryID = @catid;
-- END

-- declare @totalInventory decimal(10, 2);
-- execute p_GetCarInventory 1, @totalInventory output;
-- select ' --- ' + Convert(varchar, @totalInventory)
