using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace multilogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-U3CVKB6\\SQLEXPRESS;Initial Catalog=multilogin;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from login where username='" + txtuser.Text + "' and password='" + txtpass.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue=comboBox1.SelectedItem.ToString();
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i]["httpcode"].ToString()==cmbItemValue)
                    {
                        MessageBox.Show("you are login as" + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex ==0)
                        {
                            Form2 f = new Form2();
                            f.Show();
                            this.Hide();
                        }
                        else if(comboBox1.SelectedIndex == 1)
                        {
                            Form3 ff = new Form3();
                            ff.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form4 fff = new Form4();
                            fff.Show();
                            this.Hide();
                        }
                    }
                }
            }
           else
            {
                MessageBox.Show("error");
            }

        }
    }
}
