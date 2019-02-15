 static void LogErrorData(string username, string program, string formid, string error)
        {
            string cmdString = "INSERT INTO Log_Error (username,program,formid,error,time) VALUES (@username, @program, @formid,@error, GETDATE())";
            string conString = "data source=146.196.65.74;initial catalog=INHOPDONG;persist security info=False;user id=envietsystem;pwd=@SQl_EvGroUp_d4T4_c0nnecTion@";
            SqlConnection connOpen = new SqlConnection(conString);
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@program", program);
                    comm.Parameters.AddWithValue("@formid", formid);
                    comm.Parameters.AddWithValue("@error", error);
                    comm.CommandType = CommandType.Text;
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch 
                    {
                        // do something with the exception
                        // don't hide it
                    }
                    finally
                    {
                        comm.Connection.Dispose();
                        comm.Connection.Close();
                        comm.Dispose();
                        comm.Dispose();
                        conn.Close();
                    }
                }
            }
        }
