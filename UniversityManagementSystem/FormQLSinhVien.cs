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
    public partial class FormQLSinhVien : Form
    {
        public FormQLSinhVien()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private SqlDataReader reader;

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

            String query = "SELECT * FROM Table_SinhVien";

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
        private void ResetTextBox()
        {
            textBoxId.Text = "";
            textBoxMSSV.Text = "";
            textBoxName.Text = "";
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            textBoxNoiSinh.Text = "";
            textBoxDanToc.Text = "";
            textBoxMSSV.Focus();
        }

        private void LoadComboBoxKhoa()
        {
            if(connection.State == System.Data.ConnectionState.Closed) connection.Open();
            String query = "SELECT * FROM Table_Khoa";
            command = new SqlCommand(query, connection);
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "khoa");
            if(connection.State == System.Data.ConnectionState.Open) connection.Close();
            comboBoxKhoa.DataSource = dataSet;
            comboBoxKhoa.ValueMember = "khoa.id";
            comboBoxKhoa.DisplayMember = "khoa.tenKhoa";
        }

        private void FormQLSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;Initial Catalog=UniversityManagementData;Integrated Security=True");
                connection.Open();
                LoadComboBoxKhoa();
                ShowList();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String searchData = textBoxSearch.Text;
            String searchQuery = "Select * from Table_SinhVien Where mssv Like N'%" + searchData + "%' or hoTen Like N'%" + searchData + "%' or gioiTinh Like N'%" + searchData + "%' or ngaySinh Like N'%" + searchData + "%' or noiSinh Like N'%" + searchData + "%' or danToc Like N'%" + searchData + "%' or khoa Like N'%" + searchData + "%'";
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
                    ListViewItem item = new ListViewItem(reader["mssv"].ToString());
                    item.SubItems.Add(reader["hoTen"].ToString());
                    item.SubItems.Add(reader["gioiTinh"].ToString());
                    item.SubItems.Add(reader["ngaySinh"].ToString());
                    item.SubItems.Add(reader["noiSinh"].ToString());
                    item.SubItems.Add(reader["danToc"].ToString());
                    item.SubItems.Add(reader["khoa"].ToString());
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
            textBoxMSSV.Text = listViewList.Items[i].SubItems[1].Text;
            textBoxName.Text = listViewList.Items[i].SubItems[2].Text;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // massv
            if (string.IsNullOrEmpty(textBoxMSSV.Text))
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxMSSV.Focus();
                return;
            }

            // họ tên
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                DialogResult dlr = MessageBox.Show("Vui lòng nhập Tên sinh viên!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxName.Focus();
                return;
            }

            // Check Sex
            String gioitinh = "Chưa xác định";
            if(checkBoxNam.Checked == true) gioitinh = "Nam";
            if(checkBoxNu.Checked == true) gioitinh = "Nữ";

            String mssv = textBoxMSSV.Text.Trim();
            String hoten = textBoxName.Text.Trim();
            String ngaysinh = dateTimePickerNgaySinh.Value.ToString();
            String noisinh = textBoxNoiSinh.Text.Trim();
            String dantoc = textBoxDanToc.Text.Trim();


            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                // Kiểm tra tài khoản đã tồn tại hay chưa
                command = new SqlCommand("SELECT * FROM Table_SinhVien WHERE mssv = N'" + mssv + "'", connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    DialogResult dlr = MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK)
                    {
                        textBoxMSSV.Focus();
                    }
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;
                    string query = @"INSERT INTO Table_SinhVien (mssv, hoTen, gioiTinh, ngaySinh, noiSinh, danToc) VALUES(@mssv, @hoten, @gioitinh, @ngaysinh, @noisinh, @dantoc)";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@mssv", mssv);
                    command.Parameters.AddWithValue("@hoten", hoten);
                    command.Parameters.AddWithValue("@gioitinh", gioitinh);
                    command.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                    command.Parameters.AddWithValue("@noisinh", noisinh);
                    command.Parameters.AddWithValue("@dantoc", dantoc);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm sinh viên " + hoten + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowList();
                    ResetTextBox();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }
    }
}
