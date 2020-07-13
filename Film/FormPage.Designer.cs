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
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
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
            this.dgvResult.Size = new System.Drawing.Size(284, 230);
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
            // FormPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bReccomend);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.bShare);
            this.Controls.Add(this.tbShare);
            this.Name = "FormPage";
            this.Text = "FormPage";
            this.Load += new System.EventHandler(this.FormPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbShare;
        private System.Windows.Forms.Button bShare;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bReccomend;
    }
}