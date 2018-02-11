using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;

namespace UDW_BI
{
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            gboxAdd.Visible = false;
        }
        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            this.Tag = "Add";
            gboxAdd.Visible = true;
            gboxAdd.Text = "Add New Uer";
            LblName.Visible = true;
            txtName.Visible = true;
            LblPw.Visible = true;
            txtPw.Visible = true;
            CmdBtnOk.Location = new Point(264, 137);
        }
        private void rbtnRemove_Click(object sender, EventArgs e)
        {
            this.Tag = "Remove";
            gboxAdd.Visible = true;
            gboxAdd.Text = "Remove Existing User";
            LblPw.Visible = false;
            txtPw.Visible = false;
            CmdBtnOk.Location = new Point(264, 93);
            CmdBtnOk.Text = "Remove User";
  //        CmdBtnCancel.Location = new Point(348, 93);
        }
        private void CmdBtnCancel_Click(object sender, EventArgs e)
        {
            //Quits the Application.
            Application.Exit();
        }
        private void CmdBtnOk_Click(object sender, EventArgs e)
        {
            string myqry = "";
            int result = 0;
            switch (this.Tag.ToString())
            {
                case "Add":
                    //Execute Insert Command.
                    //Check to see Whether record all ready exists?
                    myqry = "select * from [UDW].[dbo].[Users] where [UDW].[dbo].[users].[User Name] = ('" + this.txtName.Text + "')";
                    result = this.mySelectcmd(myqry);
                    if ( result < 1 )
                    {
                        if (this.txtName.TextLength < 6 ) 
                        {
                            MessageBox.Show("Minimum Length for a User Name is six. Please try again!",
                            "UDW_BI: Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                            break; 
                        }
                        if (this.txtPw.TextLength < 6)
                        {
                            MessageBox.Show("Minimum Length for a User Password is six. Please try again!",
                            "UDW_BI: Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                            break;
                        }

                        myqry = "INSERT INTO [UDW].[dbo].[Users] ([User Name],[Password], [User Type]) VALUES ('"
                            + this.txtName.Text + "','" + this.txtPw.Text + "','Executive')";
                        
                        this.myNonSelectcmd(myqry);
                          MessageBox.Show("Executive User Successfully Added.",
                              "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        break;
                    }
                    else
                    {
                        MessageBox.Show("User Already Exists", 
                            "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop );
                        break;
                    }
                case "Remove":
                    // Execute Delete Command
                    // Query Whether User Exists or Not?
                    //select * from [UDW].[dbo].[Users] where ([User Name] = 'test45' AND [User Type] = 'Executive') 
                      myqry = "select * from [UDW].[dbo].[users] where ([User Name] = '" + this.txtName.Text +
                        "' AND [User Type] = 'Executive')"; 
                    result = this.mySelectcmd(myqry);
                    if ( result >= 1 )
                    {
                        //delete from [UDW].[dbo].[Users] where ([User Name] = 'test55' AND [Password] = '123456' AND [User Type] = 'Executive') 
                        myqry = "delete from [UDW].[dbo].[Users] where ([User Name] = '" + this.txtName.Text +
                        "' AND [User Type] = 'Executive')";   
                    DialogResult dresult = MessageBox.Show("Do you still want to remove the user.",
                              "UDW_BI: Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            
                            if (dresult == DialogResult.OK)
                                {
                                this.myNonSelectcmd(myqry);
                                MessageBox.Show("Executive User Successfully Removed.",
                                    "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                                }
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Specified.", 
                            "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop );
                        break;
                    }
                    break;

                default:
                    break;
            }
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
                    } catch (Exception ex)
                    {
                        MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:adminForm_mySelectcmd() Application. Exiting... " +
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
                    } catch (Exception ex)
                    {
                    MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:adminForm_myNonSelectcmd() Application. Exiting... " +
                    ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    finally
                    {
                      dbCmd.Dispose(); 
                      dbConnection.Close();  
                    }
        }
        private void rbtnChangePW_Click(object sender, EventArgs e)
        {
            //this.Tag = "ChangePW";
            gboxAdd.Visible = false;        
            changePasswordForm chPwForm = new changePasswordForm();
            chPwForm.ShowDialog(this);   
        }
        private void CmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}