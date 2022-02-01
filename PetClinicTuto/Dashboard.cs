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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountPet();
            CountDoctors();
            CountPrescriptions();
            SumAmt();
            BestCat();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\juny\Downloads\PetClinicTuto\PetClinicTuto\PetClinicDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountPet()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PetTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label10.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountDoctors()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from DoctorTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label11.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountPrescriptions()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PrescriptionTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label12.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumAmt()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(Cost) from PrescriptionTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label13.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void BestCat()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select top 1 Pcategorie, Count(Pcategorie) from PetTbl group by Pcategorie order by count(pcategorie)", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label14.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void PnumLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
