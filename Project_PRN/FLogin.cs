using Project_PRN.Models;

namespace Project_PRN
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        DAO Dao = new DAO();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserNameLogin.Text;
            string password = txtPasswordLogin.Text;
            Account acc = new Account(userName, password);
            if (Dao.checkAccount(acc))
            {
                ManageCoffe f = new ManageCoffe(userName,password);
                this.Hide();    
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show($"UserName or Password is not valid {userName} {password}","Error");
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are you sure to Exit", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }
    }
}