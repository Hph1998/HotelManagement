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
    public partial class Select : Form
    {
        KeepDB KeepDB = new KeepDB();
        RoomDB RoomDB = new RoomDB();
        public Select()
        {
            InitializeComponent();
            allListViewP();
            allListViewR();
        }
        public ListView allListViewP()
        {
            listViewP.Items.Clear();
            SqlDataReader temdr = KeepDB.select();
            while (temdr.Read())
            {
                string room = temdr["roomnumber"].ToString().Trim();
                string name = temdr["name"].ToString().Trim();
                string id = temdr["id"].ToString().Trim();
                string sex = temdr["sex"].ToString().Trim();
                string age = temdr["age"].ToString().Trim();
                string phone = temdr["phone"].ToString().Trim();
                string indata = temdr["indate"].ToString().Trim()+" "+ temdr["intime"].ToString().Trim();
                string outdata = temdr["outdate"].ToString().Trim() + " " + temdr["outtime"].ToString().Trim();
                string allrent = temdr["allrent"].ToString().Trim();
                string together = temdr["together"].ToString().Trim();
                if (together == "true")
                {
                    together = "否";
                }
                else
                {
                    together = "是";
                }
                //创建行对象
                ListViewItem li = new ListViewItem(room);
                //添加同一行的数据
                li.SubItems.Add(name);
                li.SubItems.Add(id);
                li.SubItems.Add(sex);
                li.SubItems.Add(age);
                li.SubItems.Add(phone);
                li.SubItems.Add(indata);
                li.SubItems.Add(outdata);
                li.SubItems.Add(allrent);
                li.SubItems.Add(together);
                //将行对象绑定在listview对象中
                listViewP.Items.Add(li);
            }
            temdr.Close();
            return listViewP;
        }
        public ListView allListViewR()
        {
            SqlDataReader temdr = RoomDB.select();
            while (temdr.Read())
            {
                string room = temdr["roomnumber"].ToString().Trim();
                string area = temdr["area"].ToString().Trim();
                string type = temdr["type"].ToString().Trim();
                string rent = temdr["rent"].ToString().Trim();
                string lease = temdr["lease"].ToString().Trim();

                //创建行对象
                ListViewItem li = new ListViewItem(room);
                //添加同一行的数据
                li.SubItems.Add(area);
                li.SubItems.Add(type);
                li.SubItems.Add(rent);
                li.SubItems.Add(lease);
                //将行对象绑定在listview对象中
                listViewR.Items.Add(li);
            }
            temdr.Close();
            return listViewR;
        }

        private void allmoney_Click(object sender, EventArgs e)
        {
            SqlDataReader temdr = KeepDB.getallmoney();
            int allmoney = 0;
            while (temdr.Read())
            {
                if (temdr["allrent"].ToString().Trim() != "")
                {
                    allmoney = allmoney + int.Parse(temdr["allrent"].ToString().Trim());
                }
            }
            temdr.Close();
            MessageBox.Show("总营业额为：" + allmoney.ToString() + "元");
        }

        private void rn_Click(object sender, EventArgs e)
        {
            if (content.Text != "")
            {
                getroomno(content.Text);
            }
            else
            {
                MessageBox.Show("请先输入查询条件！");
            }
        }
        public ListView getroomno(String roomno)
        {
            listViewP.Items.Clear();
            SqlDataReader temdr = KeepDB.getrn(roomno);
            while (temdr.Read())
            {
                string room = temdr["roomnumber"].ToString().Trim();
                string name = temdr["name"].ToString().Trim();
                string id = temdr["id"].ToString().Trim();
                string sex = temdr["sex"].ToString().Trim();
                string age = temdr["age"].ToString().Trim();
                string phone = temdr["phone"].ToString().Trim();
                string indata = temdr["indate"].ToString().Trim() + " " + temdr["intime"].ToString().Trim();
                string outdata = temdr["outdate"].ToString().Trim() + " " + temdr["outtime"].ToString().Trim();
                string allrent = temdr["allrent"].ToString().Trim();
                string together = temdr["together"].ToString().Trim();
                if (together == "true")
                {
                    together = "否";
                }
                else
                {
                    together = "是";
                }
                //创建行对象
                ListViewItem li = new ListViewItem(room);
                //添加同一行的数据
                li.SubItems.Add(name);
                li.SubItems.Add(id);
                li.SubItems.Add(sex);
                li.SubItems.Add(age);
                li.SubItems.Add(phone);
                li.SubItems.Add(indata);
                li.SubItems.Add(outdata);
                li.SubItems.Add(allrent);
                li.SubItems.Add(together);
                //将行对象绑定在listview对象中
                listViewP.Items.Add(li);
            }
            temdr.Close();
            return listViewP;
        }

        private void allguest_Click(object sender, EventArgs e)
        {
            allListViewP();
        }

        private void identity_Click(object sender, EventArgs e)
        {
            if (content.Text != "")
            {
                getid(content.Text);
            }
            else
            {
                MessageBox.Show("请先输入查询条件！");
            }
        }

        public ListView getid(String identify)
        {
            listViewP.Items.Clear();
            SqlDataReader temdr = KeepDB.getidentify(identify);
            while (temdr.Read())
            {
                string room = temdr["roomnumber"].ToString().Trim();
                string name = temdr["name"].ToString().Trim();
                string id = temdr["id"].ToString().Trim();
                string sex = temdr["sex"].ToString().Trim();
                string age = temdr["age"].ToString().Trim();
                string phone = temdr["phone"].ToString().Trim();
                string indata = temdr["indate"].ToString().Trim() + " " + temdr["intime"].ToString().Trim();
                string outdata = temdr["outdate"].ToString().Trim() + " " + temdr["outtime"].ToString().Trim();
                string allrent = temdr["allrent"].ToString().Trim();
                string together = temdr["together"].ToString().Trim();
                if (together == "true")
                {
                    together = "否";
                }
                else
                {
                    together = "是";
                }
                //创建行对象
                ListViewItem li = new ListViewItem(room);
                //添加同一行的数据
                li.SubItems.Add(name);
                li.SubItems.Add(id);
                li.SubItems.Add(sex);
                li.SubItems.Add(age);
                li.SubItems.Add(phone);
                li.SubItems.Add(indata);
                li.SubItems.Add(outdata);
                li.SubItems.Add(allrent);
                li.SubItems.Add(together);
                //将行对象绑定在listview对象中
                listViewP.Items.Add(li);
            }
            temdr.Close();
            return listViewP;
        }

        private void nowguest_Click(object sender, EventArgs e)
        {
            getnowall();
        }

        public ListView getnowall()
        {
            listViewP.Items.Clear();
            SqlDataReader temdr = KeepDB.getnow();
            while (temdr.Read())
            {
                string room = temdr["roomnumber"].ToString().Trim();
                string name = temdr["name"].ToString().Trim();
                string id = temdr["id"].ToString().Trim();
                string sex = temdr["sex"].ToString().Trim();
                string age = temdr["age"].ToString().Trim();
                string phone = temdr["phone"].ToString().Trim();
                string indata = temdr["indate"].ToString().Trim() + " " + temdr["intime"].ToString().Trim();
                string outdata = temdr["outdate"].ToString().Trim() + " " + temdr["outtime"].ToString().Trim();
                string allrent = temdr["allrent"].ToString().Trim();
                string together = temdr["together"].ToString().Trim();
                if (together == "true")
                {
                    together = "否";
                }
                else
                {
                    together = "是";
                }
                //创建行对象
                ListViewItem li = new ListViewItem(room);
                //添加同一行的数据
                li.SubItems.Add(name);
                li.SubItems.Add(id);
                li.SubItems.Add(sex);
                li.SubItems.Add(age);
                li.SubItems.Add(phone);
                li.SubItems.Add(indata);
                li.SubItems.Add(outdata);
                li.SubItems.Add(allrent);
                li.SubItems.Add(together);
                //将行对象绑定在listview对象中
                listViewP.Items.Add(li);
            }
            temdr.Close();
            return listViewP;
        }
    }
}
