using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class FormLogin : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
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
        }

        private void Eixt(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Table_Users WHERE username='" + username + "' AND password='" + password + "'";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                BienToanCuc.logged = username;

                var form = new FormManager();
                form.Show();
                this.Close();
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if(dlr == DialogResult.Cancel)
                {
                    this.Close();
                }
            }

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            var form = new FormRegister();
            form.ShowDialog();
        }
    }
}