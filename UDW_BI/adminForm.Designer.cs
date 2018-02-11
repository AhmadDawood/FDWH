namespace UDW_BI
{
    partial class adminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminForm));
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.rbtnRemove = new System.Windows.Forms.RadioButton();
            this.gboxChoices = new System.Windows.Forms.GroupBox();
            this.rbtnChangePW = new System.Windows.Forms.RadioButton();
            this.gboxAdd = new System.Windows.Forms.GroupBox();
            this.CmdBtnOk = new System.Windows.Forms.Button();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.LblPw = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.CmdClose = new System.Windows.Forms.Button();
            this.gboxChoices.SuspendLayout();
            this.gboxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Location = new System.Drawing.Point(15, 40);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(196, 20);
            this.rbtnAdd.TabIndex = 1;
            this.rbtnAdd.TabStop = true;
            this.rbtnAdd.Text = "&Add New Executive User";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            this.rbtnAdd.Click += new System.EventHandler(this.rbtnAdd_Click);
            // 
            // rbtnRemove
            // 
            this.rbtnRemove.AutoSize = true;
            this.rbtnRemove.Location = new System.Drawing.Point(15, 76);
            this.rbtnRemove.Name = "rbtnRemove";
            this.rbtnRemove.Size = new System.Drawing.Size(250, 20);
            this.rbtnRemove.TabIndex = 2;
            this.rbtnRemove.TabStop = true;
            this.rbtnRemove.Text = "&Remove Existing Executive User";
            this.rbtnRemove.UseVisualStyleBackColor = true;
            this.rbtnRemove.Click += new System.EventHandler(this.rbtnRemove_Click);
            // 
            // gboxChoices
            // 
            this.gboxChoices.Controls.Add(this.rbtnChangePW);
            this.gboxChoices.Controls.Add(this.rbtnAdd);
            this.gboxChoices.Controls.Add(this.rbtnRemove);
            this.gboxChoices.Location = new System.Drawing.Point(61, 69);
            this.gboxChoices.Name = "gboxChoices";
            this.gboxChoices.Size = new System.Drawing.Size(591, 162);
            this.gboxChoices.TabIndex = 2;
            this.gboxChoices.TabStop = false;
            this.gboxChoices.Text = "User Management Tasks";
            // 
            // rbtnChangePW
            // 
            this.rbtnChangePW.AutoSize = true;
            this.rbtnChangePW.Location = new System.Drawing.Point(15, 111);
            this.rbtnChangePW.Name = "rbtnChangePW";
            this.rbtnChangePW.Size = new System.Drawing.Size(151, 20);
            this.rbtnChangePW.TabIndex = 3;
            this.rbtnChangePW.TabStop = true;
            this.rbtnChangePW.Text = "&Change Password";
            this.rbtnChangePW.UseVisualStyleBackColor = true;
            this.rbtnChangePW.Click += new System.EventHandler(this.rbtnChangePW_Click);
            // 
            // gboxAdd
            // 
            this.gboxAdd.Controls.Add(this.CmdBtnOk);
            this.gboxAdd.Controls.Add(this.txtPw);
            this.gboxAdd.Controls.Add(this.txtName);
            this.gboxAdd.Controls.Add(this.LblPw);
            this.gboxAdd.Controls.Add(this.LblName);
            this.gboxAdd.Location = new System.Drawing.Point(61, 237);
            this.gboxAdd.Name = "gboxAdd";
            this.gboxAdd.Size = new System.Drawing.Size(591, 188);
            this.gboxAdd.TabIndex = 3;
            this.gboxAdd.TabStop = false;
            this.gboxAdd.Text = "Add New User";
            // 
            // CmdBtnOk
            // 
            this.CmdBtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnOk.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnOk.Image")));
            this.CmdBtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnOk.Location = new System.Drawing.Point(264, 134);
            this.CmdBtnOk.Name = "CmdBtnOk";
            this.CmdBtnOk.Size = new System.Drawing.Size(157, 37);
            this.CmdBtnOk.TabIndex = 6;
            this.CmdBtnOk.Text = "A&dd User";
            this.CmdBtnOk.UseVisualStyleBackColor = true;
            this.CmdBtnOk.Click += new System.EventHandler(this.CmdBtnOk_Click);
            // 
            // txtPw
            // 
            this.txtPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPw.Location = new System.Drawing.Point(264, 92);
            this.txtPw.MaxLength = 15;
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(157, 22);
            this.txtPw.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(264, 45);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 22);
            this.txtName.TabIndex = 4;
            // 
            // LblPw
            // 
            this.LblPw.AutoSize = true;
            this.LblPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPw.Location = new System.Drawing.Point(130, 92);
            this.LblPw.Name = "LblPw";
            this.LblPw.Size = new System.Drawing.Size(80, 16);
            this.LblPw.TabIndex = 8;
            this.LblPw.Text = "&Password:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(124, 45);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(90, 16);
            this.LblName.TabIndex = 7;
            this.LblName.Text = "&User Name:";
            // 
            // CmdClose
            // 
            this.CmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CmdClose.Image = ((System.Drawing.Image)(resources.GetObject("CmdClose.Image")));
            this.CmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdClose.Location = new System.Drawing.Point(492, 27);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(157, 37);
            this.CmdClose.TabIndex = 0;
            this.CmdClose.Text = "E&xit Application";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(718, 456);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.gboxAdd);
            this.Controls.Add(this.gboxChoices);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adminForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDW_BI : User Management";
            this.Load += new System.EventHandler(this.adminForm_Load);
            this.gboxChoices.ResumeLayout(false);
            this.gboxChoices.PerformLayout();
            this.gboxAdd.ResumeLayout(false);
            this.gboxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.RadioButton rbtnRemove;
        private System.Windows.Forms.GroupBox gboxChoices;
        private System.Windows.Forms.GroupBox gboxAdd;
        private System.Windows.Forms.Button CmdBtnOk;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label LblPw;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.RadioButton rbtnChangePW;
        private System.Windows.Forms.Button CmdClose;

    }
}