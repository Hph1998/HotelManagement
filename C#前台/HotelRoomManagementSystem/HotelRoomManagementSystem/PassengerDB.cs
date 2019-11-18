using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagementSystem
{
    class PassengerDB
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

        public SqlDataReader getrandno(String rn)
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select randno from Passenger where roomnumber='" + rn + "'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader select()
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select * from Passenger";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public void Insert(String rn,String name,String id,String sex,String age,String phone,int no,String deposit)
        {
            getcon();
            String sql = "insert into Passenger(roomnumber,name,id,sex,age,phone,randno,deposit) values ('"+rn+ "','" + name + "','" + id + "','" + sex + "','" + age + "','" + phone + "','" + no + "','" + deposit + "')";
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

        public void Modify(String rn, String name, String id, String sex, String age, String phone,int no)
        {
            getcon();
            String sql = "Update Passenger set roomnumber='" + rn + "',name='" + name + "',id='" + id + "',sex='" + sex + "',age='" + age + "',phone='" + phone + "'where randno='" + no + "'";
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

        public void delete(String rn)
        {
            getcon();
            String sql = "Delete Passenger where roomnumber='" + rn + "'";
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
