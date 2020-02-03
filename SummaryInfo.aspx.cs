using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SummaryInfo : System.Web.UI.Page
{
    SqlConnection myconn;
    SqlDataAdapter myadapter = new SqlDataAdapter();
    DataTable results = new DataTable();
    //private BindingSource bindingSource1 = new BindingSource();
    SqlCommandBuilder cmbl;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadOrderData();
    }
    public void LoadOrderData()
    {
        myconn = new SqlConnection();
        string connStr = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=SnowboardRentalWeb;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\SnowboardRentalWeb.mdf";
        myconn.ConnectionString = connStr;

        try
        {
            myconn.Open();
            // string statement = "select * from RentOrder";
            string statement = "select Id, PersonName[Person Name], LicenseNoId[License No / ID], Snowboard[No.of Snowboard], SnowboardWithBoot[No.of Snowboard with Boot], SnowboardRate[Snowboard Rate], SnowboardWithBootRate[Snowboard with Boot Rate], SnowboardAmt[Snowboard Amount], SnowboardWithBootAmt[Snowboard with Boot Amount], TotalAmount[Total Amount] from RentOrder";

            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandText = statement;
            mycmd.Connection = myconn;
            myadapter.SelectCommand = mycmd;
            results.Clear();

            cmbl = new SqlCommandBuilder(myadapter);
            myadapter.Fill(results);
             
            GridView1.DataSource = results;
            GridView1.DataBind();
            
            

        }
        catch (Exception ex)
        {

        }
        if (myconn.State == ConnectionState.Open)
        {
            // myconn.Close();
        }
    }

    protected void btnAddOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Order.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }

    //protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    //{

    //}

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        
        LoadOrderData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
         
        TextBox textName = (TextBox)row.Cells[2].Controls[0];
  
        GridView1.EditIndex = -1;


        myconn = new SqlConnection();
        string connStr = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=SnowboardRentalWeb;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\SnowboardRentalWeb.mdf";
        myconn.ConnectionString = connStr;

        try
        {
            myconn.Open();

            string statement = "update RentOrder set PersonName= '" + textName.Text + "' where id=" + id;
            
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandText = statement;
            mycmd.Connection = myconn;
            mycmd.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {

        }
        if (myconn.State == ConnectionState.Open)
        {
             
        }


        LoadOrderData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;

        LoadOrderData();
    }
     
}