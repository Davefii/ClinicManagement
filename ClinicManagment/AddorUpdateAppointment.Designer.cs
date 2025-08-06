namespace ClinicManagment
{
    partial class AddorUpdateAppointment
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
            this.ctrlAddorUpdateAppointment1 = new ClinicManagment.ctrlAddorUpdateAppointment();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlAddorUpdateAppointment1
            // 
            this.ctrlAddorUpdateAppointment1.BackColor = System.Drawing.Color.White;
            this.ctrlAddorUpdateAppointment1.Location = new System.Drawing.Point(12, 12);
            this.ctrlAddorUpdateAppointment1.Name = "ctrlAddorUpdateAppointment1";
            this.ctrlAddorUpdateAppointment1.Size = new System.Drawing.Size(539, 298);
            this.ctrlAddorUpdateAppointment1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(437, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddorUpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlAddorUpdateAppointment1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddorUpdateAppointment";
            this.Text = "AddorUpdateAppointment";
            this.Load += new System.EventHandler(this.AddorUpdateAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAddorUpdateAppointment ctrlAddorUpdateAppointment1;
        private System.Windows.Forms.Button button1;
    }
}