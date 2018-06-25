namespace ValoGari.com
{
    partial class frmNew
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
            this.lblWarrenty = new System.Windows.Forms.Label();
            this.txtWarrenty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWarrenty
            // 
            this.lblWarrenty.AutoSize = true;
            this.lblWarrenty.Location = new System.Drawing.Point(12, 210);
            this.lblWarrenty.Name = "lblWarrenty";
            this.lblWarrenty.Size = new System.Drawing.Size(50, 13);
            this.lblWarrenty.TabIndex = 24;
            this.lblWarrenty.Text = "Warrenty";
            // 
            // txtWarrenty
            // 
            this.txtWarrenty.Location = new System.Drawing.Point(116, 210);
            this.txtWarrenty.Name = "txtWarrenty";
            this.txtWarrenty.Size = new System.Drawing.Size(141, 20);
            this.txtWarrenty.TabIndex = 25;
            // 
            // frmNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtWarrenty);
            this.Controls.Add(this.lblWarrenty);
            this.Name = "frmNew";
            this.Text = "frmNew";
            //this.Load += new System.EventHandler(this.frmNew_Load);
            this.Controls.SetChildIndex(this.lblWarrenty, 0);
            this.Controls.SetChildIndex(this.txtWarrenty, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWarrenty;
        private System.Windows.Forms.TextBox txtWarrenty;
    }
}