declare id_cursor cursor local
for
SELECT ID_User
FROM social.dbo.[user];

open id_cursor;

declare @ID_table table (ID_User uniqueidentifier);
declare @ID uniqueidentifier;

fetch next from id_cursor INTO @ID;
while @@FETCH_STATUS = 0
begin
	INSERT INTO @ID_table
	VALUES (@ID);

	INSERT INTO social.dbo.interest
	SELECT *
	FROM @ID_table CROSS JOIN (
		SELECT TOP 3 ID_Hobbie
		FROM social.dbo.hobbie
		ORDER BY NEWID()
	) AS pass;

	DELETE FROM @ID_table
	WHERE ID_User = @ID;

	fetch next from id_cursor INTO @ID;
end

close id_cursor;
deallocate id_cursor;