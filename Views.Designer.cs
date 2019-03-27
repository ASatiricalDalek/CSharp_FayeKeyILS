namespace FayeKeyILS
{
    partial class Views
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
            this.slbl_PatronLabel = new System.Windows.Forms.Label();
            this.lst_Patrons = new System.Windows.Forms.ListBox();
            this.slbl_PatronName = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.slbl_PatronID = new System.Windows.Forms.Label();
            this.lbl_PatronID = new System.Windows.Forms.Label();
            this.slbl_PatronEmail = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.slbl_phone = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lst_CheckedOut = new System.Windows.Forms.ListBox();
            this.slbl_CheckedOutMaterials = new System.Windows.Forms.Label();
            this.slbl_ItemName = new System.Windows.Forms.Label();
            this.slbl_CheckoutDate = new System.Windows.Forms.Label();
            this.slbl_ReturnDate = new System.Windows.Forms.Label();
            this.slbl_Id = new System.Windows.Forms.Label();
            this.lbl_ItemName = new System.Windows.Forms.Label();
            this.lbl_CheckoutDate = new System.Windows.Forms.Label();
            this.lbl_ReturnDate = new System.Windows.Forms.Label();
            this.lbl_ItemID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // slbl_PatronLabel
            // 
            this.slbl_PatronLabel.AutoSize = true;
            this.slbl_PatronLabel.Location = new System.Drawing.Point(13, 23);
            this.slbl_PatronLabel.Name = "slbl_PatronLabel";
            this.slbl_PatronLabel.Size = new System.Drawing.Size(57, 13);
            this.slbl_PatronLabel.TabIndex = 1;
            this.slbl_PatronLabel.Text = "All Patrons";
            // 
            // lst_Patrons
            // 
            this.lst_Patrons.FormattingEnabled = true;
            this.lst_Patrons.Location = new System.Drawing.Point(12, 43);
            this.lst_Patrons.Name = "lst_Patrons";
            this.lst_Patrons.Size = new System.Drawing.Size(589, 225);
            this.lst_Patrons.TabIndex = 4;
            this.lst_Patrons.SelectedIndexChanged += new System.EventHandler(this.lst_Patrons_SelectedIndexChanged);
            this.lst_Patrons.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lst_Patrons_Format);
            // 
            // slbl_PatronName
            // 
            this.slbl_PatronName.AutoSize = true;
            this.slbl_PatronName.Location = new System.Drawing.Point(16, 288);
            this.slbl_PatronName.Name = "slbl_PatronName";
            this.slbl_PatronName.Size = new System.Drawing.Size(72, 13);
            this.slbl_PatronName.TabIndex = 5;
            this.slbl_PatronName.Text = "Patron Name:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(95, 288);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(0, 13);
            this.lbl_Name.TabIndex = 6;
            // 
            // slbl_PatronID
            // 
            this.slbl_PatronID.AutoSize = true;
            this.slbl_PatronID.Location = new System.Drawing.Point(16, 318);
            this.slbl_PatronID.Name = "slbl_PatronID";
            this.slbl_PatronID.Size = new System.Drawing.Size(55, 13);
            this.slbl_PatronID.TabIndex = 7;
            this.slbl_PatronID.Text = "Patron ID:";
            // 
            // lbl_PatronID
            // 
            this.lbl_PatronID.AutoSize = true;
            this.lbl_PatronID.Location = new System.Drawing.Point(98, 318);
            this.lbl_PatronID.Name = "lbl_PatronID";
            this.lbl_PatronID.Size = new System.Drawing.Size(0, 13);
            this.lbl_PatronID.TabIndex = 8;
            // 
            // slbl_PatronEmail
            // 
            this.slbl_PatronEmail.AutoSize = true;
            this.slbl_PatronEmail.Location = new System.Drawing.Point(16, 347);
            this.slbl_PatronEmail.Name = "slbl_PatronEmail";
            this.slbl_PatronEmail.Size = new System.Drawing.Size(72, 13);
            this.slbl_PatronEmail.TabIndex = 9;
            this.slbl_PatronEmail.Text = "Patron Email: ";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(98, 347);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(0, 13);
            this.lbl_email.TabIndex = 10;
            // 
            // slbl_phone
            // 
            this.slbl_phone.AutoSize = true;
            this.slbl_phone.Location = new System.Drawing.Point(16, 375);
            this.slbl_phone.Name = "slbl_phone";
            this.slbl_phone.Size = new System.Drawing.Size(75, 13);
            this.slbl_phone.TabIndex = 11;
            this.slbl_phone.Text = "Patron Phone:";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(98, 374);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(0, 13);
            this.lbl_phone.TabIndex = 12;
            // 
            // lst_CheckedOut
            // 
            this.lst_CheckedOut.FormattingEnabled = true;
            this.lst_CheckedOut.Location = new System.Drawing.Point(12, 461);
            this.lst_CheckedOut.Name = "lst_CheckedOut";
            this.lst_CheckedOut.Size = new System.Drawing.Size(333, 147);
            this.lst_CheckedOut.TabIndex = 13;
            this.lst_CheckedOut.SelectedIndexChanged += new System.EventHandler(this.lst_CheckedOut_SelectedIndexChanged);
            // 
            // slbl_CheckedOutMaterials
            // 
            this.slbl_CheckedOutMaterials.AutoSize = true;
            this.slbl_CheckedOutMaterials.Location = new System.Drawing.Point(12, 442);
            this.slbl_CheckedOutMaterials.Name = "slbl_CheckedOutMaterials";
            this.slbl_CheckedOutMaterials.Size = new System.Drawing.Size(206, 13);
            this.slbl_CheckedOutMaterials.TabIndex = 14;
            this.slbl_CheckedOutMaterials.Text = "Materials Checked Out to Selected Patron";
            // 
            // slbl_ItemName
            // 
            this.slbl_ItemName.AutoSize = true;
            this.slbl_ItemName.Location = new System.Drawing.Point(369, 480);
            this.slbl_ItemName.Name = "slbl_ItemName";
            this.slbl_ItemName.Size = new System.Drawing.Size(64, 13);
            this.slbl_ItemName.TabIndex = 15;
            this.slbl_ItemName.Text = "Item Name: ";
            // 
            // slbl_CheckoutDate
            // 
            this.slbl_CheckoutDate.AutoSize = true;
            this.slbl_CheckoutDate.Location = new System.Drawing.Point(351, 504);
            this.slbl_CheckoutDate.Name = "slbl_CheckoutDate";
            this.slbl_CheckoutDate.Size = new System.Drawing.Size(82, 13);
            this.slbl_CheckoutDate.TabIndex = 16;
            this.slbl_CheckoutDate.Text = "Checkout Date:";
            // 
            // slbl_ReturnDate
            // 
            this.slbl_ReturnDate.AutoSize = true;
            this.slbl_ReturnDate.Location = new System.Drawing.Point(365, 530);
            this.slbl_ReturnDate.Name = "slbl_ReturnDate";
            this.slbl_ReturnDate.Size = new System.Drawing.Size(68, 13);
            this.slbl_ReturnDate.TabIndex = 17;
            this.slbl_ReturnDate.Text = "Return Date:";
            // 
            // slbl_Id
            // 
            this.slbl_Id.AutoSize = true;
            this.slbl_Id.Location = new System.Drawing.Point(389, 557);
            this.slbl_Id.Name = "slbl_Id";
            this.slbl_Id.Size = new System.Drawing.Size(44, 13);
            this.slbl_Id.TabIndex = 18;
            this.slbl_Id.Text = "Item ID:";
            // 
            // lbl_ItemName
            // 
            this.lbl_ItemName.AutoSize = true;
            this.lbl_ItemName.Location = new System.Drawing.Point(439, 480);
            this.lbl_ItemName.Name = "lbl_ItemName";
            this.lbl_ItemName.Size = new System.Drawing.Size(0, 13);
            this.lbl_ItemName.TabIndex = 19;
            // 
            // lbl_CheckoutDate
            // 
            this.lbl_CheckoutDate.AutoSize = true;
            this.lbl_CheckoutDate.Location = new System.Drawing.Point(439, 504);
            this.lbl_CheckoutDate.Name = "lbl_CheckoutDate";
            this.lbl_CheckoutDate.Size = new System.Drawing.Size(0, 13);
            this.lbl_CheckoutDate.TabIndex = 20;
            // 
            // lbl_ReturnDate
            // 
            this.lbl_ReturnDate.AutoSize = true;
            this.lbl_ReturnDate.Location = new System.Drawing.Point(439, 530);
            this.lbl_ReturnDate.Name = "lbl_ReturnDate";
            this.lbl_ReturnDate.Size = new System.Drawing.Size(0, 13);
            this.lbl_ReturnDate.TabIndex = 21;
            // 
            // lbl_ItemID
            // 
            this.lbl_ItemID.AutoSize = true;
            this.lbl_ItemID.Location = new System.Drawing.Point(439, 557);
            this.lbl_ItemID.Name = "lbl_ItemID";
            this.lbl_ItemID.Size = new System.Drawing.Size(0, 13);
            this.lbl_ItemID.TabIndex = 22;
            // 
            // Views
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 629);
            this.Controls.Add(this.lbl_ItemID);
            this.Controls.Add(this.lbl_ReturnDate);
            this.Controls.Add(this.lbl_CheckoutDate);
            this.Controls.Add(this.lbl_ItemName);
            this.Controls.Add(this.slbl_Id);
            this.Controls.Add(this.slbl_ReturnDate);
            this.Controls.Add(this.slbl_CheckoutDate);
            this.Controls.Add(this.slbl_ItemName);
            this.Controls.Add(this.slbl_CheckedOutMaterials);
            this.Controls.Add(this.lst_CheckedOut);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.slbl_phone);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.slbl_PatronEmail);
            this.Controls.Add(this.lbl_PatronID);
            this.Controls.Add(this.slbl_PatronID);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.slbl_PatronName);
            this.Controls.Add(this.lst_Patrons);
            this.Controls.Add(this.slbl_PatronLabel);
            this.Name = "Views";
            this.Text = "Views";
            this.Load += new System.EventHandler(this.Views_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label slbl_PatronLabel;
        private System.Windows.Forms.ListBox lst_Patrons;
        private System.Windows.Forms.Label slbl_PatronName;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label slbl_PatronID;
        private System.Windows.Forms.Label lbl_PatronID;
        private System.Windows.Forms.Label slbl_PatronEmail;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label slbl_phone;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.ListBox lst_CheckedOut;
        private System.Windows.Forms.Label slbl_CheckedOutMaterials;
        private System.Windows.Forms.Label slbl_ItemName;
        private System.Windows.Forms.Label slbl_CheckoutDate;
        private System.Windows.Forms.Label slbl_ReturnDate;
        private System.Windows.Forms.Label slbl_Id;
        private System.Windows.Forms.Label lbl_ItemName;
        private System.Windows.Forms.Label lbl_CheckoutDate;
        private System.Windows.Forms.Label lbl_ReturnDate;
        private System.Windows.Forms.Label lbl_ItemID;
    }
}