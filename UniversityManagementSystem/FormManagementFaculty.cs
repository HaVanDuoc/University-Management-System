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

    public partial class FormManagementFaculty : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private SqlDataReader reader;

        // Lấy danh sách
        DataTable DocDanhSachKhoa()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Table_Faculty", connection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        // Load danh sách
        private void TaiDanhSachKhoa(DataTable tableKhoa)
        {
            ListViewItem item;
            listViewDanhSachKhoa.Items.Clear();

            for (int i = 0; i < tableKhoa.Rows.Count; i++)
            {
                item = listViewDanhSachKhoa.Items.Add(tableKhoa.Rows[i][0].ToString());

                for (int j = 1; j < tableKhoa.Columns.Count; j++)
                {
                    item.SubItems.Add(tableKhoa.Rows[i][j].ToString());
                }
            }
        }

        private void XuatDanhSach()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            command = new SqlCommand("SELECT * FROM Table_Faculty", connection);
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "faculty");

            // Load listView Danh sách học sinh
            DataTable tableKhoa;
            tableKhoa = DocDanhSachKhoa();
            TaiDanhSachKhoa(tableKhoa);

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Reset textbox
        private void ResetTextBox()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxName.Focus();
        }
        public FormManagementFaculty()
        {
            InitializeComponent();
        }

        private void listViewDanhSachKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listViewDanhSachKhoa.FocusedItem.Index;
            if (i < 0) return;
            textBoxId.Text = listViewDanhSachKhoa.Items[i].Text;
            textBoxName.Text = listViewDanhSachKhoa.Items[i].SubItems[1].Text;
        }

        private void FormManagementFaculty_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;Initial Catalog=UniversityManagementData;Integrated Security=True");
                connection.Open();
                XuatDanhSach();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            command = new SqlCommand("Select * from Table_Faculty Where tenKhoa Like'%" + textBoxSearch.Text + "%' or fullname Like'%" + textBoxSearch.Text + "%'", connection);
            SqlDataReader reader;

            connection.Open();

            reader = command.ExecuteReader();
            command.Dispose();
            listViewDanhSachKhoa.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    ListViewItem item = new ListViewItem(reader[0].ToString()); // Or you can specify column name - ListViewItem item = new ListViewItem(reader["column_name"].ToString()); 
                    item.SubItems.Add(reader[1].ToString());
                    item.SubItems.Add(reader[2].ToString());
                    item.SubItems.Add(reader[3].ToString());
                    listViewDanhSachKhoa.Items.Add(item); // add this item to your ListView with all of his subitems
                }
            }
            reader.Close();
            connection.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                String tenKhoa = textBoxName.Text.Trim();

                // Kiểm tra tài khoản đã tồn tại hay chưa
                command = new SqlCommand("SELECT * FROM Table_Faculty WHERE tenKhoa = '" + tenKhoa + "'", connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    DialogResult dlr = MessageBox.Show("Đã có khoa này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK)
                    {
                        textBoxName.Focus();
                    }
                    return;
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;

                    string query = @"INSERT INTO Table_Faculty VALUES(@tenKhoa)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@tenKhoa", tenKhoa);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã tạo khoa mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    XuatDanhSach();

                    ResetTextBox();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

            }
            else
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK)
                {
                    textBoxName.Focus();
                }
            }
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                String id = textBoxId.Text;
                String name = textBoxName.Text;

                String queryUpdate = "UPDATE Table_Faculty SET tenKhoa = '" + name + "'";

                try
                {
                    command = new SqlCommand(queryUpdate, connection);

                    // thực thi câu truy vấn
                    command.ExecuteNonQuery();

                    MessageBox.Show("Đã cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    XuatDanhSach();

                    ResetTextBox();
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
                MessageBox.Show("Vui lòng chọn khoa!", "Thông báo");
                return;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
