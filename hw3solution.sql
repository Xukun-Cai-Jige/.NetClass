USE Northwind;
GO
--1.List all cities that have both Employees and Customers.

select distinct c.City from Customers c inner join Employees e on c.City = e.City;

--2List all cities that have Customers but no Employee.
--a.      Use sub-query
select distinct City from Customers where city not in (select distinct city from Employees);
--b.      Do not use sub-query

select distinct c.city from Customers c left join Employees e on c.City = e.City where e.EmployeeID is null;

--3.  List all products and their total order quantities throughout all orders.

select ProductID, sum(Quantity) as [total quantities] from [Order Details] group by ProductID;

--4.  List all Customer Cities and total products ordered by that city.
select c.City, sum(d.Quantity) as totalproducts
from Customers c inner join Orders o on c.customerID = o.CustomerID inner join [Order Details] d on o.OrderID = d.OrderID group by c.City;

--5. List all Customer Cities that have at least two customers.
--a.      Use union
select city from Customers group by city having count(*) = 2
union
select city from Customers group by city having count(*) > 2;

--b.      Use sub-query and no union
select distinct city from Customers where city in (select city from Customers group by city having count(*) >= 2);


--6.List all Customer Cities that have ordered at least two different kinds of products.
select c.City
from Customers c inner join Orders o on c.customerID = o.CustomerID inner join [Order Details] d on o.OrderID = d.OrderID group by c.City having count(distinct d.ProductID) > 1;


--7. List all Customers who have ordered products, but have the ¡®ship city¡¯ on the order different from their own customer cities.


select distinct c.CustomerID

from Customers c inner join Orders o on c.customerID = o.CustomerID where c.City != o.ShipCity;

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
with
top5 as (
select top 5 d.productid
from [Order Details] d group by d.ProductID order by sum(d.Quantity) desc
),
cityquantity as (
select d.ProductID, c.city, sum(d.Quantity) as quantitypercity
from Customers c inner join Orders o on c.customerID = o.CustomerID inner join [Order Details] d on o.OrderID = d.OrderID
where d.ProductID in (select productid from top5)
GROUP BY d.ProductID, c.City
),
cityrank as(
select productid, city,
row_number() over (partition by productid order by quantitypercity desc) as rk
from cityquantity
),
averageperprod as (
select ProductID, sum(Quantity*UnitPrice)/sum(Quantity) as prodavg

from [Order Details]
where ProductID in (select productid from top5)
group by ProductID
)
select c.productid, c.city,a.prodavg
from cityrank c join averageperprod a on c.ProductID=a.ProductID where rk = 1



--9.List all cities that have never ordered something but we have employees there.
--a.      Use sub-query
select distinct City from Employees where city not in (select distinct city from Customers);
--b.      Do not use sub-query

select distinct e.city from Customers c right join Employees e on c.City = e.City where c.CustomerID is null;

--10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
select c1.city
from
(select top 1 e.city
from Orders o inner join Employees e on o.EmployeeID = e.EmployeeID group by e.City order by count(*) desc, e.city) c1
inner join
(select top 1 e.city
from Orders o inner join Customers e on o.CustomerID = e.CustomerID group by e.City order by count(*) desc, e.city) c2
on c1.city = c2.city
--11.How do you remove the duplicates record of a table?
with dups as (
select *,
row_number() over (partition by c1, c2 order by (select null)) as rk
from tab
)
delete from dups where rk > 1;