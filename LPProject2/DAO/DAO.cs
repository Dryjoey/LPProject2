using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public abstract class DAO
    {
        public SqlConnection con;
        public DAO()
        {
            this.con = new SqlConnection("Server = mssql.fhict.local; Uid = dbi382997; Database = dbi382997; Pwd =Woody125;");
        }
       
    }
}
