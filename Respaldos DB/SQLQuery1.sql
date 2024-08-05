--Create table privateMessages
--(
--    usernameSender varchar(20) not null,
--	usernameReceiver varchar(20) not null,
--	message nvarchar(400) not null,
--	time datetime not null
--)

--CREATE INDEX index_privateMessages
--ON privateMessages (usernameSender, usernameReceiver);

declare @resp int
exec insertMessage @usernameSender = 'jvero', @usernameReceiver = 'alejandro', @message = 'Hola alejandro', @response = @resp output
print @resp


--create proc insertMessage
--(
--   @usernameSender varchar(20),
--   @usernameReceiver varchar(20),
--   @message nvarchar(400),
--   @response int output
--)
--as
--  insert into privateMessages values(@usernameSender, @usernameReceiver, @message, getdate())

--  if @@error > 0
--  begin
--    set @response = 1;
--    return -1;
--  end
--  else
--    set @response = 0;
--    return 0;
--return 0;

declare @resp int
exec consultMessages @usernameSender = 'alejandro', @usernameReceiver = 'jvero', @rows = 20, @page = 1, @response = @resp output
print @resp


--ALTER PROCEDURE consultMessages
--(
--    @usernameSender VARCHAR(20),
--    @usernameReceiver VARCHAR(20),
--    @rows INT,
--    @page INT,
--	@response int output
--)
--AS
--BEGIN
--    set @response = -1;
--    ;WITH NumberedMessages AS (
--        SELECT *,
--               ROW_NUMBER() OVER (ORDER BY time ASC) AS RowNum
--        FROM privateMessages
--        WHERE (usernameSender = @usernameSender OR usernameReceiver = @usernameSender)
--          AND (usernameSender = @usernameReceiver OR usernameReceiver = @usernameReceiver)
--    )
--    SELECT *
--    FROM NumberedMessages
--    WHERE RowNum BETWEEN ((@page - 1) * @rows + 1) AND (@page * @rows);
--	set @response = 0;
--END
--GO

--alter table users add name varchar(30), lastname varchar(30)

declare @resp int
exec consultFriends @username = 'alejandro', @rows = 10, @page = 1, @response = @resp output
print @resp



--CREATE PROCEDURE consultFriends
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
--        SELECT username, name, lastname,
--               ROW_NUMBER() OVER (ORDER BY name) AS RowNum
--        FROM users
--        WHERE username != @username
--    )
--    SELECT username, name, lastname
--    FROM NumberedFriends
--    WHERE RowNum BETWEEN ((@page - 1) * @rows + 1) AND (@page * @rows);
--    SET @response = 0;
--END









