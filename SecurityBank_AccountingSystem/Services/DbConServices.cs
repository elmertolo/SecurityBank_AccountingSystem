using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using SecurityBank_AccountingSystem.Models;
using System.Configuration;


namespace SecurityBank_AccountingSystem.Services
{
    class DbConServices
    {
        public static MySqlConnection myConnect;
        public string databaseName = "";
        string Sql = "";
        MySqlCommand cmd;
        MySqlDataReader mySqlData;

       
          //  static MySqlConnection databaseConnection = null;
            //public  MySqlConnection getDBConnection(MySqlConnection _dbcon)
            //{
            //    if (_dbcon == null)
            //    {
            //        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //        _dbcon = new MySqlConnection(connectionString);
            //      //  _dbcon.Open();
            //    }
            //    return _dbcon;
            //}
        

        public void DBConnect()
        {
            try
            {
                string DBConnection = "";

                //   if (frmLogIn.userName == "elmer")
                //  {
                DBConnection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;  
          
                //   }
                //else
                //{
                //    //  DBConnection = "";
                //  DBConnection = "datasource=192.168.0.254;port=3306;username=root;password=CorpCaptive; convert zero datetime=True;";
                // MessageBox.Show("HELLO");
                //  databaseName = "captive_accounting";
                //    // MessageBox.Show(databaseName);

                //}


                myConnect = new MySqlConnection(DBConnection);

                myConnect.Open();

            }
            catch (Exception Error)
            {

                MessageBox.Show(Error.Message, "System Error");
            }
        }// end of function

        public void DBClosed()
        {
            myConnect.Close();
        }
        // end of function
        public List<SalesInvoiceModel> GetAllData(List<SalesInvoiceModel> _SI)
        {
            Sql = "SELECT Batch, Batch2,ChkType, COUNT(ChkType), DeliveryDate FROM Master_Database_SBTC WHERE  SalesInvoice IS NULL " +
                "AND UnitPrice IS NULL GROUP BY Batch, Batch2, ChkType, DeliveryDate ORDER BY Batch2, DeliveryDate DESC, Batch DESC";
            //DBConnect();
            //getDBConnection(myConnect);
            //myConnect.Open();
            DBConnect();
            cmd = new MySqlCommand(Sql, myConnect);
            mySqlData = cmd.ExecuteReader();

            while(mySqlData.Read())
            {
                SalesInvoiceModel sales = new SalesInvoiceModel();
                sales.Batch = !mySqlData.IsDBNull(0) ? mySqlData.GetString(0): "";
                sales.ChequeName = !mySqlData.IsDBNull(1) ? mySqlData.GetString(1) : "";
                sales.ChkType = !mySqlData.IsDBNull(2) ? mySqlData.GetString(2) : "";
                sales.Quantity = !mySqlData.IsDBNull(3) ? mySqlData.GetInt16(3) : 0;
                sales.DeliveryDate = !mySqlData.IsDBNull(4) ? mySqlData.GetDateTime(4) : DateTime.Now;

                _SI.Add(sales);
            }
            DBClosed();
            return _SI;
        }

    }
}
