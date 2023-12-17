namespace Order
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textloginName = new System.Windows.Forms.TextBox();
            this.textloginPass = new System.Windows.Forms.TextBox();
            this.combologinType = new System.Windows.Forms.ComboBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginSign = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkloginPass = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(-7, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 405);
            this.panel1.TabIndex = 0;
            // 
            // textloginName
            // 
            this.textloginName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textloginName.Location = new System.Drawing.Point(177, 60);
            this.textloginName.Multiline = true;
            this.textloginName.Name = "textloginName";
            this.textloginName.Size = new System.Drawing.Size(262, 40);
            this.textloginName.TabIndex = 0;
            // 
            // textloginPass
            // 
            this.textloginPass.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textloginPass.Location = new System.Drawing.Point(177, 126);
            this.textloginPass.Multiline = true;
            this.textloginPass.Name = "textloginPass";
            this.textloginPass.PasswordChar = '*';
            this.textloginPass.Size = new System.Drawing.Size(262, 40);
            this.textloginPass.TabIndex = 0;
            // 
            // combologinType
            // 
            this.combologinType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.combologinType.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combologinType.FormattingEnabled = true;
            this.combologinType.Items.AddRange(new object[] {
            "Customer",
            "Admin",
            "Seller",
            "Delivery Driver"});
            this.combologinType.Location = new System.Drawing.Point(177, 229);
            this.combologinType.Name = "combologinType";
            this.combologinType.Size = new System.Drawing.Size(262, 34);
            this.combologinType.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonLogin.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(252, 287);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(119, 37);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Forgot Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fullname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(38, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(33, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "User Type";
            // 
            // LoginSign
            // 
            this.LoginSign.AutoSize = true;
            this.LoginSign.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginSign.ForeColor = System.Drawing.Color.Blue;
            this.LoginSign.Location = new System.Drawing.Point(522, 93);
            this.LoginSign.Name = "LoginSign";
            this.LoginSign.Size = new System.Drawing.Size(83, 27);
            this.LoginSign.TabIndex = 1;
            this.LoginSign.Text = "Sign up";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(660, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 27);
            this.label6.TabIndex = 1;
            this.label6.Text = "About us";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.checkloginPass);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonLogin);
            this.panel2.Controls.Add(this.textloginName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textloginPass);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.combologinType);
            this.panel2.Location = new System.Drawing.Point(331, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 405);
            this.panel2.TabIndex = 4;
            // 
            // checkloginPass
            // 
            this.checkloginPass.AutoSize = true;
            this.checkloginPass.Location = new System.Drawing.Point(300, 172);
            this.checkloginPass.Name = "checkloginPass";
            this.checkloginPass.Size = new System.Drawing.Size(148, 24);
            this.checkloginPass.TabIndex = 4;
            this.checkloginPass.Text = "Show Password";
            this.checkloginPass.UseVisualStyleBackColor = true;
            this.checkloginPass.CheckedChanged += new System.EventHandler(this.checkloginPass_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(811, 572);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LoginSign);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ComboBox combologinType;
        private System.Windows.Forms.TextBox textloginPass;
        private System.Windows.Forms.TextBox textloginName;
        private System.Windows.Forms.Label LoginSign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.CheckBox checkloginPass;
    }
}

