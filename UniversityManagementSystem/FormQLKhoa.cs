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
    public partial class FormQLKhoa : Form
    {
        public FormQLKhoa()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private SqlDataReader reader;
        private String table = GloabalVariables.tableKhoa;

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

            String query = "SELECT * FROM "+table+" ";

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
            textBoxName.Text = "";
            textBoxName.Focus();
        }

        private void FormQLKhoa_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;Initial Catalog=" + GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
                ShowList();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //list view
        private void listViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Danh sách Khoa
            int i = listViewList.FocusedItem.Index;
            if (i < 0) return;
            textBoxId.Text = listViewList.Items[i].Text;
            textBoxName.Text = listViewList.Items[i].SubItems[1].Text;
        }

        //search
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String searchData = textBoxSearch.Text;
            String searchQuery = "Select * from " + table + " Where tenKhoa Like N'%" + searchData + "%'";
            command = new SqlCommand(searchQuery, connection);
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
                    listViewList.Items.Add(item);
                }
            }
            reader.Close();
            connection.Close();
        }

        //Add
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập tên khoa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxName.Focus();
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                String khoa = textBoxName.Text.Trim();

                // Kiểm tra tài khoản đã tồn tại hay chưa
                command = new SqlCommand("SELECT * FROM " + table + " WHERE tenKhoa = N'" + khoa + "'", connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    DialogResult dlr = MessageBox.Show("Đã có khoa này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK)
                    {
                        textBoxName.Focus();
                    }
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;
                    string query = @"INSERT INTO " + table + " VALUES(@khoa)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@khoa", khoa);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm khoa " + khoa + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowList();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: ", ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Edit
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                String id = textBoxId.Text;
                String khoa = textBoxName.Text;
                String queryUpdate = "UPDATE " + table + " SET tenKhoa = N'" + khoa + "' WHERE id = " + id + "";

                try
                {
                    DialogResult dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        command = new SqlCommand(queryUpdate, connection);
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
                MessageBox.Show("Vui lòng chọn Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        //Delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                String id = textBoxId.Text;
                String queryDelete = "DELETE FROM " + table + " WHERE id = '" + id + "'";

                try
                {
                    DialogResult dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        command = new SqlCommand(queryDelete, connection);
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
                MessageBox.Show("Vui lòng chọn người Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        //Exit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //Clear
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
