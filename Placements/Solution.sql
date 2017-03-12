SELECT MAX(s.Name)
FROM Students s
JOIN Packages p1 ON s.Id=p1.Id
JOIN Friends f ON s.Id=f.Id
JOIN Packages p2 ON f.Friend_ID=p2.Id
WHERE p1.Salary<p2.Salary
GROUP BY s.Id
HAVING MAX(p1.Salary)<MAX(p2.Salary)
ORDER BY MAX(p2.Salary);