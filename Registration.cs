using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace kurs
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkData() == true)
            {
                try
                {

                    int kod = countOfrows() + 1;
                    String surname = textBox1.Text;
                    String name = textBox2.Text;
                    String fathersname = textBox3.Text;
                    String email = textBox4.Text;
                    String status = comboBox1.Text;
                    String login = textBox5.Text;
                    String password = textBox6.Text;
                    string query = "Insert into [менеджер] (код_менеджера,прізвище,імя,побатькові,статус,логін,пароль,пошта) Values (@kod,@name,@surname,@fathersname,@status,@login,@password,@email) ";
                    SqlCommand cmd = new SqlCommand(query, glob.connection);
                    cmd.Parameters.Add(new SqlParameter("@kod", kod));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@fathersname", fathersname));
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@status", status));
                    cmd.Parameters.Add(new SqlParameter("@login", login));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ви успішно зареєструвались");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Підключення до сервісу відсутнє.");
                }
            }
            else MessageBox.Show("Неправильно введені дані.");

        }
        public bool checkData()
        {
            bool stats = true;
            if (textBox6.Text != textBox7.Text) stats = false;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "") stats = false;
            return stats;
        }
        public int countOfrows()
        {
            glob.connection.Open();
            string query1 = "SELECT COUNT(*) FROM менеджер";
            SqlCommand cmd1 = new SqlCommand(query1, glob.connection);
            Int32 count = (Int32)cmd1.ExecuteScalar();
            return count;
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }
    }
}