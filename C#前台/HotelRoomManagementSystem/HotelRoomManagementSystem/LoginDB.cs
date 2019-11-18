using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagementSystem
{
    class LoginDB
    {
        public static SqlConnection My_Conn;
        public static string openConnstr = "server=HPH;Database=Hotel;uid=hph1998;pwd=hph1998";

        public static SqlConnection getcon()
        {
            My_Conn = new SqlConnection(openConnstr);
            My_Conn.Open();
            return My_Conn;
        }

        public void conn_close()
        {
            if (My_Conn.State == ConnectionState.Open)
            {
                My_Conn.Close();
                My_Conn.Dispose();
            }
        }

        public SqlDataReader getsdr(string sqlstr)
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = sqlstr;
            SqlDataReader My_Reader = My_com.ExecuteReader();
            return My_Reader;
        }
    }
}
