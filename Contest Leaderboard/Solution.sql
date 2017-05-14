SELECT t1.hacker_id,t1.name,SUM(t1.score) finalScore
FROM (SELECT h.hacker_id,h.name,MAX(s.score) score
FROM Hackers h JOIN Submissions s ON h.hacker_id=s.hacker_id
GROUP BY h.hacker_id,s.challenge_id,h.name) t1
WHERE t1.score>0
GROUP BY t1.hacker_id,t1.name
ORDER BY finalScore DESC,t1.hacker_id;