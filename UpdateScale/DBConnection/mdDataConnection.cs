using Alamer_Reporting2.Utils;
using Jardtest2.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alamer_Reporting2.DBConnection
{
    class mdDataConnection
    {

        public static SqlConnection GlobalConnection = (SqlConnection)null;
        public static SqlConnection POSConnection = (SqlConnection)null;
        public static DataTable LoclizeTable = (DataTable)null;
        public static SqlConnection OnlineConnection = (SqlConnection)null;

        public static OleDbConnection GetAccessCon(string strFileName)
        {
            OleDbConnection oleDbConnection1;
            try
            {
                if (strFileName.Length == 0)
                    oleDbConnection1 = (OleDbConnection)null;
                else if (!File.Exists(strFileName))
                {
                    oleDbConnection1 = (OleDbConnection)null;
                }
                else
                {
                    string str = "Provider=Microsoft.Jet.OLEDB.4.0;MultipleActiveResultSets = True; Data Source=" + strFileName;
                    OleDbConnection oleDbConnection2 = new OleDbConnection();
                    oleDbConnection2.ConnectionString = str;
                    oleDbConnection2.Open();
                    oleDbConnection1 = oleDbConnection2;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                oleDbConnection1 = (OleDbConnection)null;
                ProjectData.ClearProjectError();
            }
            return oleDbConnection1;
        }

        public static OleDbConnection GetAccessCon(string strFileName, string Password)
        {
            OleDbConnection oleDbConnection1;
            try
            {
                if (strFileName.Length == 0)
                    oleDbConnection1 = (OleDbConnection)null;
                else if (!File.Exists(strFileName))
                {
                    oleDbConnection1 = (OleDbConnection)null;
                }
                else
                {
                    string str = "Provider=Microsoft.Jet.OLEDB.4.0;MultipleActiveResultSets = True;Data Source=" + strFileName + ";Jet OLEDB:Database Password=" + Password + ";";
                    OleDbConnection oleDbConnection2 = new OleDbConnection();
                    oleDbConnection2.ConnectionString = str;
                    oleDbConnection2.Open();
                    oleDbConnection1 = oleDbConnection2;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                oleDbConnection1 = (OleDbConnection)null;
                ProjectData.ClearProjectError();
            }
            return oleDbConnection1;
        }

        public static SqlConnection ConnectSqlServer(string StrConnectionString)
        {
            SqlConnection sqlConnection1 = (SqlConnection)null;
            SqlConnection sqlConnection2;
            try
            {
                sqlConnection1 = new SqlConnection(StrConnectionString);
                sqlConnection1.Open();
                sqlConnection2 = sqlConnection1;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                sqlConnection2 = sqlConnection1;
                ProjectData.ClearProjectError();
            }
            return sqlConnection2;
        }

        public static SqlConnection GetSqlConnection(string dbName)
        {
            SqlConnection sqlConnection1 = (SqlConnection)null;
            SqlConnection sqlConnection2;
            try
            {
                sqlConnection1 = new SqlConnection("(Local);Initial Catalog=" + dbName + ";Integrated Security=True");
                sqlConnection1.Open();
                sqlConnection2 = sqlConnection1;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                sqlConnection2 = sqlConnection1;
                ProjectData.ClearProjectError();
            }
            return sqlConnection2;
        }

        public static SqlConnection GetSqlConnection(string ServerName, string DbName)
        {
            SqlConnection sqlConnection1 = (SqlConnection)null;
            SqlConnection sqlConnection2;
            try
            {
                sqlConnection1 = new SqlConnection("Data Source=" + ServerName + ";MultipleActiveResultSets = True;Initial Catalog=" + DbName + ";Integrated Security=True");
                sqlConnection1.Open();
                sqlConnection2 = sqlConnection1;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                sqlConnection2 = sqlConnection1;
                ProjectData.ClearProjectError();
            }
            return sqlConnection2;
        }

        public static SqlConnection GetSqlConnection(
          string ServerName,
          string DbName,
          string USrID,
          string Pass)
        {
            SqlConnection sqlConnection1 = (SqlConnection)null;
            SqlConnection sqlConnection2;
            try
            {
                sqlConnection1 = new SqlConnection("Data Source=" + ServerName + ";MultipleActiveResultSets = True;Initial Catalog=" + DbName + ";Persist Security Info=True;User ID=" + USrID + ";Password=" + Pass);
                sqlConnection1.Open();
                sqlConnection2 = sqlConnection1;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                sqlConnection2 = sqlConnection1;
                ProjectData.ClearProjectError();
            }
            return sqlConnection2;
        }

        public static OleDbConnection ConnectTextFile(string FileName)
        {
            OleDbConnection oleDbConnection1;
            try
            {
                if (string.IsNullOrEmpty(FileName))
                    oleDbConnection1 = (OleDbConnection)null;
                else if (!File.Exists(FileName))
                {
                    oleDbConnection1 = (OleDbConnection)null;
                }
                else
                {
                    string str = "Provider=Microsoft.Jet.OLEDB.4.0;MultipleActiveResultSets = True;Data Source=" + FileName;
                    OleDbConnection oleDbConnection2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;MultipleActiveResultSets = True;Data Source=" + FileName + ";Extended Properties=text;HDR=Yes;FMT=Delimited");
                    oleDbConnection2.Open();
                    oleDbConnection1 = oleDbConnection2;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)MessageBox.Show  (ex.Message.ToString());
                oleDbConnection1 = (OleDbConnection)null;
                ProjectData.ClearProjectError();
            }
            return oleDbConnection1;
        }

        public static SqlConnection GetPOSDataConnection()
        {
            SqlConnection sqlConnection;
            try
            {
                sqlConnection = mdDataConnection.GetSqlConnection(AmerSettings.Default.POSDataServerName, AmerSettings.Default.POSDataName, AmerSettings.Default.POSDataUserName, AmerSettings.Default.POSDataPassword);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                sqlConnection = (SqlConnection)null;
                ProjectData.ClearProjectError();
            }
            return sqlConnection;
        }

  


  


        public static DataTable GetTableFromSql(string SqlData, string TblName = "NewTable")
        {
            DataTable dataTable1;
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(SqlData, mdDataConnection.GlobalConnection));
                string tableName = TblName;
                if (string.IsNullOrEmpty(tableName))
                    tableName = "NewTable";
                DataTable dataTable2 = new DataTable(tableName);
                sqlDataAdapter.Fill(dataTable2);
                dataTable1 = dataTable2;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                dataTable1 = (DataTable)null;
                ProjectData.ClearProjectError();
            }
            return dataTable1;
        }

        public static DataTable GetOnlineTableFromSql(string SqlData, string TblName = "NewTable")
        {
            DataTable dataTable1;
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(SqlData, mdDataConnection.OnlineConnection));
                string tableName = TblName;
                if (string.IsNullOrEmpty(tableName))
                    tableName = "NewTable";
                DataTable dataTable2 = new DataTable(tableName);
                sqlDataAdapter.Fill(dataTable2);
                dataTable1 = dataTable2;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                dataTable1 = (DataTable)null;
                ProjectData.ClearProjectError();
            }
            return dataTable1;
        }

        public static DataRow GetItemDataByBarCode(string PrData)
        {
            DataRow dataRow;
            try
            {
                SqlCommand selectCommand = new SqlCommand("GetItemsFromBarCode", mdDataConnection.GlobalConnection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("ItemBarCode", (object)PrData);
                DataTable dataTable = new DataTable("ItemsData");
                new SqlDataAdapter(selectCommand).Fill(dataTable);
                dataRow = dataTable.Rows.Count <= 0 ? (DataRow)null : dataTable.Rows[0];
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                dataRow = (DataRow)null;
                ProjectData.ClearProjectError();
            }
            return dataRow;
        }
    }

}
