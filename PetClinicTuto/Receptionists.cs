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

namespace PetClinicTuto
{
    public partial class Receptionists : Form
    {
        public Receptionists()
        {
            InitializeComponent();
            ShowRec();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\juny\Downloads\PetClinicTuto\PetClinicTuto\PetClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowRec()
        {
            Con.Open();
            string Query = "select * from ReceptionistTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Pets obj = new Pets();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Doctors obj = new Doctors();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Prescriptions obj = new Prescriptions();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox3.Text =="" || textBox4.Text =="" || textBox5.Text =="")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ReceptionistTbl (RecName, RecAdd, RecPhone, RecPass)values(@RN,@RA,@RP,@RPa)", Con);
                    cmd.Parameters.AddWithValue("@RN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@RA", textBox3.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox4.Text);
                    cmd.Parameters.AddWithValue("@RPa", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Saved");
                    Con.Close();
                    ShowRec();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //추가하기 버튼
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            if (textBox1.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        //수정하기 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox3.Text =="" || textBox4.Text =="" || textBox5.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ReceptionistTbl set RecName=@RN, RecAdd=@RA, RecPhone=@RP, RecPass=@RPa where RecNum=@RKey", Con);
                    cmd.Parameters.AddWithValue("@RN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@RA", textBox3.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox4.Text);
                    cmd.Parameters.AddWithValue("@RPa", textBox5.Text);
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    ShowRec();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //삭제하기 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ReceptionistTbl where RecNum=@RKey", Con);
                    cmd.Parameters.AddWithValue("@RN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@RA", textBox3.Text);
                    cmd.Parameters.AddWithValue("@RP", textBox4.Text);
                    cmd.Parameters.AddWithValue("@RPa", textBox5.Text);
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recepetionist Deleted!!!");
                    Con.Close();
                    ShowRec();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
