namespace UDW_BI
{
    partial class FormExpAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExpAnalysis));
            this.dataGridDimExpDetails = new System.Windows.Forms.DataGridView();
            this.gboxExpenseFacts = new System.Windows.Forms.GroupBox();
            this.dataGridExpense = new System.Windows.Forms.DataGridView();
            this.CmdClose = new System.Windows.Forms.Button();
            this.gboxDimExpDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDimExpDetails)).BeginInit();
            this.gboxExpenseFacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpense)).BeginInit();
            this.gboxDimExpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridDimExpDetails
            // 
            this.dataGridDimExpDetails.AllowUserToAddRows = false;
            this.dataGridDimExpDetails.AllowUserToDeleteRows = false;
            this.dataGridDimExpDetails.AllowUserToOrderColumns = true;
            this.dataGridDimExpDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridDimExpDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridDimExpDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDimExpDetails.Location = new System.Drawing.Point(12, 33);
            this.dataGridDimExpDetails.Name = "dataGridDimExpDetails";
            this.dataGridDimExpDetails.ReadOnly = true;
            this.dataGridDimExpDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDimExpDetails.Size = new System.Drawing.Size(1300, 142);
            this.dataGridDimExpDetails.TabIndex = 2;
            // 
            // gboxExpenseFacts
            // 
            this.gboxExpenseFacts.Controls.Add(this.dataGridExpense);
            this.gboxExpenseFacts.Location = new System.Drawing.Point(1, 51);
            this.gboxExpenseFacts.Name = "gboxExpenseFacts";
            this.gboxExpenseFacts.Size = new System.Drawing.Size(1334, 401);
            this.gboxExpenseFacts.TabIndex = 5;
            this.gboxExpenseFacts.TabStop = false;
            this.gboxExpenseFacts.Text = "Expense Facts";
            // 
            // dataGridExpense
            // 
            this.dataGridExpense.AllowUserToAddRows = false;
            this.dataGridExpense.AllowUserToDeleteRows = false;
            this.dataGridExpense.AllowUserToOrderColumns = true;
            this.dataGridExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridExpense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExpense.Location = new System.Drawing.Point(11, 21);
            this.dataGridExpense.MultiSelect = false;
            this.dataGridExpense.Name = "dataGridExpense";
            this.dataGridExpense.ReadOnly = true;
            this.dataGridExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridExpense.Size = new System.Drawing.Size(1303, 365);
            this.dataGridExpense.TabIndex = 1;
            this.dataGridExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridExpense_CellClick);
            this.dataGridExpense.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridExpense_CellMouseLeave);
            this.dataGridExpense.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridExpense_CellMouseMove);
            // 
            // CmdClose
            // 
            this.CmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdClose.Image = ((System.Drawing.Image)(resources.GetObject("CmdClose.Image")));
            this.CmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdClose.Location = new System.Drawing.Point(1155, 15);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(157, 37);
            this.CmdClose.TabIndex = 7;
            this.CmdClose.Text = "&Close";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // gboxDimExpDetails
            // 
            this.gboxDimExpDetails.Controls.Add(this.dataGridDimExpDetails);
            this.gboxDimExpDetails.Location = new System.Drawing.Point(3, 458);
            this.gboxDimExpDetails.Name = "gboxDimExpDetails";
            this.gboxDimExpDetails.Size = new System.Drawing.Size(1332, 192);
            this.gboxDimExpDetails.TabIndex = 6;
            this.gboxDimExpDetails.TabStop = false;
            this.gboxDimExpDetails.Text = "Dimensional Detail";
            // 
            // FormExpAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdClose;
            this.ClientSize = new System.Drawing.Size(1343, 658);
            this.Controls.Add(this.gboxExpenseFacts);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.gboxDimExpDetails);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormExpAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expenses Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormExpAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDimExpDetails)).EndInit();
            this.gboxExpenseFacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExpense)).EndInit();
            this.gboxDimExpDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDimExpDetails;
        private System.Windows.Forms.GroupBox gboxExpenseFacts;
        private System.Windows.Forms.DataGridView dataGridExpense;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.GroupBox gboxDimExpDetails;
    }
}