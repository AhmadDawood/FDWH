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
   
    public partial class revenueAnalysisForm : Form
    {
        public revenueAnalysisForm()
        {
            InitializeComponent();
        }

        private void revenueAnalysisForm_Load(object sender, EventArgs e)
        {
            //Changing Cursor state to busy while loading Fact table.
            Cursor.Current = Cursors.WaitCursor;
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            using (SqlConnection dbConnection = new SqlConnection(connstring))
            {
                try
                {
                    dbConnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from [UDW].[dbo].[RevenueFacts] order by StudentKey asc, CustomersKey asc", dbConnection);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "RevenueFacts");
                    this.dataGridRevenue.DataSource = ds.DefaultViewManager;
                    this.dataGridRevenue.DataMember = "RevenueFacts";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:revenueAnalysisForm_Load() Application. Exiting... " +
                ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            } 
            //Restoring default cursor position.
            Cursor.Current = Cursors.Default;        
        }
        private void dataGridRevenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string userchoice= "";
            string qry = "";   
            switch (e.ColumnIndex)
            {
                case 1: //StudentKey
                       userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                       qry = "Select * from [UDW].[dbo].[DimStudents] where [DimStudents].[StudentKey] = " + int.Parse(userchoice);
                       mySelectcmd(qry,"DimStudents");
                       dataGridRevenue.Rows[e.RowIndex].Cells[1].ToolTipText = "Click to Expand Dimension Below.";
                       break;
                case 2: //ProgramKey
                        userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        qry = "Select * from [UDW].[dbo].[DimPrograms] where [DimPrograms].[ProgramKey] = " + int.Parse(userchoice);
                        mySelectcmd(qry,"DimPrograms");
                        dataGridRevenue.Rows[e.RowIndex].Cells[2].ToolTipText = "Click to Expand Dimension Below.";
                       break;
                case 3: //DateKey
                        userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        qry = "Select * from [UDW].[dbo].[DimDates] where [DimDates].[DateKey] = " + int.Parse(userchoice);
                        mySelectcmd(qry,"DimDates");
                        dataGridRevenue.Rows[e.RowIndex].Cells[3].ToolTipText = "Click to Expand Dimension Below.";
                       break;
                case 4://HouroftheDayKey
                        userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        qry = "Select * from [UDW].[dbo].[DimHourOFTheDay] where [DimHourOFTheDay].[HourKey] = " + int.Parse(userchoice);
                        mySelectcmd(qry, "DimHourOFTheDay");
                        dataGridRevenue.Rows[e.RowIndex].Cells[4].ToolTipText = "Click to Expand Dimension Below.";
                       break;
                case 5://GeoKey
                        userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        qry = "Select * from [UDW].[dbo].[DimGeography] where [DimGeography].[GeoKey] = " + int.Parse(userchoice);
                        mySelectcmd(qry, "DimGeography");
                        dataGridRevenue.Rows[e.RowIndex].Cells[5].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                case 6://CustomersKey
                       userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                       qry = "Select * from [UDW].[dbo].[DimCustomers] where [DimCustomers].[CustomerKey] = " + int.Parse(userchoice);
                       mySelectcmd(qry, "DimCustomers");
                       dataGridRevenue.Rows[e.RowIndex].Cells[6].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                case 7://ProductsKey
                        userchoice = dataGridRevenue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        qry = "Select * from [UDW].[dbo].[DimProducts] where [DimProducts].[ProductKey] = " + int.Parse(userchoice);
                        mySelectcmd(qry, "DimProducts");
                        dataGridRevenue.Rows[e.RowIndex].Cells[7].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                default:
                    break;
            }
        }
        private void mySelectcmd(string myQry, string myDataSet)
        {

            //Changing Cursor state to busy while loading Fact table.
            Cursor.Current = Cursors.WaitCursor;
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            //Connection String stored in App.config file and retreived below.
            using (SqlConnection dbConnection = new SqlConnection(connstring))
            {
                try
                {
                    dbConnection.Open();
                    SqlDataAdapter daDims = new SqlDataAdapter(myQry, dbConnection);
                    DataSet dsDims = new DataSet();
                    daDims.Fill(dsDims, myDataSet);
                    this.dataGridDimDetails.DataSource = dsDims.DefaultViewManager;
                    this.dataGridDimDetails.DataMember = myDataSet;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:adminForm_mySelectcmd() Application. Exiting... " +
                ex.Message, "UDW_BI:mySelectcmd() Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }   
                    //Restoring Default Cursor.
                    Cursor.Current = Cursors.Default;
            }
        }
        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridRevenue_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 7)
            {
                dataGridRevenue.Cursor = Cursors.Hand;
            }
            else
            {
                return;
            }
        }

        private void dataGridRevenue_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridRevenue.Cursor = Cursors.Default;
        }       
    }
}
