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
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;Initial Catalog=" + GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Cancel Button
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
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

            // username
            if (string.IsNullOrEmpty(username))
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxUsername.Focus();
                return;
            }

            // password
            if (string.IsNullOrEmpty(password))
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxPassword.Focus();
                return;
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM " + GloabalVariables.tableNguoiDung + " WHERE username='" + username + "' AND password='" + password + "'";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                GloabalVariables.logged = reader["username"].ToString();
                var form = new FormManager();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Retry)
                {
                    textBoxUsername.Focus();
                }
                if (dlr == DialogResult.Cancel)
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

        private void labelCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}