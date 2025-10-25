USE AdventureWorks2019;

--1.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter

SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product;

--2.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0

SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product where ListPrice != 0;

--3.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column

SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product where Color is null;

--4.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.

SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product where Color is not null;

--5.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, 
--and the column ListPrice has a value greater than zero

SELECT ProductID, Name, Color, ListPrice 
FROM Production.Product where Color is not null AND ListPrice > 0;

--6.Write a query that concatenates the columns Name and Color like 'LL Crankarm: Black' from the Production.Product table by excluding the rows that are null for color.

SELECT Name+': '+ Color as Namecolor
FROM Production.Product where Color is not null;

--7.Write a query that generates the following result set  from Production.Product:

SELECT 'NAME: '+Name+' -- COLOR: '+ Color as Namecolor
FROM Production.Product where Color is not null;


--8.Write a query to retrieve the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500

SELECT ProductID, Name
FROM Production.Product where ProductID between 400 and 500;

--9.Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue

SELECT ProductID, Name, Color
FROM Production.Product where Color = 'black' or Color = 'blue';

--10.Write a query to get a result set on products that begins with the letter S.

SELECT *
FROM Production.Product where Name like 'S%';

--11.Write a query that retrieves the columns Name and ListPrice from the Production.Product table. 
--Order the result set by the Name column.

SELECT Name, ListPrice
FROM Production.Product order by Name;

--12. Write a query that retrieves the columns Name and ListPrice from the Production.Product table. 
--Order the result set by the Name column. The products name should start with either 'A' or 'S'

SELECT Name, ListPrice
FROM Production.Product where Name like 'S%' or Name like 'A%' order by Name;

--13.Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. 
--After this zero or more letters can exists. Order the result set by the Name column.
SELECT Name, ListPrice
FROM Production.Product where Name like 'SPO%' and Name not like 'SPOK%' order by Name DESC;

--14.Write a query that retrieves unique colors from the table Production.Product. Order the results in descending  manner

Select DISTINCT Color
from Production.Product order By Color DESC;


--15.Write a query that retrieves the unique combination of columns ProductSubcategoryID and Color from the Production.Product table. 
--We do not want any rows that are NULL.in any of the two columns in the result.
Select DISTINCT ProductSubcategoryID, Color
from Production.Product where ProductSubcategoryID is not null and Color is not null;