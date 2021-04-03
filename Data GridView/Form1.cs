using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Data_GridView
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        

        public Form1()
        {
            InitializeComponent();
        }

        string conString = "server=localhost;user id=root ;password=My5q1pa55w0rd;database=nic_form";
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
        private readonly MySqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.AddRange(new DataColumn[16] { 
            new DataColumn("Name", typeof(string)),
            new DataColumn("Father Name", typeof(string)),
            new DataColumn("Date of Birth", typeof(string)),
            new DataColumn("Present Address", typeof(string)),
            new DataColumn("Permanent Address", typeof(string)),
            new DataColumn("Citizen no", typeof(string)),
            new DataColumn("Domicile", typeof(string)),
            new DataColumn("City", typeof(string)),
            new DataColumn("Country", typeof(string)),
            new DataColumn("Identification Mark", typeof(string)),
            new DataColumn("Religion", typeof(string)),
           // new DataColumn("Religion", typeof(string)),
            new DataColumn("Gender", typeof(string)),
            new DataColumn("Status", typeof(string)),
            new DataColumn("Where do you want to Delivered Card:", typeof(string)),
            new DataColumn("Card Type", typeof(string)),
            new DataColumn("Mobile Number", typeof(long))});
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("No Rows", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;

            if (Isvalid())  //call function
             {
                 MySqlConnection con = new MySqlConnection(@"server=localhost; user id=root ; password=My5q1pa55w0rd ;     database=nic_form");
                 MySqlCommand cmd = new MySqlCommand
                 ("INSERT INTO datafom VALUES(@FullName, @FatherName, @DOB, @PresentAddress, @Permanentaddress,@CitizenNumber, @Domicile, @City, @Country, @IdentificationMark, @Religion, @Gendar, @Status, @DeliveredCard, @CardType, @MobileNo)", con);
                 cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("@FullName", textBox1.Text);
                 cmd.Parameters.AddWithValue("@FatherName", textBox2.Text);
                 cmd.Parameters.AddWithValue("@DOB", textBox10.Text);
                 cmd.Parameters.AddWithValue("@PresentAddress", textBox4.Text);
                 cmd.Parameters.AddWithValue("@Permanentaddress", textBox5.Text);
                 cmd.Parameters.AddWithValue("@CitizenNumber", textBox6.Text);
                 cmd.Parameters.AddWithValue("@Domicile", comboBox2.Text);
                 cmd.Parameters.AddWithValue("@City", textBox7.Text);
                 cmd.Parameters.AddWithValue("@Country", textBox8.Text);
                 cmd.Parameters.AddWithValue("@IdentificationMark", textBox3.Text);
                 cmd.Parameters.AddWithValue("@Religion", comboBox1.Text);
                 cmd.Parameters.AddWithValue("@Gendar", comboBox3.Text);
                 cmd.Parameters.AddWithValue("@Status", comboBox4.Text);
                 cmd.Parameters.AddWithValue("@DeliveredCard", comboBox5.Text);
                 cmd.Parameters.AddWithValue("@CardType", comboBox6.Text);
                 cmd.Parameters.AddWithValue("@MobileNo", textBox9.Text);

                 con.Open();
                 //cmd.ExecuteNonQuery();
                 con.Close();

                 MessageBox.Show("Record successfully saved in database ", "SAVED", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

                 getRecords();  		 //call function
                 reset();


             }

        }
       
        
        private void getRecords()
        {
           // MySqlConnection con = new MySqlConnection(@"server=localhost; user id=root ; password=My5q1pa55w0rd ;
            MySqlCommand cmd = new MySqlCommand("Select * from dataform", con);
            DataTable dataTable = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;
        }

        private void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox10.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            textBox1.Focus();
        }
        private bool Isvalid()
        {
            if (textBox6.Text == string.Empty)
            {
                MessageBox.Show("Citizen_Number is required", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            dt.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
