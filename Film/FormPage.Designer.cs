namespace Film
{
    partial class FormPage
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
            this.tbShare = new System.Windows.Forms.TextBox();
            this.bShare = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.bReccomend = new System.Windows.Forms.Button();
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbShare
            // 
            this.tbShare.Location = new System.Drawing.Point(54, 66);
            this.tbShare.Name = "tbShare";
            this.tbShare.Size = new System.Drawing.Size(100, 20);
            this.tbShare.TabIndex = 1;
            // 
            // bShare
            // 
            this.bShare.Location = new System.Drawing.Point(188, 66);
            this.bShare.Name = "bShare";
            this.bShare.Size = new System.Drawing.Size(75, 23);
            this.bShare.TabIndex = 2;
            this.bShare.Text = "Share film";
            this.bShare.UseVisualStyleBackColor = true;
            this.bShare.Click += new System.EventHandler(this.bShare_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 208);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.Size = new System.Drawing.Size(231, 230);
            this.dgvResult.TabIndex = 4;
            this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
            // 
            // bReccomend
            // 
            this.bReccomend.AutoSize = true;
            this.bReccomend.Location = new System.Drawing.Point(13, 172);
            this.bReccomend.Name = "bReccomend";
            this.bReccomend.Size = new System.Drawing.Size(130, 23);
            this.bReccomend.TabIndex = 5;
            this.bReccomend.Text = "Show recommendations";
            this.bReccomend.UseVisualStyleBackColor = true;
            this.bReccomend.Click += new System.EventHandler(this.bReccomend_Click);
            // 
            // sqliteCommand1
            // 
            this.sqliteCommand1.CommandText = null;
            this.sqliteCommand1.CommandTimeout = 30;
            this.sqliteCommand1.Connection = null;
            this.sqliteCommand1.Transaction = null;
            this.sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(396, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Какой-то результат - ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(249, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 230);
            this.dataGridView1.TabIndex = 7;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(495, 208);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(250, 230);
            this.dataGridView2.TabIndex = 8;
            // 
            // FormPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bReccomend);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.bShare);
            this.Controls.Add(this.tbShare);
            this.Name = "FormPage";
            this.Text = "FormPage";
            this.Load += new System.EventHandler(this.FormPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbShare;
        private System.Windows.Forms.Button bShare;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bReccomend;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}