namespace W2Open.Tools.PlayerAccountEditor
{
    partial class Form1
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
            this.btnCreateEmptyAccount = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPsw = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateEmptyAccount
            // 
            this.btnCreateEmptyAccount.Location = new System.Drawing.Point(181, 72);
            this.btnCreateEmptyAccount.Name = "btnCreateEmptyAccount";
            this.btnCreateEmptyAccount.Size = new System.Drawing.Size(141, 50);
            this.btnCreateEmptyAccount.TabIndex = 0;
            this.btnCreateEmptyAccount.Text = "Create Empty Account";
            this.btnCreateEmptyAccount.UseVisualStyleBackColor = true;
            this.btnCreateEmptyAccount.Click += new System.EventHandler(this.btnCreateEmptyAccount_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(75, 72);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(75, 102);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(100, 20);
            this.txtPsw.TabIndex = 2;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(16, 75);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login";
            // 
            // lblPsw
            // 
            this.lblPsw.AutoSize = true;
            this.lblPsw.Location = new System.Drawing.Point(16, 105);
            this.lblPsw.Name = "lblPsw";
            this.lblPsw.Size = new System.Drawing.Size(53, 13);
            this.lblPsw.TabIndex = 4;
            this.lblPsw.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 304);
            this.Controls.Add(this.lblPsw);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.btnCreateEmptyAccount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateEmptyAccount;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPsw;
    }
}

