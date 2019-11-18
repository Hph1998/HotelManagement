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
    public partial class HotelSystem : Form
    {
        RoomDB RoomDB = new RoomDB();
        KeepDB KeepDB = new KeepDB();
        int onedayall = 0;
        public HotelSystem()
        {
            InitializeComponent();
            initbtn();
            initdayall();
        }

        public void initdayall()
        {
            String outdate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlDataReader temdr = KeepDB.getdayall(outdate);
            while (temdr.Read())
            {
                onedayall = onedayall + int.Parse(temdr["allrent"].ToString().Trim());
            }
            temdr.Close();
            dayall.Text = onedayall.ToString();
        }

        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                tabPage1.Controls.Clear();
                initbtn();
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                tabPage2.Controls.Clear();
                initbtn();
            }
            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                tabPage3.Controls.Clear();
                initbtn();
            }
            if (tabControl1.SelectedTab.Name == "tabPage4")
            {
                tabPage4.Controls.Clear();
                initbtn();
            }
            if (tabControl1.SelectedTab.Name == "tabPage5")
            {
                tabPage5.Controls.Clear();
                initbtn();
            }
            if (tabControl1.SelectedTab.Name == "tabPage6")
            {
                tabPage6.Controls.Clear();
                initbtn();
            }

        }

        public void initbtn()
        {
            SqlDataReader temdr = RoomDB.select();
            int i = 1;
            int n = 1;
            while (temdr.Read())
            {
                int x = n % 3;
                int y = 0;
                if (x == 1)
                {
                    y = 0;
                }
                if (x == 2)
                {
                    y = 200;
                }
                if (x == 0)
                {
                    y = 400;
                }
                Point p = new Point(y, ((int)Math.Floor(Convert.ToDouble((n - 1) / 3)) * 200));//定义一个具体的位置  
                Button btn = new Button();
                btn.Name = "btn" + i.ToString();
                btn.Width = 190;
                btn.Height = 190;
                btn.Tag = temdr["roomnumber"].ToString().Trim();
                btn.Text = "房号：" + temdr["roomnumber"].ToString().Trim() + "\n" + "面积：" + temdr["area"].ToString().Trim() + "\n" + "类型：" + temdr["type"].ToString().Trim() + "\n" + "租金：" + temdr["rent"].ToString().Trim();
                if (temdr["lease"].ToString().Trim() == "false")
                {
                    btn.BackColor = Color.Green;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
                btn.Location = p;
                tabPage1.Controls.Add(btn);//向具体的控件中添加button
                btn.Click += new EventHandler(btn_click);
                i++;
                n++;
            }
            temdr.Close();
            temdr = RoomDB.select();
            n = 1;
            while (temdr.Read())
            {
                if (temdr["type"].ToString().Trim().Equals("单人间"))
                {
                    int x = n % 3;
                    int y = 0;
                    if (x == 1)
                    {
                        y = 0;
                    }
                    if (x == 2)
                    {
                        y = 200;
                    }
                    if (x == 0)
                    {
                        y = 400;
                    }
                    Point p = new Point(y, ((int)Math.Floor(Convert.ToDouble((n - 1) / 3)) * 200));//定义一个具体的位置  
                    Button btn = new Button();//实例化一个button  
                    btn.Name = "btn" + i.ToString();
                    btn.Width = 190;
                    btn.Height = 190;
                    btn.Tag = temdr["roomnumber"].ToString().Trim();
                    btn.Text = "房号：" + temdr["roomnumber"].ToString().Trim() + "\n" + "面积：" + temdr["area"].ToString().Trim() + "\n" + "类型：" + temdr["type"].ToString().Trim() + "\n" + "租金：" + temdr["rent"].ToString().Trim();
                    if (temdr["lease"].ToString().Trim() == "false")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                    }
                    btn.Location = p;
                    tabPage2.Controls.Add(btn);//向具体的控件中添加button  
                    btn.Click += new EventHandler(btn_click);
                    i++;
                    n++;
                }
            }
            temdr.Close();
            temdr = RoomDB.select();
            n = 1;
            while (temdr.Read())
            {
                if (temdr["type"].ToString().Trim().Equals("标准间"))
                {
                    int x = n % 3;
                    int y = 0;
                    if (x == 1)
                    {
                        y = 0;
                    }
                    if (x == 2)
                    {
                        y = 200;
                    }
                    if (x == 0)
                    {
                        y = 400;
                    }
                    Point p = new Point(y, ((int)Math.Floor(Convert.ToDouble((n - 1) / 3)) * 200));//定义一个具体的位置  
                    Button btn = new Button();//实例化一个button  
                    btn.Name = "btn" + i.ToString();
                    btn.Width = 190;
                    btn.Height = 190;
                    btn.Tag = temdr["roomnumber"].ToString().Trim();
                    btn.Text = "房号：" + temdr["roomnumber"].ToString().Trim() + "\n" + "面积：" + temdr["area"].ToString().Trim() + "\n" + "类型：" + temdr["type"].ToString().Trim() + "\n" + "租金：" + temdr["rent"].ToString().Trim();
                    if (temdr["lease"].ToString().Trim() == "false")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                    }
                    btn.Location = p;
                    tabPage3.Controls.Add(btn);//向具体的控件中添加button 
                    btn.Click += new EventHandler(btn_click);
                    i++;
                    n++;
                }
            }
            temdr.Close();
            temdr = RoomDB.select();
            n = 1;
            while (temdr.Read())
            {
                if (temdr["type"].ToString().Trim().Equals("高级标间"))
                {
                    int x = n % 3;
                    int y = 0;
                    if (x == 1)
                    {
                        y = 0;
                    }
                    if (x == 2)
                    {
                        y = 200;
                    }
                    if (x == 0)
                    {
                        y = 400;
                    }
                    Point p = new Point(y, ((int)Math.Floor(Convert.ToDouble((n - 1) / 3)) * 200));//定义一个具体的位置  
                    Button btn = new Button();//实例化一个button  
                    btn.Name = "btn" + i.ToString();
                    btn.Width = 190;
                    btn.Height = 190;
                    btn.Tag = temdr["roomnumber"].ToString().Trim();
                    btn.Text = "房号：" + temdr["roomnumber"].ToString().Trim() + "\n" + "面积：" + temdr["area"].ToString().Trim() + "\n" + "类型：" + temdr["type"].ToString().Trim() + "\n" + "租金：" + temdr["rent"].ToString().Trim();
                    if (temdr["lease"].ToString().Trim() == "false")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                    }
                    btn.Location = p;
                    tabPage4.Controls.Add(btn);//向具体的控件中添加button  
                    btn.Click += new EventHandler(btn_click);
                    i++;
                    n++;
                }
            }
            temdr.Close();
            temdr = RoomDB.select();
            n = 1;
            while (temdr.Read())
            {
                if (temdr["type"].ToString().Trim().Equals("三人间"))
                {
                    int x = n % 3;
                    int y = 0;
                    if (x == 1)
                    {
                        y = 0;
                    }
                    if (x == 2)
                    {
                        y = 200;
                    }
                    if (x == 0)
                    {
                        y = 400;
                    }
                    Point p = new Point(y, ((int)Math.Floor(Convert.ToDouble((n - 1) / 3)) * 200));//定义一个具体的位置  
                    Button btn = new Button();//实例化一个button  
                    btn.Name = "btn" + i.ToString();
                    btn.Width = 190;
                    btn.Height = 190;
                    btn.Tag = temdr["roomnumber"].ToString().Trim();
                    btn.Text = "房号：" + temdr["roomnumber"].ToString().Trim() + "\n" + "面积：" + temdr["area"].ToString().Trim() + "\n" + "类型：" + temdr["type"].ToString().Trim() + "\n" + "租金：" + temdr["rent"].ToString().Trim();
                    if (temdr["lease"].ToString().Trim() == "false")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                    }
                    btn.Location = p;
                    tabPage5.Controls.Add(btn);//向具体的控件中添加button
                    btn.Click += new EventHandler(btn_click);
                    i++;
                    n++;
                }
            }
            temdr.Close();
            temdr = RoomDB.select();
            n = 1;
            while (temdr.Read())
            {
                if (temdr["type"].ToString().Trim().Equals("豪华套房"))
                {
                    int x = n % 3;
                    int y = 0;
                    if (x == 1)
                    {
                        y = 0;
                    }
                    if (x == 2)
                    {
                        y = 200;
                    }
                    if (x == 0)
                    {
                        y = 400;
                    }
                    Point p = new Point(y, ((int)Math.Floor(Convert.ToDouble((n - 1) / 3)) * 200));//定义一个具体的位置  
                    Button btn = new Button();//实例化一个button  
                    btn.Name = "btn" + i.ToString();
                    btn.Width = 190;
                    btn.Height = 190;
                    btn.Tag = temdr["roomnumber"].ToString().Trim();
                    btn.Text = "房号：" + temdr["roomnumber"].ToString().Trim() + "\n" + "面积：" + temdr["area"].ToString().Trim() + "\n" + "类型：" + temdr["type"].ToString().Trim() + "\n" + "租金：" + temdr["rent"].ToString().Trim();
                    if (temdr["lease"].ToString().Trim() == "false")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                    }
                    btn.Location = p;
                    tabPage6.Controls.Add(btn);//向具体的控件中添加button 
                    btn.Click += new EventHandler(btn_click);
                    i++;
                    n++;
                }
            }
            temdr.Close();
            RoomDB.conn_close();
        }
        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int i = Lease(btn.Tag.ToString());
            PassengerMessage message = new PassengerMessage();
            message.Rn = btn.Tag.ToString();
            message.SetValue();
            message.ShowDialog();
            if (message.DialogResult == DialogResult.OK)
            {
                btn.BackColor = Color.Red;
            }
            if (message.DialogResult == DialogResult.Abort)
            {
                onedayall = 0;
                initdayall();
                btn.BackColor = Color.Green;
            }

        }

        public int Lease(String rn)
        {
            SqlDataReader temdr = RoomDB.select();
            while (temdr.Read())
            {
                if (rn.Equals(temdr["roomnumber"].ToString().Trim()))
                {
                    if (temdr["lease"].ToString().Trim().Equals("true"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        private void select_Click(object sender, EventArgs e)
        {
            Select select = new Select();
            select.ShowDialog();
        }
    }
}
