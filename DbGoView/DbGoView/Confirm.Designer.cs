namespace DbGoView
{
    partial class Confirm
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
            this.metroConfirmLabel = new MetroFramework.Controls.MetroLabel();
            this.metroYesButton = new MetroFramework.Controls.MetroButton();
            this.metroNoButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroConfirmLabel
            // 
            this.metroConfirmLabel.AutoSize = true;
            this.metroConfirmLabel.Location = new System.Drawing.Point(94, 60);
            this.metroConfirmLabel.Name = "metroConfirmLabel";
            this.metroConfirmLabel.Size = new System.Drawing.Size(89, 19);
            this.metroConfirmLabel.TabIndex = 0;
            this.metroConfirmLabel.Text = "Are you sure?";
            // 
            // metroYesButton
            // 
            this.metroYesButton.Location = new System.Drawing.Point(41, 99);
            this.metroYesButton.Name = "metroYesButton";
            this.metroYesButton.Size = new System.Drawing.Size(75, 23);
            this.metroYesButton.TabIndex = 1;
            this.metroYesButton.Text = "Yes";
            this.metroYesButton.UseSelectable = true;
            this.metroYesButton.Click += new System.EventHandler(this.metroYesButton_Click);
            // 
            // metroNoButton
            // 
            this.metroNoButton.Location = new System.Drawing.Point(177, 99);
            this.metroNoButton.Name = "metroNoButton";
            this.metroNoButton.Size = new System.Drawing.Size(75, 23);
            this.metroNoButton.TabIndex = 2;
            this.metroNoButton.Text = "No";
            this.metroNoButton.UseSelectable = true;
            this.metroNoButton.Click += new System.EventHandler(this.metroNoButton_Click);
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 138);
            this.Controls.Add(this.metroNoButton);
            this.Controls.Add(this.metroYesButton);
            this.Controls.Add(this.metroConfirmLabel);
            this.Name = "Confirm";
            this.Text = "Confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroConfirmLabel;
        private MetroFramework.Controls.MetroButton metroYesButton;
        private MetroFramework.Controls.MetroButton metroNoButton;
    }
}