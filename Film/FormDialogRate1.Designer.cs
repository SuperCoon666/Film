namespace Film
{
    partial class FormDialogRate1
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
            this.tbRate = new System.Windows.Forms.TextBox();
            this.bRate = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(79, 65);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(181, 20);
            this.tbRate.TabIndex = 0;
            // 
            // bRate
            // 
            this.bRate.AutoSize = true;
            this.bRate.Location = new System.Drawing.Point(79, 91);
            this.bRate.Name = "bRate";
            this.bRate.Size = new System.Drawing.Size(90, 23);
            this.bRate.TabIndex = 1;
            this.bRate.Text = "Rate this movie";
            this.bRate.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.AutoSize = true;
            this.bCancel.Location = new System.Drawing.Point(185, 91);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Come back";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rate this move and give it a raiting from 0  to 100 points!";
            // 
            // FormDialogRate1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(385, 202);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bRate);
            this.Controls.Add(this.tbRate);
            this.Name = "FormDialogRate1";
            this.Text = "FormDialogRate1";
            this.Load += new System.EventHandler(this.FormDialogRate1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.Button bRate;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label1;
    }
}