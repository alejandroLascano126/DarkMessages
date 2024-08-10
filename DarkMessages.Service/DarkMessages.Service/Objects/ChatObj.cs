using DarkMessages.DesktopApp;
using DarkMessages.models.Chats;
using DarkMessages.models.Groups;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DarkMessages.Service.Objects
{
    public class ChatObj
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

        public ChatObj()
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
        }

        public async Task<rpConsultChats> consultChats(rqConsultChats rq)
        {
            rpConsultChats rp = new rpConsultChats();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_consultChats", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@username", rq.username);
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
                            rp.chats = new List<chat>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string? email = (row["email"] == DBNull.Value) ? null : row["email"].ToString();
                                string? friendUsername = (row["friendUsername"] == DBNull.Value) ? null : row["friendUsername"].ToString();
                                string? lastMessage = (row["lastMessage"] == DBNull.Value) ? null : row["lastMessage"].ToString();
                                chat chat = new chat() { chatId = Convert.ToInt32(row["chatId"]), typeChatId = Convert.ToInt32(row["typeChatId"]), entityId = Convert.ToInt32(row["entityId"]), name = row["name"].ToString()!, userIdRelated = Convert.ToInt32(row["userIdRelated"]), lastMessage = lastMessage, friendUsername = friendUsername, dateCreated = Convert.ToDateTime(row["dateCreated"]), email = email };
                                rp.chats.Add(chat);
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
