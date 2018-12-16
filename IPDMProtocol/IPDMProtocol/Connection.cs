using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace IPDMProtocol
{
    public class Connection
    {
        public static OleDbConnection GetConnection()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\New folder\IPDM.accdb'";
            try
            {
                conn.Open();
            }
            catch(OleDbException ex)
            {
                MessageBox.Show("Connection Failded! " + ex.Message);
            }            
            if(conn.State == ConnectionState.Open)
            {
                return conn;
            }
            else
            {
                return null;
            }
        }
    }
}