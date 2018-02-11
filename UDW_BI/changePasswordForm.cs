using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace UDW_BI
{
    public partial class changePasswordForm : Form
    {
        public changePasswordForm()
        {
            InitializeComponent();
        }

        private void CmdBtnOk_Click(object sender, EventArgs e)
        {
            string myqry = "";
            int result = 0;
                //Check to see Whether record already exists?

                    myqry = "select * from [UDW].[dbo].[Users] where ([UDW].[dbo].[users].[User Name] = '" 
                        + this.txtName.Text + "'" + "and [UDW].[dbo].[users].[Password] = '" + this.txtOldPw.Text + "')";
                        
                        result = this.mySelectcmd(myqry);

                    if (result >= 1)
                    {

                        //A valid user already found now apply security principles on Password string provided by user.
                        if (this.txtNewPW.TextLength < 6)
                        {
                            MessageBox.Show("Minimum Length for a User Password is six. Please try again!",
                            "UDW_BI: Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                            this.DialogResult = System.Windows.Forms.DialogResult.None;
                        }
                        else if (this.txtNewPW.Text != this.txtRetypeNew.Text)
                        {
                            MessageBox.Show("New Password Value Did not match. Please try again!",
                            "UDW_BI: Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                            this.DialogResult = System.Windows.Forms.DialogResult.None;
                        }
                        else 
                        {
                         //else block to insert record into db.
                            
                            myqry = "update [udw].[dbo].[Users] set [Password] = '" 
                                + this.txtNewPW.Text + "' where [User Name] = '" + this.txtName.Text + "'";

                                this.myNonSelectcmd(myqry);
                                MessageBox.Show("Password changed Successfully.",
                                    "UDW_BI: Information.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        
                    }else
                    {
                        //if No user Record found then Notify user to re-enter all information.
                        MessageBox.Show("either [User Name] or [Password] Value Did not found. Please try again!",
                             "UDW_BI: Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                    }

        }

        private void CmdBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private int mySelectcmd(string qry)
        {


            int rowsaffected = 0;
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCmd = new SqlCommand();


            //Connection String stored in App.config file and retreived below.

            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;

            try
            {

                dbConnection.ConnectionString = connstring.ToString();
                dbCmd.CommandText = qry;
                dbCmd.Connection = dbConnection;
                dbCmd.Connection.Open();
                System.Data.SqlClient.SqlDataReader dbRdr;

                dbRdr = dbCmd.ExecuteReader();



                if (dbRdr.HasRows)
                {


                    while (dbRdr.Read())
                    {

                        rowsaffected++;

                    }
                    return rowsaffected;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:changePassword_mySelectcmd() Application. Exiting... " +
            ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

            finally
            {

                dbCmd.Dispose();
                dbConnection.Close();
            }

            return rowsaffected = 0;
        }

        private void myNonSelectcmd(string qry)
        {



            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCmd = new SqlCommand();


            //Connection String stored in App.config file and retreived below.

            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;


            try
            {

                dbConnection.ConnectionString = connstring.ToString();
                dbCmd.CommandText = qry;
                dbCmd.Connection = dbConnection;
                dbCmd.Connection.Open();

                dbCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:changePasswordForm_myNonSelectcmd() Application. Exiting... " +
                ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            finally
            {

                dbCmd.Dispose();
                dbConnection.Close();
            }


        }
    }
}
