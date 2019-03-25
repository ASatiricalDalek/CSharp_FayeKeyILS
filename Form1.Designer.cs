namespace FayeKeyILS
{
    partial class main
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
            this.slbl_CheckoutSectionHeader = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.slbl_CheckoutLibraryIDLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.slbl_materialCheckoutLabel = new System.Windows.Forms.Label();
            this.btn_Checkout = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.slbl_ReturnSectionHeader = new System.Windows.Forms.Label();
            this.slbl_ReturnMaterialabel = new System.Windows.Forms.Label();
            this.btn_Return = new System.Windows.Forms.Button();
            this.viewPatronsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPatronsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMaterialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMaterialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slbl_CheckoutSectionHeader
            // 
            this.slbl_CheckoutSectionHeader.AutoSize = true;
            this.slbl_CheckoutSectionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slbl_CheckoutSectionHeader.Location = new System.Drawing.Point(12, 22);
            this.slbl_CheckoutSectionHeader.Name = "slbl_CheckoutSectionHeader";
            this.slbl_CheckoutSectionHeader.Size = new System.Drawing.Size(130, 31);
            this.slbl_CheckoutSectionHeader.TabIndex = 0;
            this.slbl_CheckoutSectionHeader.Text = "Checkout";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 1;
            // 
            // slbl_CheckoutLibraryIDLabel
            // 
            this.slbl_CheckoutLibraryIDLabel.AutoSize = true;
            this.slbl_CheckoutLibraryIDLabel.Location = new System.Drawing.Point(191, 86);
            this.slbl_CheckoutLibraryIDLabel.Name = "slbl_CheckoutLibraryIDLabel";
            this.slbl_CheckoutLibraryIDLabel.Size = new System.Drawing.Size(52, 13);
            this.slbl_CheckoutLibraryIDLabel.TabIndex = 2;
            this.slbl_CheckoutLibraryIDLabel.Text = "Library ID";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 116);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 20);
            this.textBox2.TabIndex = 3;
            // 
            // slbl_materialCheckoutLabel
            // 
            this.slbl_materialCheckoutLabel.AutoSize = true;
            this.slbl_materialCheckoutLabel.Location = new System.Drawing.Point(191, 123);
            this.slbl_materialCheckoutLabel.Name = "slbl_materialCheckoutLabel";
            this.slbl_materialCheckoutLabel.Size = new System.Drawing.Size(44, 13);
            this.slbl_materialCheckoutLabel.TabIndex = 4;
            this.slbl_materialCheckoutLabel.Text = "Material";
            // 
            // btn_Checkout
            // 
            this.btn_Checkout.Location = new System.Drawing.Point(160, 189);
            this.btn_Checkout.Name = "btn_Checkout";
            this.btn_Checkout.Size = new System.Drawing.Size(75, 23);
            this.btn_Checkout.TabIndex = 5;
            this.btn_Checkout.Text = "Checkout";
            this.btn_Checkout.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patronToolStripMenuItem,
            this.materialToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // patronToolStripMenuItem
            // 
            this.patronToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPatronsToolStripMenuItem,
            this.addPatronsToolStripMenuItem});
            this.patronToolStripMenuItem.Name = "patronToolStripMenuItem";
            this.patronToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patronToolStripMenuItem.Text = "Patron...";
            this.patronToolStripMenuItem.Click += new System.EventHandler(this.patronToolStripMenuItem_Click);
            // 
            // materialToolStripMenuItem
            // 
            this.materialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMaterialsToolStripMenuItem,
            this.addMaterialsToolStripMenuItem});
            this.materialToolStripMenuItem.Name = "materialToolStripMenuItem";
            this.materialToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materialToolStripMenuItem.Text = "Material...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(324, 79);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(142, 20);
            this.textBox3.TabIndex = 7;
            // 
            // slbl_ReturnSectionHeader
            // 
            this.slbl_ReturnSectionHeader.AutoSize = true;
            this.slbl_ReturnSectionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slbl_ReturnSectionHeader.Location = new System.Drawing.Point(318, 24);
            this.slbl_ReturnSectionHeader.Name = "slbl_ReturnSectionHeader";
            this.slbl_ReturnSectionHeader.Size = new System.Drawing.Size(96, 31);
            this.slbl_ReturnSectionHeader.TabIndex = 8;
            this.slbl_ReturnSectionHeader.Text = "Return";
            // 
            // slbl_ReturnMaterialabel
            // 
            this.slbl_ReturnMaterialabel.AutoSize = true;
            this.slbl_ReturnMaterialabel.Location = new System.Drawing.Point(472, 86);
            this.slbl_ReturnMaterialabel.Name = "slbl_ReturnMaterialabel";
            this.slbl_ReturnMaterialabel.Size = new System.Drawing.Size(44, 13);
            this.slbl_ReturnMaterialabel.TabIndex = 9;
            this.slbl_ReturnMaterialabel.Text = "Material";
            // 
            // btn_Return
            // 
            this.btn_Return.Location = new System.Drawing.Point(441, 189);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(75, 23);
            this.btn_Return.TabIndex = 10;
            this.btn_Return.Text = "Return";
            this.btn_Return.UseVisualStyleBackColor = true;
            // 
            // viewPatronsToolStripMenuItem
            // 
            this.viewPatronsToolStripMenuItem.Name = "viewPatronsToolStripMenuItem";
            this.viewPatronsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewPatronsToolStripMenuItem.Text = "View Patrons";
            this.viewPatronsToolStripMenuItem.Click += new System.EventHandler(this.viewPatronsToolStripMenuItem_Click);
            // 
            // addPatronsToolStripMenuItem
            // 
            this.addPatronsToolStripMenuItem.Name = "addPatronsToolStripMenuItem";
            this.addPatronsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addPatronsToolStripMenuItem.Text = "Add Patrons";
            this.addPatronsToolStripMenuItem.Click += new System.EventHandler(this.addPatronsToolStripMenuItem_Click);
            // 
            // viewMaterialsToolStripMenuItem
            // 
            this.viewMaterialsToolStripMenuItem.Name = "viewMaterialsToolStripMenuItem";
            this.viewMaterialsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewMaterialsToolStripMenuItem.Text = "View Materials";
            this.viewMaterialsToolStripMenuItem.Click += new System.EventHandler(this.viewMaterialsToolStripMenuItem_Click);
            // 
            // addMaterialsToolStripMenuItem
            // 
            this.addMaterialsToolStripMenuItem.Name = "addMaterialsToolStripMenuItem";
            this.addMaterialsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addMaterialsToolStripMenuItem.Text = "Add Materials";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 253);
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.slbl_ReturnMaterialabel);
            this.Controls.Add(this.slbl_ReturnSectionHeader);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btn_Checkout);
            this.Controls.Add(this.slbl_materialCheckoutLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.slbl_CheckoutLibraryIDLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.slbl_CheckoutSectionHeader);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "Faye Key ILS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label slbl_CheckoutSectionHeader;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label slbl_CheckoutLibraryIDLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label slbl_materialCheckoutLabel;
        private System.Windows.Forms.Button btn_Checkout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label slbl_ReturnSectionHeader;
        private System.Windows.Forms.Label slbl_ReturnMaterialabel;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.ToolStripMenuItem viewPatronsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPatronsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMaterialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMaterialsToolStripMenuItem;
    }
}

