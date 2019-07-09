declare id_cursor cursor local
for
SELECT ID_User
FROM social.dbo.[user];

open id_cursor;

declare @ID uniqueidentifier;
declare @cnt int;
declare @ID_table table (ID_User uniqueidentifier);
declare @friends table (ID_User uniqueidentifier);

fetch next from id_cursor into @ID;
while @@FETCH_STATUS = 0
begin
	INSERT INTO @ID_table 
	VALUES (@ID);

	INSERT INTO @friends
		SELECT ID_User_A AS ID_User
		FROM social.dbo.friendship
		WHERE ID_User_B = @ID
		UNION
		SELECT ID_User_B AS ID_User
		FROM social.dbo.friendship
		WHERE ID_User_A = @ID
		UNION
		SELECT *
		FROM @ID_table

	set @cnt = 6 - (
		SELECT COUNT(ID_User)
		FROM @friends
	);

	if @cnt > 0
	INSERT INTO social.dbo.friendship
	SELECT *
	FROM @ID_table CROSS JOIN (
		SELECT TOP (@cnt) ID_User
		FROM (
			SELECT ID_User FROM social.dbo.[user]
			EXCEPT
			SELECT ID_User FROM @friends
		) AS pass
		ORDER BY NEWID()
	) AS pass


	DELETE FROM @friends;
	DELETE FROM @ID_table;

	fetch next from id_cursor into @ID;
end

close id_cursor;
deallocate id_cursor