﻿using DarkMessages.DesktopApp;
using DarkMessages.models.Groups;
using DarkMessages.models.Message;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace DarkMessages.Service.Objects
{
    public class GroupObj
    {

        EmailSender emailSender;

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = GlobalVariables.DataSource,
            InitialCatalog = GlobalVariables.InitialCatalog,
            UserID = GlobalVariables.UserID,
            Password = GlobalVariables.Password,
            ConnectTimeout = GlobalVariables.ConnectTimeout,
            Encrypt = GlobalVariables.Encrypt,
            TrustServerCertificate = GlobalVariables.TrustServerCertificate,
        };

        string connectionString = "";

        public GroupObj()
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
        }


        public async Task<rpRegisterGroup> registerGroup(rqRegisterGroup rq)
        {
            rpRegisterGroup rp = new rpRegisterGroup();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_registerGroup", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@name", rq.name);
                        command.Parameters.AddWithValue("@description", rq.description);
                        command.Parameters.AddWithValue("@public", rq.isPublic);
                        command.Parameters.AddWithValue("@photo", rq.photo);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter idOutput = new SqlParameter("@id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        command.Parameters.Add(idOutput);
                        await command.ExecuteNonQueryAsync();
                        int response = (int)responseOutput.Value;
                        int groupId = (int)idOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                            rp.id = groupId;
                        }
                        else
                        {
                            rp.success = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }


        public async Task<rpRegisterGroupMember> registerGroupMember(rqRegisterGroupMember rq)
        {
            rpRegisterGroupMember rp = new rpRegisterGroupMember();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_registerGroupMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        command.Parameters.AddWithValue("@username", rq.username);
                        command.Parameters.AddWithValue("@roleId", rq.roleId);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter userIdOutput = new SqlParameter("@userId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        command.Parameters.Add(userIdOutput);
                        await command.ExecuteNonQueryAsync();
                        int response = (int)responseOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                        }
                        else
                        {
                            rp.success = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }



        public async Task<rpRegisterGroupMessages> registerGroupMessages(rqRegisterGroupMessages rq)
        {
            rpRegisterGroupMessages rp = new rpRegisterGroupMessages();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_registerGroupMessages", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@username", rq.username);
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        command.Parameters.AddWithValue("@messageContent", rq.messageContent);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        await command.ExecuteNonQueryAsync();
                        int response = (int)responseOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                        }
                        else
                        {
                            rp.success = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }


        public async Task<rpConsultGroup> consultGroup(rqConsultGroup rq)
        {
            rpConsultGroup rp = new rpConsultGroup();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_consultGroup", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@groupId", rq.idgroupId);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rp.groups = new List<group>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                group group = new group() { groupId = Convert.ToInt32(row["groupId"]), name = row["name"].ToString()!, description = row["description"].ToString()!, isPublic = row["public"].ToString()!, photo = row["photo"].ToString()!, dateCreated = Convert.ToDateTime(row["dateCreated"]), dateUpdated = (!row["dateUpdated"].Equals(DBNull.Value)) ?Convert.ToDateTime(row["dateUpdated"]) : null };
                                rp.groups.Add(group);
                            }
                        }


                        int response = (int)responseOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                        }
                        else
                        {
                            rp.success = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }


        public async Task<rpConsultGroupMembers> consultGroupMembers(rqConsultGroupMembers rq)
        {
            rpConsultGroupMembers rp = new rpConsultGroupMembers();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_consultGroupMembers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        command.Parameters.AddWithValue("@rows", rq.rows);
                        command.Parameters.AddWithValue("@page", rq.page);
                        command.Parameters.AddWithValue("@option", rq.option);
                        command.Parameters.AddWithValue("@value", rq.value);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter countOutput = new SqlParameter("@countValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        command.Parameters.Add(countOutput);

                        if (rq.option == "CNT")
                        {
                            await command.ExecuteNonQueryAsync();
                            int response = (int)responseOutput.Value;
                            rp.success = (response == 0) ? true : false;
                            rp.message = countOutput.Value.ToString() ?? "0";
                        }
                        else
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                rp.groupMembers = new List<groupMember>();
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    int roleId = 1;
                                    if (row.Table.Columns.Contains("roleId"))
                                    {
                                        roleId = (row["roleId"] != DBNull.Value) ? Convert.ToInt32(row["roleId"]) : 1;
                                    }
                                    groupMember groupMember = new groupMember() { idUser = Convert.ToInt32(row["idUser"]), username = row["username"].ToString()!, name = row["name"].ToString()!, lastname = row["lastname"].ToString()!, email = row["email"].ToString()!, roleId = roleId, profilePicture = (!row["profilePictur"].Equals(DBNull.Value)) ? (byte[])row["profilePictur"] : null };
                                    rp.groupMembers.Add(groupMember);
                                }
                            }

                            int response = (int)responseOutput.Value;
                            if (response == 0)
                            {
                                rp.success = true;
                            }
                            else
                            {
                                rp.success = false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                rp.success = false;
                rp.message = ex.Message;
            }
            return rp;
        }



        public async Task<rpConsultGroupMessages> consultGroupMessages(rqConsultGroupMessages rq)
        {
            rpConsultGroupMessages rp = new rpConsultGroupMessages();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_consultGroupMessages", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        command.Parameters.AddWithValue("@rows", rq.rows);
                        command.Parameters.AddWithValue("@page", rq.page);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rp.messages = new List<groupMessage>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                groupMessage groupMember = new groupMessage() { messageId = Convert.ToInt32(row["messageId"]), dateCreated = Convert.ToDateTime(row["dateCreated"]), messageContent = row["messageContent"].ToString()!, username = row["username"].ToString()!, name = row["name"].ToString()!, lastname = row["lastname"].ToString()! };
                                rp.messages.Add(groupMember);
                            }
                        }

                        int response = (int)responseOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                        }
                        else
                        {
                            rp.success = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }


        public async Task<rpCountMessages> countGroupMessages(rqCountGroupMessages rq)
        {
            rpCountMessages rp = new rpCountMessages();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_countGroupMessages", connection))
                    {
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        

                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter countOutput = new SqlParameter("@count", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        command.Parameters.Add(countOutput);

                        await command.ExecuteNonQueryAsync();

                        int response = (int)responseOutput.Value;
                        int count = (int)countOutput.Value;

                        if (response == 0)
                        {
                            rp.count = count;
                            rp.success = true;
                        }
                        else
                        {
                            rp.success = false;
                            rp.count = 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                rp.success = false;
                rp.count = 0;
            }

            return rp;
        }


        public async Task<rpRemoveGroupMember> removeGroupMember(rqRemoveGroupMember rq)
        {
            rpRemoveGroupMember rp = new rpRemoveGroupMember();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_remove_groupMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        command.Parameters.AddWithValue("@userId", rq.userId);
                        command.Parameters.AddWithValue("@userIdRemove", rq.userIdRemove);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        await command.ExecuteNonQueryAsync();
                        int response = (int)responseOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                        }
                        else if (response == 1)
                        {
                            rp.success = false;
                            rp.message = "The group members wasn't removed";
                        }
                        else if (response == 2)
                        {
                            rp.success = false;
                            rp.message = "The group members wasn't removed";
                        }
                        else 
                        {
                            rp.success = false;
                            rp.message = "The group members wasn't removed";
                        }
                    }
                }
            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }

        public async Task<rpConsultGroupMembers> consultGroupMember(rqConsultGroupMembers rq)
        {
            rpConsultGroupMembers rp = new rpConsultGroupMembers();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_consult_groupMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@groupId", rq.groupId);
                        command.Parameters.AddWithValue("@userId", Int32.Parse(rq.value));
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rp.groupMembers = new List<groupMember>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                int roleId = 1;
                                if (row.Table.Columns.Contains("roleId"))
                                {
                                    roleId = (row["roleId"] != DBNull.Value) ? Convert.ToInt32(row["roleId"]) : 1;
                                }
                                groupMember groupMember = new groupMember() { idUser = Convert.ToInt32(row["userId"]), username = "", name = "", lastname = "", email = "", roleId = roleId };
                                rp.groupMembers.Add(groupMember);
                            }
                        }

                        int response = (int)responseOutput.Value;
                        if (response == 0)
                        {
                            rp.success = true;
                        }
                        else
                        {
                            rp.success = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                rp.success = false;
            }
            return rp;
        }
    }
}
