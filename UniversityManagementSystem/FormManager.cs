﻿
using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class FormManager : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        String query;
        DialogResult dlr;
        public FormManager()
        {
            InitializeComponent();
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

        private void FormManager_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;
                    Initial Catalog=" + GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            // Load thông tin người dùng
            command = new SqlCommand();
            command.Connection = connection;
            query =
                "SELECT * " +
                "FROM " + GloabalVariables.tableNguoiDung + " " +
                "WHERE username='" + GloabalVariables.logged + "'";
            command.CommandText = query;
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                labelFullname.Text = reader["fullname"].ToString();
                labelUsername.Text = reader["username"].ToString();
                labelPassword.Text = reader["password"].ToString();
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
            dlr = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if(dlr == DialogResult.Yes)
            {
                GloabalVariables.logged = "";
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

        private void buttonQLDiemSV_Click(object sender, EventArgs e)
        {
            var form = new FormQLDiemSinhVien();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonQLGiangVien_Click(object sender, EventArgs e)
        {
            var form = new FormGiangVien();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonQLMonHoc_Click(object sender, EventArgs e)
        {
            var form = new FormMonHoc();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
