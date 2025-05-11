namespace CodeGenerator_Project.Forms
{
    partial class frmGenerate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConnect = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTabels = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabels)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConnect.BorderRadius = 15;
            this.btnConnect.BorderThickness = 3;
            this.btnConnect.CheckedState.Parent = this.btnConnect;
            this.btnConnect.CustomImages.Parent = this.btnConnect;
            this.btnConnect.FillColor = System.Drawing.Color.Silver;
            this.btnConnect.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.HoverState.Parent = this.btnConnect;
            this.btnConnect.Location = new System.Drawing.Point(280, 393);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.ShadowDecoration.Parent = this.btnConnect;
            this.btnConnect.Size = new System.Drawing.Size(180, 45);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Generate";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dgvTabels
            // 
            this.dgvTabels.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvTabels.AllowUserToAddRows = false;
            this.dgvTabels.AllowUserToDeleteRows = false;
            this.dgvTabels.AllowUserToOrderColumns = true;
            this.dgvTabels.AllowUserToResizeColumns = false;
            this.dgvTabels.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTabels.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTabels.BackgroundColor = System.Drawing.Color.White;
            this.dgvTabels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTabels.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabels.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabels.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTabels.EnableHeadersVisualStyles = false;
            this.dgvTabels.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTabels.Location = new System.Drawing.Point(12, 82);
            this.dgvTabels.Name = "dgvTabels";
            this.dgvTabels.ReadOnly = true;
            this.dgvTabels.RowHeadersVisible = false;
            this.dgvTabels.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1);
            this.dgvTabels.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabels.RowTemplate.Height = 24;
            this.dgvTabels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabels.Size = new System.Drawing.Size(776, 296);
            this.dgvTabels.TabIndex = 8;
            this.dgvTabels.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvTabels.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTabels.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTabels.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTabels.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTabels.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTabels.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTabels.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTabels.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTabels.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvTabels.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvTabels.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTabels.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTabels.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvTabels.ThemeStyle.ReadOnly = true;
            this.dgvTabels.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTabels.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTabels.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvTabels.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTabels.ThemeStyle.RowsStyle.Height = 24;
            this.dgvTabels.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTabels.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "File to Generate :";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCount.Location = new System.Drawing.Point(7, 393);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(132, 27);
            this.lblFileCount.TabIndex = 10;
            this.lblFileCount.Text = "22 File(s)";
            this.lblFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTabels);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmGenerate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnConnect;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTabels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileCount;
    }
}