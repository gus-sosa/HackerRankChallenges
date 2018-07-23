SELECT w.id,
       temp.age,
       temp.coins_needed,
       temp.power
FROM
(
    SELECT wp.code,
           wp.age,
           w.power,
           MIN(w.coins_needed) AS coins_needed
    FROM Wands w
         LEFT JOIN Wands_Property wp ON w.code = wp.code
    WHERE wp.is_evil = 0
    GROUP BY wp.code,
             wp.age,
             w.power
) AS temp
JOIN Wands w ON temp.code = w.code
                AND temp.power = w.power
                AND temp.coins_needed = w.coins_needed
ORDER BY temp.power DESC,
         temp.age DESC;