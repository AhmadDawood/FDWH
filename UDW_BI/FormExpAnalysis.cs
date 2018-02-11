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
    public partial class FormExpAnalysis : Form
    {
        public FormExpAnalysis()
        {
            InitializeComponent();
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormExpAnalysis_Load(object sender, EventArgs e)
        {
            //Changing Cursor state to busy while loading Fact table.
            Cursor.Current = Cursors.WaitCursor;
            //Openning of Expense facts
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            using (SqlConnection dbConnection = new SqlConnection(connstring))
            {
                try
                {
                    dbConnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from [UDW].[dbo].ExpenseFacts order by ExpensesTypeKey asc, EmployeeKey asc", dbConnection);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ExpenseFacts");
                    this.dataGridExpense.DataSource = ds.DefaultViewManager;
                    this.dataGridExpense.DataMember = "ExpenseFacts";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:ExpenseAnalysis_formload() Application. Exiting... " +
                        ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            //Restoring default cursor position.
            Cursor.Current = Cursors.Default;
        }
        private void myfillDims(string myQry, string myDataSet)
        {
            //Changing Cursor state to busy while loading Fact table.
            Cursor.Current = Cursors.WaitCursor;
            //Connection String stored in App.config file and retreived below.
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            using (SqlConnection dbConnection = new SqlConnection(connstring))
            {
                try
                {
                    dbConnection.Open();
                    SqlDataAdapter daDims = new SqlDataAdapter(myQry, dbConnection);
                    DataSet dsDims = new DataSet();
                    daDims.Fill(dsDims, myDataSet);
                    this.dataGridDimExpDetails.DataSource = dsDims.DefaultViewManager;
                    this.dataGridDimExpDetails.DataMember = myDataSet;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:ExpenseAnalysis_myfillDims() Application. Exiting... " +
                        ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            //Restoring Default Cursor Postion.
            Cursor.Current = Cursors.Default;
        }
        private void dataGridExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string userInput = "";
            string selectQry = "";
            try
            {
                switch (e.ColumnIndex)
                {
                    case 1: //ExpensesCategory
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "Select * from [UDW].[dbo].[DimExpenseCategory] where [DimExpenseCategory].[ExpenseKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimExpenseCategory");
                        dataGridExpense.Rows[e.RowIndex].Cells[1].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    case 2: //Requesting EmployeeKey
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "Select * from [UDW].[dbo].[DimEmployee] where [DimEmployee].[EmployeeKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimEmployee");
                        dataGridExpense.Rows[e.RowIndex].Cells[2].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    case 3: //DimPresentJob
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "Select * from [UDW].[dbo].[DimPresentJob] where [DimPresentJob].[EmpInfoKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimPresentJob");
                        dataGridExpense.Rows[e.RowIndex].Cells[3].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    case 4: //DimExpenseAuthorisation
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "select * from [UDW].[dbo].[DimExpenseAuthorisation] "
                        + " where [DimExpenseAuthorisation].[ExpAuthorKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimExpenseAuthorisation"); 
                        dataGridExpense.Rows[e.RowIndex].Cells[4].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    case 5://Dateskey
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "Select * from [UDW].[dbo].[DimDates] where [DimDates].[DateKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimDates");
                        dataGridExpense.Rows[e.RowIndex].Cells[6].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    case 6://HouroftheDayKey
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "Select * from [UDW].[dbo].[DimHourOFTheDay] where [DimHourOFTheDay].[HourKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimHourOFTheDay");
                        dataGridExpense.Rows[e.RowIndex].Cells[7].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    case 7://GeoKey
                        userInput = dataGridExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        selectQry = "Select * from [UDW].[dbo].[DimGeography] where [DimGeography].[GeoKey] = " + int.Parse(userInput);
                        myfillDims(selectQry, "DimGeography");
                        dataGridExpense.Rows[e.RowIndex].Cells[8].ToolTipText = "Click to Expand Dimension Below.";
                        break;
                    default:
                        break;
                }
            }
             catch (IndexOutOfRangeException I)
            {
            MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:ExpenseAnalysis_dataGridExpense_CellClick() Application. Exiting... " +
                  I.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void dataGridExpense_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 7)
            {
                dataGridExpense.Cursor = Cursors.Hand;
            }
            else
            {
                return;
            }
        }
        private void dataGridExpense_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridExpense.Cursor = Cursors.Default;
        }
    }
}