namespace CodeGenerator_Project.Connection
{
    partial class frmMain
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
            this.cbDatabases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.clDatabaseTabels = new System.Windows.Forms.CheckedListBox();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.txtPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chkCheckAllList = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnInlineSQL = new System.Windows.Forms.RadioButton();
            this.rbtnStordProcedure = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database :";
            // 
            // cbDatabases
            // 
            this.cbDatabases.BackColor = System.Drawing.Color.Transparent;
            this.cbDatabases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.FocusedColor = System.Drawing.Color.Empty;
            this.cbDatabases.FocusedState.Parent = this.cbDatabases;
            this.cbDatabases.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDatabases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.HoverState.Parent = this.cbDatabases;
            this.cbDatabases.ItemHeight = 30;
            this.cbDatabases.ItemsAppearance.Parent = this.cbDatabases;
            this.cbDatabases.Location = new System.Drawing.Point(195, 69);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.ShadowDecoration.Parent = this.cbDatabases;
            this.cbDatabases.Size = new System.Drawing.Size(400, 36);
            this.cbDatabases.TabIndex = 3;
            this.cbDatabases.SelectedIndexChanged += new System.EventHandler(this.cbDatabases_SelectedIndexChanged);
            // 
            // clDatabaseTabels
            // 
            this.clDatabaseTabels.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDatabaseTabels.FormattingEnabled = true;
            this.clDatabaseTabels.Location = new System.Drawing.Point(195, 155);
            this.clDatabaseTabels.Name = "clDatabaseTabels";
            this.clDatabaseTabels.Size = new System.Drawing.Size(400, 284);
            this.clDatabaseTabels.TabIndex = 4;
            this.clDatabaseTabels.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clDatabaseTabels_ItemCheck);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.BorderRadius = 15;
            this.btnBrowse.BorderThickness = 3;
            this.btnBrowse.CheckedState.Parent = this.btnBrowse;
            this.btnBrowse.CustomImages.Parent = this.btnBrowse;
            this.btnBrowse.FillColor = System.Drawing.Color.Silver;
            this.btnBrowse.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.Black;
            this.btnBrowse.HoverState.Parent = this.btnBrowse;
            this.btnBrowse.Location = new System.Drawing.Point(514, 455);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.ShadowDecoration.Parent = this.btnBrowse;
            this.btnBrowse.Size = new System.Drawing.Size(117, 45);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.BorderColor = System.Drawing.Color.DarkGray;
            this.txtPath.BorderRadius = 10;
            this.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPath.DefaultText = "";
            this.txtPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPath.DisabledState.Parent = this.txtPath;
            this.txtPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPath.FocusedState.Parent = this.txtPath;
            this.txtPath.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.HoverState.Parent = this.txtPath;
            this.txtPath.Location = new System.Drawing.Point(195, 455);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPath.PlaceholderText = "";
            this.txtPath.SelectedText = "";
            this.txtPath.ShadowDecoration.Parent = this.txtPath;
            this.txtPath.Size = new System.Drawing.Size(312, 45);
            this.txtPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "path :";
            // 
            // btnNext
            // 
            this.btnNext.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.BorderRadius = 15;
            this.btnNext.BorderThickness = 3;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.Silver;
            this.btnNext.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Location = new System.Drawing.Point(280, 518);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(121, 45);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // chkCheckAllList
            // 
            this.chkCheckAllList.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckAllList.Location = new System.Drawing.Point(195, 111);
            this.chkCheckAllList.Name = "chkCheckAllList";
            this.chkCheckAllList.Size = new System.Drawing.Size(159, 38);
            this.chkCheckAllList.TabIndex = 11;
            this.chkCheckAllList.Text = "check all";
            this.chkCheckAllList.UseVisualStyleBackColor = true;
            this.chkCheckAllList.CheckedChanged += new System.EventHandler(this.chkCheckAllList_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnStordProcedure);
            this.groupBox1.Controls.Add(this.rbtnInlineSQL);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 283);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gnerate With";
            // 
            // rbtnInlineSQL
            // 
            this.rbtnInlineSQL.AutoSize = true;
            this.rbtnInlineSQL.Checked = true;
            this.rbtnInlineSQL.Location = new System.Drawing.Point(7, 33);
            this.rbtnInlineSQL.Name = "rbtnInlineSQL";
            this.rbtnInlineSQL.Size = new System.Drawing.Size(86, 25);
            this.rbtnInlineSQL.TabIndex = 0;
            this.rbtnInlineSQL.TabStop = true;
            this.rbtnInlineSQL.Text = "Inline SQL";
            this.rbtnInlineSQL.UseVisualStyleBackColor = true;
            // 
            // rbtnStordProcedure
            // 
            this.rbtnStordProcedure.AutoSize = true;
            this.rbtnStordProcedure.Location = new System.Drawing.Point(7, 59);
            this.rbtnStordProcedure.Name = "rbtnStordProcedure";
            this.rbtnStordProcedure.Size = new System.Drawing.Size(133, 25);
            this.rbtnStordProcedure.TabIndex = 1;
            this.rbtnStordProcedure.Text = "Stored Procedures";
            this.rbtnStordProcedure.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(684, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCheckAllList);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDatabases);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.clDatabaseTabels);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbDatabases;
        private System.Windows.Forms.CheckedListBox clDatabaseTabels;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private Guna.UI2.WinForms.Guna2TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkCheckAllList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnStordProcedure;
        private System.Windows.Forms.RadioButton rbtnInlineSQL;
    }
}