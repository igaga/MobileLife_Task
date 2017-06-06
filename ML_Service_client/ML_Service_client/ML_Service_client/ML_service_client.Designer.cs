namespace ML_Service_client
{
    partial class ML_service_client
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
            this.getTax_Click = new System.Windows.Forms.Button();
            this.textBoxMunicipality = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMunicipalityAdd = new System.Windows.Forms.TextBox();
            this.buttonAddRecord = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelValidFrom = new System.Windows.Forms.Label();
            this.labelValidTo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonUploadFile = new System.Windows.Forms.Button();
            this.comboBoxTaxTypes = new System.Windows.Forms.ComboBox();
            this.textBoxTaxAdd = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.labelDate = new System.Windows.Forms.Label();
            this.buttonUpdateResult = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGetTax = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageAddTax = new System.Windows.Forms.TabPage();
            this.tabPageUploadData = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.tabPageGetTax.SuspendLayout();
            this.tabPageAddTax.SuspendLayout();
            this.tabPageUploadData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getTax_Click
            // 
            this.getTax_Click.Location = new System.Drawing.Point(176, 144);
            this.getTax_Click.Name = "getTax_Click";
            this.getTax_Click.Size = new System.Drawing.Size(75, 23);
            this.getTax_Click.TabIndex = 0;
            this.getTax_Click.Text = "Get tax";
            this.getTax_Click.UseVisualStyleBackColor = true;
            this.getTax_Click.Click += new System.EventHandler(this.getTax_Click_Click);
            // 
            // textBoxMunicipality
            // 
            this.textBoxMunicipality.Location = new System.Drawing.Point(74, 12);
            this.textBoxMunicipality.Name = "textBoxMunicipality";
            this.textBoxMunicipality.Size = new System.Drawing.Size(157, 20);
            this.textBoxMunicipality.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Municipality";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(257, 147);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxResult.TabIndex = 5;
            this.textBoxResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxResult_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result:";
            // 
            // textBoxMunicipalityAdd
            // 
            this.textBoxMunicipalityAdd.Location = new System.Drawing.Point(80, 12);
            this.textBoxMunicipalityAdd.Name = "textBoxMunicipalityAdd";
            this.textBoxMunicipalityAdd.Size = new System.Drawing.Size(100, 20);
            this.textBoxMunicipalityAdd.TabIndex = 7;
            // 
            // buttonAddRecord
            // 
            this.buttonAddRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddRecord.Location = new System.Drawing.Point(343, 203);
            this.buttonAddRecord.Name = "buttonAddRecord";
            this.buttonAddRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRecord.TabIndex = 12;
            this.buttonAddRecord.Text = "Add tax";
            this.buttonAddRecord.UseVisualStyleBackColor = true;
            this.buttonAddRecord.Click += new System.EventHandler(this.buttonAddRecord_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Municipality";
            // 
            // labelValidFrom
            // 
            this.labelValidFrom.AutoSize = true;
            this.labelValidFrom.Location = new System.Drawing.Point(77, 42);
            this.labelValidFrom.Name = "labelValidFrom";
            this.labelValidFrom.Size = new System.Drawing.Size(53, 13);
            this.labelValidFrom.TabIndex = 14;
            this.labelValidFrom.Text = "Date from";
            // 
            // labelValidTo
            // 
            this.labelValidTo.AutoSize = true;
            this.labelValidTo.Location = new System.Drawing.Point(77, 72);
            this.labelValidTo.Name = "labelValidTo";
            this.labelValidTo.Size = new System.Drawing.Size(42, 13);
            this.labelValidTo.TabIndex = 15;
            this.labelValidTo.Text = "Date to";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tax";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(75, 18);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(355, 20);
            this.textBoxFileName.TabIndex = 18;
            // 
            // buttonUploadFile
            // 
            this.buttonUploadFile.Location = new System.Drawing.Point(75, 44);
            this.buttonUploadFile.Name = "buttonUploadFile";
            this.buttonUploadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonUploadFile.TabIndex = 19;
            this.buttonUploadFile.Text = "Upload file";
            this.buttonUploadFile.UseVisualStyleBackColor = true;
            this.buttonUploadFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // comboBoxTaxTypes
            // 
            this.comboBoxTaxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTaxTypes.FormattingEnabled = true;
            this.comboBoxTaxTypes.Location = new System.Drawing.Point(186, 11);
            this.comboBoxTaxTypes.Name = "comboBoxTaxTypes";
            this.comboBoxTaxTypes.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTaxTypes.TabIndex = 22;
            this.comboBoxTaxTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaxTypes_SelectedIndexChanged);
            // 
            // textBoxTaxAdd
            // 
            this.textBoxTaxAdd.Location = new System.Drawing.Point(318, 12);
            this.textBoxTaxAdd.Name = "textBoxTaxAdd";
            this.textBoxTaxAdd.Size = new System.Drawing.Size(100, 20);
            this.textBoxTaxAdd.TabIndex = 11;
            this.textBoxTaxAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTaxIn_KeyPress);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 94);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 25;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(9, 57);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 28;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(71, 35);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(30, 13);
            this.labelDate.TabIndex = 30;
            this.labelDate.Text = "Date";
            // 
            // buttonUpdateResult
            // 
            this.buttonUpdateResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateResult.Location = new System.Drawing.Point(343, 232);
            this.buttonUpdateResult.Name = "buttonUpdateResult";
            this.buttonUpdateResult.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateResult.TabIndex = 29;
            this.buttonUpdateResult.Text = "Update tax";
            this.buttonUpdateResult.UseVisualStyleBackColor = true;
            this.buttonUpdateResult.Click += new System.EventHandler(this.buttonUpdateResult_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date  from:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Date to:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageGetTax);
            this.tabControl.Controls.Add(this.tabPageAddTax);
            this.tabControl.Controls.Add(this.tabPageUploadData);
            this.tabControl.Location = new System.Drawing.Point(3, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(444, 294);
            this.tabControl.TabIndex = 33;
            // 
            // tabPageGetTax
            // 
            this.tabPageGetTax.Controls.Add(this.label8);
            this.tabPageGetTax.Controls.Add(this.label1);
            this.tabPageGetTax.Controls.Add(this.textBoxMunicipality);
            this.tabPageGetTax.Controls.Add(this.monthCalendar2);
            this.tabPageGetTax.Controls.Add(this.labelDate);
            this.tabPageGetTax.Controls.Add(this.getTax_Click);
            this.tabPageGetTax.Controls.Add(this.textBoxResult);
            this.tabPageGetTax.Controls.Add(this.label3);
            this.tabPageGetTax.Location = new System.Drawing.Point(4, 22);
            this.tabPageGetTax.Name = "tabPageGetTax";
            this.tabPageGetTax.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGetTax.Size = new System.Drawing.Size(436, 268);
            this.tabPageGetTax.TabIndex = 0;
            this.tabPageGetTax.Text = "Get or update";
            this.tabPageGetTax.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Date";
            // 
            // tabPageAddTax
            // 
            this.tabPageAddTax.Controls.Add(this.buttonAddRecord);
            this.tabPageAddTax.Controls.Add(this.label5);
            this.tabPageAddTax.Controls.Add(this.buttonUpdateResult);
            this.tabPageAddTax.Controls.Add(this.textBoxMunicipalityAdd);
            this.tabPageAddTax.Controls.Add(this.label2);
            this.tabPageAddTax.Controls.Add(this.textBoxTaxAdd);
            this.tabPageAddTax.Controls.Add(this.monthCalendar1);
            this.tabPageAddTax.Controls.Add(this.label4);
            this.tabPageAddTax.Controls.Add(this.comboBoxTaxTypes);
            this.tabPageAddTax.Controls.Add(this.labelValidFrom);
            this.tabPageAddTax.Controls.Add(this.labelValidTo);
            this.tabPageAddTax.Controls.Add(this.label7);
            this.tabPageAddTax.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddTax.Name = "tabPageAddTax";
            this.tabPageAddTax.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddTax.Size = new System.Drawing.Size(436, 268);
            this.tabPageAddTax.TabIndex = 1;
            this.tabPageAddTax.Text = "Add tax";
            this.tabPageAddTax.UseVisualStyleBackColor = true;
            // 
            // tabPageUploadData
            // 
            this.tabPageUploadData.Controls.Add(this.dataGridView1);
            this.tabPageUploadData.Controls.Add(this.label6);
            this.tabPageUploadData.Controls.Add(this.textBoxFileName);
            this.tabPageUploadData.Controls.Add(this.buttonUploadFile);
            this.tabPageUploadData.Location = new System.Drawing.Point(4, 22);
            this.tabPageUploadData.Name = "tabPageUploadData";
            this.tabPageUploadData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUploadData.Size = new System.Drawing.Size(436, 268);
            this.tabPageUploadData.TabIndex = 2;
            this.tabPageUploadData.Text = "Upload data";
            this.tabPageUploadData.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(420, 186);
            this.dataGridView1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Choose file:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(450, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ML_service_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 332);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Name = "ML_service_client";
            this.Text = "ML service client";
            this.Load += new System.EventHandler(this.ML_service_client_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageGetTax.ResumeLayout(false);
            this.tabPageGetTax.PerformLayout();
            this.tabPageAddTax.ResumeLayout(false);
            this.tabPageAddTax.PerformLayout();
            this.tabPageUploadData.ResumeLayout(false);
            this.tabPageUploadData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTax_Click;
        private System.Windows.Forms.TextBox textBoxMunicipality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMunicipalityAdd;
        private System.Windows.Forms.Button buttonAddRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelValidFrom;
        private System.Windows.Forms.Label labelValidTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonUploadFile;
        private System.Windows.Forms.ComboBox comboBoxTaxTypes;
        private System.Windows.Forms.TextBox textBoxTaxAdd;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button buttonUpdateResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGetTax;
        private System.Windows.Forms.TabPage tabPageAddTax;
        private System.Windows.Forms.TabPage tabPageUploadData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

