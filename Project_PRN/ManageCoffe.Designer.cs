namespace Project_PRN
{
    partial class ManageCoffe
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lisBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nUDDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cbListFoodNamebyCategories = new System.Windows.Forms.ComboBox();
            this.cbListCategory = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.profileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem1,
            this.signOutToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem1
            // 
            this.profileToolStripMenuItem1.Name = "profileToolStripMenuItem1";
            this.profileToolStripMenuItem1.Size = new System.Drawing.Size(147, 26);
            this.profileToolStripMenuItem1.Text = "Profile";
            this.profileToolStripMenuItem1.Click += new System.EventHandler(this.profileToolStripMenuItem1_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lisBill);
            this.panel2.Location = new System.Drawing.Point(459, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 317);
            this.panel2.TabIndex = 1;
            // 
            // lisBill
            // 
            this.lisBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lisBill.Location = new System.Drawing.Point(0, 0);
            this.lisBill.Name = "lisBill";
            this.lisBill.Size = new System.Drawing.Size(433, 314);
            this.lisBill.TabIndex = 0;
            this.lisBill.UseCompatibleStateImageBehavior = false;
            this.lisBill.View = System.Windows.Forms.View.Details;
            this.lisBill.SelectedIndexChanged += new System.EventHandler(this.lisBill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total Price";
            this.columnHeader4.Width = 100;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Controls.Add(this.nUDDiscount);
            this.panel3.Controls.Add(this.btnDiscount);
            this.panel3.Controls.Add(this.btnCheckout);
            this.panel3.Location = new System.Drawing.Point(459, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(436, 75);
            this.panel3.TabIndex = 2;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTotalPrice.Location = new System.Drawing.Point(208, 18);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(125, 34);
            this.txtTotalPrice.TabIndex = 7;
            this.txtTotalPrice.Text = "0";
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(3, 44);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(101, 28);
            this.cbSwitchTable.TabIndex = 4;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(3, 6);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(101, 33);
            this.btnSwitchTable.TabIndex = 6;
            this.btnSwitchTable.Text = "SwitchTable";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // nUDDiscount
            // 
            this.nUDDiscount.Location = new System.Drawing.Point(110, 45);
            this.nUDDiscount.Name = "nUDDiscount";
            this.nUDDiscount.Size = new System.Drawing.Size(94, 27);
            this.nUDDiscount.TabIndex = 4;
            this.nUDDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(110, 6);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(94, 33);
            this.btnDiscount.TabIndex = 5;
            this.btnDiscount.Text = "Discount";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(339, 6);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(94, 62);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nUDQuantity);
            this.panel4.Controls.Add(this.btnAddNew);
            this.panel4.Controls.Add(this.cbListFoodNamebyCategories);
            this.panel4.Controls.Add(this.cbListCategory);
            this.panel4.Location = new System.Drawing.Point(459, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(436, 74);
            this.panel4.TabIndex = 3;
            // 
            // nUDQuantity
            // 
            this.nUDQuantity.Location = new System.Drawing.Point(365, 22);
            this.nUDQuantity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nUDQuantity.Name = "nUDQuantity";
            this.nUDQuantity.Size = new System.Drawing.Size(55, 27);
            this.nUDQuantity.TabIndex = 3;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(265, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(94, 62);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Add or Reduce";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cbListFoodNamebyCategories
            // 
            this.cbListFoodNamebyCategories.FormattingEnabled = true;
            this.cbListFoodNamebyCategories.Location = new System.Drawing.Point(3, 37);
            this.cbListFoodNamebyCategories.Name = "cbListFoodNamebyCategories";
            this.cbListFoodNamebyCategories.Size = new System.Drawing.Size(256, 28);
            this.cbListFoodNamebyCategories.TabIndex = 1;
            // 
            // cbListCategory
            // 
            this.cbListCategory.FormattingEnabled = true;
            this.cbListCategory.Location = new System.Drawing.Point(3, 3);
            this.cbListCategory.Name = "cbListCategory";
            this.cbListCategory.Size = new System.Drawing.Size(256, 28);
            this.cbListCategory.TabIndex = 0;
            this.cbListCategory.SelectedIndexChanged += new System.EventHandler(this.cbListCategory_SelectedIndexChanged);
            // 
            // flowLayoutPanelTable
            // 
            this.flowLayoutPanelTable.AutoScroll = true;
            this.flowLayoutPanelTable.Location = new System.Drawing.Point(12, 34);
            this.flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            this.flowLayoutPanelTable.Size = new System.Drawing.Size(441, 478);
            this.flowLayoutPanelTable.TabIndex = 4;
            this.flowLayoutPanelTable.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelTable_Paint);
            // 
            // ManageCoffe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 520);
            this.Controls.Add(this.flowLayoutPanelTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManageCoffe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageCoffe";
            this.Load += new System.EventHandler(this.ManageCoffe_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem1;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private Panel panel2;
        private ListView lisBill;
        private Panel panel3;
        private ComboBox cbSwitchTable;
        private Button btnSwitchTable;
        private NumericUpDown nUDDiscount;
        private Button btnDiscount;
        private Button btnCheckout;
        private Panel panel4;
        private NumericUpDown nUDQuantity;
        private Button btnAddNew;
        private ComboBox cbListFoodNamebyCategories;
        private ComboBox cbListCategory;
        private FlowLayoutPanel flowLayoutPanelTable;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox txtTotalPrice;
    }
}