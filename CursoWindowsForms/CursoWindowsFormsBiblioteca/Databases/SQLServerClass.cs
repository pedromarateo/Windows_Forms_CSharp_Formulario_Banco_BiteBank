using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class SQLServerClass
    {
        public string stringConn;
        public SqlConnection connDB;


        public SQLServerClass()
        {
            try
            {
                stringConn = "Data Source=DESKTOP-1POK67O;Initial Catalog=ByteBank;Persist Security Info=True;User ID=sa;Password=123";
                connDB = new SqlConnection(stringConn);
                connDB.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommnad = new SqlCommand(SQL, connDB);
                myCommnad.CommandTimeout = 0;
                var myReader = myCommnad.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string SQLCommand(string SQL)
        {
            try
            {
                var myCommnad = new SqlCommand(SQL, connDB);
                myCommnad.CommandTimeout = 0;
                var myReader = myCommnad.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Close()
        {
            connDB.Close();
        }

    }
}
