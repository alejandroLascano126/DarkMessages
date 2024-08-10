using DarkMessages.DesktopApp;
using DarkMessages.models.Friends;
using DarkMessages.models.Login;
using DarkMessages.models.Message;
using DarkMessages.models.SignUp;
using DarkMessages.models.Usuarios;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DarkMessages.Service.Objects
{
    public class UserObj
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

        public UserObj() 
        {
            connectionString = builder.ConnectionString;
            emailSender = new EmailSender();
        }

        public async Task<rpSignUp> registerUserAsync(rqSignUp rq) 
        {
            rpSignUp rp = new rpSignUp();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("sp_register_user", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@username", rq.userName);
                        command.Parameters.AddWithValue("@password", rq.password);
                        command.Parameters.AddWithValue("@email", rq.email);
                        command.Parameters.AddWithValue("@languages", rq.languages);
                        command.Parameters.AddWithValue("@country", rq.country);
                        command.Parameters.AddWithValue("@name", rq.name);
                        command.Parameters.AddWithValue("@lastname", rq.lastname);

                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter responsemsgOutput = new SqlParameter("@responsemsg", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter idOutput = new SqlParameter("@id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        command.Parameters.Add(responsemsgOutput);
                        command.Parameters.Add(idOutput);

                        await command.ExecuteNonQueryAsync();

                        int response = (int)responseOutput.Value;
                        string responsemsg = (string)responsemsgOutput.Value;
                        int id = (int)idOutput.Value;
                        string email = hiddenEmail(rq.email);

                        if (response == 0)
                        {
                            rp.id = id;
                            int sc = 0;
                            Random random = new Random();
                            sc = random.Next(100000, 999999);

                            bool resp = await emailSender.SendEmailAsync(rq.email, "", "", sc);

                            if (resp)
                            {
                                rqValidateSecurityCode rqReg = new rqValidateSecurityCode();
                                rqReg.idUser = id;
                                rqReg.securityCode = sc;
                                bool rersp = await RegisterSecurityCodeDB(rqReg);
                                if (rersp)
                                {

                                    rp.message = (resp) ? $"User registered successfully. An security code has been sent to {email}" : "Error sending the security code";
                                    rp.success = true;
                                }
                            }
                            else
                            {
                                rp.message = "Error: Security code wasn't registered";
                                rp.success = false;
                            }

                        }
                        else
                        {
                            rp.id = 0;
                            rp.success = false;
                            rp.message = $"User cannot be registered. {responsemsg}";
                        }
                    }     
                }
            }
            catch (Exception ex)
            {
                rp.id = 0;
                rp.success = false;
                rp.message = ex.Message;
            }
            return rp;
        }

        public async Task<rpLogin> LoginUserAsync(rqLogin rq)
        {
            rpLogin rp = new rpLogin();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("sp_validate_userpw", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", rq.username);
                    command.Parameters.AddWithValue("@password", rq.password);

                    SqlParameter emailOutput = new SqlParameter("@email", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };
                    SqlParameter idUserOutput = new SqlParameter("@idUser", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter nameOutput = new SqlParameter("@name", SqlDbType.VarChar, 30)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter lastnameOutput = new SqlParameter("@lastname", SqlDbType.VarChar, 30)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(emailOutput);
                    command.Parameters.Add(idUserOutput);
                    command.Parameters.Add(responseOutput);
                    command.Parameters.Add(nameOutput);
                    command.Parameters.Add(lastnameOutput);

                    await connection.OpenAsync();
                    int respValue = await command.ExecuteNonQueryAsync();

                    int response = (int)responseOutput.Value;

                    if (response == 0)
                    {
                        rp.email = (string)emailOutput.Value;
                        rp.id = (int)idUserOutput.Value;
                        rp.name = (string)nameOutput.Value;
                        rp.lastname = (string)lastnameOutput.Value;

                        if (rq.emailValidation)
                        {
                            int sc = 0;
                            Random random = new Random();
                            sc = random.Next(100000, 999999);

                            bool resp = await emailSender.SendEmailAsync(rp.email, "", "", sc);

                            if (resp)
                            {
                                rqValidateSecurityCode rqReg = new rqValidateSecurityCode();
                                rqReg.idUser = rp.id;
                                rqReg.securityCode = sc;
                                bool rersp = await RegisterSecurityCodeDB(rqReg);
                                if (rersp)
                                {
                                    rp.message = (resp) ? "User logged in successfully. An security code has been sent to alejan**********@gmail.com" : "Error sending the security code";
                                    rp.success = true;
                                }

                            }
                            else
                            {
                                rp.message = "Error: Security code wasn't registered";
                                rp.success = false;
                            }
                        }
                        else 
                        {
                            rp.message = "User logged in successfully.";
                            rp.success = true;
                        }
                    }
                    else
                    {
                        rp.email = "";
                        rp.id = 0;
                        rp.success = false;
                        rp.message = "Invalid username or password.";
                    }
                }
            }
            catch (Exception ex)
            {
                rp.email = "";
                rp.id = 0;
                rp.success = false;
                rp.message = "An error occurred: " + ex.Message;
            }

            return rp;
        }

        private async Task<bool> RegisterSecurityCodeDB(rqValidateSecurityCode rq) 
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("sp_insert_securitycode", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idUser", rq.idUser);
                    command.Parameters.AddWithValue("@securityCode", rq.securityCode);

                    SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(responseOutput);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    int response = (int)responseOutput.Value;
                    if (response == 0)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<rpValidateSecurityCode> ValidateSecurityCodeAsync(rqValidateSecurityCode rq) 
        {
            rpValidateSecurityCode rp = new rpValidateSecurityCode();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("sp_validate_securitycode", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@idUser", rq.idUser);
                    command.Parameters.AddWithValue("@securityCode", rq.securityCode);

                    SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    
                    command.Parameters.Add(responseOutput);

                    await connection.OpenAsync();
                    int respValue = await command.ExecuteNonQueryAsync();

                    int response = (int)responseOutput.Value;

                    if (response == 0)
                    {
                        rp.success = true;
                        rp.message = "Security code verified";
                    }
                    else
                    {
                        rp.success = false;
                        rp.message = "Invalid security code";
                    }
                }
            }
            catch (Exception ex)
            {
                rp.success = false;
                rp.message = "An error occurred: " + ex.Message;
            }


            return rp;
        
        }

        public async Task<rpLogin> generateSecurityCode(rqLogin rq) 
        {
            rpLogin rp = new rpLogin();
            rp = await LoginUserAsync(rq);
            return rp;
        }

        private string hiddenEmail(string email) 
        {
            string[] elements = email.Split('@');
            string name = elements[0];
            string domain = elements[1];
            string hiddenName = name.Substring(0, 5) + new string('*', name.Length - 5);
            return $"{hiddenName}@{domain}";
        }

        public async Task<rpConsultFriends> consultFriends(rqConsultFriends rq) 
        {
            rpConsultFriends rp = new rpConsultFriends();
            try 
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("consultFriends", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@username", rq.username);
                        command.Parameters.AddWithValue("@rows", rq.rows);
                        command.Parameters.AddWithValue("@page", rq.page);
                        //command.Parameters.AddWithValue("@option", rq.option ?? "");
                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rp.friends = new List<Friend>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                Friend msg = new Friend() { username = row["friend"].ToString()!, name = row["name"].ToString()!, lastname = row["lastname"].ToString()!, lastChatMessage = row["lastMessage"].ToString()!, email = row["email"].ToString()! };
                                rp.friends.Add(msg);
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
            catch (Exception ex) 
            {
                rp.success = false;
            }
            return rp;
        }

        public async Task<rpUserQuery> filterUsers(rqUserQuery rq) 
        {
            rpUserQuery rp = new rpUserQuery();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_consultFilterUsers", connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@value", rq.value);
                        command.Parameters.AddWithValue("@myUsername", rq.username);
                        

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            rp.users = new List<User>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                User user = new() { Id = Convert.ToInt32(row["idUser"]!), userName = row["username"].ToString()!, name = row["name"].ToString()!, lastname = row["lastname"].ToString()!, email = row["email"].ToString()!, isFriend = (row["isFriend"].ToString()! == "Y") ? true : false  };
                                rp.users.Add(user ?? new User());
                            }
                        }
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

        public async Task<rpAddFriendship> registerFriendship(rqAddFriendship rq)
        {
            rpAddFriendship rp = new rpAddFriendship();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("sp_registerFriendship", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usernameFirst", rq.usernameFirst);
                        command.Parameters.AddWithValue("@usernameSecond", rq.usernameSecond);


                        SqlParameter responseOutput = new SqlParameter("@response", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(responseOutput);
                        int respValue = await command.ExecuteNonQueryAsync();

                        int response = (int)responseOutput.Value;

                        if (response == 0)
                        {
                            rp.success = true;
                            rp.message = "You have a new Friend";
                        }
                        else
                        {
                            rp.success = false;
                            rp.message = "Error adding new Friend";
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
    }
}
