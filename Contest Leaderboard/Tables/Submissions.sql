CREATE TABLE [dbo].[Submissions]
(
	[submission_id] INT NOT NULL PRIMARY KEY,
	[hacker_id] INT NOT NULL,
	[challenge_id] INT NOT NULL,
	[score] INT NOT NULL
)
