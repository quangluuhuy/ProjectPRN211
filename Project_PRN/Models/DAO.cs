using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PRN.Models
{
    internal class DAO
    {
        public List<Account> GetAccountsList()
        {
            var accounts = new List<Account>();
            try
            {
                using var context = new QuanlyQuanCafeContext();
                accounts = context.Accounts.ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return accounts;
        }

       
        public bool checkAccount(Account account)
        {
            bool check;
            try
            {
                using var context = new QuanlyQuanCafeContext();
                check = context.Accounts.FromSqlRaw("SELECT * FROM Account WHERE UserName " +
                    "COLLATE SQL_Latin1_General_Cp850_CS_AS like {0} " +
                    "AND Password COLLATE SQL_Latin1_General_Cp850_CS_AS like {1}", 
                    account.UserName, account.Password).Any();
            }
            catch (Exception)
            {
                throw;
            }
            return check;
        }

        public bool checkAdminRole(string userName, string password)
        {
            bool check = false;
            try
            {
                using var context = new QuanlyQuanCafeContext();
                var checkRole = context.Accounts
                    .Where(acc => acc.UserName == userName && acc.Password == password && acc.Type == 1)
                    .FirstOrDefault();
                if(checkRole != null)
                {
                    check = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return check;
        }

        public List<Table> GetTableList()
        {
            var table = new List<Table>();
            try
            {
                using var context = new QuanlyQuanCafeContext();
                table = context.Tables.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return table;
        }

        public List<FoodCategory> GetCategoryList()
        {
            var categories = new List<FoodCategory>();
            try
            {
                using var context = new QuanlyQuanCafeContext();
                categories = context.FoodCategories.ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return categories;
        }

        public int getIdBill(int tableID)
        {
            int billId;
            try
            {
                using var context = new QuanlyQuanCafeContext();
                billId = Convert.ToInt32(
                            (from b in context.Bills
                            where b.IdTable == tableID && b.Status == 0
                            select b.Id)
                            .FirstOrDefault());



            }
            catch (Exception)
            {

                throw;
            }
            return billId;
        }

        public int getIdFood(string category, string foodName)
        {
            int FoodId;
            try
            {
                using var context = new QuanlyQuanCafeContext();
                FoodId = Convert.ToInt32(
                            (from f in context.Foods
                             join fc in context.FoodCategories
                             on f.IdCategory equals fc.Id
                             where f.Name == foodName && fc.Name == category
                             select f.Id).FirstOrDefault());
            }
            catch (Exception)
            {

                throw;
            }
            return FoodId;
        }
        public void addBill(BillDetail billDetail, Bill bill)
        {
            try
            {
                using var context = new QuanlyQuanCafeContext();
                var billId = context.Bills.Where(b => b.IdTable == bill.IdTable && b.Status == 0).FirstOrDefault();
                if (billId == null)
                {
                    //Add bill
                    context.Bills.Add(bill);
                    context.SaveChanges();
                    billId = context.Bills.OrderByDescending(c => c.Id).FirstOrDefault();
                    //Add billDetail
                    billDetail.IdBill = billId.Id;
                    context.BillDetails.Add(billDetail);
                    context.SaveChanges();
                }
                else
                {
                    context.BillDetails.Add(billDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void deleteBill(int billID)
        {
            try
            {
                using var context = new QuanlyQuanCafeContext();
                var billsDetailToDelete = context.Bills.Where(b => b.Id == billID);
                context.Bills.RemoveRange(billsDetailToDelete);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void deleteBillDetail(int billID, int foodID)
        {
            try
            {
                using var context = new QuanlyQuanCafeContext();
                var billsDetailToDelete = context.Bills.Where(b => b.Id == billID);
                context.Bills.RemoveRange(billsDetailToDelete);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void checkoutBill(int billID, int discount, int totalPrice)
        {
            try
            {
                DateTime checkoutDate = DateTime.Now;
                using var context = new QuanlyQuanCafeContext();
                var checkoutBill = context.Bills.Where(b => b.Id == billID);
                foreach (var item in checkoutBill)
                {
                    item.DateCheckOut = checkoutDate;
                    item.Discount = discount;
                    item.Status = 1;
                    item.TotalPrice = totalPrice;
                }
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
       






    }
}
