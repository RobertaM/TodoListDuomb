namespace WindowsFormsApplication6
{
    partial class Form2
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
            this.label3 = new System.Windows.Forms.Label();
            this.TaskTypes2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ToDo2 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.TextBox();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.seve2 = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Task type";
            // 
            // TaskTypes2
            // 
            this.TaskTypes2.AllowDrop = true;
            this.TaskTypes2.FormattingEnabled = true;
            this.TaskTypes2.Items.AddRange(new object[] {
            "Home",
            "University/School",
            "Sports",
            "Work",
            "Other"});
            this.TaskTypes2.Location = new System.Drawing.Point(108, 25);
            this.TaskTypes2.Name = "TaskTypes2";
            this.TaskTypes2.Size = new System.Drawing.Size(153, 21);
            this.TaskTypes2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To-do ";
            // 
            // ToDo2
            // 
            this.ToDo2.Location = new System.Drawing.Point(108, 72);
            this.ToDo2.Name = "ToDo2";
            this.ToDo2.Size = new System.Drawing.Size(352, 81);
            this.ToDo2.TabIndex = 8;
            this.ToDo2.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Deadline";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(108, 244);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(153, 20);
            this.date2.TabIndex = 10;
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(303, 165);
            this.monthCalendar3.MaxSelectionCount = 1;
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 11;
            this.monthCalendar3.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateChanged);
            // 
            // seve2
            // 
            this.seve2.Location = new System.Drawing.Point(20, 304);
            this.seve2.Name = "seve2";
            this.seve2.Size = new System.Drawing.Size(75, 23);
            this.seve2.TabIndex = 12;
            this.seve2.Text = "Save";
            this.seve2.UseVisualStyleBackColor = true;
            this.seve2.Click += new System.EventHandler(this.edit2_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(108, 304);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 346);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.seve2);
            this.Controls.Add(this.monthCalendar3);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ToDo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TaskTypes2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TaskTypes2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ToDo2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox date2;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.Button seve2;
        private System.Windows.Forms.Button cancel;
    }
}