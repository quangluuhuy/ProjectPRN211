using Microsoft.IdentityModel.Tokens;
using Project_PRN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PRN
{
    public partial class ManageCoffe : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ManageCoffe()
        {
            InitializeComponent();

        }

        public ManageCoffe(string username, string password)
        {
            InitializeComponent();
            Username = username;
            Password = password;
        }

        DAO Dao = new DAO();
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void profileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string userName = this.Username;
            string password = this.Password;
            AccProfile accountProfile = new AccProfile(userName, password);
            accountProfile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = Username;
            string password = Password;
            using var context = new QuanlyQuanCafeContext();
            if (Dao.checkAdminRole(userName, password))
            {
                Admin admin = new Admin();
                admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("You do not have access to this site.");
            }
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ManageCoffe_Load(object sender, EventArgs e)
        {
            flowLayoutPanelTable.Controls.Clear();
            cbListCategory.Items.Clear();
            //Add combobox FoodCategories
            List<FoodCategory> foodCategories = Dao.GetCategoryList();
            foreach (var item in foodCategories)
            {
                cbListCategory.Items.Add(item.Name);
            }
            //Add table
            List<Table> listTables = Dao.GetTableList();
            using var context = new QuanlyQuanCafeContext();
            foreach (Table table in listTables)
            {
                cbSwitchTable.Items.Add(table.Name);
                var foodByTable = context.Bills.Where(b => b.IdTable == table.Id && b.Status == 0).FirstOrDefault();
                if (foodByTable != null)
                {
                    table.Status = "Booking";
                    context.SaveChanges();
                }
                Button btn = new Button() { Width = 120, Height = 120 };
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += btn_Click;
                btn.Tag = table;
                if ("None Booking".Equals(table.Status))
                {
                    btn.BackColor = Color.LightGray;
                }
                else
                {
                    btn.BackColor = Color.LightGreen;
                }
                flowLayoutPanelTable.Controls.Add(btn);

            }
        }

        int tableID;
        private void btn_Click(object? sender, EventArgs e)
        {
            lisBill.Items.Clear();
            tableID = ((sender as Button).Tag as Table).Id;//Convert the button.Tag to Table
            using var context = new QuanlyQuanCafeContext();
            var listFoodByTable = from bd in context.BillDetails
                                  join b in context.Bills on bd.IdBill equals b.Id
                                  join t in context.Tables on b.IdTable equals t.Id
                                  join f in context.Foods on bd.Idfood equals f.Id
                                  where b.IdTable == tableID && b.Status == 0
                                  select new { b.Id, f.Name, bd.Count, f.Price };
            String check = "";
            double totalPrice = 0;
            //List order of table clicked
            foreach (var item in listFoodByTable)
            {
                check += item.Name + " " + item.Count + " " + item.Price;
                ListViewItem lsvItem = new ListViewItem(item.Name);
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add((item.Count * item.Price).ToString());
                totalPrice += (item.Count * item.Price);
                lisBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = (totalPrice - (totalPrice * discount/100)).ToString("c", culture);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string categories = cbListCategory.Text;
            string ItemName = cbListFoodNamebyCategories.Text;
            int quantity = Convert.ToInt32(nUDQuantity.Value);
            int billID = Dao.getIdBill(tableID);
            int foodID = Dao.getIdFood(categories, ItemName);
            BillDetail billDetail = new BillDetail(billID, foodID, quantity);
            using var context = new QuanlyQuanCafeContext();
            //Validate before updateFood
            if (quantity == 0)
            {
                MessageBox.Show("Please select the number of items");
            }
            else if (categories.IsNullOrEmpty())
            {
                MessageBox.Show("Please select categories of items");
            }
            else if (ItemName.IsNullOrEmpty())
            {
                MessageBox.Show("Please select items");
            }
            else
            {
                var foodByTable = context.BillDetails
                    .Where(bd => bd.IdBill == billID && bd.Idfood == foodID)
                    .FirstOrDefault();

                if (foodByTable != null)//BillDetail exist
                {
                    foodByTable.Count += quantity;
                    context.SaveChanges();
                    if (foodByTable.Count <= 0 && lisBill.Items.Count == 1) {//Delete the last item in the billDetail

                        var billsDetailToDelete = context.BillDetails.Where(bd => bd.IdBill == billID && bd.Idfood == foodID);
                        context.BillDetails.RemoveRange(billsDetailToDelete);
                        context.SaveChanges();
                        Dao.deleteBill(billID);
                    }
                    else if(foodByTable.Count <= 0)//Delete the item in the billDetail
                    {
                        var billsDetailToDelete = context.BillDetails.Where(bd => bd.IdBill == billID && bd.Idfood == foodID);
                        context.BillDetails.RemoveRange(billsDetailToDelete);
                        context.SaveChanges();
                    }
                }
                else//BillDetail not exist
                {
                    if(quantity < 0 && lisBill.Items.Count == 0)
                    {
                        MessageBox.Show("Error to reduce the items");
                        
                    }
                    else
                    {
                        DateTime currentDateTime = DateTime.Now;
                        int tableBillID = tableID;
                        Bill bill = new Bill(currentDateTime, null, tableBillID);
                        Dao.addBill(billDetail, bill);
                    }
                }
            }
            loadForm();
        }

        public void loadForm()
        {
            flowLayoutPanelTable.Controls.Clear();
            cbListCategory.Items.Clear();
            List<FoodCategory> foodCategories = Dao.GetCategoryList();
            foreach (var item in foodCategories)
            {
                cbListCategory.Items.Add(item.Name);
            }
            List<Table> listTables = Dao.GetTableList();
            using var context = new QuanlyQuanCafeContext();
            foreach (Table table in listTables)
            {
                var foodByTable = context.Bills.Where(bd => bd.IdTable == table.Id && bd.Status == 0).FirstOrDefault();
                if (foodByTable != null)
                {
                    table.Status = "Booking";
                    context.SaveChanges();
                }
                Button btn = new Button() { Width = 120, Height = 120 };
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += btn_Click;
                btn.Tag = table;
                if ("None Booking".Equals(table.Status))
                {
                    btn.BackColor = Color.LightGray;
                }
                else
                {
                    btn.BackColor = Color.LightGreen;
                }
                flowLayoutPanelTable.Controls.Add(btn);

            }

            lisBill.Items.Clear();
            var listFoodByTable = from bd in context.BillDetails
                                  join b in context.Bills on bd.IdBill equals b.Id
                                  join t in context.Tables on b.IdTable equals t.Id
                                  join f in context.Foods on bd.Idfood equals f.Id
                                  where b.IdTable == tableID && b.Status == 0
                                  select new { b.Id, f.Name, bd.Count, f.Price };
            String check = "";
            double totalPrice = 0;
            foreach (var item in listFoodByTable)
            {
                check += item.Name + " " + item.Count + " " + item.Price;
                ListViewItem lsvItem = new ListViewItem(item.Name);
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add((item.Count * item.Price).ToString());
                totalPrice += (item.Count * item.Price);
                lisBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = (totalPrice - (totalPrice * discount/100)).ToString("c", culture);
        }
        private void lisBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbListFoodNamebyCategories.Items.Clear();
            string categoryname = cbListCategory.Text;
            using var context = new QuanlyQuanCafeContext();
            var foods = from f in context.Foods
                        join fc in context.FoodCategories
                        on f.IdCategory equals fc.Id
                        where fc.Name == categoryname
                        select new {f.Name};
            foreach (var item in foods)
            {
                cbListFoodNamebyCategories.Items.Add(item.Name);
            }
            cbListFoodNamebyCategories.SelectedIndex = 0;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            int totalPrice = int.Parse(txtTotalPrice.Text, NumberStyles.Currency, culture);
            int billID = Dao.getIdBill(tableID);
            if (MessageBox.Show("Are you sure to checkout table " + tableID, "Announcement", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Dao.checkoutBill(billID, discount, totalPrice);
            }
            loadForm();
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            if (cbSwitchTable.Text.IsNullOrEmpty() || tableID == 0)
            {
                MessageBox.Show("Please select the table you want to switch");
            }
            else
            {
                using var context = new QuanlyQuanCafeContext();
                var switchTableID = context.Tables.Where(t => t.Name == cbSwitchTable.Text).FirstOrDefault();
                if (switchTableID != null)
                {
                    var checkBooking = context.Bills.Where(b => b.IdTable == switchTableID.Id && b.Status == 0).FirstOrDefault();
                    if (checkBooking == null)
                    {
                        var switchbillTable = context.Bills.Where(b => b.IdTable == tableID).FirstOrDefault();
                        if (switchbillTable != null)
                        {
                            switchbillTable.IdTable = switchTableID.Id;
                            context.SaveChanges();
                            MessageBox.Show("Switch successful from:  " + " Table " + tableID + " to " + cbSwitchTable.Text);
                        }
                        else
                        {
                            MessageBox.Show("Error switching table");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can not switch to " + cbSwitchTable.Text );
                    }
                }
                else
                {
                    MessageBox.Show("Not valid table to switch");
                }
                loadForm();
            }
        }

        int discount = 0;
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            discount = Convert.ToInt32(nUDDiscount.Value);
            loadForm();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
