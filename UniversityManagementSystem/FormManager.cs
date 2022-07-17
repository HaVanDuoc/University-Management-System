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

namespace UniversityManagementSystem
{
    public partial class FormManager : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public FormManager()
        {
            InitializeComponent();
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;Initial Catalog=UniversityManagementData;Integrated Security=True");
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load thông tin người dùng

            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Table_Users WHERE username='" + FormLogin.logged + "'";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                labelFullname.Text = reader["fullname"].ToString();
                labelUsername.Text = reader["username"].ToString();
                labelPassword.Text = reader["password"].ToString();

                // fullname
                //int fullnameIndex = reader.GetOrdinal("fullname");
                //string fullname = reader.GetString(fullnameIndex);

                // username
                //int usernameIndex = reader.GetOrdinal("username");
                //string username = reader.GetString(usernameIndex);

                // password
                //int passwordIndex = reader.GetOrdinal("password");
                //string password = reader.GetString(usernameIndex);

            }
            else
            {
                labelFullname.Text = "";
                labelUsername.Text = "";
                labelPassword.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonManagementUsers_Click(object sender, EventArgs e)
        {
            var form = new FormManagementUsers();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonManagementFaculty_Click(object sender, EventArgs e)
        {
            var form = new FormQLKhoa();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dlr == DialogResult.Yes)
            {
                FormLogin.logged = "";
                this.Close();
            }
        }

        private void buttonManagementClassroom_Click(object sender, EventArgs e)
        {
            var form = new FormQLLop();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonManagementStudents_Click(object sender, EventArgs e)
        {
            var form = new FormQLSinhVien();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
