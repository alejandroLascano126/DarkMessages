--alter PROCEDURE consultFriends
--(
--    @username VARCHAR(20),
--    @rows INT,
--    @page INT,
--    @response INT OUTPUT
--)
--AS
--BEGIN    
--    SET @response = -1;

--    ;WITH NumberedFriends AS (
--        SELECT a.username, a.name, a.lastname,
--               ROW_NUMBER() OVER (ORDER BY a.name) AS RowNum,
--               (SELECT TOP 1 b.message
--                FROM privateMessages b
--                WHERE (b.usernameSender = a.username AND b.usernameReceiver = @username) OR
--                      (b.usernameReceiver = a.username AND b.usernameSender = @username)
--                ORDER BY b.time DESC) AS lastMessage
--        FROM users a
--        WHERE a.username != @username
--          AND EXISTS (SELECT 1
--                      FROM privateMessages b
--                      WHERE (b.usernameSender = @username AND b.usernameReceiver = a.username) OR
--                            (b.usernameReceiver = @username AND b.usernameSender = a.username))
--    )
--    SELECT username, name, lastname, lastMessage
--    FROM NumberedFriends
--    WHERE RowNum BETWEEN ((@page - 1) * @rows + 1) AND (@page * @rows);

--    SET @response = 0;
--END
--GO


declare @resp int
exec consultFriends @username = 'alejandro', @rows = 10, @page = 1, @response = @resp








