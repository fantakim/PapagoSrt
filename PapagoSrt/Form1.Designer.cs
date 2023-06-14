namespace PapagoSrt
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvFile = new DataGridView();
            colNumber = new DataGridViewTextBoxColumn();
            colFilename = new DataGridViewTextBoxColumn();
            colCompleted = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            btnStart = new Button();
            btnRemoveAll = new Button();
            btnRemoveFile = new Button();
            btnAddFile = new Button();
            groupBox1 = new GroupBox();
            cbxSameFolder = new CheckBox();
            txtFolder = new TextBox();
            btnOpenFolder = new Button();
            btnChangeFolder = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFile).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFile
            // 
            dgvFile.AllowUserToAddRows = false;
            dgvFile.AllowUserToDeleteRows = false;
            dgvFile.AllowUserToResizeColumns = false;
            dgvFile.AllowUserToResizeRows = false;
            dgvFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFile.Columns.AddRange(new DataGridViewColumn[] { colNumber, colFilename, colCompleted });
            dgvFile.Location = new Point(12, 17);
            dgvFile.Margin = new Padding(3, 4, 3, 4);
            dgvFile.MultiSelect = false;
            dgvFile.Name = "dgvFile";
            dgvFile.ReadOnly = true;
            dgvFile.RowHeadersVisible = false;
            dgvFile.RowHeadersWidth = 62;
            dgvFile.RowTemplate.Height = 30;
            dgvFile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFile.ShowEditingIcon = false;
            dgvFile.Size = new Size(1062, 565);
            dgvFile.TabIndex = 0;
            dgvFile.DataBindingComplete += dgvFile_DataBindingComplete;
            dgvFile.DefaultValuesNeeded += dgvFile_DefaultValuesNeeded;
            dgvFile.KeyDown += dgvFile_KeyDown;
            // 
            // colNumber
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNumber.DefaultCellStyle = dataGridViewCellStyle1;
            colNumber.HeaderText = "No";
            colNumber.MinimumWidth = 8;
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;
            colNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            colNumber.Width = 40;
            // 
            // colFilename
            // 
            colFilename.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFilename.DataPropertyName = "Filename";
            colFilename.HeaderText = "파일";
            colFilename.MinimumWidth = 100;
            colFilename.Name = "colFilename";
            colFilename.ReadOnly = true;
            colFilename.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colCompleted
            // 
            colCompleted.DataPropertyName = "Status";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCompleted.DefaultCellStyle = dataGridViewCellStyle2;
            colCompleted.HeaderText = "상태";
            colCompleted.MinimumWidth = 100;
            colCompleted.Name = "colCompleted";
            colCompleted.ReadOnly = true;
            colCompleted.SortMode = DataGridViewColumnSortMode.NotSortable;
            colCompleted.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnStart);
            groupBox2.Controls.Add(btnRemoveAll);
            groupBox2.Controls.Add(btnRemoveFile);
            groupBox2.Controls.Add(btnAddFile);
            groupBox2.Location = new Point(12, 590);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1062, 115);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "대상 파일";
            // 
            // btnStart
            // 
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Location = new Point(848, 22);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(208, 85);
            btnStart.TabIndex = 3;
            btnStart.Text = "번역 시작";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.Location = new Point(244, 38);
            btnRemoveAll.Margin = new Padding(3, 4, 3, 4);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new Size(113, 60);
            btnRemoveAll.TabIndex = 2;
            btnRemoveAll.Text = "전체 제거";
            btnRemoveAll.UseVisualStyleBackColor = true;
            btnRemoveAll.Click += btnRemoveAll_Click;
            // 
            // btnRemoveFile
            // 
            btnRemoveFile.Location = new Point(125, 38);
            btnRemoveFile.Margin = new Padding(3, 4, 3, 4);
            btnRemoveFile.Name = "btnRemoveFile";
            btnRemoveFile.Size = new Size(113, 60);
            btnRemoveFile.TabIndex = 1;
            btnRemoveFile.Text = "선택 제거";
            btnRemoveFile.UseVisualStyleBackColor = true;
            btnRemoveFile.Click += btnRemoveFile_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(6, 38);
            btnAddFile.Margin = new Padding(3, 4, 3, 4);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(113, 60);
            btnAddFile.TabIndex = 0;
            btnAddFile.Text = "파일 추가";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbxSameFolder);
            groupBox1.Controls.Add(txtFolder);
            groupBox1.Controls.Add(btnOpenFolder);
            groupBox1.Controls.Add(btnChangeFolder);
            groupBox1.Location = new Point(12, 732);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1062, 115);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "저장 폴더";
            // 
            // cbxSameFolder
            // 
            cbxSameFolder.AutoSize = true;
            cbxSameFolder.Location = new Point(843, 50);
            cbxSameFolder.Margin = new Padding(3, 4, 3, 4);
            cbxSameFolder.Name = "cbxSameFolder";
            cbxSameFolder.Size = new Size(170, 29);
            cbxSameFolder.TabIndex = 4;
            cbxSameFolder.Text = "원본폴더에 저장";
            cbxSameFolder.UseVisualStyleBackColor = true;
            cbxSameFolder.CheckedChanged += cbxSameFolder_CheckedChanged;
            // 
            // txtFolder
            // 
            txtFolder.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtFolder.Location = new Point(6, 39);
            txtFolder.Margin = new Padding(3, 4, 3, 4);
            txtFolder.Name = "txtFolder";
            txtFolder.ReadOnly = true;
            txtFolder.Size = new Size(580, 45);
            txtFolder.TabIndex = 3;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(711, 39);
            btnOpenFolder.Margin = new Padding(3, 4, 3, 4);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(113, 46);
            btnOpenFolder.TabIndex = 1;
            btnOpenFolder.Text = "폴더 열기";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // btnChangeFolder
            // 
            btnChangeFolder.Location = new Point(592, 39);
            btnChangeFolder.Margin = new Padding(3, 4, 3, 4);
            btnChangeFolder.Name = "btnChangeFolder";
            btnChangeFolder.Size = new Size(113, 46);
            btnChangeFolder.TabIndex = 0;
            btnChangeFolder.Text = "폴더 변경";
            btnChangeFolder.UseVisualStyleBackColor = true;
            btnChangeFolder.Click += btnChangeFolder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 860);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(dgvFile);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "PapagoSrt";
            ((System.ComponentModel.ISupportInitialize)dgvFile).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFile;
        private GroupBox groupBox2;
        private Button btnRemoveAll;
        private Button btnRemoveFile;
        private Button btnAddFile;
        private GroupBox groupBox1;
        private TextBox txtFolder;
        private Button btnOpenFolder;
        private Button btnChangeFolder;
        private CheckBox cbxSameFolder;
        private Button btnStart;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colFilename;
        private DataGridViewTextBoxColumn colCompleted;
    }
}