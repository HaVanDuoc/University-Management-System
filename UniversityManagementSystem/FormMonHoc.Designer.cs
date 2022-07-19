namespace UniversityManagementSystem
{
    partial class FormMonHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonHoc));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewList = new System.Windows.Forms.ListView();
            this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSoTinChi = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSoTinChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExit);
            this.groupBox3.Controls.Add(this.buttonDelete);
            this.groupBox3.Controls.Add(this.buttonEdit);
            this.groupBox3.Controls.Add(this.buttonAdd);
            this.groupBox3.Controls.Add(this.listViewList);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(395, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(874, 496);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.ForeColor = System.Drawing.Color.SandyBrown;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(693, 426);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonExit.Size = new System.Drawing.Size(165, 55);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Thoát";
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.ForeColor = System.Drawing.Color.Brown;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.Location = new System.Drawing.Point(357, 426);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonDelete.Size = new System.Drawing.Size(165, 55);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.Location = new System.Drawing.Point(186, 426);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonEdit.Size = new System.Drawing.Size(165, 55);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Chỉnh sửa";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.Location = new System.Drawing.Point(15, 426);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAdd.Size = new System.Drawing.Size(165, 55);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Thêm mới";
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listViewList
            // 
            this.listViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderSoTinChi});
            this.listViewList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewList.Location = new System.Drawing.Point(15, 29);
            this.listViewList.Name = "listViewList";
            this.listViewList.Size = new System.Drawing.Size(843, 381);
            this.listViewList.TabIndex = 0;
            this.listViewList.UseCompatibleStateImageBehavior = false;
            this.listViewList.View = System.Windows.Forms.View.Details;
            this.listViewList.SelectedIndexChanged += new System.EventHandler(this.listViewList_SelectedIndexChanged);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Môn";
            this.columnHeaderName.Width = 350;
            // 
            // columnHeaderSoTinChi
            // 
            this.columnHeaderSoTinChi.Text = "Số Tín Chỉ";
            this.columnHeaderSoTinChi.Width = 200;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(395, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quản Lý Thông Tin Môn Học";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(1077, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonSearch.Size = new System.Drawing.Size(157, 53);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(396, 29);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Bạn đang tìm gì?";
            this.textBoxSearch.Size = new System.Drawing.Size(672, 45);
            this.textBoxSearch.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.Location = new System.Drawing.Point(65, 426);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonClear.Size = new System.Drawing.Size(235, 55);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Làm mới";
            this.buttonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSoTinChi);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Controls.Add(this.textBoxId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(11, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 496);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // textBoxSoTinChi
            // 
            this.textBoxSoTinChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSoTinChi.Location = new System.Drawing.Point(142, 140);
            this.textBoxSoTinChi.Name = "textBoxSoTinChi";
            this.textBoxSoTinChi.Size = new System.Drawing.Size(230, 30);
            this.textBoxSoTinChi.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số tín chỉ:";
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.Location = new System.Drawing.Point(142, 95);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(230, 30);
            this.textBoxName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên môn:";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1255, 112);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // FormMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMonHoc";
            this.Load += new System.EventHandler(this.FormMonHoc_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox3;
        private Button buttonExit;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonAdd;
        private ListView listViewList;
        private ColumnHeader columnHeaderID;
        private ColumnHeader columnHeaderName;
        private Label label1;
        private Button buttonSearch;
        private TextBox textBoxSearch;
        private Button buttonClear;
        private GroupBox groupBox2;
        private TextBox textBoxId;
        private Label label5;
        private TextBox textBoxName;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox textBoxSoTinChi;
        private Label label3;
        private ColumnHeader columnHeaderSoTinChi;
    }
}