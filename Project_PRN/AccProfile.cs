using Project.Models;
using Project_PRN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PRN
{
    public partial class AccProfile : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccProfile()
        {
            InitializeComponent();
        }

        public AccProfile(string username, string password)
        {
            InitializeComponent();
            Username = username;
            Password = password;
        }

        private void AccProfile_Load(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            var accountProfile = context.Accounts.
                Where(acc => acc.UserName == Username && acc.Password == Password).
                FirstOrDefault();
            txtUserNameProfile.Text = accountProfile.UserName;
            txtNickName.Text = accountProfile.DisplayName;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using var context = new QuanlyQuanCafeContext();
            string userName = txtUserNameProfile.Text;
            string displayName = txtNickName.Text;
            string password = txtPassword.Text;
            string pass1 = txtNewPass1.Text;
            string pass2 = txtNewPass2.Text;
            var accountProfile = context.Accounts.
                Where(acc => acc.UserName == userName && acc.Password == password).
                FirstOrDefault();
            if (accountProfile != null)
            {
                if (pass1.Equals(pass2))
                {
                    accountProfile.Password = pass1;
                    context.SaveChanges();
                    MessageBox.Show("Update successful");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("New password not similar");
                }
            }
            else
            {
                MessageBox.Show("Password was not correct.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
