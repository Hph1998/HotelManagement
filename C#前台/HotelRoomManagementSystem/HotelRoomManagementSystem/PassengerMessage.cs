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
    public partial class PassengerMessage : Form
    {
        PassengerDB PassengerDB = new PassengerDB();
        RoomDB RoomDB = new RoomDB();
        KeepDB KeepDB = new KeepDB();
        public int no;
        private string rn;
        public string Rn
        {
            set
            {
                rn = value;
            }
        }
        public void SetValue()
        {
            this.rnlabel2.Text = rn;
            initListView();
        }

        public PassengerMessage()
        {
            InitializeComponent();
        }

        public void randno()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);
            no = random.Next();
        }

        public ListView initListView()
        {
            SqlDataReader temdr = PassengerDB.select();
            while (temdr.Read())
            {
                if (rn.Equals(temdr["roomnumber"].ToString().Trim()))
                {
                    string randno = temdr["randno"].ToString().Trim();
                    string name = temdr["name"].ToString().Trim();
                    string id = temdr["id"].ToString().Trim();
                    string sex = temdr["sex"].ToString().Trim();
                    string age = temdr["age"].ToString().Trim();
                    string phone = temdr["phone"].ToString().Trim();
                    string deposit = temdr["deposit"].ToString().Trim();
                    //创建行对象
                    ListViewItem li = new ListViewItem(randno);
                    //添加同一行的数据
                    li.SubItems.Add(name);
                    li.SubItems.Add(id);
                    li.SubItems.Add(sex);
                    li.SubItems.Add(age);
                    li.SubItems.Add(phone);
                    li.SubItems.Add(deposit);
                    //将行对象绑定在listview对象中
                    listView.Items.Add(li);
                }
            }
            temdr.Close();
            return listView;
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            randno();
            InsertListView(listView);
        }

        public ListView InsertListView(ListView lv)
        {
            if (nametxt.Text != "" && idtxt.Text != "" && sexbox.Text != "" && agetxt.Text != "" && phonetxt.Text != "" && idtxt.Text.Length==18 && phonetxt.Text.Length==11)
            {
                //获取文本框中的值
                string randno = no.ToString();
                string name = nametxt.Text;
                string id = idtxt.Text;
                string sex = sexbox.Text;
                string age = agetxt.Text;
                string phone = phonetxt.Text;
                string indate = DateTime.Now.ToString("yyyy-MM-dd");
                string intime = DateTime.Now.ToLongTimeString().ToString();
                SqlDataReader temdr = RoomDB.Deposit(rn);
                String deposit="";
                String lease = "";
                while (temdr.Read())
                {
                    deposit = temdr["rent"].ToString().Trim();
                    lease = temdr["lease"].ToString().Trim();
                }
                temdr.Close();
                PassengerDB.Insert(rn, name,id,sex,age,phone,no,deposit);
                KeepDB.Insert(rn, name, id, sex, age, phone,indate,intime, no, lease);
                RoomDB.Modify("true", rn);
                //创建行对象
                ListViewItem li = new ListViewItem(randno);
                //添加同一行的数据
                li.SubItems.Add(name);
                li.SubItems.Add(id);
                li.SubItems.Add(sex);
                li.SubItems.Add(age);
                li.SubItems.Add(phone);
                //将行对象绑定在listview对象中
                listView.Items.Add(li);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("办理入住成功！");
            }
            else
            {
                MessageBox.Show("请补全信息或正确格式输入再办理入住！");
            }
            return lv;
        }

        private void modifybtn_Click(object sender, EventArgs e)
        {
            ModifyListView(listView);
        }

        public ListView ModifyListView(ListView lv)
        {
            if (nametxt.Text != "" && idtxt.Text != "" && sexbox.Text != "" && agetxt.Text != "" && phonetxt.Text != "")
            {
                //获取文本框中的值
                string name = nametxt.Text;
                string id = idtxt.Text;
                string sex = sexbox.Text;
                string age = agetxt.Text;
                string phone = phonetxt.Text;
                if (this.listView.SelectedItems.Count > 0)
                {
                    no = int.Parse(lv.SelectedItems[0].SubItems[0].Text);
                    lv.SelectedItems[0].SubItems[1].Text = name;
                    lv.SelectedItems[0].SubItems[2].Text = id;
                    lv.SelectedItems[0].SubItems[3].Text = sex;
                    lv.SelectedItems[0].SubItems[4].Text = age;
                    lv.SelectedItems[0].SubItems[5].Text = phone;
                    PassengerDB.Modify(rn, name, id, sex, age, phone,no);
                    KeepDB.ModifyP(rn, name, id, sex, age, phone, no);
                    MessageBox.Show("修改入住信息成功！");
                }
                else
                {
                    MessageBox.Show("请先选择需要修改的信息行！");
                }
            }
            else
            {
                MessageBox.Show("请补全信息再修改入住！");
            }
            return lv;
        }



        private void listView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {
                //把选择的信息显示在相应的文本框中
                nametxt.Text = this.listView.SelectedItems[0].SubItems[1].Text;
                idtxt.Text = this.listView.SelectedItems[0].SubItems[2].Text;
                sexbox.Text = this.listView.SelectedItems[0].SubItems[3].Text;
                agetxt.Text = this.listView.SelectedItems[0].SubItems[4].Text;
                phonetxt.Text = this.listView.SelectedItems[0].SubItems[5].Text;
            }
        }

        private void leavebtn_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                string outdate = DateTime.Now.ToString("yyyy-MM-dd");
                string outtime = DateTime.Now.ToLongTimeString().ToString();
                DateTime date = Convert.ToDateTime("2999-01-01");
                SqlDataReader temdr = PassengerDB.getrandno(rn);
                String[] randno = new String[10];
                int i = 0;
                int j = 0;
                while (temdr.Read())
                {
                    randno[i] = temdr["randno"].ToString().Trim();
                    i++;
                    j++;
                }
                temdr.Close();
                while (i >= 0)
                {
                    temdr = KeepDB.getindate(randno[i]);
                    while (temdr.Read())
                    {
                        DateTime temp = Convert.ToDateTime(temdr["indate"].ToString().Trim());
                        int compNum = DateTime.Compare(temp, date);
                        if (compNum < 0)
                        {
                            date = temp;
                        }
                    }
                    i--;
                }
                DateTime outdates = Convert.ToDateTime(outdate);
                TimeSpan ts = outdates - date;
                int days = ts.Days;
                if (days == 0)
                {
                    days++;
                }
                temdr.Close();
                temdr = RoomDB.Deposit(rn);
                int deposit = 0;
                while (temdr.Read())
                {
                    deposit = int.Parse(temdr["rent"].ToString().Trim());
                }
                string allrent = (deposit*days).ToString();
                while (j >= 0)
                {
                    KeepDB.Modify(randno[j],outdate, outtime, allrent);
                    j--;
                }
                PassengerDB.delete(rn);
                RoomDB.Modify("false",rn);
                listView.Items.Clear();
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show("退房办理成功！房费共" + allrent+"元");
            }
            else
            {
                MessageBox.Show("没有入住信息！");
            }
        }
    }
}
