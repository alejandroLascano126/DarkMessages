--CREATE TABLE groups
--(
--  groupId int,
--  name nvarchar(50),
--  description nvarchar(400),
--  [public] bit,
--  photo text,
--  dateCreated datetime,
--  dateUpdated datetime
--);
--CREATE INDEX groups_index 
--ON groups (groupId, name);


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


--CREATE TABLE groupMembersRoles
--(
--  roleId int identity,
--  name varchar(20),
--  description varchar(200)
--)
--CREATE INDEX groupMembersRoles_index 
--ON groupMembersRoles (roleId, name);

--insert into groupMembersRoles(name, description)values('standard','limited features')
--insert into groupMembersRoles(name, description)values('administrator','all the features')


--CREATE TABLE groupMessages
--(
--  messageId int,
--  userId int,
--  groupId int,
--  dateCreated int,
--  messageContent nvarchar(300)
--)
--CREATE INDEX groupMessages_index 
--ON groupMessages (messageId, userId, groupId);