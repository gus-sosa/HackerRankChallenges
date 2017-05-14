DECLARE @var INT = (SELECT MAX(salary*months)
				    FROM Employee);

SELECT @var,SUM(1)
FROM Employee
WHERE salary*months=@var;


--another solution
--this solution is not good because there is a nested loop, and
--the max value is calculated twice
--SELECT (SELECT MAX(e1.salary*e1.months) FROM Employee e1),SUM(1)
--FROM Employee e2
--WHERE e2.salary*e2.months=(SELECT MAX(e.salary*e.months)
--				    FROM Employee e);