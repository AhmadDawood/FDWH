using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDW_BI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //fQryBuilder f = new fQryBuilder();
            //Application.Run(f);
            loginForm flogin = new loginForm();
            try
            {
                if (flogin.ShowDialog() == DialogResult.OK)
                {
                    switch (loginForm.usertype.ToString())
                    {
                        case "Executive":
                            // load Interface for Executive user
                            mainForm fmain = new mainForm();
                            Application.Run(fmain);
                            flogin.Close();
                            break;
                        case "Admin":
                            //load Interface for Admin user.
                            adminForm fadmin = new adminForm();
                            Application.Run(fadmin);
                            flogin.Close();
                            break;
                        default:
                            MessageBox.Show("A Fatal Exception has Occured in the Application, Exiting... " , 
                                "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Application.Exit();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("A Fatal Exception has Occured in the UDW_BI Application. Exiting... " +
                    e.Message, "UDW_BI: Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
             
    }
}
