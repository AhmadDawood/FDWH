using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; 
using System.Data.SqlClient;
 
namespace UDW_BI
{
    
    public partial class loginForm : Form
    {
        //Global Variable to Hold usertype.
        //it is used in Program.cs to load a form for either Executive or Admin.
        public static string usertype; 
        public loginForm()
        {
            InitializeComponent();
        }

        private void CmdBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            Application.Exit();
        }
        private void CmdBtnOk_Click(object sender, EventArgs e)
        {
            //Code to Query the User Information From Sql Server Table.
           // IF user is admin then load form for user management.
            // If user is executive type then load Bi_Main.
            string sSelect;
            sSelect = "select * from [udw].[dbo].[users] where [User Name] = '" + this.txtName.Text.ToString() +
                "' and [Password] = '" + this.txtPw.Text.ToString() + "' and [User Type] = '" + this.lboxType.Text.ToString() + "'";
            //Connection String stored in App.config file and retreived below.
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;

            using (SqlConnection dbConnection = new SqlConnection(connstring))
            {
                try
                {
                    SqlCommand dbCmd = new SqlCommand();
                    System.Data.SqlClient.SqlDataReader dbRdr;
                    dbConnection.ConnectionString = connstring.ToString();
                    dbCmd.CommandText = sSelect;
                    dbCmd.Connection = dbConnection;
                    dbCmd.Connection.Open();
                    dbRdr = dbCmd.ExecuteReader();
                    dbRdr.Read();
                    if (dbRdr.HasRows)
                    {
                        // if user is of executive type then load Main Application Mdi Form.
                        // if user is not executive then load a Management form for admin.
                        usertype = dbRdr.GetString(3).ToString();
                        if (usertype == "Executive")
                        {
                            //Transfer Control to Program.cs file to load Interface for Executive.
                            this.DialogResult = DialogResult.OK;
                        }
                        if (usertype == "Admin")
                        {
                            //Transfer Control to Program.cs file to load Interface for Admin user.
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        //Ask For another retry.
                        MessageBox.Show("Wrong user Name, password or user type specified. Please try again! ", 
                            "UDW_BI: Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }   
            }
          }

        private void txtName_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtPw_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void lboxType_Enter(object sender, EventArgs e)
        {
            lboxType.SelectedIndex = lboxType.FindString("Executive");
        }                   
    }
}
