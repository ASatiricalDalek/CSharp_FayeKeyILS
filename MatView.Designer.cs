namespace FayeKeyILS
{
    partial class MatView
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
            this.lst_Mat = new System.Windows.Forms.ListBox();
            this.slbl_PatronLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_Mat
            // 
            this.lst_Mat.FormattingEnabled = true;
            this.lst_Mat.HorizontalScrollbar = true;
            this.lst_Mat.ItemHeight = 25;
            this.lst_Mat.Location = new System.Drawing.Point(14, 62);
            this.lst_Mat.Margin = new System.Windows.Forms.Padding(6);
            this.lst_Mat.Name = "lst_Mat";
            this.lst_Mat.Size = new System.Drawing.Size(1354, 529);
            this.lst_Mat.TabIndex = 6;
            this.lst_Mat.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lst_Mat_Format);
            // 
            // slbl_PatronLabel
            // 
            this.slbl_PatronLabel.AutoSize = true;
            this.slbl_PatronLabel.Location = new System.Drawing.Point(16, 23);
            this.slbl_PatronLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.slbl_PatronLabel.Name = "slbl_PatronLabel";
            this.slbl_PatronLabel.Size = new System.Drawing.Size(130, 25);
            this.slbl_PatronLabel.TabIndex = 5;
            this.slbl_PatronLabel.Text = "All Materials";
            // 
            // MatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 650);
            this.Controls.Add(this.lst_Mat);
            this.Controls.Add(this.slbl_PatronLabel);
            this.Name = "MatView";
            this.Text = "MatView";
            this.Load += new System.EventHandler(this.MatView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_Mat;
        private System.Windows.Forms.Label slbl_PatronLabel;
    }
}