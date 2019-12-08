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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registration reg = new registration();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                glob.connection.Open();
                String Login = textBox1.Text;
                String Password = textBox2.Text;
                string query = "Select * From [менеджер] where логін=@login and пароль=@password";
                SqlCommand cmd = new SqlCommand(query, glob.connection);
                cmd.Parameters.Add(new SqlParameter("@login", Login));
                cmd.Parameters.Add(new SqlParameter("@password", Password));

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                 //   MessageBox.Show("Ласкаво просимо в систему");
                    Thread thread1 = new Thread(new ThreadStart(mainform));
                    thread1.Start();
                    Application.Exit();

                }
                else MessageBox.Show("Неправильно введені логін або пароль");
                glob.connection.Close();
            }
            catch { MessageBox.Show("Підключення до сервісу відсутнє"); }
        }
    public  static  void mainform()
        {
            Application.Run(new MainForm());
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}