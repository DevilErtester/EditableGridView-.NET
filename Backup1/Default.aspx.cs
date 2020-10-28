// DataView.CommandName: http://msdn.microsoft.com/es-es/library/system.web.ui.webcontrols.gridview.rowcommand(v=vs.80).aspx
// DataView http://msdn.microsoft.com/es-es/library/system.web.ui.webcontrols.gridview.onrowdatabound(v=vs.80).aspx 
// DataView.RowState http://msdn.microsoft.com/es-es/library/system.web.ui.webcontrols.gridviewrow.rowstate.aspx


using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Web.UI.WebControls.WebParts;



/*
 O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O
O|0                   Provider:Microsoft.ACE.OLEDB.12.0                       0|O
o|o                             Bb0y ch3Ché                                   o|o
0|O                        chepseyer@gmail.com                                O|0
O|0                       bboy_rys@hotmail.com                                0|O
o|o                     --> 18 - Marzo - 2011 <--                             o|o
0|O           Microsoft Visual Studio - Microsoft Access 2007                 O|0
 O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O_0_o_O
*/
namespace EditableGridview
{
    public partial class _Default : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        OleDbConnection sqlcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showgrid();
            }            
        }
        public void showgrid()
        {
            DataTable dt = new DataTable();
            sqlcon = new OleDbConnection(con);
            sqlcon.Open();
            string strQuery = "SELECT * FROM employee ";

            OleDbDataAdapter sda = new OleDbDataAdapter(strQuery, con);
            
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showgrid();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           GridView1.EditIndex = e.NewEditIndex;
           showgrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lb = (Label)GridView1.Rows[e.RowIndex].FindControl("Label");
            DropDownList ddl = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
            RadioButtonList rbl = (RadioButtonList)GridView1.Rows[e.RowIndex].FindControl("RadioButtonList1");
            CheckBoxList chb = (CheckBoxList)GridView1.Rows[e.RowIndex].FindControl("CheckBoxList2");            
            TextBox tx1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox tx2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox tx3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            sqlcon = new OleDbConnection(con);
            sqlcon.Open();
            string sql = "UPDATE employee SET Emp_name='" + tx1.Text + "',Emp_address='" + tx2.Text + "',Department='" +
                ddl.SelectedValue.ToString() + "',Salary='" + tx3.Text + "',Maritalstatus='" +
                rbl.SelectedValue.ToString() + "',Active_Status='" + chb.SelectedValue.ToString() + "' WHERE Emp_ID=" +
                lb.Text;

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            sqlcon.Close();
            showgrid();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            Label lb = (Label)GridView1.Rows[e.RowIndex].FindControl("Label");
            sqlcon = new OleDbConnection(con);
            sqlcon.Open();
            string sql = "DELETE FROM employee where Emp_ID=" + lb.Text;
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            GridView1.EditIndex = -1;
            showgrid();
            
        }
        protected void GridView1_Deleted (object sender, GridViewDeletedEventArgs e) {
            String s = "";
        }


        public DataTable load_department()
        {
            DataTable dt = new DataTable();
            sqlcon = new OleDbConnection(con);
            sqlcon.Open();
            string sql = "SELECT dept_name FROM department";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlcon;
            OleDbDataAdapter sd = new OleDbDataAdapter(cmd);
            sd.Fill(dt);
            return dt;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                if  ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");

                    //dp.DataSource = load_department();
                    //dp.DataBind();

                    
                    DataTable dt = load_department();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem lt = new ListItem();
                        lt.Text = dt.Rows[i][0].ToString();
                        dp.Items.Add(lt);
                    }

                    // dp.SelectedValue = drv[3].ToString();
                    dp.SelectedValue = e.Row.Cells[3].ToString();

                    RadioButtonList rbtnl = (RadioButtonList)e.Row.FindControl("RadioButtonList1");
                    rbtnl.SelectedValue = drv[5].ToString();
                    CheckBoxList chkb = (CheckBoxList)e.Row.FindControl("CheckBoxList2");
                    chkb.SelectedIndex = -1;
                    chkb.SelectedValue = drv[6].ToString();
                }
            }

            // Pel Footer
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");
                DataTable dt = load_department();
                for (int i = 0; i < dt.Rows.Count; i++) {
                    ListItem lt = new ListItem();
                    lt.Text = dt.Rows[i][0].ToString();
                    dp.Items.Add(lt);
                 }
            }
        }
        protected void addItem(object sender, EventArgs e)
        {
            TextBox B = (TextBox)GridView1.FooterRow.FindControl("XC1");
            String XC1 = B.Text.ToString();

            B = (TextBox)GridView1.FooterRow.FindControl("XC2");
            String XC2 = B.Text.ToString();

          
        }

    }
}

