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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\juny\Downloads\PetClinicTuto\PetClinicTuto\PetClinicDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select your Role!!!");
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                //Admin
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Both UserName and Password!!!");
                }
                else
                {
                    if(textBox1.Text == "Admin" && textBox2.Text == "Password")
                    {
                        Receptionists obj = new Receptionists();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Admin Name Or Password!!!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //Receptionist
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Both UserName and Password!!!");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from ReceptionistTbl where RecName='" + textBox1.Text + "' and RecPass='" + textBox2.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0].ToString() == "1")
                    {
                        Pets Obj = new Pets();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Receptionist Name or Password!!!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    Con.Close();
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                //Doctor
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Both DoctorName and Password!!!");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DoctorTbl where DocName='" + textBox1.Text + "' and DocPass='" + textBox2.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0].ToString() == "1")
                    {
                        Prescriptions Obj = new Prescriptions();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Doctor Name Or Password!!!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    Con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
