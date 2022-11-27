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
    public partial class frmLogin2 : Form
    {
        public frmLogin2()
        {
            InitializeComponent();
        }
        
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(d.TaiKhoans.Where(r=>r.TenTaiKhoan==txtUsername.Text && r.MatKhau == txtPassword.Text).Count()>0)
            //    {
            //        this.Hide();
            //        frmMain f = new frmMain();
            //        f.ShowDialog();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Tên tài khoản hoặc mật khẩu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
            //}
            //catch(Exception ert)
            //{

            //}
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void tswShow_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}
