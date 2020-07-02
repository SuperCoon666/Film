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
            this.LBRecommend = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bShare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBRecommend
            // 
            this.LBRecommend.FormattingEnabled = true;
            this.LBRecommend.Location = new System.Drawing.Point(-2, 295);
            this.LBRecommend.Name = "LBRecommend";
            this.LBRecommend.Size = new System.Drawing.Size(495, 147);
            this.LBRecommend.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
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
            // FormPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bShare);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LBRecommend);
            this.Name = "FormPage";
            this.Text = "FormPage";
            this.Load += new System.EventHandler(this.FormPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBRecommend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bShare;
    }
}