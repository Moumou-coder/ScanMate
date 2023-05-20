namespace ScanMate.Services;

public partial class UserManagementService
{
    public OleDbDataAdapter Users_Adapter = new();
    public OleDbConnection Connexion = new();

    internal void ConfigTools()
    {
        //Establish the connection
        Connexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.16.0;"
                                    + "Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScanMateServer", "UserAccounts.accdb")
                                    + ";Persist Security Info=False";

        //Create commands
        string Insert_CommandText = "INSERT INTO DB_Users(UserName,UserPassword,UserAccessType) VALUES (@UserName,@UserPassword,@UserAccessType);";
        string Delete_CommandText = "DELETE FROM DB_Users WHERE UserName = @UserName;";
        string Select_CommandText = "SELECT * FROM DB_Users ORDER BY User_ID;";
        string Update_CommandText = "UPDATE DB_Users SET UserPassword = @UserPassword, UserAccessType = @UserAccessType WHERE UserName = @UserName;";

        OleDbCommand Insert_Command = new OleDbCommand(Insert_CommandText, Connexion);
        OleDbCommand Delete_Command = new OleDbCommand(Delete_CommandText, Connexion);
        OleDbCommand Select_Command = new OleDbCommand(Select_CommandText, Connexion);
        OleDbCommand Update_Command = new OleDbCommand(Update_CommandText, Connexion);

        Users_Adapter.SelectCommand = Select_Command;
        Users_Adapter.InsertCommand = Insert_Command;
        Users_Adapter.DeleteCommand = Delete_Command;
        Users_Adapter.UpdateCommand = Update_Command;

        Users_Adapter.TableMappings.Add("DB_Users", "Users");
        Users_Adapter.TableMappings.Add("DB_Access", "Access");

        Users_Adapter.InsertCommand.Parameters.Add("@UserName", OleDbType.VarChar, 40, "UserName");
        Users_Adapter.InsertCommand.Parameters.Add("@UserPassword", OleDbType.VarChar, 40, "UserPassword");
        Users_Adapter.InsertCommand.Parameters.Add("@UserAccessType", OleDbType.Numeric, 100, "UserAccessType");
        Users_Adapter.DeleteCommand.Parameters.Add("@UserName", OleDbType.VarChar, 40, "UserName");
        Users_Adapter.UpdateCommand.Parameters.Add("@UserName", OleDbType.VarChar, 40, "UserName");
        Users_Adapter.UpdateCommand.Parameters.Add("@UserPassword", OleDbType.VarChar, 40, "UserPassword");
        Users_Adapter.UpdateCommand.Parameters.Add("@UserAccessType", OleDbType.Numeric, 100, "UserAccessType");
    }
    public async Task ReadAccessTable()
    {
        OleDbCommand SelectCommand = new OleDbCommand("SELECT * FROM DB_Access ORDER BY Access_ID;", Connexion);
        try
        {
            Connexion.Open();

            OleDbDataReader oleDbDataReader = SelectCommand.ExecuteReader();

            if (oleDbDataReader.HasRows)
            {
                while (oleDbDataReader.Read())
                {
                    Globals.UserSet.Tables["Access"].Rows.Add(new object[] { oleDbDataReader[0], oleDbDataReader[1], oleDbDataReader[2], oleDbDataReader[3], oleDbDataReader[4], oleDbDataReader[5] });
                }
            }

            oleDbDataReader.Close();

        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        finally
        {
            Connexion.Close();
        }
    }

    public async Task ReadUserTable()
    {
        OleDbCommand SelectCommand = new OleDbCommand("SELECT * FROM DB_Users ORDER BY User_ID;", Connexion);
        try
        {
            Connexion.Open();

            OleDbDataReader oleDbDataReader = SelectCommand.ExecuteReader();

            if (oleDbDataReader.HasRows)
            {
                while (oleDbDataReader.Read())
                {
                    Globals.UserSet.Tables["Users"].Rows.Add(new object[] { oleDbDataReader[0], oleDbDataReader[1], oleDbDataReader[2], oleDbDataReader[3] });
                }
            }

            oleDbDataReader.Close();

        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        finally
        {
            Connexion.Close();
        }
    }

    public async Task FillUser()
    {
        Globals.UserSet.Tables["Users"].Clear();

        try
        {
            Connexion.Open();

            Users_Adapter.Fill(Globals.UserSet.Tables["Users"]);



        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        finally
        {
            Connexion.Close();
        }
    }

    public async Task InsertUser(string name, string password, Int32 access)
    {
        try
        {
            Connexion.Open();
            Users_Adapter.InsertCommand.Parameters[0].Value = name;
            Users_Adapter.InsertCommand.Parameters[1].Value = password;
            Users_Adapter.InsertCommand.Parameters[2].Value = access;

            if (Users_Adapter.InsertCommand.ExecuteNonQuery() != 0)
            {
                await Shell.Current.DisplayAlert("Database", "User ins�r�", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Database", "User non ins�r�", "OK");

            }


        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        finally
        {
            Connexion.Close();
        }
    }

    public async Task DeleteUser(string name)
    {
        try
        {
            Connexion.Open();
            Users_Adapter.DeleteCommand.Parameters[0].Value = name;


            if (Users_Adapter.DeleteCommand.ExecuteNonQuery() != 0)
            {
                await Shell.Current.DisplayAlert("Database", "User supprim�", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Database", "User non supprim�", "OK");

            }


        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        finally
        {
            Connexion.Close();
        }
    }

    public async Task UpdateUser()
    {
        try
        {
            Connexion.Open();

            Users_Adapter.Update(Globals.UserSet.Tables["Users"]);

        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Database", ex.Message, "OK");
        }
        finally
        {
            Connexion.Close();
        }
    }
}