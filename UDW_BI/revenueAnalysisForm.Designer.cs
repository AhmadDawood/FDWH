namespace UDW_BI
{
    partial class revenueAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(revenueAnalysisForm));
            this.gboxRevenueFacts = new System.Windows.Forms.GroupBox();
            this.dataGridRevenue = new System.Windows.Forms.DataGridView();
            this.gboxDimDetails = new System.Windows.Forms.GroupBox();
            this.dataGridDimDetails = new System.Windows.Forms.DataGridView();
            this.CmdClose = new System.Windows.Forms.Button();
            this.gboxRevenueFacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRevenue)).BeginInit();
            this.gboxDimDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDimDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxRevenueFacts
            // 
            this.gboxRevenueFacts.Controls.Add(this.dataGridRevenue);
            this.gboxRevenueFacts.Location = new System.Drawing.Point(12, 65);
            this.gboxRevenueFacts.Name = "gboxRevenueFacts";
            this.gboxRevenueFacts.Size = new System.Drawing.Size(1330, 397);
            this.gboxRevenueFacts.TabIndex = 1;
            this.gboxRevenueFacts.TabStop = false;
            this.gboxRevenueFacts.Text = "Revenue Facts";
            // 
            // dataGridRevenue
            // 
            this.dataGridRevenue.AllowUserToAddRows = false;
            this.dataGridRevenue.AllowUserToDeleteRows = false;
            this.dataGridRevenue.AllowUserToOrderColumns = true;
            this.dataGridRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridRevenue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRevenue.Location = new System.Drawing.Point(11, 34);
            this.dataGridRevenue.MultiSelect = false;
            this.dataGridRevenue.Name = "dataGridRevenue";
            this.dataGridRevenue.ReadOnly = true;
            this.dataGridRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridRevenue.Size = new System.Drawing.Size(1301, 345);
            this.dataGridRevenue.TabIndex = 1;
            this.dataGridRevenue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRevenue_CellClick);
            this.dataGridRevenue.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRevenue_CellMouseLeave);
            this.dataGridRevenue.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridRevenue_CellMouseMove);
            // 
            // gboxDimDetails
            // 
            this.gboxDimDetails.Controls.Add(this.dataGridDimDetails);
            this.gboxDimDetails.Location = new System.Drawing.Point(12, 484);
            this.gboxDimDetails.Name = "gboxDimDetails";
            this.gboxDimDetails.Size = new System.Drawing.Size(1326, 165);
            this.gboxDimDetails.TabIndex = 2;
            this.gboxDimDetails.TabStop = false;
            this.gboxDimDetails.Text = "Dimensional Detail";
            // 
            // dataGridDimDetails
            // 
            this.dataGridDimDetails.AllowUserToAddRows = false;
            this.dataGridDimDetails.AllowUserToDeleteRows = false;
            this.dataGridDimDetails.AllowUserToOrderColumns = true;
            this.dataGridDimDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDimDetails.Location = new System.Drawing.Point(11, 23);
            this.dataGridDimDetails.Name = "dataGridDimDetails";
            this.dataGridDimDetails.ReadOnly = true;
            this.dataGridDimDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDimDetails.Size = new System.Drawing.Size(1301, 133);
            this.dataGridDimDetails.TabIndex = 1;
            // 
            // CmdClose
            // 
            this.CmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdClose.Image = ((System.Drawing.Image)(resources.GetObject("CmdClose.Image")));
            this.CmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdClose.Location = new System.Drawing.Point(1181, 26);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(157, 37);
            this.CmdClose.TabIndex = 3;
            this.CmdClose.Text = "&Close";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // revenueAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdClose;
            this.ClientSize = new System.Drawing.Size(1354, 677);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.gboxDimDetails);
            this.Controls.Add(this.gboxRevenueFacts);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "revenueAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Revenue Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.revenueAnalysisForm_Load);
            this.gboxRevenueFacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRevenue)).EndInit();
            this.gboxDimDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDimDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxRevenueFacts;
        private System.Windows.Forms.DataGridView dataGridRevenue;
        private System.Windows.Forms.GroupBox gboxDimDetails;
        private System.Windows.Forms.DataGridView dataGridDimDetails;
        private System.Windows.Forms.Button CmdClose;
    }
}