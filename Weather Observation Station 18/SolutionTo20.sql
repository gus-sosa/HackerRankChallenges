﻿DECLARE @COUNT INT =(SELECT COUNT(*) FROM STATION);

SELECT *
FROM (SELECT RANK() as RowNumber,*
	FROM STATION)
ORDER BY RowNumber;