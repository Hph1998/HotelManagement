using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelRoomManagementSystem
{
    public partial class Login : Form
    {
        LoginDB loginDB = new LoginDB();
        public Login()
        {
            InitializeComponent();
        }

        private void denglu_Click(object sender, EventArgs e)
        {
            if (username.Text != "" & password.Text != "")
            {
                SqlDataReader temdr = loginDB.getsdr("select * from Hoteluser where username='" + username.Text.Trim() + "' and password='" + password.Text.Trim() + "'");
                bool ifcom = temdr.Read();
                if (ifcom)
                {
                    HotelSystem frmMain = new HotelSystem();
                    this.Hide();
                    frmMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                    username.Text = "";
                    password.Text = "";
                }
                loginDB.conn_close();
            }
            else
            {
                MessageBox.Show("请填写用户名和密码！");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
