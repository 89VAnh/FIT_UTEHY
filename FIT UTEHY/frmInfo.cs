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
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        QLCBEntities db = new QLCBEntities();

        private void frmInfo_Load(object sender, EventArgs e)
        {
            TaiKhoan user = Global.CurrentUser;
            txtName.Text = user.HoTen;
            txtPhone.Text = user.DT;
            txtEmail.Text = user.Email;
            picture.Image = Global.Base64ToImg(user.Hinhanh);

            txtUserName.Text = user.TenDangNhap;
            txtPassword.Text = user.MatKhau;
        }

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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtEmail.Text.Trim() != "")
            {

                TaiKhoan user = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == txtUserName.Text);
                user.HoTen = txtName.Text;
                user.Email = txtEmail.Text;
                user.DT = txtPhone.Text;
                user.Hinhanh = Global.ImgToBase64(picture.Image, picture.Image.RawFormat);
                db.SaveChanges();
                Global.CurrentUser = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == Global.CurrentUser.TenDangNhap);
                MessageBox.Show("Đã sửa thành công !");
                frmInfo_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
