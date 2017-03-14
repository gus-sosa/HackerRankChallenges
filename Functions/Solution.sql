SELECT DISTINCT f.X,f.Y
FROM Functions f
WHERE (f.X=f.Y AND (SELECT COUNT(*) FROM Functions f1 WHERE f1.X=f1.Y AND f1.X=f.X)>1) OR 
	  (f.X<f.Y AND (SELECT COUNT(*) FROM Functions f1 WHERE f.X=f1.Y AND f.Y=f1.X)>0)
ORDER BY f.X;