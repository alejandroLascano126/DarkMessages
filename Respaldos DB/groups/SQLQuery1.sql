--CREATE TABLE groupMessages
--(
--  messageId int identity,
--  userId int,
--  groupId int,
--  dateCreated datetime,
--  messageContent nvarchar(300)
--)
--CREATE INDEX groupMessages_index 
--ON groupMessages (messageId, userId, groupId);


--CREATE PROCEDURE sp_registerGroupMessages
--(
--  @username varchar(20),
--  @groupId int,
--  @messageContent nvarchar(300),
--  @reponse int output
--)
--as
--begin
--  declare @userId int

--  select @userId = idUser from users where username = @username

--  insert into groupMessages(userId, groupId, dateCreated, messageContent)
--                     values(@userId, @groupId, getdate(), @messageContent)

--  if @@error > 0
--  begin 
--    set @reponse = 1
--	return -1
--  end
--  else
--    set @reponse = 0
--return 0;
--end


--CREATE PROCEDURE sp_consultGroupMessages
--(
--  @groupId int,
--  @response int output
--)
--as
--begin
--  select m.messageId, m.dateCreated, m.messageContent, u.username, u.name, u.lastname from groupMessages m
--  inner join users u on u.idUser = m.userId
--  inner join groupMembers gm on gm.groupId = m.groupId
--  inner join groups g on g.groupId = m.groupId
--  where m.groupId = @groupId
--  order by m.dateCreated

--  set @response = 0
--return 0;
--end


--CREATE PROCEDURE sp_deleteGroupMessage
--(
--  @messageId int,
--  @response int output 
--)
--as
--  delete from groupMessages where messageId = @messageId
--  set @response = 0
--return 0;