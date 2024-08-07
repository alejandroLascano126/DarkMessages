using DarkMessages.DesktopApp;
using Microsoft.Data.SqlClient;
using DarkMessages.models.Message;
using System.Data;

namespace DarkMessages.Service.Objects
{
    public class MessageObj
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

        public MessageObj() 
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
        }


        public async Task<rpInsertMessage> insertMessage(rqInsertMessage rq) 
        {
            rpInsertMessage rp = new rpInsertMessage();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("insertMessage", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@usernameSender", rq.senderUser);
                        command.Parameters.AddWithValue("@usernameReceiver", rq.receiverUser);
                        command.Parameters.AddWithValue("@message", rq.messageContent);
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

        public async Task<rpConsultMessages> consultMessages(rqConsultMessages rq) 
        {
            rpConsultMessages rp = new rpConsultMessages();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("consultMessages", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@usernameSender", rq.usernameSender);
                        command.Parameters.AddWithValue("@usernameReceiver", rq.usernameReceiver);
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
                            rp.messages = new List<message>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                message msg = new message() {senderUser = row["usernameSender"].ToString()!, receiverUser = row["usernameReceiver"].ToString()!, messageContent = row["message"].ToString()!, createdAt = Convert.ToDateTime(row["time"].ToString()!) };
                                rp.messages.Add(msg);
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


        public async Task<rpCountMessages> countMessages(rqCountMessages rq) 
        {
            rpCountMessages rp = new rpCountMessages();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("countPrivateMessages", connection)) 
                    {
                        command.Parameters.Clear();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usernameSender", rq.usernameSender);
                        command.Parameters.AddWithValue("@usernameReceiver", rq.usernameReceiver);
                        
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
    }
}
