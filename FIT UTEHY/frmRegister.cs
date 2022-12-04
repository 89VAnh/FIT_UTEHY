using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT_UTEHY
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        QLCBEntities db = new QLCBEntities();

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file(.png,.jpg)|*.png;*.jpg";
            openFile.Title = "Chọn hình ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picture.Image = Image.FromFile(openFile.FileName);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng ký không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "" && txtName.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtEmail.Text.Trim() != "")
                {

                    if (db.TaiKhoans.Where(tk => tk.TenDangNhap == txtUserName.Text).Count() == 0)
                    {
                        TaiKhoan tk = new TaiKhoan();

                        tk.TenDangNhap = txtUserName.Text;
                        tk.MatKhau = txtPassword.Text;
                        tk.HoTen = txtName.Text;
                        tk.DT = txtPhone.Text;
                        tk.Email = txtEmail.Text;
                        tk.Hinhanh = Global.ImgToBase64(picture.Image, picture.Image.RawFormat);

                        db.TaiKhoans.Add(tk);
                        db.SaveChanges();
                        MessageBox.Show("Chúc mừng bạn đã đăng ký thành công !");
                        this.Hide();
                        frmLogin f = new frmLogin();
                        f.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại !");
                        txtUserName.Focus();
                        txtUserName.SelectionStart = 0;
                        txtUserName.SelectionLength = txtUserName.Text.Length;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
                    if (txtUserName.Text.Trim() == "")
                        errorProvider.SetError(txtUserName, "Thiếu thông tin");
                    if (txtPassword.Text.Trim() == "")
                        errorProvider.SetError(txtPassword, "Thiếu thông tin");
                    if (txtName.Text.Trim() == "")
                        errorProvider.SetError(txtName, "Thiếu thông tin");
                    if (txtPhone.Text.Trim() == "")
                        errorProvider.SetError(txtPhone, "Thiếu thông tin");
                    if (txtEmail.Text.Trim() == "")
                        errorProvider.SetError(txtEmail, "Thiếu thông tin");
                }

            }
        }      
    }
}
