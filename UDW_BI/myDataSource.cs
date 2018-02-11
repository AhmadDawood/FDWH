using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UDW_BI
{
    class myDataSource
    {


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

                MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:myDataSource.cs_myNonSelectcmd() Module. Exiting... " +
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
                MessageBox.Show("A Fatal Exception has Occured in the UDW_BI:myDataSource.cs_myNonSelectcmd() Module. Exiting... " +
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

