USE [DarkMessages]
GO
/****** Object:  StoredProcedure [dbo].[consultMessages]    Script Date: 08/04/2024 11:33:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[consultMessages]
(
    @usernameSender VARCHAR(20),
    @usernameReceiver VARCHAR(20),
    @rows INT,
    @page INT,
	@response int output
)
AS
BEGIN
    set @response = -1;
    ;WITH NumberedMessages AS (
        SELECT *,
               ROW_NUMBER() OVER (ORDER BY time ASC) AS RowNum
        FROM privateMessages
        WHERE (usernameSender = @usernameSender OR usernameReceiver = @usernameSender)
          AND (usernameSender = @usernameReceiver OR usernameReceiver = @usernameReceiver)
    )
    SELECT *
    FROM NumberedMessages
    WHERE RowNum BETWEEN ((@page - 1) * @rows + 1) AND (@page * @rows);
	set @response = 0;
END
