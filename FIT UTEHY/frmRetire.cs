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
    public partial class frmRetire : Form
    {
        QLCBEntities db = new QLCBEntities();
        public frmRetire()
        {
            InitializeComponent();
        }
        private void LoadDB()
        {
            var data = from d in db.NghiHuus
                       select new {d.MaCB,d.Hovaten,d.NgayNghi,d.BoMon.TenBM};
            dgvRetire.DataSource = data.ToList();
        }
        private void infoRefresh()
        {
            txtID.Clear();
            txtName.Clear();
            dtRetire.Text="";          
            cboSubject.SelectedIndex = 0;
            txtKeyword.Clear();
        }

        private void frmRetire_Load(object sender, EventArgs e)
        {
            var data = from d in db.NghiHuus
                       select new { d.MaCB, d.Hovaten, d.NgayNghi, d.BoMon.TenBM };
            dgvRetire.DataSource = data.ToList();
            cboSubject.DataSource = db.BoMons.ToList();
            cboSubject.ValueMember = "MaBM";
            cboSubject.DisplayMember = "TenBM";
            infoRefresh();

        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtID.Text.Trim() != ""  && txtName.Text.Trim() != "" )
                {
                    NghiHuu cb = new NghiHuu();
                    cb.MaCB = Convert.ToInt16(txtID.Text);
                    cb.Hovaten = txtName.Text;
                    cb.MaBM = Convert.ToInt16(cboSubject.SelectedValue);
                    cb.NgayNghi = dtRetire.Value;
                    db.NghiHuus.Add(cb);
                    db.SaveChanges();
                    MessageBox.Show("Đã thêm thành công !");
                    frmRetire_Load(sender,e);
                }

                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
                    if (txtID.Text.Trim() == "")
                        errID.SetError(txtID, "Thiếu thông tin");
                    if (txtName.Text.Trim() == "")
                        errName.SetError(txtName, "Thiếu thông tin");

                }
            }
        }

        private void cboSubject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //var data = db.GetNghiHuuByMaBM((short)cboSubject.SelectedValue);
            //dgvRetire.DataSource = data.ToList();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            NghiHuu cb = db.NghiHuus.SingleOrDefault(x => x.MaCB.ToString() == txtID.Text);
            cb.MaCB = Convert.ToInt16(txtID.Text);
            cb.Hovaten = txtName.Text;
            cb.MaBM = Convert.ToInt16(cboSubject.SelectedValue);
            cb.NgayNghi = dtRetire.Value;
            MessageBox.Show("Đã sửa thành công !");
            frmRetire_Load(sender, e);
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NghiHuu d = db.NghiHuus.SingleOrDefault(x => x.MaCB.ToString() == txtID.Text);
                db.NghiHuus.Remove(d);
                db.SaveChanges();
                MessageBox.Show("Đã xoá thành công !");
                frmRetire_Load(sender, e);
            }
        }

        private void dgvRetire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtID.Text = Convert.ToString(dgvRetire.Rows[e.RowIndex].Cells[0].Value);
                txtName.Text = Convert.ToString(dgvRetire.Rows[e.RowIndex].Cells[1].Value);
                dtRetire.Value = Convert.ToDateTime(dgvRetire.Rows[e.RowIndex].Cells[2].Value);
                cboSubject.Text = Convert.ToString(dgvRetire.Rows[e.RowIndex].Cells[3].Value);
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            var data = from d in db.NghiHuus
                       where d.Hovaten.Contains(txtKeyword.Text)
                       select new { d.MaCB, d.Hovaten, d.NgayNghi, d.BoMon.TenBM };
            dgvRetire.DataSource = data.ToList();
            
        }

        private void dgvRetire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            if (dgvRetire.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvRetire.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvRetire.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvRetire.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvRetire.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvRetire.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            dtRetire.Value = DateTime.Now;
            cboSubject.SelectedIndex =  0;
            txtKeyword.Clear();
            var data = from d in db.NghiHuus
                       select new { d.MaCB, d.Hovaten, d.NgayNghi, d.BoMon.TenBM };
            dgvRetire.DataSource = data.ToList();

        }

      
    }
}
