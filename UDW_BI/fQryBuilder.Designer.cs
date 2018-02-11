namespace UDW_BI
{
    partial class fQryBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQryBuilder));
            this.gBoxMain = new System.Windows.Forms.GroupBox();
            this.CmdBtnVerifyQry = new System.Windows.Forms.Button();
            this.lblSql = new System.Windows.Forms.Label();
            this.lblRelations = new System.Windows.Forms.Label();
            this.lblSFields = new System.Windows.Forms.Label();
            this.lblDbView = new System.Windows.Forms.Label();
            this.dataGridViewRelations = new System.Windows.Forms.DataGridView();
            this.dataGridViewRelationsCol1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewRelationsCol2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewRelationsCol3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewRelationsCol4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewRelationsCol5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CmdClose = new System.Windows.Forms.Button();
            this.CmdBtnGenerate = new System.Windows.Forms.Button();
            this.CmdBtnSaveQry = new System.Windows.Forms.Button();
            this.txtboxSql = new System.Windows.Forms.TextBox();
            this.dataGridViewCols = new System.Windows.Forms.DataGridView();
            this.Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Col5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeViewTbls = new System.Windows.Forms.TreeView();
            this.saveFileDialogSql = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogData = new System.Windows.Forms.SaveFileDialog();
            this.gBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCols)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxMain
            // 
            this.gBoxMain.Controls.Add(this.CmdBtnVerifyQry);
            this.gBoxMain.Controls.Add(this.lblSql);
            this.gBoxMain.Controls.Add(this.lblRelations);
            this.gBoxMain.Controls.Add(this.lblSFields);
            this.gBoxMain.Controls.Add(this.lblDbView);
            this.gBoxMain.Controls.Add(this.dataGridViewRelations);
            this.gBoxMain.Controls.Add(this.CmdClose);
            this.gBoxMain.Controls.Add(this.CmdBtnGenerate);
            this.gBoxMain.Controls.Add(this.CmdBtnSaveQry);
            this.gBoxMain.Controls.Add(this.txtboxSql);
            this.gBoxMain.Controls.Add(this.dataGridViewCols);
            this.gBoxMain.Controls.Add(this.treeViewTbls);
            this.gBoxMain.Location = new System.Drawing.Point(13, 10);
            this.gBoxMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxMain.Name = "gBoxMain";
            this.gBoxMain.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxMain.Size = new System.Drawing.Size(1207, 600);
            this.gBoxMain.TabIndex = 0;
            this.gBoxMain.TabStop = false;
            // 
            // CmdBtnVerifyQry
            // 
            this.CmdBtnVerifyQry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CmdBtnVerifyQry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnVerifyQry.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnVerifyQry.Image")));
            this.CmdBtnVerifyQry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnVerifyQry.Location = new System.Drawing.Point(462, 535);
            this.CmdBtnVerifyQry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdBtnVerifyQry.Name = "CmdBtnVerifyQry";
            this.CmdBtnVerifyQry.Size = new System.Drawing.Size(143, 49);
            this.CmdBtnVerifyQry.TabIndex = 7;
            this.CmdBtnVerifyQry.Text = "  &Verify Query";
            this.CmdBtnVerifyQry.UseVisualStyleBackColor = true;
            this.CmdBtnVerifyQry.Click += new System.EventHandler(this.CmdBtnVerifyQry_Click);
            // 
            // lblSql
            // 
            this.lblSql.AutoSize = true;
            this.lblSql.Location = new System.Drawing.Point(316, 323);
            this.lblSql.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSql.Name = "lblSql";
            this.lblSql.Size = new System.Drawing.Size(91, 16);
            this.lblSql.TabIndex = 13;
            this.lblSql.Text = "Sql Statement";
            // 
            // lblRelations
            // 
            this.lblRelations.AutoSize = true;
            this.lblRelations.Location = new System.Drawing.Point(316, 196);
            this.lblRelations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRelations.Name = "lblRelations";
            this.lblRelations.Size = new System.Drawing.Size(90, 16);
            this.lblRelations.TabIndex = 12;
            this.lblRelations.Text = "Relationships";
            // 
            // lblSFields
            // 
            this.lblSFields.AutoSize = true;
            this.lblSFields.Location = new System.Drawing.Point(309, 19);
            this.lblSFields.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSFields.Name = "lblSFields";
            this.lblSFields.Size = new System.Drawing.Size(102, 16);
            this.lblSFields.TabIndex = 11;
            this.lblSFields.Text = "Selected Fields";
            // 
            // lblDbView
            // 
            this.lblDbView.AutoSize = true;
            this.lblDbView.Location = new System.Drawing.Point(29, 19);
            this.lblDbView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDbView.Name = "lblDbView";
            this.lblDbView.Size = new System.Drawing.Size(145, 16);
            this.lblDbView.TabIndex = 10;
            this.lblDbView.Text = "Data WareHouse View";
            // 
            // dataGridViewRelations
            // 
            this.dataGridViewRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewRelationsCol1,
            this.dataGridViewRelationsCol2,
            this.dataGridViewRelationsCol3,
            this.dataGridViewRelationsCol4,
            this.dataGridViewRelationsCol5});
            this.dataGridViewRelations.Location = new System.Drawing.Point(302, 221);
            this.dataGridViewRelations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewRelations.Name = "dataGridViewRelations";
            this.dataGridViewRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRelations.Size = new System.Drawing.Size(847, 96);
            this.dataGridViewRelations.TabIndex = 3;
            this.dataGridViewRelations.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewRelations_DataError);
            this.dataGridViewRelations.SelectionChanged += new System.EventHandler(this.dataGridViewRelations_SelectionChanged);
            // 
            // dataGridViewRelationsCol1
            // 
            this.dataGridViewRelationsCol1.HeaderText = "Left Table";
            this.dataGridViewRelationsCol1.Items.AddRange(new object[] {
            "DimCustomers",
            "DimDates",
            "DimEmployee",
            "DimExpenseAuthorisation",
            "DimExpenseCategory",
            "DimGeography",
            "DimHourOFTheDay",
            "DimPastExperience",
            "DimPresentJob",
            "DimProducts",
            "DimPrograms",
            "DimStudents",
            "ExpenseFacts",
            "RevenueFacts"});
            this.dataGridViewRelationsCol1.Name = "dataGridViewRelationsCol1";
            this.dataGridViewRelationsCol1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRelationsCol1.Width = 150;
            // 
            // dataGridViewRelationsCol2
            // 
            this.dataGridViewRelationsCol2.DropDownWidth = 250;
            this.dataGridViewRelationsCol2.HeaderText = "Left Column";
            this.dataGridViewRelationsCol2.Items.AddRange(new object[] {
            "[DimCustomers].[Age]",
            "[DimCustomers].[CustomerKey]",
            "[DimCustomers].[CustomerKeyAlternate]",
            "[DimCustomers].[Date of Birth]",
            "[DimCustomers].[Designation]",
            "[DimCustomers].[Education]",
            "[DimCustomers].[Email Address]",
            "[DimCustomers].[First Name]",
            "[DimCustomers].[Gender]",
            "[DimCustomers].[Last Name]",
            "[DimCustomers].[Marital Status]",
            "[DimCustomers].[Occupation]",
            "[DimCustomers].[Organization]",
            "[DimCustomers].[Phone Number]",
            "[DimCustomers].[Row Created]",
            "[DimCustomers].[Row Validity]",
            "[DimDates].[DateAlternateKey]",
            "[DimDates].[DateKey]",
            "[DimDates].[Day]",
            "[DimDates].[Full Date]",
            "[DimDates].[Month]",
            "[DimDates].[Quarter]",
            "[DimDates].[Week]",
            "[DimDates].[Year]",
            "[DimEmployee].[Age]",
            "[DimEmployee].[Date of Birth]",
            "[DimEmployee].[Education]",
            "[DimEmployee].[Email Address]",
            "[DimEmployee].[Employee Name]",
            "[DimEmployee].[EmployeeIDAltKey]",
            "[DimEmployee].[EmployeeKey]",
            "[DimEmployee].[Gender]",
            "[DimEmployee].[Marital Status]",
            "[DimEmployee].[Organization]",
            "[DimEmployee].[Phone Number]",
            "[DimEmployee].[Professional Qualifications]",
            "[DimEmployee].[Row Created]",
            "[DimEmployee].[Row Validity]",
            "[DimExpenseAuthorisation].[Designation]",
            "[DimExpenseAuthorisation].[ExpAuthorKey]",
            "[DimExpenseAuthorisation].[GrantedByAltKey]",
            "[DimExpenseAuthorisation].[Name]",
            "[DimExpenseAuthorisation].[Row_Created]",
            "[DimExpenseAuthorisation].[Row_Validity]",
            "[DimExpenseCategory].[ExpenseKey]",
            "[DimExpenseCategory].[ExpenseName]",
            "[DimExpenseCategory].[ExpensesAltKey]",
            "[DimExpenseCategory].[ExpenseType]",
            "[DimExpenseCategory].[Row Created]",
            "[DimExpenseCategory].[Row Validity]",
            "[DimGeography].[Address]",
            "[DimGeography].[City]",
            "[DimGeography].[Country]",
            "[DimGeography].[GeoIDAlternateKey]",
            "[DimGeography].[GeoKey]",
            "[DimGeography].[Row Created]",
            "[DimGeography].[Row Validity]",
            "[DimGeography].[State]",
            "[DimHourOFTheDay].[Hour]",
            "[DimHourOFTheDay].[HourKey]",
            "[DimPastExperience].[EmpIDAltKey]",
            "[DimPastExperience].[End_Date]",
            "[DimPastExperience].[Join_Date]",
            "[DimPastExperience].[Organisation]",
            "[DimPastExperience].[PastExperienceKey]",
            "[DimPastExperience].[Post Held]",
            "[DimPastExperience].[Row_Created]",
            "[DimPastExperience].[Row_Validity]",
            "[DimPresentJob].[Department]",
            "[DimPresentJob].[Designation]",
            "[DimPresentJob].[EmpInfoKey]",
            "[DimPresentJob].[Employee Type]",
            "[DimPresentJob].[EmployeeIDAltKey]",
            "[DimPresentJob].[Row Created]",
            "[DimPresentJob].[Row Validity]",
            "[DimProducts].[Category]",
            "[DimProducts].[License Type]",
            "[DimProducts].[Media]",
            "[DimProducts].[PlatForm]",
            "[DimProducts].[Product Description]",
            "[DimProducts].[Product Features]",
            "[DimProducts].[ProductKey]",
            "[DimProducts].[ProductKeyAlternate]",
            "[DimProducts].[Row Created]",
            "[DimProducts].[Row Validity]",
            "[DimProducts].[Software Product Item]",
            "[DimProducts].[Version]",
            "[DimProducts].[Weight]",
            "[DimPrograms].[Batch]",
            "[DimPrograms].[Duration]",
            "[DimPrograms].[Program Name]",
            "[DimPrograms].[ProgramKey]",
            "[DimPrograms].[Row Created]",
            "[DimPrograms].[Row Validity]",
            "[DimPrograms].[StudentKeyAlternate]",
            "[DimStudents].[Date of Birth]",
            "[DimStudents].[Degree Status]",
            "[DimStudents].[E-Mail]",
            "[DimStudents].[Father Name]",
            "[DimStudents].[First Name]",
            "[DimStudents].[Gender]",
            "[DimStudents].[Last Name]",
            "[DimStudents].[Last Qualification]",
            "[DimStudents].[Phone Number]",
            "[DimStudents].[Reg Date]",
            "[DimStudents].[Reg Status]",
            "[DimStudents].[Row Created]",
            "[DimStudents].[Row Validity]",
            "[DimStudents].[StudentIDAlternateKey]",
            "[DimStudents].[StudentKey]",
            "[ExpenseFacts].[Basic Pay]",
            "[ExpenseFacts].[Conveyance Allowance]",
            "[ExpenseFacts].[DateKey]",
            "[ExpenseFacts].[EmployeeKey]",
            "[ExpenseFacts].[ExpAuthorityKey]",
            "[ExpenseFacts].[ExpenceFactsKey]",
            "[ExpenseFacts].[Expense Amount]",
            "[ExpenseFacts].[ExpenseID]",
            "[ExpenseFacts].[ExpensesTypeKey]",
            "[ExpenseFacts].[GeoKey]",
            "[ExpenseFacts].[HourOfTheDayKey]",
            "[ExpenseFacts].[House Rent]",
            "[ExpenseFacts].[Medical Allowance]",
            "[ExpenseFacts].[Net Salary]",
            "[ExpenseFacts].[PresentJobKey]",
            "[ExpenseFacts].[Provident Fund]",
            "[ExpenseFacts].[SalaryID]",
            "[ExpenseFacts].[Tax Amount]",
            "[RevenueFacts].[CustomersKey]",
            "[RevenueFacts].[DateKey]",
            "[RevenueFacts].[Discount Allowed]",
            "[RevenueFacts].[FeesVoucherID]",
            "[RevenueFacts].[GeoKey]",
            "[RevenueFacts].[HourOfTheDayKey]",
            "[RevenueFacts].[LateFeesAmount]",
            "[RevenueFacts].[Net Amount]",
            "[RevenueFacts].[OrderID]",
            "[RevenueFacts].[ProductsKey]",
            "[RevenueFacts].[ProgramKey]",
            "[RevenueFacts].[RevenueKey]",
            "[RevenueFacts].[StudentFees]",
            "[RevenueFacts].[StudentKey]",
            "[RevenueFacts].[Unit Price]",
            "[RevenueFacts].[Units Sold]"});
            this.dataGridViewRelationsCol2.Name = "dataGridViewRelationsCol2";
            this.dataGridViewRelationsCol2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRelationsCol2.Width = 170;
            // 
            // dataGridViewRelationsCol3
            // 
            this.dataGridViewRelationsCol3.HeaderText = "Join Type";
            this.dataGridViewRelationsCol3.Items.AddRange(new object[] {
            "INNER JOIN",
            "LEFT JOIN",
            "RIGHT JOIN"});
            this.dataGridViewRelationsCol3.Name = "dataGridViewRelationsCol3";
            this.dataGridViewRelationsCol3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewRelationsCol4
            // 
            this.dataGridViewRelationsCol4.HeaderText = "Right Table";
            this.dataGridViewRelationsCol4.Items.AddRange(new object[] {
            "DimCustomers",
            "DimDates",
            "DimEmployee",
            "DimExpenseAuthorisation",
            "DimExpenseCategory",
            "DimGeography",
            "DimHourOFTheDay",
            "DimPastExperience",
            "DimPresentJob",
            "DimProducts",
            "DimPrograms",
            "DimStudents",
            "ExpenseFacts",
            "RevenueFacts"});
            this.dataGridViewRelationsCol4.Name = "dataGridViewRelationsCol4";
            this.dataGridViewRelationsCol4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRelationsCol4.Width = 150;
            // 
            // dataGridViewRelationsCol5
            // 
            this.dataGridViewRelationsCol5.DropDownWidth = 250;
            this.dataGridViewRelationsCol5.HeaderText = "Right Column";
            this.dataGridViewRelationsCol5.Items.AddRange(new object[] {
            "[DimCustomers].[Age]",
            "[DimCustomers].[CustomerKey]",
            "[DimCustomers].[CustomerKeyAlternate]",
            "[DimCustomers].[Date of Birth]",
            "[DimCustomers].[Designation]",
            "[DimCustomers].[Education]",
            "[DimCustomers].[Email Address]",
            "[DimCustomers].[First Name]",
            "[DimCustomers].[Gender]",
            "[DimCustomers].[Last Name]",
            "[DimCustomers].[Marital Status]",
            "[DimCustomers].[Occupation]",
            "[DimCustomers].[Organization]",
            "[DimCustomers].[Phone Number]",
            "[DimCustomers].[Row Created]",
            "[DimCustomers].[Row Validity]",
            "[DimDates].[DateAlternateKey]",
            "[DimDates].[DateKey]",
            "[DimDates].[Day]",
            "[DimDates].[Full Date]",
            "[DimDates].[Month]",
            "[DimDates].[Quarter]",
            "[DimDates].[Week]",
            "[DimDates].[Year]",
            "[DimEmployee].[Age]",
            "[DimEmployee].[Date of Birth]",
            "[DimEmployee].[Education]",
            "[DimEmployee].[Email Address]",
            "[DimEmployee].[Employee Name]",
            "[DimEmployee].[EmployeeIDAltKey]",
            "[DimEmployee].[EmployeeKey]",
            "[DimEmployee].[Gender]",
            "[DimEmployee].[Marital Status]",
            "[DimEmployee].[Organization]",
            "[DimEmployee].[Phone Number]",
            "[DimEmployee].[Professional Qualifications]",
            "[DimEmployee].[Row Created]",
            "[DimEmployee].[Row Validity]",
            "[DimExpenseAuthorisation].[Designation]",
            "[DimExpenseAuthorisation].[ExpAuthorKey]",
            "[DimExpenseAuthorisation].[GrantedByAltKey]",
            "[DimExpenseAuthorisation].[Name]",
            "[DimExpenseAuthorisation].[Row_Created]",
            "[DimExpenseAuthorisation].[Row_Validity]",
            "[DimExpenseCategory].[ExpenseKey]",
            "[DimExpenseCategory].[ExpenseName]",
            "[DimExpenseCategory].[ExpensesAltKey]",
            "[DimExpenseCategory].[ExpenseType]",
            "[DimExpenseCategory].[Row Created]",
            "[DimExpenseCategory].[Row Validity]",
            "[DimGeography].[Address]",
            "[DimGeography].[City]",
            "[DimGeography].[Country]",
            "[DimGeography].[GeoIDAlternateKey]",
            "[DimGeography].[GeoKey]",
            "[DimGeography].[Row Created]",
            "[DimGeography].[Row Validity]",
            "[DimGeography].[State]",
            "[DimHourOFTheDay].[Hour]",
            "[DimHourOFTheDay].[HourKey]",
            "[DimPastExperience].[EmpIDAltKey]",
            "[DimPastExperience].[End_Date]",
            "[DimPastExperience].[Join_Date]",
            "[DimPastExperience].[Organisation]",
            "[DimPastExperience].[PastExperienceKey]",
            "[DimPastExperience].[Post Held]",
            "[DimPastExperience].[Row_Created]",
            "[DimPastExperience].[Row_Validity]",
            "[DimPresentJob].[Department]",
            "[DimPresentJob].[Designation]",
            "[DimPresentJob].[EmpInfoKey]",
            "[DimPresentJob].[Employee Type]",
            "[DimPresentJob].[EmployeeIDAltKey]",
            "[DimPresentJob].[Row Created]",
            "[DimPresentJob].[Row Validity]",
            "[DimProducts].[Category]",
            "[DimProducts].[License Type]",
            "[DimProducts].[Media]",
            "[DimProducts].[PlatForm]",
            "[DimProducts].[Product Description]",
            "[DimProducts].[Product Features]",
            "[DimProducts].[ProductKey]",
            "[DimProducts].[ProductKeyAlternate]",
            "[DimProducts].[Row Created]",
            "[DimProducts].[Row Validity]",
            "[DimProducts].[Software Product Item]",
            "[DimProducts].[Version]",
            "[DimProducts].[Weight]",
            "[DimPrograms].[Batch]",
            "[DimPrograms].[Duration]",
            "[DimPrograms].[Program Name]",
            "[DimPrograms].[ProgramKey]",
            "[DimPrograms].[Row Created]",
            "[DimPrograms].[Row Validity]",
            "[DimPrograms].[StudentKeyAlternate]",
            "[DimStudents].[Date of Birth]",
            "[DimStudents].[Degree Status]",
            "[DimStudents].[E-Mail]",
            "[DimStudents].[Father Name]",
            "[DimStudents].[First Name]",
            "[DimStudents].[Gender]",
            "[DimStudents].[Last Name]",
            "[DimStudents].[Last Qualification]",
            "[DimStudents].[Phone Number]",
            "[DimStudents].[Reg Date]",
            "[DimStudents].[Reg Status]",
            "[DimStudents].[Row Created]",
            "[DimStudents].[Row Validity]",
            "[DimStudents].[StudentIDAlternateKey]",
            "[DimStudents].[StudentKey]",
            "[ExpenseFacts].[Basic Pay]",
            "[ExpenseFacts].[Conveyance Allowance]",
            "[ExpenseFacts].[DateKey]",
            "[ExpenseFacts].[EmployeeKey]",
            "[ExpenseFacts].[ExpAuthorityKey]",
            "[ExpenseFacts].[ExpenceFactsKey]",
            "[ExpenseFacts].[Expense Amount]",
            "[ExpenseFacts].[ExpenseID]",
            "[ExpenseFacts].[ExpensesTypeKey]",
            "[ExpenseFacts].[GeoKey]",
            "[ExpenseFacts].[HourOfTheDayKey]",
            "[ExpenseFacts].[House Rent]",
            "[ExpenseFacts].[Medical Allowance]",
            "[ExpenseFacts].[Net Salary]",
            "[ExpenseFacts].[PresentJobKey]",
            "[ExpenseFacts].[Provident Fund]",
            "[ExpenseFacts].[SalaryID]",
            "[ExpenseFacts].[Tax Amount]",
            "[RevenueFacts].[CustomersKey]",
            "[RevenueFacts].[DateKey]",
            "[RevenueFacts].[Discount Allowed]",
            "[RevenueFacts].[FeesVoucherID]",
            "[RevenueFacts].[GeoKey]",
            "[RevenueFacts].[HourOfTheDayKey]",
            "[RevenueFacts].[LateFeesAmount]",
            "[RevenueFacts].[Net Amount]",
            "[RevenueFacts].[OrderID]",
            "[RevenueFacts].[ProductsKey]",
            "[RevenueFacts].[ProgramKey]",
            "[RevenueFacts].[RevenueKey]",
            "[RevenueFacts].[StudentFees]",
            "[RevenueFacts].[StudentKey]",
            "[RevenueFacts].[Unit Price]",
            "[RevenueFacts].[Units Sold]"});
            this.dataGridViewRelationsCol5.Name = "dataGridViewRelationsCol5";
            this.dataGridViewRelationsCol5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRelationsCol5.Width = 170;
            // 
            // CmdClose
            // 
            this.CmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClose.Image = ((System.Drawing.Image)(resources.GetObject("CmdClose.Image")));
            this.CmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdClose.Location = new System.Drawing.Point(938, 535);
            this.CmdClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(167, 49);
            this.CmdClose.TabIndex = 10;
            this.CmdClose.Text = "&Close";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // CmdBtnGenerate
            // 
            this.CmdBtnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnGenerate.Image")));
            this.CmdBtnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnGenerate.Location = new System.Drawing.Point(763, 536);
            this.CmdBtnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdBtnGenerate.Name = "CmdBtnGenerate";
            this.CmdBtnGenerate.Size = new System.Drawing.Size(167, 48);
            this.CmdBtnGenerate.TabIndex = 9;
            this.CmdBtnGenerate.Text = " Generate And &Save Report";
            this.CmdBtnGenerate.UseVisualStyleBackColor = true;
            this.CmdBtnGenerate.Click += new System.EventHandler(this.CmdBtnGenerate_Click);
            // 
            // CmdBtnSaveQry
            // 
            this.CmdBtnSaveQry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CmdBtnSaveQry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBtnSaveQry.Image = ((System.Drawing.Image)(resources.GetObject("CmdBtnSaveQry.Image")));
            this.CmdBtnSaveQry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdBtnSaveQry.Location = new System.Drawing.Point(613, 535);
            this.CmdBtnSaveQry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdBtnSaveQry.Name = "CmdBtnSaveQry";
            this.CmdBtnSaveQry.Size = new System.Drawing.Size(143, 49);
            this.CmdBtnSaveQry.TabIndex = 8;
            this.CmdBtnSaveQry.Text = " Save &Query";
            this.CmdBtnSaveQry.UseVisualStyleBackColor = true;
            this.CmdBtnSaveQry.Click += new System.EventHandler(this.CmdBtnSaveQry_Click);
            // 
            // txtboxSql
            // 
            this.txtboxSql.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxSql.Location = new System.Drawing.Point(302, 346);
            this.txtboxSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtboxSql.Multiline = true;
            this.txtboxSql.Name = "txtboxSql";
            this.txtboxSql.Size = new System.Drawing.Size(847, 178);
            this.txtboxSql.TabIndex = 4;
            // 
            // dataGridViewCols
            // 
            this.dataGridViewCols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col1,
            this.Col2,
            this.Col3,
            this.Col4,
            this.Col5,
            this.Col6,
            this.Col7});
            this.dataGridViewCols.Location = new System.Drawing.Point(302, 40);
            this.dataGridViewCols.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewCols.Name = "dataGridViewCols";
            this.dataGridViewCols.Size = new System.Drawing.Size(847, 150);
            this.dataGridViewCols.TabIndex = 2;
            this.dataGridViewCols.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewCols_DataError);
            this.dataGridViewCols.SelectionChanged += new System.EventHandler(this.dataGridViewCols_SelectionChanged);
            // 
            // Col1
            // 
            this.Col1.HeaderText = "Columns";
            this.Col1.Name = "Col1";
            // 
            // Col2
            // 
            this.Col2.HeaderText = "Alias";
            this.Col2.Name = "Col2";
            // 
            // Col3
            // 
            this.Col3.HeaderText = "Table";
            this.Col3.Name = "Col3";
            // 
            // Col4
            // 
            this.Col4.HeaderText = "output";
            this.Col4.Name = "Col4";
            // 
            // Col5
            // 
            this.Col5.HeaderText = "Sort";
            this.Col5.Items.AddRange(new object[] {
            "No",
            "ASC",
            "DESC"});
            this.Col5.Name = "Col5";
            this.Col5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col6
            // 
            this.Col6.HeaderText = "Group By";
            this.Col6.Items.AddRange(new object[] {
            "No",
            "Group By",
            "Sum",
            "Avg",
            "Min",
            "Max",
            "Count"});
            this.Col6.Name = "Col6";
            // 
            // Col7
            // 
            this.Col7.HeaderText = "Filter";
            this.Col7.Name = "Col7";
            this.Col7.ToolTipText = "Please add apostrophe before and after a string value.";
            // 
            // treeViewTbls
            // 
            this.treeViewTbls.Location = new System.Drawing.Point(25, 38);
            this.treeViewTbls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewTbls.Name = "treeViewTbls";
            this.treeViewTbls.Size = new System.Drawing.Size(262, 486);
            this.treeViewTbls.TabIndex = 1;
            this.treeViewTbls.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTbls_NodeMouseDoubleClick);
            // 
            // saveFileDialogSql
            // 
            this.saveFileDialogSql.FileName = "SqlQuery1";
            this.saveFileDialogSql.Title = "Save As";
            this.saveFileDialogSql.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogSql_FileOk);
            // 
            // saveFileDialogData
            // 
            this.saveFileDialogData.FileName = "Report1";
            this.saveFileDialogData.Title = "Save As";
            // 
            // fQryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 621);
            this.Controls.Add(this.gBoxMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "fQryBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ABCU DWH Query Builder";
            this.Load += new System.EventHandler(this.fQryBuilder_Load);
            this.gBoxMain.ResumeLayout(false);
            this.gBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCols)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxMain;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.Button CmdBtnGenerate;
        private System.Windows.Forms.Button CmdBtnSaveQry;
        private System.Windows.Forms.TextBox txtboxSql;
        private System.Windows.Forms.DataGridView dataGridViewCols;
        private System.Windows.Forms.TreeView treeViewTbls;
        private System.Windows.Forms.DataGridView dataGridViewRelations;
        private System.Windows.Forms.Label lblSql;
        private System.Windows.Forms.Label lblRelations;
        private System.Windows.Forms.Label lblSFields;
        private System.Windows.Forms.Label lblDbView;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewRelationsCol1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewRelationsCol2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewRelationsCol3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewRelationsCol4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewRelationsCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Col4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col7;
        private System.Windows.Forms.Button CmdBtnVerifyQry;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSql;
        private System.Windows.Forms.SaveFileDialog saveFileDialogData;

    }
}