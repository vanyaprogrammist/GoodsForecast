CREATE TABLE #Products
(Id INT,
 Name VARCHAR(2000))

CREATE TABLE #ProductSales
(ProductId INT,
Date DATE,
Quantity INT)

INSERT INTO #Products 
VALUES 
(1,'Мишка'),
(2,'Зайчик'),
(3,'Телефон'),
(4,'Пенал'),
(5,'Портфель')

INSERT INTO #ProductSales
VALUES
(1,CAST('12-21-2016' AS DATE),560),
(1,CAST('12-24-2016' AS DATE),500),
(4,CAST('12-15-2016' AS DATE),1200),
(3,CAST('01-24-2016' AS DATE),1700),
(2,CAST('12-24-2015' AS DATE),1700),
(5,CAST('12-20-2016' AS DATE),993),
(5,CAST('12-21-2016' AS DATE),1)

select DISTINCT p.Id, p.Name
from #Products p
join (select 
			ps.ProductId,
			MONTH(ps.Date) as [Month],
			YEAR(ps.Date) as [Year],
			SUM(ps.Quantity) over (partition by ps.ProductId) as [SUM]
	  from #ProductSales ps) ps on(ps.ProductId = p.Id)
where ps.SUM > 1000 and ps.Month = 12 and ps.Year = 2016




