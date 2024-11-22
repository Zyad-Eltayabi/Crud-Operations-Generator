namespace WindowsFormsApp1
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCopyDataTierText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Database";
            // 
            // cbDatabases
            // 
            this.cbDatabases.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(220, 27);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(361, 41);
            this.cbDatabases.TabIndex = 2;
            this.cbDatabases.SelectedIndexChanged += new System.EventHandler(this.cbDatabases_SelectedIndexChanged);
            // 
            // dgvTables
            // 
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Location = new System.Drawing.Point(29, 99);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.RowHeadersWidth = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTables.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTables.RowTemplate.Height = 26;
            this.dgvTables.Size = new System.Drawing.Size(240, 599);
            this.dgvTables.TabIndex = 2;
            this.dgvTables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTables_CellClick);
            // 
            // dgvColumns
            // 
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Location = new System.Drawing.Point(307, 99);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowHeadersWidth = 51;
            this.dgvColumns.RowTemplate.Height = 26;
            this.dgvColumns.Size = new System.Drawing.Size(420, 599);
            this.dgvColumns.TabIndex = 2;
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(748, 99);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCode.Size = new System.Drawing.Size(621, 599);
            this.tbCode.TabIndex = 3;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Tahoma", 18F);
            this.btnGenerate.Location = new System.Drawing.Point(976, 704);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(185, 46);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCopyDataTierText
            // 
            this.btnCopyDataTierText.Font = new System.Drawing.Font("Tahoma", 18F);
            this.btnCopyDataTierText.Location = new System.Drawing.Point(1184, 704);
            this.btnCopyDataTierText.Name = "btnCopyDataTierText";
            this.btnCopyDataTierText.Size = new System.Drawing.Size(185, 46);
            this.btnCopyDataTierText.TabIndex = 5;
            this.btnCopyDataTierText.Text = "Copy";
            this.btnCopyDataTierText.UseVisualStyleBackColor = true;
            this.btnCopyDataTierText.Click += new System.EventHandler(this.btnCopyDataTierText_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 762);
            this.Controls.Add(this.btnCopyDataTierText);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.dgvTables);
            this.Controls.Add(this.cbDatabases);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Code Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCopyDataTierText;
    }
}

