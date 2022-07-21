
using System.Data;
using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class FormQLDiemSinhVien : Form
    {
        public FormQLDiemSinhVien()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private SqlDataReader reader;
        String table = GloabalVariables.tableDiem;
        String query;
        String monhoc;
        DialogResult dlr;
        String ketQua;
        String mon;
        String diemLan2;
        String diemLan1;
        String mssv;
        String id;
        String hoten;

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

            monhoc = comboBoxMonHoc.Text.Trim();

            query = 
                "SELECT d.id,s.mssv, s.hoTen, diemLan1, diemLan2, ketQua " +
                "FROM Diem d " +
                    "JOIN MonHoc m ON d.monhoc_id = m.id " +
                    "Join SinhVien s ON d.sinhvien_id = s.id " +
                "WHERE m.tenMonHoc = N'" + monhoc + "'";

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
            textBoxDiemLan1.Text = "";
            textBoxDiemLan2.Text = "";
            labelKetQua.Text = "";
        }

        private void LoadComboBoxMonHoc()
        {
            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();

            query = "SELECT * FROM " + GloabalVariables.tableMonHoc + " ";
            command = new SqlCommand(query, connection);
            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "table");

            if (connection.State == System.Data.ConnectionState.Open) connection.Close();

            comboBoxMonHoc.DataSource = dataSet;
            comboBoxMonHoc.ValueMember = "table.id";
            comboBoxMonHoc.DisplayMember = "table.tenMonHoc";
        }

        private void FormQLDiemSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=LAPTOP-H1GC0D8K;
                    Initial Catalog=" + GloabalVariables.databaseName + ";Integrated Security=True");
                connection.Open();
                LoadComboBoxMonHoc();
                labelKetQua.Text = "";
                ShowList();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void listViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listViewList.FocusedItem.Index;
            if (i < 0) return;
            textBoxId.Text = listViewList.Items[i].Text;
            textBoxMSSV.Text = listViewList.Items[i].SubItems[1].Text;
            textBoxName.Text = listViewList.Items[i].SubItems[2].Text;
            textBoxDiemLan1.Text = listViewList.Items[i].SubItems[3].Text;
            textBoxDiemLan2.Text = listViewList.Items[i].SubItems[4].Text;
            labelKetQua.Text = listViewList.Items[i].SubItems[5].Text;
        }

        private void labelKetQua_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowList();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // mssv
            if (string.IsNullOrEmpty(textBoxMSSV.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxMSSV.Focus();
                return;
            }

            // diem
            if (string.IsNullOrEmpty(textBoxDiemLan1.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập điểm!", "Thông báo", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxDiemLan1.Focus();
                return;
            }

            id = textBoxId.Text.Trim();
            mssv = textBoxMSSV.Text.Trim();
            diemLan1 = textBoxDiemLan1.Text.Trim();
            diemLan2 = textBoxDiemLan2.Text.Trim();
            mon = comboBoxMonHoc.Text.Trim();

            ketQua = "KHÔNG ĐẠT";
            if (diemLan2 == "")
            {
                if (Int32.Parse(diemLan1) >= 5) ketQua = "ĐẠT";
            }
            else if(diemLan2 != "")
            {
                if (Int32.Parse(diemLan1) >= 5 || Int32.Parse(diemLan2) >= 5) ketQua = "ĐẠT";
            }

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                query = 
                    "SELECT * FROM Diem " +
                        "LEFT JOIN SinhVien ON Diem.sinhvien_id = SinhVien.id " +
                        "LEFT JOIN MonHoc ON Diem.monhoc_id = MonHoc.id " +
                     "WHERE SinhVien.mssv = N'" + mssv + "' AND MonHoc.tenMonHoc = N'" + mon + "'";

                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    dlr = MessageBox.Show("Sinh viên đã có điểm trong danh sách!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK) textBoxMSSV.Focus();
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;

                    query = 
                        "INSERT INTO Diem (diemLan1, diemLan2, ketQua, sinhvien_id, monhoc_id) " +
                        "SELECT N'" + diemLan1 + "', N'" + diemLan2 + "', N'" + ketQua + "', " +
                            "(SELECT id FROM SinhVien WHERE SinhVien.mssv = N'" + mssv + "'), " +
                            "(SELECT id FROM MonHoc WHERE MonHoc.tenMonHoc = N'" + mon + "')";

                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm điểm cho sinh viên!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ShowList();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                id = textBoxId.Text.Trim();
                mssv = textBoxMSSV.Text.Trim();
                diemLan1 = textBoxDiemLan1.Text.Trim();
                diemLan2 = textBoxDiemLan2.Text.Trim();
                mon = comboBoxMonHoc.Text.Trim();

                ketQua = "KHÔNG ĐẠT";
                if (diemLan2 == "")
                {
                    if (Int32.Parse(diemLan1) >= 5) ketQua = "ĐẠT";
                }
                else if (diemLan2 != "")
                {
                    if (Int32.Parse(diemLan1) >= 5 || Int32.Parse(diemLan2) >= 5) ketQua = "ĐẠT";
                }

                try
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        command = new SqlCommand();
                        command.Connection = connection;
                        query = 
                            "UPDATE Diem " +
                            "SET diemLan1 = N'" + diemLan1 + "', diemLan2 = N'" + diemLan2 + "', " +
                                "ketQua = N'" + ketQua + "' " +
                            "WhERE id = " + id + " ";
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã cập nhật!", "Thông báo", MessageBoxButtons.OK, 
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
            else
            {
                MessageBox.Show("Vui lòng chọn Sinh viên!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
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
                    DialogResult dlr = MessageBox.Show("Bạn đã chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show("Vui lòng chọn Sinh viên!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            mon = comboBoxMonHoc.Text.Trim();
            mssv = textBoxMSSV.Text.Trim();
            hoten = textBoxName.Text.Trim();
            query =
                "SELECT d.id, s.mssv, s.hoTen, d.diemLan1, d.diemLan2, d.ketQua " +
                "FROM Diem d " +
                    "LEFT JOIN MonHoc m ON d.monhoc_id = m.id " +
                    "LEFT JOIN SinhVien s ON d.sinhvien_id = s.id " +
                "WHERE s.mssv Like N'%" + mssv + "%' OR s.hoTen Like N'%" + hoten + "%' AND m.tenMonHoc = N'" + mon + "' ";

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

        private void textBoxDiemLan2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
