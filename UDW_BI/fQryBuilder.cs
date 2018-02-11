using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace UDW_BI
{
    public partial class fQryBuilder : Form
    {
        public fQryBuilder()
        {
            InitializeComponent();
        }
        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fQryBuilder_Load(object sender, EventArgs e)
        {
            //Changing Cursor state to busy while loading table.
            Cursor.Current = Cursors.WaitCursor;
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            String SQL;
            SQL = "SELECT [TABLE_CATALOG], [TABLE_SCHEMA], [TABLE_NAME], [COLUMN_NAME], [ORDINAL_POSITION]" +
            " FROM [UDW].[INFORMATION_SCHEMA].[COLUMNS] " +
            " Where [UDW].[INFORMATION_SCHEMA].[COLUMNS].TABLE_NAME != 'sysdiagrams' " +
            " AND [UDW].[INFORMATION_SCHEMA].[COLUMNS].TABLE_NAME != 'Users' " +
            " ORDER BY [ORDINAL_POSITION] ";
            // Createing ADO.NET objects.
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    SqlDataReader r;
                    // Executes the query and store Table Name in a List.
                    List<String> listTableNames = new List<string>();
                    r = cmd.ExecuteReader();
                    DataTable schema = new DataTable();
                    schema.Load(r);
                    foreach (DataRow row in schema.Rows)
                    {
                        //Add Table Names in a list
                        listTableNames.Add(row["Table_Name"].ToString());
                    }
                    //Removing duplicates in Table Names.
                    List<String> listUniqueTableNames = listTableNames.Distinct().ToList();
                    treeViewTbls.Nodes.Add("Tables");
                    foreach (String T in listUniqueTableNames)
                    {
                        treeViewTbls.Nodes.Add(T);
                    }
                    foreach (DataRow row in schema.Rows)
                    {
                        foreach (TreeNode item in treeViewTbls.Nodes)
                        {
                            if ((row["Table_Name"]).Equals(item.Text))
                            {
                                treeViewTbls.Nodes[item.Index].Nodes.Add(row["Column_Name"].ToString());
                            }
                        }// End foreach(treeNode...)
                    }// End Foreach(DataRow row)    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:FQryBuilder_formload() Application. Exiting... " +
                        ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                } // End Catch
                finally
                {
                    con.Close();
                }
            } // End Try Block.
            //Changing Cursor state to busy while loading Fact table.
            Cursor.Current = Cursors.Default;
        }
        private void treeViewTbls_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeViewTbls.SelectedNode.Level == 1)
            {
                try
                {
                    String[] cellToAdd = new String[7];
                    String[] rowToAdd = new String[7];
                    //Assigning Default values to DataGridViewCols
                    cellToAdd[0] = this.treeViewTbls.SelectedNode.Text.ToString(); //Column Name.
                    cellToAdd[1] = ""; //Dummy value for Alias Column.
                    cellToAdd[2] = this.treeViewTbls.SelectedNode.Parent.Text.ToString(); //Table Name.
                    cellToAdd[3] = true.ToString(); //output Column Default Value.
                    cellToAdd[4] = "No";
                    cellToAdd[5] = "No";
                    cellToAdd[6] = "No";
                    //Add New Row in DataGridViewCols.
                    for (int i = 0; i <= 6; i++)
                    {
                        rowToAdd[i] = cellToAdd[i];
                    }
                    this.dataGridViewCols.Rows.Add(rowToAdd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                this.txtboxSql.Text = this.makeQuery();
            }
        }

        String BuildColumsString()
        {
            //A Procedure to Prepare Columns Part of SQL Statement.
            StringBuilder QryBuilder = new StringBuilder();
            String[] cellToAdd = new String[6];
            int qbLength = 0;
            try
            {
                QryBuilder.Insert(qbLength, "Select  ");
                // Get Data from DataGridView Column by Columns.
                for (int rows = 0; rows < dataGridViewCols.Rows.Count - 1; rows++)
                {
                    //Select [TableName].[FieldName] as [ ],
                    //Check Output Column First, if it is true?.
                    if (Convert.ToBoolean(dataGridViewCols.Rows[rows].Cells[3].Value) == true)
                    {
                        //Check if Aggregate Function is Specified then.
                        if (Convert.ToString(dataGridViewCols.Rows[rows].Cells[5].Value) != "No" &&
                            Convert.ToString(dataGridViewCols.Rows[rows].Cells[5].Value) != "Group By")
                        {
                            //COUNT(Orders.OrderID) AS Totalorders
                            //Get Aggregate Function Name.
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, (dataGridViewCols.Rows[rows].Cells[5].Value.ToString() + "("));
                            //Get [Table Name].[Field Name]
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "])"));
                            //Get Alias Name if provided by the user.
                            if (dataGridViewCols.Rows[rows].Cells[1].Value.ToString().Length > 0)
                            {
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, " as [" + (dataGridViewCols.Rows[rows].Cells[1].Value.ToString() + "], "));
                            }
                            else
                            {
                                dataGridViewCols.Rows[rows].Cells[1].Value = "Exp1";
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, " as [" + (dataGridViewCols.Rows[rows].Cells[1].Value.ToString() + "]  "));
                            }
                        }
                        else
                        {
                            //Get Table Names.
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                            //Get Alias Name if provided by the user.
                            if (dataGridViewCols.Rows[rows].Cells[1].Value.ToString().Length > 0)
                            {
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "]"));
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, " as [" + (dataGridViewCols.Rows[rows].Cells[1].Value.ToString() + "], "));
                            }
                            else
                            {
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "], "));
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                //Stop NullReferenceException.
            }
            //Remove Comma Sign at the end of last Column Name.
            qbLength = QryBuilder.Length;
            QryBuilder.Remove(qbLength - 2, 1);

            return QryBuilder.ToString();
        }
        String BuildFromClause()
        {
            //The following Code will produce from clause.
            StringBuilder QryBuilder = new StringBuilder();
            int qbLength = 0;
            try
            {
                for (int rows = 0; rows < dataGridViewCols.Rows.Count - 1; rows++)
                {
                    //Check Output Column First, if it is true?.
                    if (Convert.ToBoolean(dataGridViewCols.Rows[rows].Cells[3].Value) == true)
                    {
                        ////Check Table Column Specified 
                        if (dataGridViewCols.Rows[rows].Cells[2].Value.ToString().Length > 0)
                        {
                            //Get Table Names.
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "FROM [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "] "));
                            break;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                //Stop NullReferenceException.
            }
            return QryBuilder.ToString();
        }
        String BuildJoinClause()
        {
            StringBuilder QryBuilder = new StringBuilder();
            int qbLength = 0;
            try
            {
                for (int rows = 0; rows < dataGridViewRelations.Rows.Count - 1; rows++)
                {
                    //INNER JOIN [RightTable]  ON [LeftTable].[Key] =  [RightTable].[Key] 
                    //LEFT JOIN [RightTable]  ON [LeftTable].[Key] =  [RightTable].[Key] 
                    //RIGHT JOIN [RightTable]  ON [LeftTable].[Key] =  [RightTable].[Key] 
                    qbLength = QryBuilder.Length;
                    // Join Type.
                    QryBuilder.Insert(qbLength, (" " + dataGridViewRelations.Rows[rows].Cells[2].Value.ToString()));
                    qbLength = QryBuilder.Length;
                    //Right Table Name
                    QryBuilder.Insert(qbLength, " [" + (dataGridViewRelations.Rows[rows].Cells[3].Value.ToString() + "] "));
                    qbLength = QryBuilder.Length;
                    //[LEFT Table Name].[Field Name]
                    QryBuilder.Insert(qbLength, " ON " + (dataGridViewRelations.Rows[rows].Cells[1].Value.ToString() + " = "));
                    //[Right Table Name].[Field Name]
                    qbLength = QryBuilder.Length;
                    QryBuilder.Insert(qbLength, " " + dataGridViewRelations.Rows[rows].Cells[4].Value.ToString() + " ");
                }
            }
            catch (NullReferenceException)
            {
                //Stop NullReferenceException.
            }
            return QryBuilder.ToString();
        }

        String BuildOrderByClause()
        {
            //This is the procedure that produces the order by statement.
            StringBuilder QryBuilder = new StringBuilder();
            int qbLength = 0;
            bool IsOrderBy = false;
            try
            {
                for (int rows = 0; rows < dataGridViewCols.Rows.Count - 1; rows++)
                {
                    //Select [TableName].[FieldName] as [ ],
                    //Do it at the end of Query Processing.
                    if (dataGridViewCols.Rows[rows].Cells[4].Value.ToString() != "No"
                        && dataGridViewCols.Rows[rows].Cells[4].Value.ToString().Length > 0)
                    {
                        if (!IsOrderBy)
                        {
                            //ORDER BY column_name ASC|DESC, column_name ASC|DESC;
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, " ORDER BY [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "] "));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, dataGridViewCols.Rows[rows].Cells[4].Value.ToString());
                            IsOrderBy = true;
                        }
                        else
                        {
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, ", [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "] "));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, dataGridViewCols.Rows[rows].Cells[4].Value.ToString());
                            IsOrderBy = true;
                        }
                    }
                }
            
            }
            catch (NullReferenceException)
            {
                //Stop NullReferenceException.
            }
            
            return QryBuilder.ToString();
        }

        String BuildWhereClause()
        {
            // A Procedure to Build Where Clause.
            StringBuilder QryBuilder = new StringBuilder();
            bool IsWhereBy = false;
            int qbLength = 0;
            try
            {
                for (int rows = 0; rows < dataGridViewCols.Rows.Count - 1; rows++)
                {
                    if (dataGridViewCols.Rows[rows].Cells[6].Value.ToString() != "No" &&
                         dataGridViewCols.Rows[rows].Cells[6].Value.ToString().Length >= 1)
                    {
                        if (!IsWhereBy)
                        {
                            //SELECT * FROM Customers
                            //WHERE Country='Mexico' and CustomerID = 3
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, " Where [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "]= "));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, dataGridViewCols.Rows[rows].Cells[6].Value.ToString());
                            IsWhereBy = true;
                        }
                        else
                        {
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, " AND [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "]= "));
                            qbLength = QryBuilder.Length;
                            QryBuilder.Insert(qbLength, dataGridViewCols.Rows[rows].Cells[6].Value.ToString());
                            IsWhereBy = true;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                //Stop NullReferenceException.
            }
            return QryBuilder.ToString();
        }
        String BuildGroupByClause()
        {
            //This Procedure can be used to build group by clause.
            StringBuilder QryBuilder = new StringBuilder();
            bool IsGroupBy = false;
            int qbLength = 0;
            try
            {
                for (int rows = 0; rows < dataGridViewCols.Rows.Count - 1; rows++)
                {
                    //Do it at the end of Query Processing.
                    if (dataGridViewCols.Rows[rows].Cells[5].Value != null &&
                        dataGridViewCols.Rows[rows].Cells[5].Value.ToString().Length > 0)
                    {
                        if (dataGridViewCols.Rows[rows].Cells[5].Value.ToString() == "Group By")
                        {
                            //Where [Conditions]
                            //GROUP BY Column1, Column2
                            //Order By col
                            if (!IsGroupBy)
                            {
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, " GROUP BY [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "] "));
                                IsGroupBy = true;
                            }
                            else
                            {
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, ", [" + (dataGridViewCols.Rows[rows].Cells[2].Value.ToString() + "]."));
                                qbLength = QryBuilder.Length;
                                QryBuilder.Insert(qbLength, "[" + (dataGridViewCols.Rows[rows].Cells[0].Value.ToString() + "] "));
                                IsGroupBy = true;
                            }
                        }
                     }
                }
            }
            catch (NullReferenceException)
            {
                //Stop NullReferenceException.
            }
            
            return QryBuilder.ToString();
        }
        String makeQuery()
        {
            //Builds Sql Statement.
            StringBuilder q = new StringBuilder();
                q.Append(this.BuildColumsString());
                q.Append(this.BuildFromClause());
                q.Append(this.BuildJoinClause());
                q.Append(this.BuildWhereClause());
                q.Append(this.BuildGroupByClause());
                q.Append(this.BuildOrderByClause());
            return q.ToString(); 
        }
        private void dataGridViewRelations_SelectionChanged(object sender, EventArgs e)
        {
            //String Builder Code
            this.txtboxSql.Text = this.makeQuery();            
        }

        private void dataGridViewCols_SelectionChanged(object sender, EventArgs e)
        {
            this.txtboxSql.Text = this.makeQuery();
        }

        private void CmdBtnVerifyQry_Click(object sender, EventArgs e)
        {
           //A Procedure to verify Sql Query.
            Cursor.Current = Cursors.WaitCursor;
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            int rowsAffected;
            String SQL;
            SQL = this.txtboxSql.Text.ToString();
            // Createing ADO.NET objects.
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    cmd.CommandText =  SQL ;
                    rowsAffected = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Query verified Successfully!", "UDW_BI: Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    con.Close();
                }
            } 
            //Restoring default cursor position.
            Cursor.Current = Cursors.Default;
        }

        private void CmdBtnSaveQry_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogSql.Filter = "sql files (*.sql)|*.sql|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialogSql.FilterIndex = 1;
                saveFileDialogSql.RestoreDirectory = true;
                saveFileDialogData.Title = "Save Query as";
                this.saveFileDialogSql.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } 
        }

        private void saveFileDialogSql_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string FileName = this.saveFileDialogSql.FileName;
                File.WriteAllText(FileName, this.txtboxSql.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);   
            }
        }

        private void CmdBtnGenerate_Click(object sender, EventArgs e)
        {
            //A Procedure to verify Sql Query.
            Cursor.Current = Cursors.WaitCursor;
            var connstring = ConfigurationManager.ConnectionStrings["UDW"].ConnectionString;
            String SQL;
            String header = string.Empty;
            int columnCount = 0;
            SQL = this.txtboxSql.Text.ToString();
            // Createing ADO.NET objects.
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    SqlDataReader reader;
                    cmd.CommandText = SQL;
                    reader = cmd.ExecuteReader();
                    //Now Extract reader data into Report File.
                    if (reader.HasRows)
                    {
                        //File Save DialogueBox.
                        saveFileDialogData.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        saveFileDialogData.FilterIndex = 1;
                        saveFileDialogData.RestoreDirectory = true;
                        saveFileDialogData.Title = "Save Report as";
                        DataTable dt = new DataTable();
                        //Load Table with data reader.
                        dt.Load(reader);
                        MessageBox.Show(dt.Rows.Count.ToString() + " Records Found!",
                            "UDW_BI: Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (saveFileDialogData.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter sw = File.CreateText(saveFileDialogData.FileName);
                            columnCount = dt.Columns.Count;
                            for (int i = 0; i < columnCount; i++)
                            {
                                //Gather Column Names of a Table.
                                //header += dt.Columns[i].ColumnName + "     |";
                                header += dt.Columns[i].ColumnName + ",";
                            }
                            sw.Write(header.Trim());  // Write header into report file.
                            sw.Write(sw.NewLine);
                            //Extracts Report detailed data into Report file.
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    sw.Write(row[column].ToString().Trim() + ",");
                                }
                                sw.Write(sw.NewLine);
                            }
                            MessageBox.Show("Report Saved Successfully!", "UDW_BI: Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dt.Dispose();
                            reader.Close();
                            cmd.Dispose();
                            sw.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    con.Close();
                }
            }
            //Restoring default cursor position.
            Cursor.Current = Cursors.Default;   
        }

        private void dataGridViewCols_DataError(object sender, DataGridViewDataErrorEventArgs error)
        {
            //Code to Suppress Data Entry Errors in DataGridViewCols Control.
            error.Cancel = true;
        }

        private void dataGridViewRelations_DataError(object sender, DataGridViewDataErrorEventArgs error)
        {
            //Code to Suppress Data Entry Errors in DataGridViewCols Control.
                error.Cancel = true;
        }
    }
}
