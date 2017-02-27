SELECT h.hacker_id,h.name
FROM Hackers h
JOIN Submissions s ON h.hacker_id=s.hacker_id
JOIN Challenges c ON c.challenge_id=s.challenge_id
JOIN Difficulty d ON d.difficulty_level=c.difficulty_level
WHERE s.score=d.score
GROUP BY h.hacker_id,h.name
HAVING COUNT(*)>1
ORDER BY COUNT(*) DESC,h.hacker_id ASC;