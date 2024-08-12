using DarkMessages.DesktopApp;
using DarkMessages.models.Notifications;
using DarkMessages.models.Usuarios;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DarkMessages.Service.Objects
{
    public class NotificationObj
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

        public NotificationObj()
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
        }

        public async Task<rpMantNotifications> mantNotifications(rqMantNotifications rq)
        {
            rpMantNotifications rp = new rpMantNotifications();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_mantNotifications", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", rq.username);
                        command.Parameters.AddWithValue("@rows", rq.rows);
                        command.Parameters.AddWithValue("@page", rq.page);
                        command.Parameters.AddWithValue("@notificationId", rq.notificationId);
                        command.Parameters.AddWithValue("@option", rq.option);

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


                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rp.notifications = new List<Notification>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                Notification notification = new() { notificationId = Convert.ToInt32(row["notificationId"]!), title = row["title"].ToString()!, description = row["description"].ToString()!, receiverUsername = row["receiverUsername"].ToString()!, typeId = Convert.ToInt32(row["typeId"]), infoJson = row["infoJson"].ToString()!, deateCreated =  Convert.ToDateTime(row["deateCreated"]) };
                                rp.notifications.Add(notification ?? new Notification());
                            }
                        }
                        rp.count = (countOutput.Value != DBNull.Value) ? (int)countOutput.Value : 0;
                        rp.success = true;
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
    }
}
