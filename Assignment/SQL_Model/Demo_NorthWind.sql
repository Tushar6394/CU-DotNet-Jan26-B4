select * from products
where productName like '_A%';

select ProductName, UnitPrice, UnitsInStock, (UnitPrice * UnitsInStock) as 'Inventory'
from Products
where UnitPrice * UnitsInStock <> 0
Order by 4 desc;

select p.productName, s.CompanyName
from suppliers s inner join products p 
on s.SupplierID = p.SupplierID
order by 2;

--display all total projects
select count(*) from products; 

--display total products by category and name also

select P.CategoryID, C.CategoryName, 
COUNT(*) as Count, 
avg(p.UnitPrice) as AvgPrice
from Products P inner join 
Categories C on  
P.CategoryID = C.CategoryID
where P.UnitPrice>10
group by P.CategoryID, c.CategoryName
having count(*) > 7
order by 2 desc;

--Customer Name, OrderID, OrderDate, Count(Prod)
select c.ContactName, o.OrderID, o.OrderDate, count(od.ProductID)
from Customers as c inner join Orders o on c.CustomerID = o.CustomerID
inner join [Order Details] as od on o.OrderID = od.OrderID
group by c.ContactName, o.OrderID, o.OrderDate
order by 4 desc;

--Display category name and most expensive product in that category
select c.CategoryName, p.ProductName, p.UnitPrice
from Categories as c inner join Products p on c.CategoryID = p.CategoryID
where p.UnitPrice = (select max(UnitPrice) from Products where CategoryID = c.CategoryID) --Correlated Subquery
order by 3 desc;


--Display products whose price is more than the price of chai (Using ANY)
select ProductName, UnitPrice
from Products
where UnitPrice > ALL(select UnitPrice from Products where ProductName like 'A%'); -- unrelated subquery

--Using ALL
select ProductName, UnitPrice
from Products
where UnitPrice > ALL(select UnitPrice from Products where ProductName like 'A%'); -- unrelated subquery

--If we want to display NULL values from the left table, we can use LEFT JOIN. 
--If we want to display NULL values from the right table, we can use RIGHT JOIN. 
--If we want to display only matching records, we can use INNER JOIN.
select c.CategoryName, p.ProductName
from Categories as C
full join Products as P
on c.CategoryID = p.CategoryID
where c.CategoryName is null
or p.CategoryID is null;

