INSERT INTO Hackers(hacker_id,name) VALUES 
(5580,'Rose'),
(8439,'Angela'),
(27205,'Frank'),
(52243,'Patrick'),
(52348,'Lisa'),
(57645,'Kimberly'),
(77726,'Bonnie'),
(83082,'Michael'),
(86870,'Todd'),
(90411,'Joe');

INSERT INTO Difficulty(difficulty_level,score) VALUES
(1,20),
(2,30),
(3,40),
(4,60),
(5,80),
(6,100),
(7,120);

INSERT INTO Challenges(challenge_id,hacker_id,difficulty_level) VALUES 
(4810,77726,4),
(21089,27205,1),
(36566,5580,7),
(66730,52243,6),
(71055,52243,2);

INSERT INTO Submissions(submission_id,hacker_id,challenge_id,score) VALUES
(68628,77726,36566,30),
(65300,77726,21089,10),
(40326,52243,36566,77),
(8941,27205,4810,4),
(83554,77726,66730,30),
(43353,52243,66730,0);