namespace Wav2Amiga
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNote = new System.Windows.Forms.ComboBox();
            this.cbxMode = new System.Windows.Forms.ComboBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnApplyNote = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destination Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Conversion Mode";
            // 
            // cbxNote
            // 
            this.cbxNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNote.FormattingEnabled = true;
            this.cbxNote.Location = new System.Drawing.Point(108, 26);
            this.cbxNote.Name = "cbxNote";
            this.cbxNote.Size = new System.Drawing.Size(121, 21);
            this.cbxNote.TabIndex = 2;
            // 
            // cbxMode
            // 
            this.cbxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMode.FormattingEnabled = true;
            this.cbxMode.Location = new System.Drawing.Point(108, 56);
            this.cbxMode.Name = "cbxMode";
            this.cbxMode.Size = new System.Drawing.Size(121, 21);
            this.cbxMode.TabIndex = 2;
            this.cbxMode.SelectedIndexChanged += new System.EventHandler(this.cbxMode_SelectedIndexChanged);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowDrop = true;
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Note,
            this.Status});
            this.dgvItems.Location = new System.Drawing.Point(12, 130);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(696, 326);
            this.dgvItems.TabIndex = 3;
            this.dgvItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvItems_DragDrop);
            this.dgvItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvItems_DragEnter);
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "Filename";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 300;
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Drag and drop wav files.  Result is saved in the same folder with .8SVX extension" +
    ".";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(504, 95);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(633, 95);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnApplyNote
            // 
            this.btnApplyNote.Location = new System.Drawing.Point(238, 24);
            this.btnApplyNote.Name = "btnApplyNote";
            this.btnApplyNote.Size = new System.Drawing.Size(75, 23);
            this.btnApplyNote.TabIndex = 4;
            this.btnApplyNote.Text = "Apply Note";
            this.btnApplyNote.UseVisualStyleBackColor = true;
            this.btnApplyNote.Click += new System.EventHandler(this.btnApplyNote_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(235, 59);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(32, 13);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Cock";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 468);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnApplyNote);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.cbxMode);
            this.Controls.Add(this.cbxNote);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Wav2Amiga";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNote;
        private System.Windows.Forms.ComboBox cbxMode;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnApplyNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label lblMode;
    }
}

