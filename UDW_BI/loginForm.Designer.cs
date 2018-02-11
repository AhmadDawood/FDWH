namespace UDW_BI
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.grpboxLogin = new System.Windows.Forms.GroupBox();
            this.lboxType = new System.Windows.Forms.ListBox();
            this.LblType = new System.Windows.Forms.Label();
            this.CmdBtnCancel = new System.Windows.Forms.Button();
            this.CmdBtnOk = new System.Windows.Forms.Button();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.LblPw = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.grpboxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpboxLogin
            // 
            this.grpboxLogin.Controls.Add(this.lboxType);
            this.grpboxLogin.Controls.Add(this.LblType);
            this.grpboxLogin.Controls.Add(this.CmdBtnCancel);
            this.grpboxLogin.Controls.Add(this.CmdBtnOk);
            this.grpboxLogin.Controls.Add(this.txtPw);
            this.grpboxLogin.Controls.Add(this.txtName);
            this.grpboxLogin.Controls.Add(this.LblPw);
            this.grpboxLogin.Controls.Add(this.LblName);
            this.grpboxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxLogin.Location = new System.Drawing.Point(36, 24);
            this.grpboxLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpboxLogin.Name = "grpboxLogin";
            this.grpboxLogin.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpboxLogin.Size = new System.Drawing.Size(616, 312);
            this.grpboxLogin.TabIndex = 7;
            this.grpboxLogin.TabStop = false;
            this.grpboxLogin.Text = "User Login";
            // 
            // lboxType
            // 
            this.lboxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxType.FormattingEnabled = true;
            this.lboxType.ItemHeight = 16;
            this.lboxType.Items.AddRange(new object[] {
            "Executive",
            "Admin"});
            this.lboxType.Location = new System.Drawing.Point(275, 158);
            this.lboxType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lboxType.Name = "lboxType";
            this.lboxType.Size = new System.Drawing.Size(208, 36);
            this.lboxType.TabIndex = 11;
            this.lboxType.Enter += new System.EventHandler(this.lboxType_Enter);
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.Location = new System.Drawing.Point(89, 163);
            this.LblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(85, 16);
            this.LblType.TabIndex = 13;
            this.LblType.Text = "User Type:";
            // 
            // CmdBtnCancel
            // 
            this.CmdBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnCancel.Image")));
            this.CmdBtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnCancel.Location = new System.Drawing.Point(387, 226);
            this.CmdBtnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmdBtnCancel.Name = "CmdBtnCancel";
            this.CmdBtnCancel.Size = new System.Drawing.Size(121, 43);
            this.CmdBtnCancel.TabIndex = 14;
            this.CmdBtnCancel.Text = "&Cancel";
            this.CmdBtnCancel.UseVisualStyleBackColor = true;
            this.CmdBtnCancel.Click += new System.EventHandler(this.CmdBtnCancel_Click);
            // 
            // CmdBtnOk
            // 
            this.CmdBtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnOk.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnOk.Image")));
            this.CmdBtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnOk.Location = new System.Drawing.Point(257, 226);
            this.CmdBtnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmdBtnOk.Name = "CmdBtnOk";
            this.CmdBtnOk.Size = new System.Drawing.Size(121, 43);
            this.CmdBtnOk.TabIndex = 12;
            this.CmdBtnOk.Text = "&Ok";
            this.CmdBtnOk.UseVisualStyleBackColor = true;
            this.CmdBtnOk.Click += new System.EventHandler(this.CmdBtnOk_Click);
            // 
            // txtPw
            // 
            this.txtPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPw.Location = new System.Drawing.Point(275, 112);
            this.txtPw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPw.MaxLength = 15;
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(208, 22);
            this.txtPw.TabIndex = 10;
            this.txtPw.Enter += new System.EventHandler(this.txtPw_Enter);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(275, 58);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 22);
            this.txtName.TabIndex = 9;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // LblPw
            // 
            this.LblPw.AutoSize = true;
            this.LblPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPw.Location = new System.Drawing.Point(96, 112);
            this.LblPw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPw.Name = "LblPw";
            this.LblPw.Size = new System.Drawing.Size(80, 16);
            this.LblPw.TabIndex = 8;
            this.LblPw.Text = "Password:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(88, 58);
            this.LblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(90, 16);
            this.LblName.TabIndex = 7;
            this.LblName.Text = "User Name:";
            // 
            // loginForm
            // 
            this.AcceptButton = this.CmdBtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdBtnCancel;
            this.ClientSize = new System.Drawing.Size(689, 378);
            this.Controls.Add(this.grpboxLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.grpboxLogin.ResumeLayout(false);
            this.grpboxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxLogin;
        private System.Windows.Forms.ListBox lboxType;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Button CmdBtnCancel;
        private System.Windows.Forms.Button CmdBtnOk;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label LblPw;
        private System.Windows.Forms.Label LblName;

    }
}

