SELECT CASE WHEN Grade<8 THEN NULL ELSE Name END,Grade,Marks
FROM Students,Grades
WHERE Marks>=Min_Mark AND Marks<=Max_Mark
ORDER BY Grade DESC,Name,Marks;