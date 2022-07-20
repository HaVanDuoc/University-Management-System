
using System.Data;
using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class FormMonHoc : Form
    {
        public FormMonHoc()
        {
            InitializeComponent();
        }

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private SqlDataReader reader;
        String table = GloabalVariables.tableMonHoc;
        String query;
        DialogResult dlr;
        String sotinchi;
        String tenmon;
        String id;

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

            query = "SELECT * FROM " + table + " ";
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
            textBoxSoTinChi.Text = "";
            textBoxName.Focus();
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
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

        private void listViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listViewList.FocusedItem.Index;
            if (i < 0) return;
            textBoxId.Text = listViewList.Items[i].Text;
            textBoxName.Text = listViewList.Items[i].SubItems[1].Text;
            textBoxSoTinChi.Text = listViewList.Items[i].SubItems[2].Text;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // ten mon
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                dlr = MessageBox.Show("Vui lòng nhập Tên môn học!", "Thông báo", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning);
                if (dlr == DialogResult.OK) textBoxName.Focus();
                return;
            }          

            id = textBoxId.Text.Trim();
            tenmon = textBoxName.Text.Trim();
            sotinchi = textBoxSoTinChi.Text.Trim();

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                query = "SELECT * FROM " + table + " WHERE tenMonHoc = N'" + tenmon + "' AND id != '" + id + "' ";
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    DialogResult dlr = MessageBox.Show("Đã có môn học này!", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    if (dlr == DialogResult.OK) textBoxName.Focus();
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand();
                    command.Connection = connection;

                    query = 
                        "INSERT INTO " + table + " (tenMonHoc, tinChi) " +
                        "VALUES (N'" + tenmon + "', N'" + sotinchi + "')";

                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm môn " + tenmon + "!", "Thông báo", MessageBoxButtons.OK,
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
                MessageBox.Show("Vui lòng chọn Môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxId.Text))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                id = textBoxId.Text.Trim();
                tenmon = textBoxName.Text.Trim();
                sotinchi = textBoxSoTinChi.Text.Trim();

                try
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    query = "SELECT * FROM " + table + " WHERE tenMonHoc = N'" + tenmon + "' AND id != '" + id + "' ";
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        dlr = MessageBox.Show("Đã có môn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dlr == DialogResult.OK) textBoxName.Focus();
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
                                "UPDATE " + table + " " +
                                "SET tenMonHoc = N'" + tenmon + "', tinChi = N'" + sotinchi + "' " +
                                "WhERE id = " + id + "";
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
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String searchData = textBoxSearch.Text;
            query = 
                "SELECT * " +
                "FROM MonHoc " +
                "WHERE tenMonHoc LIKE N'%" + searchData + "%' OR tinChi Like N'%" + searchData + "%' ";
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
    }
}
