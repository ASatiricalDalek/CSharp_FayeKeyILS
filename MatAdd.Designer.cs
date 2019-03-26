namespace FayeKeyILS
{
    partial class MatAdd
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
            this.slbl_Email = new System.Windows.Forms.Label();
            this.slbl_LastName = new System.Windows.Forms.Label();
            this.slbl_FirstName = new System.Windows.Forms.Label();
            this.txtEmailAdd = new System.Windows.Forms.TextBox();
            this.txtLNameAdd = new System.Windows.Forms.TextBox();
            this.txtFNameAdd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // slbl_Email
            // 
            this.slbl_Email.AutoSize = true;
            this.slbl_Email.Location = new System.Drawing.Point(37, 319);
            this.slbl_Email.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.slbl_Email.Name = "slbl_Email";
            this.slbl_Email.Size = new System.Drawing.Size(150, 25);
            this.slbl_Email.TabIndex = 15;
            this.slbl_Email.Text = "Email Address";
            // 
            // slbl_LastName
            // 
            this.slbl_LastName.AutoSize = true;
            this.slbl_LastName.Location = new System.Drawing.Point(37, 211);
            this.slbl_LastName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.slbl_LastName.Name = "slbl_LastName";
            this.slbl_LastName.Size = new System.Drawing.Size(115, 25);
            this.slbl_LastName.TabIndex = 14;
            this.slbl_LastName.Text = "Last Name";
            // 
            // slbl_FirstName
            // 
            this.slbl_FirstName.AutoSize = true;
            this.slbl_FirstName.Location = new System.Drawing.Point(37, 111);
            this.slbl_FirstName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.slbl_FirstName.Name = "slbl_FirstName";
            this.slbl_FirstName.Size = new System.Drawing.Size(116, 25);
            this.slbl_FirstName.TabIndex = 13;
            this.slbl_FirstName.Text = "First Name";
            // 
            // txtEmailAdd
            // 
            this.txtEmailAdd.Location = new System.Drawing.Point(37, 350);
            this.txtEmailAdd.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new System.Drawing.Size(378, 31);
            this.txtEmailAdd.TabIndex = 12;
            // 
            // txtLNameAdd
            // 
            this.txtLNameAdd.Location = new System.Drawing.Point(37, 242);
            this.txtLNameAdd.Margin = new System.Windows.Forms.Padding(6);
            this.txtLNameAdd.Name = "txtLNameAdd";
            this.txtLNameAdd.Size = new System.Drawing.Size(378, 31);
            this.txtLNameAdd.TabIndex = 11;
            // 
            // txtFNameAdd
            // 
            this.txtFNameAdd.Location = new System.Drawing.Point(37, 142);
            this.txtFNameAdd.Margin = new System.Windows.Forms.Padding(6);
            this.txtFNameAdd.Name = "txtFNameAdd";
            this.txtFNameAdd.Size = new System.Drawing.Size(378, 31);
            this.txtFNameAdd.TabIndex = 10;
            // 
            // MatAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 1019);
            this.Controls.Add(this.slbl_Email);
            this.Controls.Add(this.slbl_LastName);
            this.Controls.Add(this.slbl_FirstName);
            this.Controls.Add(this.txtEmailAdd);
            this.Controls.Add(this.txtLNameAdd);
            this.Controls.Add(this.txtFNameAdd);
            this.Name = "MatAdd";
            this.Text = "MatAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label slbl_Email;
        private System.Windows.Forms.Label slbl_LastName;
        private System.Windows.Forms.Label slbl_FirstName;
        private System.Windows.Forms.TextBox txtEmailAdd;
        private System.Windows.Forms.TextBox txtLNameAdd;
        private System.Windows.Forms.TextBox txtFNameAdd;
    }
}