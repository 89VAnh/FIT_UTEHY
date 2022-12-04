using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT_UTEHY
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        QLCBEntities d = new QLCBEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (d.TaiKhoans.Where(tk => tk.TenDangNhap == txtUserName.Text && tk.MatKhau == txtPassword.Text).Count() > 0)
            {
                Global.CurrentUser = d.TaiKhoans.Where(tk => tk.TenDangNhap == txtUserName.Text).FirstOrDefault();//nạp tt tài khoản 

                this.Hide();
                frmMain f = new frmMain();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tswShow_CheckedChanged(object sender, EventArgs e)
        {
            if (tswShow.Checked == true)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '●';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister f = new frmRegister();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
