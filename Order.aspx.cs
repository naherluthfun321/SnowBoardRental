using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
{
    public const double SnowboardRate = 20;
    public const double SnowboardWithBootRate = 30;
    //public SummaryInfo ParentForm;

    SqlConnection myconn;
    SqlDataAdapter myadapter = new SqlDataAdapter();
    // DataTable results = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtSnowboards_TextChanged(object sender, EventArgs e)
    {
        if (txtSnowboards.Text != "")
        {
            double SnowboardAmt = GetSnowboardAmt();
            lblSnowAmt.Text = "$" + SnowboardAmt.ToString();
        }
        else
        {
            lblSnowAmt.Text = "$0.00";
        }
        double totalAmt = GetSnowboardAmt() + GetSnowboardWithBootAmt();
        txtRentalTotal.Text = "$" + totalAmt.ToString();
    }
    protected void txtSnowboardsBoots_TextChanged(object sender, EventArgs e)
    {
        if (txtSnowboardsBoots.Text != "")
        {
            double SnowboardBootAmt = GetSnowboardWithBootAmt();
            lblSnowBootAmt.Text = "$" + SnowboardBootAmt.ToString();
        }
        else
        {
            lblSnowBootAmt.Text = "$0.00";
        }
        double totalAmt = GetSnowboardAmt() + GetSnowboardWithBootAmt();
        txtRentalTotal.Text = "$" + totalAmt.ToString();
    }
    private double GetSnowboardAmt()
    {
        double SnowboardAmt = 0.00;
        if (txtSnowboards.Text != "")
        {
            int numOfSnowboard = Convert.ToInt32(txtSnowboards.Text);
            SnowboardAmt = numOfSnowboard * SnowboardRate;

        }
        return SnowboardAmt;
    }
    private double GetSnowboardWithBootAmt()
    {
        double SnowboardWithBootAmt = 0.00;
        if (txtSnowboardsBoots.Text != "")
        {
            int numOfSnowboard = Convert.ToInt32(txtSnowboardsBoots.Text);
            SnowboardWithBootAmt = numOfSnowboard * SnowboardWithBootRate;

        }
        return SnowboardWithBootAmt;
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        txtErrorMsg.ForeColor = System.Drawing.Color.Red;
        if (txtPersonName.Text == "")
        {
            txtErrorMsg.Text = "Please enter person name.";
            return;
        }

        if (txtSnowboards.Text == "" && txtSnowboardsBoots.Text == "")
        {
            txtErrorMsg.Text = "Please enter at least 1 snowboard or snowboard with boot.";
            return;
        }


        myconn = new SqlConnection();
        string connStr = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=SnowboardRentalWeb;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\SnowboardRentalWeb.mdf";
        myconn.ConnectionString = connStr;

        try
        {
            myconn.Open();

            string statement = "insert into RentOrder values(@PersonName,@LicenseNoId,@Snowboard,@SnowboardWithBoot,@SnowboardRate,@SnowboardWithBootRate,@SnowboardAmt,@SnowboardWithBootAmt,@TotalAmount)";
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandText = statement;

            SqlParameter myparm = new SqlParameter("@PersonName", SqlDbType.VarChar);
            myparm.Value = txtPersonName.Text;
            mycmd.Parameters.Add(myparm);

            SqlParameter myparm1 = new SqlParameter("@LicenseNoId", SqlDbType.VarChar);
            myparm1.Value = txtLicenseId.Text;
            mycmd.Parameters.Add(myparm1);

            SqlParameter myparm2 = new SqlParameter("@Snowboard", SqlDbType.Int);
            myparm2.Value = txtSnowboards.Text == "" ? 0 : Convert.ToInt32(txtSnowboards.Text);
            mycmd.Parameters.Add(myparm2);

            SqlParameter myparm3 = new SqlParameter("@SnowboardWithBoot", SqlDbType.Int);
            myparm3.Value = txtSnowboardsBoots.Text == "" ? 0 : Convert.ToInt32(txtSnowboardsBoots.Text);
            mycmd.Parameters.Add(myparm3);

            SqlParameter myparm4 = new SqlParameter("@SnowboardRate", SqlDbType.Decimal);
            myparm4.Value = SnowboardRate;
            mycmd.Parameters.Add(myparm4);

            SqlParameter myparm5 = new SqlParameter("@SnowboardWithBootRate", SqlDbType.Decimal);
            myparm5.Value = SnowboardWithBootRate;
            mycmd.Parameters.Add(myparm5);

            double SnowboardAmt = GetSnowboardAmt();
            double SnowboardBootAmt = GetSnowboardWithBootAmt();
            double totalAmt = SnowboardAmt + SnowboardBootAmt;

            SqlParameter myparm6 = new SqlParameter("@SnowboardAmt", SqlDbType.Decimal);
            myparm6.Value = SnowboardAmt;
            mycmd.Parameters.Add(myparm6);

            SqlParameter myparm7 = new SqlParameter("@SnowboardWithBootAmt", SqlDbType.Decimal);
            myparm7.Value = SnowboardBootAmt;
            mycmd.Parameters.Add(myparm7);

            SqlParameter myparm8 = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
            myparm8.Value = totalAmt;
            mycmd.Parameters.Add(myparm8);

            mycmd.Connection = myconn;



            int res = mycmd.ExecuteNonQuery();
            if (res > 0)
            {
                txtErrorMsg.Text = "Order has been submitted successfully!";
                txtErrorMsg.ForeColor = System.Drawing.Color.Green;
                myconn.Close();
                Response.Redirect("SummaryInfo.aspx");
                //this.ParentForm.LoadOrderData();
                //this.Close();
            }

        }
        catch (Exception ex)
        {
            txtErrorMsg.Text = "There was an error";
        }
        if (myconn.State == ConnectionState.Open)
        {
            myconn.Close();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SummaryInfo.aspx");
    }
}