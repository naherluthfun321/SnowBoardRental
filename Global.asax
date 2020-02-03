<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
            System.Data.SqlClient.SqlConnection myconn = new System.Data.SqlClient.SqlConnection();
            string connStr = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=SnowboardRentalWeb;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\SnowboardRentalWeb.mdf";
            myconn.ConnectionString = connStr;

            try
            {
                myconn.Open();                
                System.Data.SqlClient.SqlCommand mycmd = new System.Data.SqlClient.SqlCommand();
                mycmd.CommandText = "delete from RentOrder";                
                mycmd.Connection = myconn;
                int res = mycmd.ExecuteNonQuery();            
            }
            catch (Exception ex)
            {
               
            }
           

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
