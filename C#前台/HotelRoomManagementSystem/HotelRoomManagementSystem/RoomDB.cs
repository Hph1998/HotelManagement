using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagementSystem
{
    class RoomDB
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

        public SqlDataReader select()
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select * from Guestroom";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader Deposit(String rn)
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select rent,lease from Guestroom where roomnumber='" + rn + "'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public void Modify(String YN,String rn)
        {
            getcon();
            String sql = "Update Guestroom set lease='" + YN + "' where roomnumber ='"+rn+"'";
            SqlCommand MyCommand = new SqlCommand(sql, My_Conn);
            try//异常处理
            {
                MyCommand.ExecuteNonQuery();
                My_Conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

    }
}
