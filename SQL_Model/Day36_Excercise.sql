-- Level 1: The Join Foundation
-- Focus: Inner Joins and basic multi-table connections.
--1. Basic Linking: List all Product Names along with their Category Names.
--2. Order Details: Display every Order ID alongside the Company Name of the customer who placed it.
--3. Supplier Tracking: Show all Product Names and the Company Name of their respective suppliers.
--4. Employee Sales: List all Orders (ID and Date) and the First/Last Name of the employee who processed them.
--5. International Logistics: Find all Orders shipped to "France," showing the Order ID and the Company Name of the Shipper (from the Shippers table).

--Ans-1
select p.ProductName, c.CategoryName
from Products as p inner join Categories as c on p.CategoryID = c.CategoryID;

--Ans-2
select o.OrderID, cu.CompanyName
from Orders as o inner join Customers as cu on o.CustomerID = cu.CustomerID;

--Ans-3
select p.ProductName, s.CompanyName
from Products as p inner join Suppliers as s on p.SupplierID = s.SupplierID;

--Ans-4
select o.OrderID, o.OrderDate, e.FirstName, e.LastName
from Orders as o inner join Employees as e on o.EmployeeID = e.EmployeeID;

--Ans-5
select o.OrderID, s.CompanyName
from Orders as o inner join Shippers as s on o.ShipVia = s.ShipperID
where o.ShipCountry = 'France';




---------------------------------------------------------------------------------------------------------------------------------------------------
-- Level 2: Aggregations with Joins
-- Focus: Using GROUP BY across multiple tables.
--6. Category Stock: Show the Category Name and the total number of units in stock for that category.
--7. Customer Spend: List the Company Name and the total amount of money (Price $\times$ Quantity) they have spent across all orders.
--8. Employee Performance: Display the Last Name of each employee and the total number of orders they have taken.
--9. Shipping Costs: Find the total Freight charges paid to each Shipper company.
--10. Top Products: List the top 5 Product Names based on total quantity sold.

--Ans-6
select c.CategoryName, sum(p.UnitsInStock) as TotalUnitsInStock
from Categories as c inner join Products as p on c.CategoryID = p.CategoryID
group by c.CategoryName;

--Ans-7
select cu.CompanyName, sum(od.UnitPrice * od.Quantity) as TotalSpent
from Customers as cu inner join Orders as o on cu.CustomerID = o.CustomerID 
inner join [Order Details] as od on o.OrderID = od.OrderID
group by cu.CompanyName;

--Ans-8
select e.LastName, count(*) as TotalOrders
from Employees as e inner join Orders as o on e.EmployeeID = o.EmployeeID
group by e.LastName;

--Ans-9
select s.CompanyName, sum(o.Freight) as TotalFreight
from Shippers as s inner join Orders as o on s.ShipperID = o.ShipVia
group by s.CompanyName;

--Ans-10
select top 5 p.ProductName, sum(od.Quantity) as TotalQuantitySold
from Products as p inner join [Order Details] as od on p.ProductID = od.ProductID
group by p.ProductName
order by TotalQuantitySold desc;




---------------------------------------------------------------------------------------------------------------------------------------------------
-- Level 3: Subqueries & Self-Joins
-- Focus: Nested queries and tables referencing themselves.
--11. Above Average: List all Product Names whose UnitPrice is greater than the average price of all products.
--12. The Bosses: Use a Self-Join on the Employees table to show each employee's name and their manager's name.
--13. No Orders: Find all Customers (Company Name) who have never placed an order (Use NOT IN or NOT EXISTS).
--14. High-Value Orders: Identify Order IDs where the total order value is higher than the average order value of the entire database.
--15. Late Bloomers: Select Product Names that have never been ordered after the year 1997.

--Ans-11
select ProductName
from Products
where UnitPrice > (select avg(UnitPrice) from Products);

--Ans-12
SELECT e2.FirstName as Employee, e1.FirstName as 'Reports To'
from Employees E1 inner join Employees E2
on e1.EmployeeID = e2.ReportsTo;

--Ans-13
select CompanyName
from Customers
where CustomerID not in (select CustomerID from Orders);

--Ans-14
select OrderID
from Orders
where (select sum(UnitPrice * Quantity) from [Order Details] 
where OrderID = Orders.OrderID) > (select avg(UnitPrice * Quantity) from [Order Details]);

--Ans-15
select ProductName
from Products
where ProductID not in (select ProductID from [Order Details] od inner join Orders o on od.OrderID = o.OrderID
where YEAR(o.OrderDate) > 1997);




---------------------------------------------------------------------------------------------------------------------------------------------------
-- Level 4: Complex Logic & Advanced Joins
-- Focus: Multiple joins, HAVING clauses, and correlated subqueries.
--16. Territory Coverage: List all Employees and the names of the Regions they cover (requires joining Employees, EmployeeTerritories, Territories, and Region).
--17. Duplicate Cities: Find Customers and Suppliers who are located in the same city.
--18. Multi-Category Customers: List Customers who have purchased products from more than 3 different categories.
--19. Discontinued Sales: Calculate the total revenue generated only by products that are currently Discontinued.
--20. Correlated Subquery: For each Category, list the most expensive product name and its price.

--Ans-16
select e.FirstName, e.LastName, r.RegionDescription
from Employees as e inner join EmployeeTerritories as et on e.EmployeeID = et.EmployeeID
inner join Territories as t on et.TerritoryID = t.TerritoryID
inner join Region as r on t.RegionID = r.RegionID;

--Ans-17
select c.CompanyName as CustomerCompany, s.CompanyName as SupplierCompany, c.City
from Customers as c inner join Suppliers as s on c.City = s.City;

--Ans-18
select cu.CompanyName, count(distinct c.CategoryID) as CategoryCount
from Customers as cu inner join Orders as o on cu.CustomerID = o.CustomerID
inner join [Order Details] as od on o.OrderID = od.OrderID
inner join Products as p on od.ProductID = p.ProductID
inner join Categories as c on p.CategoryID = c.CategoryID
group by cu.CompanyName
having count(distinct c.CategoryID) > 3;

--Ans-19
select sum(od.UnitPrice * od.Quantity) as TotalRevenue
from [Order Details] as od inner join Products as p on od.ProductID = p.ProductID
where p.Discontinued = 1;

--Ans-20
select c.CategoryName, p.ProductName, p.UnitPrice
from Categories as c inner join Products as p on c.CategoryID = p.CategoryID
where p.UnitPrice = (select max(UnitPrice) from Products where CategoryID = c.CategoryID)
order by 3 desc;