using DarkMessages.DesktopApp;
using DarkMessages.models.Groups;
using DarkMessages.models.Session;
using Microsoft.Data.SqlClient;
using System.Data;

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

    }
}
