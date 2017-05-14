DELETE Students;
DELETE Friends;
DELETE Packages;

INSERT INTO Students(Id,Name) VALUES
(1,'Ashley'),
(2,'Samantha'),
(3,'Julia'),
(4,'Scarlet');

INSERT INTO Friends(Id,Friend_ID) VALUES
(1,2),
(2,3),
(3,4),
(4,1);

INSERT INTO Packages(Id,Salary) VALUES
(1,15.20),
(2,10.06),
(3,11.55),
(4,12.12);