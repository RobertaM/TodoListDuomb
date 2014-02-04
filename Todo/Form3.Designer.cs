namespace WindowsFormsApplication6
{
    partial class Form3
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
            this.label5 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.surname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.save3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Name";
            // 
            // name2
            // 
            this.name2.Location = new System.Drawing.Point(108, 25);
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(165, 20);
            this.name2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Surname";
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(108, 69);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(165, 20);
            this.surname.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Phone number";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(108, 125);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(165, 20);
            this.phone.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Address";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(108, 169);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(165, 20);
            this.address.TabIndex = 13;
            // 
            // save3
            // 
            this.save3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save3.Location = new System.Drawing.Point(108, 220);
            this.save3.Name = "save3";
            this.save3.Size = new System.Drawing.Size(65, 23);
            this.save3.TabIndex = 14;
            this.save3.Text = "Save";
            this.save3.UseVisualStyleBackColor = true;
            this.save3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(207, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 253);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save3);
            this.Controls.Add(this.address);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.name2);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox name2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Button save3;
        private System.Windows.Forms.Button button2;
    }
}