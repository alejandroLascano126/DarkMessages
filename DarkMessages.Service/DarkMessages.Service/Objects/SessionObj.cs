using DarkMessages.DesktopApp;
using DarkMessages.models.Friends;
using DarkMessages.models.Groups;
using DarkMessages.models.Session;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace DarkMessages.Service.Objects
{
    public class SessionObj
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

        public SessionObj() 
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
        }

        public async Task<rpLoginSession> LoginSession(rqLoginSession rq)
        {
            rpLoginSession rp = new rpLoginSession();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_LoginSession", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ip_name", rq.ip_name);
                        command.Parameters.AddWithValue("@username", rq.username);
                        command.Parameters.AddWithValue("@saveSession", rq.saveSession);
                        command.Parameters.AddWithValue("@option", rq.option);
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

        public async Task<rpMantSession> MantSession(rqMantSession rq)
        {
            rpMantSession rp = new rpMantSession();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_mantSession", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@username", rq.username);
                        command.Parameters.AddWithValue("@onlineStatus", rq.onlineStatus ?? false);
                        command.Parameters.AddWithValue("@ipName", rq.ipName ?? "");
                        command.Parameters.AddWithValue("@option", rq.option);
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(responseOutput);
                        if (rq.option == "CON") 
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command)) 
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                rp.sessions = new List<session>();
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    session session = new() { sessionId = Convert.ToInt32(row["sessionId"]), ipName = row["ip_name"].ToString()!, enabled = Convert.ToBoolean(row["enabled"]), lastConnection = Convert.ToDateTime(row["lastConnection"]), username = row["username"].ToString()!, onlineStatus = Convert.ToBoolean(row["enabled"]) };
                                    rp.sessions.Add(session ?? new session());
                                }
                                
                                rp.success = true;
                            }
                        }
                        if (rq.option == "UPD") 
                        {
                            await command.ExecuteNonQueryAsync();
                            rp.sessions = new List<session>();
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
            catch (Exception ex)
            {
                rp.success = false;
            }
            return rp;
        }

    }
}
