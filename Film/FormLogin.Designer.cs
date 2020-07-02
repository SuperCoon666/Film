namespace Film
{
    partial class FormLogin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tdEmail = new System.Windows.Forms.TextBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.bReg = new System.Windows.Forms.Button();
            this.tbPsw = new System.Windows.Forms.TextBox();
            this.lErorr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tdEmail
            // 
            this.tdEmail.Location = new System.Drawing.Point(251, 138);
            this.tdEmail.Name = "tdEmail";
            this.tdEmail.Size = new System.Drawing.Size(173, 20);
            this.tdEmail.TabIndex = 0;
            this.tdEmail.Text = "Email";
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(251, 237);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(69, 23);
            this.bLogin.TabIndex = 1;
            this.bLogin.Text = "Login";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // bReg
            // 
            this.bReg.Location = new System.Drawing.Point(349, 237);
            this.bReg.Name = "bReg";
            this.bReg.Size = new System.Drawing.Size(75, 23);
            this.bReg.TabIndex = 2;
            this.bReg.Text = "Registration";
            this.bReg.UseVisualStyleBackColor = true;
            // 
            // tbPsw
            // 
            this.tbPsw.Location = new System.Drawing.Point(251, 182);
            this.tbPsw.Name = "tbPsw";
            this.tbPsw.Size = new System.Drawing.Size(173, 20);
            this.tbPsw.TabIndex = 3;
            this.tbPsw.Text = "Password";
            // 
            // lErorr
            // 
            this.lErorr.AutoSize = true;
            this.lErorr.Location = new System.Drawing.Point(304, 94);
            this.lErorr.Name = "lErorr";
            this.lErorr.Size = new System.Drawing.Size(35, 13);
            this.lErorr.TabIndex = 4;
            this.lErorr.Text = "label1";
            this.lErorr.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lErorr);
            this.Controls.Add(this.tbPsw);
            this.Controls.Add(this.bReg);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.tdEmail);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tdEmail;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Button bReg;
        private System.Windows.Forms.TextBox tbPsw;
        private System.Windows.Forms.Label lErorr;
    }
}

