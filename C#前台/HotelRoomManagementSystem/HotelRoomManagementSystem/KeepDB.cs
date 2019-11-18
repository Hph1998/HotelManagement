using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagementSystem
{
    class KeepDB
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
            My_com.CommandText = "select * from Keepmessage";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader getrn(String roomno)
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select * from Keepmessage where roomnumber = '"+roomno+"'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader getidentify(String id)
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select * from Keepmessage where id = '" + id + "'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader getnow()
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select * from Keepmessage where outdate is null";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader getallmoney()
        {
            String str = "false";
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select allrent from Keepmessage where together = '"+str+"'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader getdayall(String outdate)
        {
            String str = "false";
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select allrent from Keepmessage where outdate = '"+outdate+"' and together = '"+str+"'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public SqlDataReader getindate(String randno)
        {
            getcon();
            SqlCommand My_com = My_Conn.CreateCommand();
            My_com.CommandText = "select indate from Keepmessage where randno='"+randno+"'";
            SqlDataReader reader = My_com.ExecuteReader();
            return reader;
        }

        public void Insert(String rn, String name, String id, String sex, String age, String phone,String indate,String intime,int no,String to)
        {
            getcon();
            String sql = "insert into Keepmessage(roomnumber,name,id,sex,age,phone,indate,intime,randno,together) values ('" + rn + "','" + name + "','" + id + "','" + sex + "','" + age + "','" + phone + "','" + indate + "','" + intime + "','" + no + "','" + to + "')";
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

        public void Modify(String randno, String outdate, String outtime, String allrent)
        {
            getcon();
            String sql = "Update Keepmessage set outdate='" + outdate + "',outtime='" + outtime + "',allrent='" + allrent + "' Where randno = '" + randno + "'";
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
        public void ModifyP(String rn, String name, String id, String sex, String age, String phone, int no)
        {
            getcon();
            String sql = "Update Keepmessage set roomnumber='" + rn + "',name='" + name + "',id='" + id + "',sex='" + sex + "',age='" + age + "',phone='" + phone + "'where randno='" + no + "'";
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
