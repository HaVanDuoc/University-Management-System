
using System.Data;
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
        String table = GloabalVariables.tableSinhVien;
        String query;
        String gioitinh;
        String dantoc;
        String noisinh;
        String khoa;
        String id;
        String mssv;
        String hoten;
        String ngaysinh;
        DialogResult dlr;

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

            query = 
                "SELECT SinhVien.id, mssv, hoTen, gioiTinh, ngaySinh, Khoa.tenKhoa, noiSinh, danToc " +
                "FROM SinhVien LEFT JOIN Khoa ON SinhVien.khoa_id = Khoa.id ";

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
            textBoxMSSV.Text = "";
            textBoxName.Text = "";
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            dateTimePickerNgaySinh.Value = DateTime.Now;
            comboBoxKhoa.SelectedIndex = 0;
            textBoxNoiSinh.Text = "";
            textBoxDanToc.Text = "";
            textBoxMSSV.Focus();
        }

        private void LoadComboBoxKhoa()
        {
            if(connection.State == System.Data.ConnectionState.Closed) connection.Open();

            query = "SELECT * FROM "+ GloabalVariables.tableKhoa + " ";

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
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;
                    Initial Catalog=" + GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
                LoadComboBoxKhoa();
                ShowList();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String searchData = textBoxSearch.Text;
            query = 
                "Select SinhVien.id, mssv, hoTen, gioiTinh, ngaySinh, Khoa.tenKhoa, noiSinh, danToc " +
                "from SinhVien LEFT JOIN Khoa ON SinhVien.khoa_id = Khoa.id " +
                "Where mssv Like N'%" + searchData + "%' " +
                    "or hoTen Like N'%" + searchData + "%' " +
                    "or gioiTinh Like N'%" + searchData + "%' " +
                    "or ngaySinh Like N'%" + searchData + "%' " +
                    "or noiSinh Like N'%" + searchData + "%' " +
                    "or danToc Like N'%" + searchData + "%' " +
                    "or Khoa.tenKhoa Like N'%" + searchData + "%'";
            command = new SqlCommand(query, connection);
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "table");

            // Load listView
            DataTable dataTable;
            dataTable = ReadList(query);
            LoadList(dataTable);
        }

        private void listViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listViewList.FocusedItem.Index;
            if (i < 0) return;
            textBoxId.Text = listViewList.Items[i].Text;
            textBoxMSSV.Text = listViewList.Items[i].SubItems[1].Text;
            textBoxName.Text = listViewList.Items[i].SubItems[2].Text;

            if (listViewList.Items[i].SubItems[3].Text == "Nam")
            {
                checkBoxNam.Checked = true;
            }
            else if(listViewList.Items[i].SubItems[3].Text == "Nữ")
            {
                checkBoxNu.Checked = true;
            }
            else
            {
                checkBoxNam.Checked = false;
                checkBoxNu.Checked = false;
            }

            string ngaysinh = listViewList.Items[i].SubItems[4].Text;
            dateTimePickerNgaySinh.Value = DateTime.ParseExact(ngaysinh, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            string selectComboBox = listViewList.Items[i].SubItems[5].Text;
            comboBoxKhoa.SelectedIndex = comboBoxKhoa.FindStringExact(selectComboBox);

            textBoxNoiSinh.Text = listViewList.Items[i].SubItems[6].Text;
            textBoxDanToc.Text = listViewList.Items[i].SubItems[7].Text;

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                gioitinh = "Chưa xác định";
                if (checkBoxNam.Checked == true) gioitinh = "Nam";
                if (checkBoxNu.Checked == true) gioitinh = "Nữ";

                id = textBoxId.Text.Trim();
                mssv = textBoxMSSV.Text.Trim();
                hoten = textBoxName.Text.Trim();
                ngaysinh = dateTimePickerNgaySinh.Value.ToString("dd-MM-yyyy");
                khoa = comboBoxKhoa.Text.Trim();
                noisinh = textBoxNoiSinh.Text.Trim();
                dantoc = textBoxDanToc.Text.Trim();

                try
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    // Kiểm tra tài khoản đã tồn tại hay chưa
                    query = "SELECT * FROM " + table + " WHERE mssv = N'" + mssv + "' AND id != '" + id + "' ";
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        dlr = MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        if (dlr == DialogResult.OK) textBoxMSSV.Focus();
                    }
                    else
                    {
                        dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, 
                            MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {
                            reader.Close();
                            command = new SqlCommand();
                            command.Connection = connection;
                            query = 
                                "update SinhVien " +
                                "set mssv = N'"+mssv+"', hoTen = N'"+hoten+"', gioiTinh = N'"+gioitinh+"', " +
                                    "ngaySinh = N'"+ngaysinh+"',  noiSinh = N'"+noisinh+"', danToc = N'"+dantoc+"', " +
                                    "khoa_id = Khoa.id " +
                                "from Khoa inner join SinhVien on Khoa.tenKhoa = N'"+khoa+"' " +
                                "where SinhVien.id = '"+id+"';";
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                            MessageBox.Show("Đã cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowList();
                            Clear();
                        }
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
            else
            {
                MessageBox.Show("Vui lòng chọn Sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // massv
            if (string.IsNullOrEmpty(textBoxMSSV.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxMSSV.Focus();
                return;
            }

            // họ tên
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập Tên sinh viên!", "Thông báo", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxName.Focus();
                return;
            }

            gioitinh = "Chưa xác định";
            if(checkBoxNam.Checked == true) gioitinh = "Nam";
            if(checkBoxNu.Checked == true) gioitinh = "Nữ";

            id = textBoxId.Text.Trim();
            mssv = textBoxMSSV.Text.Trim();
            hoten = textBoxName.Text.Trim();
            ngaysinh = dateTimePickerNgaySinh.Value.ToString("dd-MM-yyyy");
            noisinh = textBoxNoiSinh.Text.Trim();
            dantoc = textBoxDanToc.Text.Trim();
            khoa = comboBoxKhoa.Text.Trim();

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                // Kiểm tra tài khoản đã tồn tại hay chưa
                query = "SELECT * FROM " + table + " WHERE mssv = N'" + mssv + "' AND id != '" + id + "' ";
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    dlr = MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK) textBoxMSSV.Focus();
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;

                    query =
                        "insert into SinhVien(mssv, hoTen, gioiTinh, ngaySinh, noiSinh, danToc, khoa_id) " +
                        "select N'" + mssv + "', N'" + hoten + "', N'" + gioitinh + "', N'" + ngaysinh + "', " +
                            "N'" + noisinh + "', N'" + dantoc + "', Khoa.id " +
                        "from Khoa " +
                        "Where Khoa.tenKhoa = N'" + khoa + "'";

                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm sinh viên " + hoten + "!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                id = textBoxId.Text;
                query = "DELETE FROM " + table + " WHERE id = '" + id + "'";

                try
                {
                    DialogResult dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, 
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
                MessageBox.Show("Vui lòng chọn Sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
