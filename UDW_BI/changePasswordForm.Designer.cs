namespace UDW_BI
{
    partial class changePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePasswordForm));
            this.gboxAdd = new System.Windows.Forms.GroupBox();
            this.txtRetypeNew = new System.Windows.Forms.TextBox();
            this.lblReNewPW = new System.Windows.Forms.Label();
            this.txtNewPW = new System.Windows.Forms.TextBox();
            this.lblNewPW = new System.Windows.Forms.Label();
            this.CmdBtnCancel = new System.Windows.Forms.Button();
            this.CmdBtnOk = new System.Windows.Forms.Button();
            this.txtOldPw = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.LblPw = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.gboxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxAdd
            // 
            this.gboxAdd.Controls.Add(this.txtRetypeNew);
            this.gboxAdd.Controls.Add(this.lblReNewPW);
            this.gboxAdd.Controls.Add(this.txtNewPW);
            this.gboxAdd.Controls.Add(this.lblNewPW);
            this.gboxAdd.Controls.Add(this.CmdBtnCancel);
            this.gboxAdd.Controls.Add(this.CmdBtnOk);
            this.gboxAdd.Controls.Add(this.txtOldPw);
            this.gboxAdd.Controls.Add(this.txtName);
            this.gboxAdd.Controls.Add(this.LblPw);
            this.gboxAdd.Controls.Add(this.LblName);
            this.gboxAdd.Location = new System.Drawing.Point(27, 32);
            this.gboxAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gboxAdd.Name = "gboxAdd";
            this.gboxAdd.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gboxAdd.Size = new System.Drawing.Size(554, 299);
            this.gboxAdd.TabIndex = 4;
            this.gboxAdd.TabStop = false;
            this.gboxAdd.Text = "Change Password";
            // 
            // txtRetypeNew
            // 
            this.txtRetypeNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetypeNew.Location = new System.Drawing.Point(257, 192);
            this.txtRetypeNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtRetypeNew.MaxLength = 15;
            this.txtRetypeNew.Name = "txtRetypeNew";
            this.txtRetypeNew.PasswordChar = '*';
            this.txtRetypeNew.Size = new System.Drawing.Size(208, 22);
            this.txtRetypeNew.TabIndex = 3;
            // 
            // lblReNewPW
            // 
            this.lblReNewPW.AutoSize = true;
            this.lblReNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReNewPW.Location = new System.Drawing.Point(35, 192);
            this.lblReNewPW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReNewPW.Name = "lblReNewPW";
            this.lblReNewPW.Size = new System.Drawing.Size(173, 16);
            this.lblReNewPW.TabIndex = 12;
            this.lblReNewPW.Text = "&Re-type New Password:";
            // 
            // txtNewPW
            // 
            this.txtNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPW.Location = new System.Drawing.Point(257, 145);
            this.txtNewPW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNewPW.MaxLength = 15;
            this.txtNewPW.Name = "txtNewPW";
            this.txtNewPW.PasswordChar = '*';
            this.txtNewPW.Size = new System.Drawing.Size(208, 22);
            this.txtNewPW.TabIndex = 2;
            // 
            // lblNewPW
            // 
            this.lblNewPW.AutoSize = true;
            this.lblNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPW.Location = new System.Drawing.Point(94, 145);
            this.lblNewPW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewPW.Name = "lblNewPW";
            this.lblNewPW.Size = new System.Drawing.Size(114, 16);
            this.lblNewPW.TabIndex = 10;
            this.lblNewPW.Text = "&New Password:";
            // 
            // CmdBtnCancel
            // 
            this.CmdBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnCancel.Image")));
            this.CmdBtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnCancel.Location = new System.Drawing.Point(362, 239);
            this.CmdBtnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmdBtnCancel.Name = "CmdBtnCancel";
            this.CmdBtnCancel.Size = new System.Drawing.Size(121, 43);
            this.CmdBtnCancel.TabIndex = 5;
            this.CmdBtnCancel.Text = "&Cancel";
            this.CmdBtnCancel.UseVisualStyleBackColor = true;
            this.CmdBtnCancel.Click += new System.EventHandler(this.CmdBtnCancel_Click);
            // 
            // CmdBtnOk
            // 
            this.CmdBtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CmdBtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnOk.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnOk.Image")));
            this.CmdBtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnOk.Location = new System.Drawing.Point(228, 239);
            this.CmdBtnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmdBtnOk.Name = "CmdBtnOk";
            this.CmdBtnOk.Size = new System.Drawing.Size(121, 43);
            this.CmdBtnOk.TabIndex = 4;
            this.CmdBtnOk.Text = "&Ok";
            this.CmdBtnOk.UseVisualStyleBackColor = true;
            this.CmdBtnOk.Click += new System.EventHandler(this.CmdBtnOk_Click);
            // 
            // txtOldPw
            // 
            this.txtOldPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPw.Location = new System.Drawing.Point(257, 97);
            this.txtOldPw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtOldPw.MaxLength = 15;
            this.txtOldPw.Name = "txtOldPw";
            this.txtOldPw.PasswordChar = '*';
            this.txtOldPw.Size = new System.Drawing.Size(208, 22);
            this.txtOldPw.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(257, 44);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 22);
            this.txtName.TabIndex = 0;
            // 
            // LblPw
            // 
            this.LblPw.AutoSize = true;
            this.LblPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPw.Location = new System.Drawing.Point(75, 98);
            this.LblPw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPw.Name = "LblPw";
            this.LblPw.Size = new System.Drawing.Size(133, 16);
            this.LblPw.TabIndex = 8;
            this.LblPw.Text = "&Current Password:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(128, 45);
            this.LblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(90, 16);
            this.LblName.TabIndex = 7;
            this.LblName.Text = "&User Name:";
            // 
            // changePasswordForm
            // 
            this.AcceptButton = this.CmdBtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdBtnCancel;
            this.ClientSize = new System.Drawing.Size(617, 362);
            this.Controls.Add(this.gboxAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changePasswordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.gboxAdd.ResumeLayout(false);
            this.gboxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxAdd;
        private System.Windows.Forms.TextBox txtNewPW;
        private System.Windows.Forms.Label lblNewPW;
        private System.Windows.Forms.Button CmdBtnCancel;
        private System.Windows.Forms.Button CmdBtnOk;
        private System.Windows.Forms.TextBox txtOldPw;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label LblPw;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox txtRetypeNew;
        private System.Windows.Forms.Label lblReNewPW;
    }
}