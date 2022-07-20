

namespace UniversityManagementSystem
{
    public partial class FormIndex : Form
    {
        public FormIndex()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormLogin();
            form.ShowDialog();
            this.Hide();
            this.Show();
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {

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
    }
}
