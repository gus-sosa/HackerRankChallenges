DECLARE @starts TABLE(
	StartDate DATE
);
INSERT INTO @starts
SELECT Start_Date
FROM Projects
WHERE NOT(Start_Date IN (SELECT End_Date FROM Projects));

DECLARE @ends TABLE(
	EndDate DATE
);
INSERT INTO @ends
SELECT End_Date
FROM Projects
WHERE NOT(End_Date IN (SELECT Start_Date FROM Projects));

SELECT *
FROM (SELECT  t2.StartDate ,(SELECT TOP 1 t1.EndDate
					  FROM @ends t1
					  WHERE t1.EndDate>t2.StartDate
					  ORDER BY t1.EndDate) endDate
FROM @starts t2) t3
ORDER BY DATEDIFF(day,t3.endDate,t3.StartDate) DESC,t3.StartDate;