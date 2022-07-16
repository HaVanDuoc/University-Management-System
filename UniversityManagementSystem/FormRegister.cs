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
using System.Data.OleDb;

namespace UniversityManagementSystem
{
    public partial class FormRegister : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
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
            string fullname = textBoxFullname.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim();

            // check fullname
            if (String.IsNullOrEmpty(fullname))
            {
                DialogResult dlr = MessageBox.Show("Họ tên không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxFullname.Focus();
                    return;
                }
            }

            // check password
            if (String.IsNullOrEmpty(password))
            {
                DialogResult dlr = MessageBox.Show("Mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxPassword.Focus();
                    return;
                }
            }

            // check password
            if (String.IsNullOrEmpty(password))
            {
                DialogResult dlr = MessageBox.Show("Mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxPassword.Focus();
                    return;
                }
            }

            if (String.IsNullOrEmpty(confirmPassword))
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxConfirmPassword.Focus();
                    return;
                }
            }

            if (password == confirmPassword)
            {
                command = new SqlCommand("SELECT * FROM Table_Users WHERE username = '" + textBoxUsername.Text + "'", connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    DialogResult dlr = MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK)
                    {
                        textBoxUsername.Focus();
                    }
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;

                    string query = @"INSERT INTO Table_Users VALUES(@fullname, @username, @password)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@fullname", fullname);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tài khoản của bạn đã được tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxPassword.Focus();
                }
            }

        }
    }
}
