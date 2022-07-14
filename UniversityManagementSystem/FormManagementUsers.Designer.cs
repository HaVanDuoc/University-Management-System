namespace UniversityManagementSystem
{
    partial class FormManagementUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFullname = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewListUser = new System.Windows.Forms.ListView();
            this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFullname = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUsername = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPassword = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(424, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Thông Tin Người Dùng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1258, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // buttonSearch
            // 
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(1017, 39);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonSearch.Size = new System.Drawing.Size(126, 30);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(510, 39);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Bạn đang tìm gì?";
            this.textBoxSearch.Size = new System.Drawing.Size(501, 30);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxFullname);
            this.groupBox2.Controls.Add(this.textBoxPassword);
            this.groupBox2.Controls.Add(this.textBoxUsername);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 496);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // textBoxId
            // 
            this.textBoxId.ForeColor = System.Drawing.Color.Red;
            this.textBoxId.Location = new System.Drawing.Point(142, 50);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(230, 30);
            this.textBoxId.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "ID:";
            // 
            // textBoxFullname
            // 
            this.textBoxFullname.Location = new System.Drawing.Point(142, 171);
            this.textBoxFullname.Name = "textBoxFullname";
            this.textBoxFullname.Size = new System.Drawing.Size(230, 30);
            this.textBoxFullname.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(142, 127);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(230, 30);
            this.textBoxPassword.TabIndex = 4;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(142, 86);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(230, 30);
            this.textBoxUsername.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Họ tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExit);
            this.groupBox3.Controls.Add(this.buttonDelete);
            this.groupBox3.Controls.Add(this.buttonEdit);
            this.groupBox3.Controls.Add(this.buttonAdd);
            this.groupBox3.Controls.Add(this.listViewListUser);
            this.groupBox3.Location = new System.Drawing.Point(396, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(874, 496);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // buttonExit
            // 
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(693, 426);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonExit.Size = new System.Drawing.Size(165, 55);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Thoát";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(357, 426);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonDelete.Size = new System.Drawing.Size(165, 55);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.Location = new System.Drawing.Point(186, 426);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonEdit.Size = new System.Drawing.Size(165, 55);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Chỉnh sửa";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(15, 426);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAdd.Size = new System.Drawing.Size(165, 55);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Thêm mới";
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listViewListUser
            // 
            this.listViewListUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderFullname,
            this.columnHeaderUsername,
            this.columnHeaderPassword});
            this.listViewListUser.Location = new System.Drawing.Point(15, 29);
            this.listViewListUser.Name = "listViewListUser";
            this.listViewListUser.Size = new System.Drawing.Size(843, 381);
            this.listViewListUser.TabIndex = 0;
            this.listViewListUser.UseCompatibleStateImageBehavior = false;
            this.listViewListUser.View = System.Windows.Forms.View.Details;
            this.listViewListUser.SelectedIndexChanged += new System.EventHandler(this.listViewListUser_SelectedIndexChanged);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            // 
            // columnHeaderFullname
            // 
            this.columnHeaderFullname.Text = "Họ tên";
            this.columnHeaderFullname.Width = 250;
            // 
            // columnHeaderUsername
            // 
            this.columnHeaderUsername.Text = "Tên đăng nhập";
            this.columnHeaderUsername.Width = 300;
            // 
            // columnHeaderPassword
            // 
            this.columnHeaderPassword.Text = "Mật khẩu";
            this.columnHeaderPassword.Width = 200;
            // 
            // FormManagementUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormManagementUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.FormManagementUsers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button buttonAdd;
        private ListView listViewListUser;
        private Button buttonExit;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonSearch;
        private TextBox textBoxSearch;
        private TextBox textBoxFullname;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Label label4;
        private Label label3;
        private Label label2;
        private ColumnHeader columnHeaderID;
        private ColumnHeader columnHeaderFullname;
        private ColumnHeader columnHeaderPassword;
        private ColumnHeader columnHeaderUsername;
        private TextBox textBoxId;
        private Label label5;
    }
}