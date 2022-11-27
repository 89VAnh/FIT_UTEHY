using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT_UTEHY
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            btnList.Checked = true;
            btnSearch.Checked = false;
            btnRetire.Checked = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmCadres")
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            frmCadres frm = new frmCadres();
            frm.MdiParent = this;
            frm.Show();

        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            btnSearch.Checked = true;
            btnList.Checked = false;
            btnRetire.Checked = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmSubject")
                {
                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            frmSearch frm = new frmSearch();
            frm.MdiParent = this;
            frm.Show();

        }

        private void btnRetire_Click(object sender, EventArgs e)
        {
            btnRetire.Checked = true;
            btnSearch.Checked = false;
            btnList.Checked = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmRetire")
                {
                    f.WindowState = FormWindowState.Maximized;
                    f.Activate();
                    return;
                }
            }

            frmRetire frm = new frmRetire();
            frm.MdiParent = this;
            frm.Show();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất không ?", "Đăng xuất", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Global.CurrentUser = null;
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnAccount.Text = Global.CurrentUser.HoTen;
            btnAccount.Image = Global.Base64ToImg(Global.CurrentUser.Hinhanh);
        }


        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInfo f = new frmInfo();
            f.ShowDialog();
            this.Close();
        }
    }
}
