DECLARE @MAX_CHALLENGES INT;
SELECT @MAX_CHALLENGES= MAX(t.col)
FROM (SELECT COUNT(*) col
FROM Hackers h JOIN Challenges c ON h.hacker_id=c.hacker_id
GROUP BY h.hacker_id) t;

SELECT t1.hacker_id,t1.name,t1.cant
FROM (
	SELECT DISTINCT h.hacker_id,h.name, COUNT(*) cant
	FROM Hackers h JOIN Challenges c ON h.hacker_id=c.hacker_id
	GROUP BY h.hacker_id,h.name
) t1
GROUP BY t1.cant,t1.hacker_id,t1.name
HAVING t1.cant=@MAX_CHALLENGES OR t1.cant NOT IN (SELECT COUNT(*)
												  FROM Challenges cc1
												  GROUP BY cc1.hacker_id
												  HAVING cc1.hacker_id!=t1.hacker_id)
ORDER BY t1.cant DESC,t1.hacker_id;
