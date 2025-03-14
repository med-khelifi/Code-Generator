namespace CodeGenerator_Project
{
    partial class frmConnection
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
            this.txtServer = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new Guna.UI2.WinForms.Guna2Button();
            this.txtUserID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.pbConnecting = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.chkRememberMe = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.BorderColor = System.Drawing.Color.DarkGray;
            this.txtServer.BorderRadius = 10;
            this.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServer.DefaultText = "";
            this.txtServer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtServer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtServer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServer.DisabledState.Parent = this.txtServer;
            this.txtServer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServer.FocusedState.Parent = this.txtServer;
            this.txtServer.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.HoverState.Parent = this.txtServer;
            this.txtServer.Location = new System.Drawing.Point(254, 89);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtServer.Name = "txtServer";
            this.txtServer.PasswordChar = '\0';
            this.txtServer.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtServer.PlaceholderText = "";
            this.txtServer.SelectedText = "";
            this.txtServer.ShadowDecoration.Parent = this.txtServer;
            this.txtServer.Size = new System.Drawing.Size(312, 41);
            this.txtServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password :";
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
            this.btnConnect.Location = new System.Drawing.Point(283, 301);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.ShadowDecoration.Parent = this.btnConnect;
            this.btnConnect.Size = new System.Drawing.Size(180, 45);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.txtUserID.BorderRadius = 10;
            this.txtUserID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserID.DefaultText = "";
            this.txtUserID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.DisabledState.Parent = this.txtUserID;
            this.txtUserID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.FocusedState.Parent = this.txtUserID;
            this.txtUserID.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.HoverState.Parent = this.txtUserID;
            this.txtUserID.Location = new System.Drawing.Point(254, 146);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '\0';
            this.txtUserID.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtUserID.PlaceholderText = "";
            this.txtUserID.SelectedText = "";
            this.txtUserID.ShadowDecoration.Parent = this.txtUserID;
            this.txtUserID.Size = new System.Drawing.Size(312, 41);
            this.txtUserID.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.Location = new System.Drawing.Point(254, 205);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new System.Drawing.Size(312, 41);
            this.txtPassword.TabIndex = 3;
            // 
            // pbConnecting
            // 
            this.pbConnecting.AutoStart = true;
            this.pbConnecting.CircleSize = 1F;
            this.pbConnecting.Location = new System.Drawing.Point(338, 289);
            this.pbConnecting.Margin = new System.Windows.Forms.Padding(4);
            this.pbConnecting.Name = "pbConnecting";
            this.pbConnecting.ProgressColor = System.Drawing.Color.Black;
            this.pbConnecting.Size = new System.Drawing.Size(68, 68);
            this.pbConnecting.TabIndex = 5;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRememberMe.CheckedState.BorderRadius = 2;
            this.chkRememberMe.CheckedState.BorderThickness = 0;
            this.chkRememberMe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRememberMe.CheckedState.Parent = this.chkRememberMe;
            this.chkRememberMe.Location = new System.Drawing.Point(254, 255);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.ShadowDecoration.Parent = this.chkRememberMe;
            this.chkRememberMe.Size = new System.Drawing.Size(25, 22);
            this.chkRememberMe.TabIndex = 7;
            this.chkRememberMe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkRememberMe.UncheckedState.BorderRadius = 2;
            this.chkRememberMe.UncheckedState.BorderThickness = 0;
            this.chkRememberMe.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkRememberMe.UncheckedState.Parent = this.chkRememberMe;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Remember me";
            // 
            // frmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.pbConnecting);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnConnect;
        private Guna.UI2.WinForms.Guna2TextBox txtUserID;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2ProgressIndicator pbConnecting;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chkRememberMe;
        private System.Windows.Forms.Label label4;
    }
}

