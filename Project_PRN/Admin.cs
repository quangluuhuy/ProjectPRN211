using Project_PRN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_PRN
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        DAO Dao = new DAO();

        private void Admin_Load(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();

            //get all Bill in database
            var billBindingSource = new BindingSource();
            var getAllbill = (from b in context.Bills
                              join t in context.Tables
                              on b.IdTable equals t.Id
                              where b.Status == 1
                              select new { t.Name, b.DateCheckIn, b.DateCheckOut, b.TotalPrice, b.Discount }).ToList();
            billBindingSource.DataSource = getAllbill;
            dgvRevenue.AutoGenerateColumns = false;
            dgvRevenue.Columns.Add("Name", "Table Name");
            dgvRevenue.Columns[0].DataPropertyName = "Name";
            dgvRevenue.Columns.Add("DateCheckIn", "Time Checkin");
            dgvRevenue.Columns[1].DataPropertyName = "DateCheckIn";
            dgvRevenue.Columns.Add("DateCheckOut", "Time Checkout");
            dgvRevenue.Columns[2].DataPropertyName = "DateCheckOut";
            dgvRevenue.Columns.Add("TotalPrice", "Total Price");
            dgvRevenue.Columns[3].DataPropertyName = "TotalPrice";
            dgvRevenue.Columns.Add("Discount", "Discount");
            dgvRevenue.Columns[4].DataPropertyName = "Discount";
            dgvRevenue.DataSource = billBindingSource;

            //get All account in database
            cbRoleAccount.Items.Add("Admin");
            cbRoleAccount.Items.Add("Employee");
            var accountBindingSource = new BindingSource();
            var getAllAcount = (from acc in context.Accounts
                                select new { acc.UserName, acc.DisplayName, acc.Password, acc.Type }).ToList();
            accountBindingSource.DataSource = getAllAcount;
            dgvAccount.AutoGenerateColumns = false;
            dgvAccount.Columns.Add("UserName", "UserName");
            dgvAccount.Columns[0].DataPropertyName = "UserName";
            dgvAccount.Columns.Add("DisplayName", "NickName");
            dgvAccount.Columns[1].DataPropertyName = "DisplayName";
            dgvAccount.Columns.Add("Password", "Password");
            dgvAccount.Columns[2].DataPropertyName = "Password";
            dgvAccount.Columns.Add("Type", "Role");
            dgvAccount.Columns[3].DataPropertyName = "Type";
            dgvAccount.DataSource = accountBindingSource;

            //get All Food
            List<FoodCategory> listCategories = Dao.GetCategoryList();
            foreach (var item in listCategories)
            {
                cbFoodCategory.Items.Add(item.Name);
            }
            var foodBindingSource = new BindingSource();
            var getAllFood = (from f in context.Foods
                              join cate in context.FoodCategories
                              on f.IdCategory equals cate.Id
                              select new {No = f.Id, f.Name, CategoriesName = cate.Name, f.Price }).ToList();
            foodBindingSource.DataSource = getAllFood;
            dgvFood.DataSource = foodBindingSource;
            //get All Food Categories
            var categoryBindingSource = new BindingSource();
            var getAllCategories = (from cate in context.FoodCategories
                                    select new {No = cate.Id, cate.Name}).ToList();
            categoryBindingSource.DataSource = getAllCategories;
            dgvCategory.DataSource = categoryBindingSource;
            //get All Table
            var tableBindingSource = new BindingSource();
            var getAllTable = (from t in context.Tables
                                    select new { No = t.Id, t.Name }).ToList();
            tableBindingSource.DataSource = getAllTable;
            dgvTable.DataSource = tableBindingSource;





        }


        private void btnStatistic_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimePickerFromDate.Value;
            DateTime dateTo = dateTimePickerToDate.Value;
            dgvRevenue.DataSource = null;
            dgvRevenue.Columns.Clear();   
            using var context = new QuanlyQuanCafeContext();
            var billBindingSource = new BindingSource();
            var getAllbill = (from b in context.Bills
                              join t in context.Tables
                              on b.IdTable equals t.Id
                              where b.Status == 1
                              && (b.DateCheckIn >= dateFrom && b.DateCheckIn <= dateTo)
                              && (b.DateCheckOut >= dateFrom && b.DateCheckOut <= dateTo)
                              select new { t.Name, b.DateCheckIn, b.DateCheckOut, b.TotalPrice, b.Discount }).ToList();
            billBindingSource.DataSource = getAllbill;
            dgvRevenue.AutoGenerateColumns = false;
            dgvRevenue.Columns.Add("Name", "Table Name");
            dgvRevenue.Columns[0].DataPropertyName = "Name";
            dgvRevenue.Columns.Add("DateCheckIn", "Time Checkin");
            dgvRevenue.Columns[1].DataPropertyName = "DateCheckIn";
            dgvRevenue.Columns.Add("DateCheckOut", "Time Checkout");
            dgvRevenue.Columns[2].DataPropertyName = "DateCheckOut";
            dgvRevenue.Columns.Add("TotalPrice", "Total Price");
            dgvRevenue.Columns[3].DataPropertyName = "TotalPrice";
            dgvRevenue.Columns.Add("Discount", "Discount");
            dgvRevenue.Columns[4].DataPropertyName = "Discount";
            dgvRevenue.DataSource = billBindingSource;
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            foreach (var item in cbFoodCategory.Items)
            {
                if (item.ToString().Equals(dgvFood.Rows[dgvFood.CurrentCell.RowIndex].Cells[2].Value))
                {

                    cbFoodCategory.SelectedIndex = i;

                }
                i++;

            }
            txtFoodID.DataBindings.Add("Text", dgvFood.DataSource, "No", true, DataSourceUpdateMode.Never);
            txtFoodID.DataBindings.Clear();
            txtFoodName.DataBindings.Add("Text", dgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtFoodName.DataBindings.Clear();
            numericUpDownFoodPrice.DataBindings.Add("Text", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never);
            numericUpDownFoodPrice.DataBindings.Clear();
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTableID.DataBindings.Add("Text", dgvTable.DataSource, "No", true, DataSourceUpdateMode.Never);
            txtTableID.DataBindings.Clear();
            txtTableName.DataBindings.Add("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtTableName.DataBindings.Clear();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoryID.DataBindings.Add("Text", dgvCategory.DataSource, "No", true, DataSourceUpdateMode.Never);
            txtCategoryID.DataBindings.Clear();
            txtCategoryName.DataBindings.Add("Text", dgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtCategoryName.DataBindings.Clear();
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            txtUserName.DataBindings.Add("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never);
            txtUserName.DataBindings.Clear();
            txtNickName.DataBindings.Add("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never);
            txtNickName.DataBindings.Clear();
            txtPassword.DataBindings.Add("Text", dgvAccount.DataSource, "Password", true, DataSourceUpdateMode.Never);
            txtPassword.DataBindings.Clear();
            string role = dgvAccount.Rows[dgvAccount.CurrentCell.RowIndex].Cells[2].Value.ToString();
            if ("1".Equals(role))
            {
                role = "Admin";
            }
            else
            {
                role= "Employee";
            }
            int i = 0;
            foreach (var item in cbRoleAccount.Items)
            {
                if (item.ToString().Equals(role))
                {
                    cbRoleAccount.SelectedIndex= i;
                }
                i++;
            }

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string foodName = txtFoodName.Text;
                List<FoodCategory> listCategories = Dao.GetCategoryList();
                int i = 1;
                int cateID = 0;
                foreach (var item in listCategories)
                {
                    if (item.Name.Equals(cbFoodCategory.Text))
                    {
                        cateID = i;
                    }
                    i++;
                }
                float price = Convert.ToInt32(numericUpDownFoodPrice.Value);
                Food newFood = new Food(foodName, cateID, price);
                using var context = new QuanlyQuanCafeContext();
                context.Foods.Add(newFood);
                context.SaveChanges();
                //ReLoad
                dgvFood.DataSource = null;
                dgvFood.Columns.Clear();
                var foodBindingSource = new BindingSource();
                var getAllFood = (from f in context.Foods
                                  join cate in context.FoodCategories
                                  on f.IdCategory equals cate.Id
                                  select new { No = f.Id, f.Name, CategoriesName = cate.Name, f.Price }).ToList();
                foodBindingSource.DataSource = getAllFood;
                dgvFood.DataSource = foodBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Add fail");
                
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtFoodID.Text);
                string foodName = txtFoodName.Text;
                List<FoodCategory> listCategories = Dao.GetCategoryList();
                int i = 1;
                int cateID = 0;
                foreach (var item in listCategories)
                {
                    if (item.Name.Equals(cbFoodCategory.Text))
                    {
                        cateID = i;
                    }
                    i++;
                }
                float price = Convert.ToInt32(numericUpDownFoodPrice.Value);
                Food newFood = new Food(id, foodName, cateID, price);
                using var context = new QuanlyQuanCafeContext();
                context.Foods.Remove(newFood);
                context.SaveChanges();
                //ReLoad
                dgvFood.DataSource = null;
                dgvFood.Columns.Clear();
                var foodBindingSource = new BindingSource();
                var getAllFood = (from f in context.Foods
                                  join cate in context.FoodCategories
                                  on f.IdCategory equals cate.Id
                                  select new { No = f.Id, f.Name, CategoriesName = cate.Name, f.Price }).ToList();
                foodBindingSource.DataSource = getAllFood;
                dgvFood.DataSource = foodBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Delete Fail");
                
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtFoodID.Text);
                string foodName = txtFoodName.Text;
                List<FoodCategory> listCategories = Dao.GetCategoryList();
                int i = 1;
                int cateID = 0;
                foreach (var item in listCategories)
                {
                    if (item.Name.Equals(cbFoodCategory.Text))
                    {
                        cateID = i;
                    }
                    i++;
                }
                float price = Convert.ToInt32(numericUpDownFoodPrice.Value);
                Food newFood = new Food(id, foodName, cateID, price);
                using var context = new QuanlyQuanCafeContext();
                context.Foods.Update(newFood);
                context.SaveChanges();
                //ReLoad
                dgvFood.DataSource = null;
                dgvFood.Columns.Clear();
                var foodBindingSource = new BindingSource();
                var getAllFood = (from f in context.Foods
                                  join cate in context.FoodCategories
                                  on f.IdCategory equals cate.Id
                                  select new { No = f.Id, f.Name, CategoriesName = cate.Name, f.Price }).ToList();
                foodBindingSource.DataSource = getAllFood;
                dgvFood.DataSource = foodBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Update fail");
                
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            string searching = txtSearchFood.Text;
            dgvFood.DataSource = null;
            dgvFood.Columns.Clear();
            var foodBindingSource = new BindingSource();
            var getAllFood = (from f in context.Foods
                              join cate in context.FoodCategories
                              on f.IdCategory equals cate.Id
                              where f.Name.Contains(searching)
                              select new { No = f.Id, f.Name, CategoriesName = cate.Name, f.Price }).ToList();
            foodBindingSource.DataSource = getAllFood;
            dgvFood.DataSource = foodBindingSource;
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            dgvFood.DataSource = null;
            dgvFood.Columns.Clear();
            var foodBindingSource = new BindingSource();
            var getAllFood = (from f in context.Foods
                              join cate in context.FoodCategories
                              on f.IdCategory equals cate.Id
                              select new { No = f.Id, f.Name, CategoriesName = cate.Name, f.Price }).ToList();
            foodBindingSource.DataSource = getAllFood;
            dgvFood.DataSource = foodBindingSource;
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtTableName.Text;
                Table addTable = new Table(Name, "None Booking");
                using var context = new QuanlyQuanCafeContext();
                context.Tables.Add(addTable);
                context.SaveChanges();
                //Reload
                dgvTable.DataSource = null;
                dgvTable.Columns.Clear();
                var tableBindingSource = new BindingSource();
                var getAllTable = (from t in context.Tables
                                   select new { No = t.Id, t.Name }).ToList();
                tableBindingSource.DataSource = getAllTable;
                dgvTable.DataSource = tableBindingSource;

            }
            catch (Exception)
            {
                MessageBox.Show("Add fail");
                
            }

        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtTableID.Text);
                string Name = txtTableName.Text;
                Table addTable = new Table(id ,Name);
                using var context = new QuanlyQuanCafeContext();
                context.Tables.Remove(addTable);
                context.SaveChanges();
                //Reload
                dgvTable.DataSource = null;
                dgvTable.Columns.Clear();
                var tableBindingSource = new BindingSource();
                var getAllTable = (from t in context.Tables
                                   select new { No = t.Id, t.Name }).ToList();
                tableBindingSource.DataSource = getAllTable;
                dgvTable.DataSource = tableBindingSource;

            }
            catch (Exception)
            {
                MessageBox.Show("Delete fail");
                
            }
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtTableID.Text);
                string Name = txtTableName.Text;
                Table addTable = new Table(id, Name,"None Booking");
                using var context = new QuanlyQuanCafeContext();
                context.Tables.Update(addTable);
                context.SaveChanges();
                //Reload
                dgvTable.DataSource = null;
                dgvTable.Columns.Clear();
                var tableBindingSource = new BindingSource();
                var getAllTable = (from t in context.Tables
                                   select new { No = t.Id, t.Name }).ToList();
                tableBindingSource.DataSource = getAllTable;
                dgvTable.DataSource = tableBindingSource;

            }
            catch (Exception)
            {
                MessageBox.Show("Update fail");
                
            }
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            string serching  = txtSearchTable.Text;
            dgvTable.DataSource = null;
            dgvTable.Columns.Clear();
            var tableBindingSource = new BindingSource();
            var getAllTable = (from t in context.Tables
                               where t.Name.Contains(serching)
                               select new { No = t.Id, t.Name }).ToList();
            tableBindingSource.DataSource = getAllTable;
            dgvTable.DataSource = tableBindingSource;

        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            dgvTable.DataSource = null;
            dgvTable.Columns.Clear();
            var tableBindingSource = new BindingSource();
            var getAllTable = (from t in context.Tables
                               select new { No = t.Id, t.Name }).ToList();
            tableBindingSource.DataSource = getAllTable;
            dgvTable.DataSource = tableBindingSource;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text;
                using var context = new QuanlyQuanCafeContext();
                var getAllCategories = (from cate in context.FoodCategories
                                        select new { No = cate.Id, cate.Name }).ToList();
                var getAllCategoriesName = getAllCategories.Select(x => x.Name).ToList();
                if (getAllCategoriesName.Contains(categoryName))
                {
                    throw new Exception();
                }
                
                FoodCategory category = new FoodCategory(categoryName);
                context.FoodCategories.Add(category);
                context.SaveChanges();
                //Reload
                dgvCategory.DataSource = null;
                dgvCategory.Columns.Clear();
                var categoryBindingSource = new BindingSource();

                categoryBindingSource.DataSource = getAllCategories;
                dgvCategory.DataSource = categoryBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Add fail");

            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text;
                using var context = new QuanlyQuanCafeContext();
                var getAllCategories = (from cate in context.FoodCategories
                                        select new { No = cate.Id, cate.Name }).ToList();
                var getAllCategoriesName = getAllCategories.Select(x => x.Name).ToList();
                if (getAllCategoriesName.Contains(categoryName))
                {
                    throw new Exception();
                }

                FoodCategory category = new FoodCategory(categoryName);
                context.FoodCategories.Remove(category);
                context.SaveChanges();
                //Reload
                dgvCategory.DataSource = null;
                dgvCategory.Columns.Clear();
                var categoryBindingSource = new BindingSource();

                categoryBindingSource.DataSource = getAllCategories;
                dgvCategory.DataSource = categoryBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("remove fail");

            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtTableID.Text);
                string categoryName = txtCategoryName.Text;
                using var context = new QuanlyQuanCafeContext();
                FoodCategory category = new FoodCategory(id, categoryName);
                context.FoodCategories.Update(category);
                context.SaveChanges();
                //Reload
                dgvCategory.DataSource = null;
                dgvCategory.Columns.Clear();
                var categoryBindingSource = new BindingSource();
                var getAllCategories = (from cate in context.FoodCategories
                                        select new { No = cate.Id, cate.Name }).ToList();
                categoryBindingSource.DataSource = getAllCategories;
                dgvCategory.DataSource = categoryBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Update fail");
                
            }
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            dgvCategory.DataSource = null;
            dgvCategory.Columns.Clear();
            var categoryBindingSource = new BindingSource();
            var getAllCategories = (from cate in context.FoodCategories
                                    select new { No = cate.Id, cate.Name }).ToList();
            categoryBindingSource.DataSource = getAllCategories;
            dgvCategory.DataSource = categoryBindingSource;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                using var context = new QuanlyQuanCafeContext();
                string userName = txtUserName.Text;
                string displayName = txtNickName.Text;
                int role = 0;
                if (cbRoleAccount.Text.Equals("Admin"))
                {
                    role = 1;
                }
                Account account = new Account(userName, displayName,"1", role);
                context.Accounts.Add(account);
                context.SaveChanges();
                //Reload
                dgvAccount.DataSource = null;
                dgvAccount.Columns.Clear();
                var accountBindingSource = new BindingSource();
                var getAllAcount = (from acc in context.Accounts
                                    select new { acc.UserName, acc.DisplayName, acc.Type }).ToList();
                accountBindingSource.DataSource = getAllAcount;
                dgvAccount.AutoGenerateColumns = false;
                dgvAccount.Columns.Add("UserName", "UserName");
                dgvAccount.Columns[0].DataPropertyName = "UserName";
                dgvAccount.Columns.Add("DisplayName", "NickName");
                dgvAccount.Columns[1].DataPropertyName = "DisplayName";
                dgvAccount.Columns.Add("Type", "Role");
                dgvAccount.Columns[2].DataPropertyName = "Type";
                dgvAccount.DataSource = accountBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Add fail");
                
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                using var context = new QuanlyQuanCafeContext();
                string userName = txtUserName.Text;
                string displayName = txtNickName.Text;
                int role = 0;
                if (cbRoleAccount.Text.Equals("Admin"))
                {
                     role = 1;
                }
                Account account = new Account(userName, displayName, role);
                context.Accounts.Remove(account);
                context.SaveChanges();
                //Reload
                dgvAccount.DataSource = null;
                dgvAccount.Columns.Clear();
                var accountBindingSource = new BindingSource();
                var getAllAcount = (from acc in context.Accounts
                                    select new { acc.UserName, acc.DisplayName, acc.Type }).ToList();
                accountBindingSource.DataSource = getAllAcount;
                dgvAccount.AutoGenerateColumns = false;
                dgvAccount.Columns.Add("UserName", "UserName");
                dgvAccount.Columns[0].DataPropertyName = "UserName";
                dgvAccount.Columns.Add("DisplayName", "NickName");
                dgvAccount.Columns[1].DataPropertyName = "DisplayName";
                dgvAccount.Columns.Add("Type", "Role");
                dgvAccount.Columns[2].DataPropertyName = "Type";
                dgvAccount.DataSource = accountBindingSource;


            }
            catch (Exception)
            {
                MessageBox.Show("Delete fail");
                
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                using var context = new QuanlyQuanCafeContext();
                string userName = txtUserName.Text;
                string displayName = txtNickName.Text;
                int role = 0;
                if (cbRoleAccount.Text.Equals("Admin"))
                {
                    role = 1;
                }
                string password = txtPassword.Text;
                Account account = new Account(userName, displayName,password, role);
                context.Accounts.Update(account);
                context.SaveChanges();
                //Reload
                dgvAccount.DataSource = null;
                dgvAccount.Columns.Clear();
                var accountBindingSource = new BindingSource();
                var getAllAcount = (from acc in context.Accounts
                                    select new { acc.UserName, acc.DisplayName, acc.Password, acc.Type }).ToList();
                accountBindingSource.DataSource = getAllAcount;
                dgvAccount.AutoGenerateColumns = false;
                dgvAccount.Columns.Add("UserName", "UserName");
                dgvAccount.Columns[0].DataPropertyName = "UserName";
                dgvAccount.Columns.Add("DisplayName", "NickName");
                dgvAccount.Columns[1].DataPropertyName = "DisplayName";
                dgvAccount.Columns.Add("Password", "Password");
                dgvAccount.Columns[2].DataPropertyName = "Password";
                dgvAccount.Columns.Add("Type", "Role");
                dgvAccount.Columns[3].DataPropertyName = "Type";
                dgvAccount.DataSource = accountBindingSource;
            }
            catch (Exception)
            {
                MessageBox.Show("Update fail");
            }
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            dgvAccount.DataSource = null;
            dgvAccount.Columns.Clear();
            var accountBindingSource = new BindingSource();
            var getAllAcount = (from acc in context.Accounts
                                select new { acc.UserName, acc.DisplayName, acc.Type }).ToList();
            accountBindingSource.DataSource = getAllAcount;
            dgvAccount.AutoGenerateColumns = false;
            dgvAccount.Columns.Add("UserName", "UserName");
            dgvAccount.Columns[0].DataPropertyName = "UserName";
            dgvAccount.Columns.Add("DisplayName", "NickName");
            dgvAccount.Columns[1].DataPropertyName = "DisplayName";
            dgvAccount.Columns.Add("Type", "Role");
            dgvAccount.Columns[2].DataPropertyName = "Type";
            dgvAccount.DataSource = accountBindingSource;
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            string searching = txtSearchAccount.Text;
            using var context = new QuanlyQuanCafeContext();
            dgvAccount.DataSource = null;
            dgvAccount.Columns.Clear();
            var accountBindingSource = new BindingSource();
            var getAllAcount = (from acc in context.Accounts
                                where acc.UserName.Contains(searching)
                                select new { acc.UserName, acc.DisplayName, acc.Type }).ToList();
            accountBindingSource.DataSource = getAllAcount;
            dgvAccount.AutoGenerateColumns = false;
            dgvAccount.Columns.Add("UserName", "UserName");
            dgvAccount.Columns[0].DataPropertyName = "UserName";
            dgvAccount.Columns.Add("DisplayName", "NickName");
            dgvAccount.Columns[1].DataPropertyName = "DisplayName";
            dgvAccount.Columns.Add("Type", "Role");
            dgvAccount.Columns[2].DataPropertyName = "Type";
            dgvAccount.DataSource = accountBindingSource;
        }

        private void dgvAccount_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
