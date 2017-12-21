using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SqlBulkCopyDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ProductDBConnectionString

    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data.xml"));
            DataTable dtDepartment = ds.Tables["Department"];
            DataTable dtEmployee = ds.Tables["Employee"];
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                con.Open();
                bc.DestinationTableName = "tbl_Departments"; //destination
                bc.ColumnMappings.Add("Id", "Id");
                bc.ColumnMappings.Add("Name", "Name");
                bc.ColumnMappings.Add("Location", "Location");
                bc.WriteToServer(dtDepartment); //source 
                Response.Write("Department data written to table");
                
            }
            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {
                //con.Open();
                bc.DestinationTableName = "tbl_Employees"; //destination
                bc.ColumnMappings.Add("Id", "Id");
                bc.ColumnMappings.Add("Name", "Name");
                bc.ColumnMappings.Add("Title", "Title");
                bc.ColumnMappings.Add("DeptId", "DeptId");
                bc.WriteToServer(dtEmployee); //source 
                Response.Write("Tables were successfully created");
            }
        }

    }
}