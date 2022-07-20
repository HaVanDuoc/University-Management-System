
using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class FormRegister : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        String query;
        String fullname;
        String username;
        String password;
        String confirmPassword;
        DialogResult dlr;
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;
                    Initial Catalog="+ GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            fullname = textBoxFullname.Text.Trim();
            username = textBoxUsername.Text.Trim();
            password = textBoxPassword.Text.Trim();
            confirmPassword = textBoxConfirmPassword.Text.Trim();

            // check fullname
            if (String.IsNullOrEmpty(fullname))
            {
                dlr = MessageBox.Show("Họ tên không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxFullname.Focus();
                    return;
                }
            }

            // check password
            if (String.IsNullOrEmpty(password))
            {
                dlr = MessageBox.Show("Mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxPassword.Focus();
                    return;
                }
            }

            // check password
            if (String.IsNullOrEmpty(password))
            {
                dlr = MessageBox.Show("Mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxPassword.Focus();
                    return;
                }
            }

            if (String.IsNullOrEmpty(confirmPassword))
            {
                dlr = MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxConfirmPassword.Focus();
                    return;
                }
            }

            if (password == confirmPassword)
            {
                query = "SELECT * FROM " + GloabalVariables.tableNguoiDung + " WHERE username = '" + textBoxUsername.Text + "'";
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    dlr = MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK) textBoxUsername.Focus();
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;

                    query = @"INSERT INTO " + GloabalVariables.tableNguoiDung + " VALUES(@fullname, @username, @password)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@fullname", fullname);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tài khoản của bạn đã được tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    if(connection.State == System.Data.ConnectionState.Open) connection.Close();
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxPassword.Focus();
            }

        }
    }
}
