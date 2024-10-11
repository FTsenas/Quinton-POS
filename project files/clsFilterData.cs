using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace QuintonPOS
{
    class clsFilterData
    {
        //DATABASE VARIABLES...
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;

      public  static string supID = "";

           public void getData( DataGridView searchRst,String query,String tableName)
        {

            try
            {

                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();
                    cmd = new OleDbCommand(query + tableName, con);

                    ds = new DataSet();
                    adp = new OleDbDataAdapter(cmd);
                    adp.Fill(ds, tableName);


                    searchRst.DataSource = ds.Tables[0].DefaultView;


                    con.Close();
                

            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


           public void searchData(DataGridView searchRst, String query, String inputString, String tableName)
        {

            try
            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();
                    cmd = new OleDbCommand(query + inputString + "%' ", con);

                    ds = new DataSet();
                    adp = new OleDbDataAdapter(cmd);
                    adp.Fill(ds, tableName);


                    searchRst.DataSource = ds.Tables[0].DefaultView;


                    con.Close();
                }
                catch (OleDbException ex)
                {
                    
                MessageBox.Show("Character not supported!");
             

                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
