using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FIT_UTEHY
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        QLCBEntities db = new QLCBEntities();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldPw.Text.Trim() != "" && txtNewPw.Text.Trim() != "" && txtReNewPw.Text.Trim() != "")
            {
                if (txtOldPw.Text == Global.CurrentUser.MatKhau)
                {
                    if (txtReNewPw.Text == txtNewPw.Text)
                    {
                        if (txtNewPw.Text == txtOldPw.Text)
                        {
                            MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ");
                            txtNewPw.Focus();
                        }
                        else
                        {
                            TaiKhoan user = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == Global.CurrentUser.TenDangNhap);
                            user.MatKhau = txtNewPw.Text;
                            db.SaveChanges();
                            Global.CurrentUser.MatKhau = txtNewPw.Text;
                            MessageBox.Show("Thay đổi mật khẩu thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu nhập lại không chính xác");
                        txtReNewPw.Focus();
                    }
                }
                else
                {

                    MessageBox.Show("Mật khẩu cũ không chính xác");
                    txtOldPw.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
                if (txtOldPw.Text.Trim() == "")
                    errorProvider.SetError(txtOldPw, "Thiếu thông tin");
                if (txtNewPw.Text.Trim() == "")
                    errorProvider.SetError(txtNewPw, "Thiếu thông tin");
                if (txtReNewPw.Text.Trim() == "")
                    errorProvider.SetError(txtReNewPw, "Thiếu thông tin");
            }
        }
    }
}
