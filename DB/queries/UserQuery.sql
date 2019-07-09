INSERT INTO social.dbo.[user]
VALUES (NEWID(),
'Barnes',
'Sharon',
'C.',
'1988.03.18',
(SELECT ID_Gender FROM social.dbo.gender
 WHERE name = 'Not Selected'),
(SELECT TOP 1 ID_Locality FROM social.dbo.locality
 ORDER BY NEWID()),
(SELECT TOP 1 ID_Locality FROM social.dbo.locality
 ORDER BY NEWID()),
'1-785-285-2480');