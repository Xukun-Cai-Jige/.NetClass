USE AdventureWorks2019;

--1.How many products can you find in the Production.Product table?
select top 10 * from Production.Product
select count(ProductID) from Production.Product

--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
select count(ProductID) from Production.Product where ProductSubcategoryID is not null;


--3.Count how many products belong to each product subcategory.
--	Write a query that displays the result with two columns:

--	ProductSubcategoryID (the subcategory ID)£¬ CountedProducts (the number of products in that subcategory).

select ProductSubcategoryID, count(*) as CountedProducts from Production.Product group by ProductSubcategoryID having ProductSubcategoryID is not null;


--4.How many products that do not have a product subcategory.

select count(ProductID) from Production.Product where ProductSubcategoryID is null;

--5.Write a query to list the sum of products quantity in the Production.ProductInventory table.

select top 10 * from Production.ProductInventory
select sum(Quantity) from Production.ProductInventory
--6.Write a query to list the sum of products in the Production.ProductInventory table 
--and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
select ProductID, sum(Quantity) as sumofquantity from Production.ProductInventory where LocationID = 40 group by ProductID having sum(Quantity)<100;


--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory 
--table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

select ProductID, sum(Quantity) as sumofquantity from Production.ProductInventory where LocationID = 40 and shelf is not null group by ProductID having sum(Quantity)<100;


--8.Write the query to list the average quantity for products where column LocationID has the value o f 10 from the table Production.ProductInventory table.

select ProductID, avg(Quantity) as avgofquantity from Production.ProductInventory where LocationID = 10 group by ProductID;

--9.Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

select Shelf, avg(Quantity) as avgofquantity from Production.ProductInventory group by Shelf;

--10.Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

select Shelf, avg(Quantity) as avgofquantity from Production.ProductInventory group by Shelf having Shelf != 'N/A';

--11.List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. 
--Exclude the rows where Color or Class are null.

select Color, Class, avg(ListPrice) as avglistprice from Production.Product where Color is not null and Class is not null group by Color, Class;

--12.Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. 
--Join them and produce a result set similar to the following

;

select c.name as country , s.name as province from person.CountryRegion c inner join person.StateProvince s on c.CountryRegionCode = s.CountryRegionCode;

--13.Write a query that lists the country and province names from person. CountryRegion and person. 
--StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

select c.name as country , s.name as province from person.CountryRegion c inner join person.StateProvince s on c.CountryRegionCode = s.CountryRegionCode where c.name = 'Germany' or c.name = 'Canada';


-- Using Northwnd Database: (Use aliases for all the Joins)

USE Northwind;
GO
--14.List all Products that has been sold at least once in last 25 years.

SELECT TOP 5 *
FROM [Order Details];
SELECT TOP 5 *
FROM Orders;

select d.ProductID
from [Order Details] d inner join orders o on d.OrderID = o.OrderID where o.OrderDate >= DATEADD(YEAR, -25, GETDATE());

--15.List top 5 locations (Zip Code) where the products sold most.

select top 5 ShipPostalCode
from orders group by ShipPostalCode order by count(*);

--16.List top 5 locations (Zip Code) where the products sold most in last 25 years.

select top 5 ShipPostalCode
from orders where OrderDate >= DATEADD(YEAR, -25, GETDATE()) group by ShipPostalCode
order by count(*);

--17.List all city names and number of customers in that city.    

SELECT TOP 50 *
FROM Customers;

select City, count(*) as numberofcustomers
from Customers group by City;
--18.List city names which have more than 2 customers, and number of customers in that city

select City, count(*) as numberofcustomers
from Customers group by City having count(*) > 2;

--19.List the names of customers who placed orders after 1/1/98 with order date.

select distinct c.ContactName
from Customers c inner join Orders o on c.CustomerID = o.CustomerID where o.OrderDate > '1998-01-01'; 

--20.List the names of all customers with most recent order dates

select c.ContactName, MAX(o.OrderDate) as lastorderdate
from Customers c inner join Orders o on c.CustomerID = o.CustomerID group by c.ContactName;


--21.Display the names of all customers  along with the  count of products they bought

select c.ContactName, sum(d.Quantity) as countofproducts
from Customers c inner join Orders o on c.CustomerID = o.CustomerID inner join [Order Details] d on d.OrderID = o.OrderID group by c.ContactName;

--22.Display the customer ids who bought more than 100 Products with count of products.

select c.ContactName, sum(d.Quantity) as countofproducts
from Customers c inner join Orders o on c.CustomerID = o.CustomerID inner join [Order Details] d on d.OrderID = o.OrderID group by c.ContactName having sum(d.Quantity) > 100;

--23.Show all the possible combinations of suppliers and shippers, representing every way a supplier can ship its products.
--	The result should display two columns:

--	Supplier CompanyName£¬ Shipper CompanyName
Select top 5 *
from Suppliers

select su.CompanyName, o.ShipName
from products p inner join suppliers su on p.supplierID = su.supplierID
inner join [Order Details] d on p.productid = d.productid
inner join orders o on o.orderid = d.orderid;

--24.Display the products order each day. Show Order date and Product Name.

select o.OrderDate, p.ProductName
from products p inner join [Order Details] d on p.productid = d.productid
inner join orders o on o.orderid = d.orderid;

--25.Displays pairs of employees who have the same job title.

select e1.employeeid, e2.employeeid
from employees e1 inner join employees e2 on e1.Title = e2.Title and e1.EmployeeID != e2.EmployeeID;


--26.Display all the Managers who have more than 2 employees reporting to them.

select e2.EmployeeID
from employees e1 inner join employees e2 on e1.reportsto = e2.EmployeeID group by e2.EmployeeID having count(e1.ReportsTo) > 2;

--27.List all customers and suppliers together, grouped by city.
--The result should display the following columns:

--City£¬CompanyName£¬ContactName£¬Type (indicating whether the record is a Customer or a Supplier).

select City, CompanyName, ContactName, 'Customer'as Type from Customers where City is not null
union
select City, CompanyName, ContactName, 'Supplier'as Type from Suppliers where City is not null
order by City;