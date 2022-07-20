
using System.Data;
using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class FormManagementUsers : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private SqlDataReader reader;
        String table = GloabalVariables.tableNguoiDung;
        String query;
        DialogResult dlr;
        String id;
        String username;
        String password;
        String fullname;

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

        // Đọc danh sách
        DataTable ReadList(String query)
        {
            dataAdapter = new SqlDataAdapter(query, connection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        // Load danh sách
        private void LoadList(DataTable dataTable)
        {
            ListViewItem item;
            listViewList.Items.Clear();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                item = listViewList.Items.Add(dataTable.Rows[i][0].ToString());

                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    item.SubItems.Add(dataTable.Rows[i][j].ToString());
                }
            }
        }

        private void ShowList()
        {
            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();

            query = "SELECT * FROM " + GloabalVariables.tableNguoiDung + " ";

            command = new SqlCommand(query, connection);
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "table");

            // Load listView
            DataTable dataTable;
            dataTable = ReadList(query);
            LoadList(dataTable);

            if (connection.State == System.Data.ConnectionState.Open) connection.Close();
        }

        // Reset textbox
        private void Clear()
        {
            textBoxId.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxFullname.Text = "";
            textBoxUsername.Focus();
        }

        public FormManagementUsers()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormManagementUsers_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;
                    Initial Catalog=" + GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
                ShowList();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // check data
            // username
            if (string.IsNullOrEmpty(textBoxUsername.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning);
                if(dlr == DialogResult.OK) textBoxUsername.Focus();
                return;
            }

            // password
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxPassword.Focus();
                return;
            }

            // fullname
            if (string.IsNullOrEmpty(textBoxFullname.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxFullname.Focus();
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                username = textBoxUsername.Text.Trim();
                password = textBoxPassword.Text.Trim();
                fullname = textBoxFullname.Text.Trim();

                // Kiểm tra tài khoản đã tồn tại hay chưa
                query = "SELECT * FROM " + table + " WHERE username = '" + username + "'";
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    DialogResult dlr = MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK) textBoxUsername.Focus();
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;
                    query = @"INSERT INTO "+table+" VALUES(@fullname, @username, @password)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@fullname", fullname);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tài khoản của bạn đã được tạo", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    ShowList();
                    Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: ", ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void listViewListUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                id = textBoxId.Text;
                username = textBoxUsername.Text;
                password = textBoxPassword.Text;
                fullname = textBoxFullname.Text;
                query = 
                    "UPDATE " + table + " " +
                    "SET fullname = N'" + fullname + "', username = N'" + username + "', " +
                        "password = '" + password + "' " +
                    "WHERE id = '" + id + "'";

                try
                {
                    dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowList();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }
        }

        //delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                id = textBoxId.Text;
                query = "DELETE FROM " + table + " WHERE id = '" + id + "'";

                try
                {
                    dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowList();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            query =
                "Select * " +
                "from " + table + " " +
                "Where username Like'%" + textBoxSearch.Text + "%' " +
                    "or fullname Like'%" + textBoxSearch.Text + "%'";

            command = new SqlCommand(query, connection);
            SqlDataReader reader;
            connection.Open();

            reader = command.ExecuteReader();
            command.Dispose();
            listViewList.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader[0].ToString());
                    item.SubItems.Add(reader[1].ToString());
                    item.SubItems.Add(reader[2].ToString());
                    item.SubItems.Add(reader[3].ToString());
                    listViewList.Items.Add(item);
                }
            }
            reader.Close();
            connection.Close();
        }

        private void listViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listViewList.FocusedItem.Index;
            if (i < 0) return;
            textBoxId.Text = listViewList.Items[i].Text;
            textBoxUsername.Text = listViewList.Items[i].SubItems[2].Text;
            textBoxPassword.Text = listViewList.Items[i].SubItems[3].Text;
            textBoxFullname.Text = listViewList.Items[i].SubItems[1].Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
