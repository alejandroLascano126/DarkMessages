--CREATE TABLE groups
--(
--  groupId int identity,
--  name nvarchar(50),
--  description nvarchar(400),
--  [public] bit,
--  photo text,
--  dateCreated datetime,
--  dateUpdated datetime
--);
--CREATE INDEX groups_index 
--ON groups (groupId, name);




--ALTER PROCEDURE sp_registerGroup
--(
--   @name nvarchar(50),
--   @description nvarchar(400),
--   @public bit,
--   @photo text,
--   @response int output,
--   @id int output
--)
--as
--begin
--  insert into groups(name, description, [public], photo, dateCreated, dateUpdated)
--              values(@name, @description, @public, @photo, getdate(), null)

--  if @@error > 0
--  begin
--    set @id = 0;
--    return -1;
--  end 
--  else
--  begin
--    set @response = 0
--    select @id = groupId from groups 
--	where name = @name and 
--	      description = @description and
--		  [public] = @public
--  end
--return 0;
--end


--CREATE TABLE groupMembers
--(
--  groupId int,
--  userId int,
--  dateCreated datetime,
--  dateUpdated datetime,
--  roleId int
--)
--CREATE INDEX groupMembers_index 
--ON groupMembers (groupId, userId);


--ALTER PROCEDURE sp_registerGroupMember
--(
--  @groupId int,
--  @username varchar(20),
--  @roleId int,
--  @response int output,
--  @userId int output
--)
--as
--begin  
--  select @userId = idUser from users where username = @username
  
--  insert into groupMembers(groupId, userId, dateCreated, dateUpdated, roleId)
--                    values(@groupId, @userId, getdate(), null, @roleId)

--  if @@error > 0
--  begin
--    set @response = 1
--	set @userId = 0
--    return -1
--  end
--  else
--  begin
--    set @response = 0
--  end
--return 0;
--end


--CREATE PROCEDURE sp_consultGroup
--(
--  @groupId int,
--  @response int output
--)
--as
--  select groupId, name, description, [public], photo, dateCreated, dateUpdated from groups

--  if @@error > 0
--  begin
--    set @response = 1
--    return -1
--  end
--  else
--    set @response = 0

--return 0;


--ALTER PROCEDURE sp_consultGroupMembers
--(
--  @groupId int,
--  @response int output
--)
--as
--  select u.idUser, u.username, u.name, u.lastname, u.email, m.roleId from groups g 
--  inner join groupMembers m on g.groupId = m.groupId
--  inner join users u on u.idUser = m.userId
--  where m.groupId = @groupId
--  order by u.username

--  if @@error > 0
--  begin
--    set @response = 1
--    return -1
--  end
--  else
--    set @response = 0
--return 0;

