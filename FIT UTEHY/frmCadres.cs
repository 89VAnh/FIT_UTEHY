using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Windows.Forms;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FIT_UTEHY
{
    public partial class frmCadres : Form
    {
        QLCBEntities db = new QLCBEntities();
        public frmCadres()
        {
            InitializeComponent();
        }

        private void frmCadres_Load(object sender, EventArgs e)
        {
            var data = from d in db.CanBoes
                       select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
            dgvLecturer.DataSource = data.ToList();

            cboSubject.DataSource = db.BoMons.ToList();
            cboSubject.ValueMember = "MaBM";
            cboSubject.DisplayMember = "TenBM";
            cboLevel.DataSource = db.TrinhDoes.ToList();
            cboLevel.ValueMember = "MaTD";
            cboLevel.DisplayMember = "TenTD";
            cboPosition.DataSource = db.ChucVus.ToList();
            cboPosition.ValueMember = "MaCV";
            cboPosition.DisplayMember = "TenCV";
            Delete();
        }

        private void Delete()
        {           
            txtID.Clear();
            txtName.Clear();
            rdoMale.Checked = true;
            dtBirthday.Text="";
            txtAddress.Clear();
            cboSubject.SelectedIndex =  0;
            cboLevel.SelectedIndex =  0;
            cboPosition.SelectedIndex = 0;
            txtEmail.Clear();
            txtPhone.Clear();
            picture.Image = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.Length-9) + "Resources/noimage.png");
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file(.png,.jpg)|*.png;*.jpg";
            openFile.Title = "Chọn hình ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picture.Image = Image.FromFile(openFile.FileName);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(txtID.Text.Trim() != ""  && txtName.Text.Trim() != "" && txtAddress.Text.Trim()  != "" && txtEmail.Text.Trim() != ""  && txtPhone.Text.Trim() != "")
                {

                CanBo cb = new CanBo();
                cb.MaCB = int.Parse(txtID.Text);
                cb.Hovaten = txtName.Text;
                cb.Gioitinh = rdoMale.Checked ? "Nam" : "Nữ";
                cb.Ngaysinh = dtBirthday.Value;
                cb.Quequan = txtAddress.Text;
                cb.MaBM = Convert.ToInt16(cboSubject.SelectedValue);
                cb.MaTD = cboLevel.SelectedValue.ToString();
                cb.MaCV = cboPosition.SelectedValue.ToString();
                cb.Email = txtEmail.Text;
                cb.DT = txtPhone.Text;
                cb.Hinhanh = Global.ImgToBase64(picture.Image, picture.Image.RawFormat); ;
                db.CanBoes.Add(cb);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công !");
                frmCadres_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
                    if (txtID.Text.Trim() == "")
                        errId.SetError(txtID, "Thiếu thông tin");
                    if (txtName.Text.Trim() == "")
                        errName.SetError(txtName, "Thiếu thông tin");
                    if (txtAddress.Text.Trim() == "")
                        errAddress.SetError(txtAddress, "Thiếu thông tin");
                    if (txtEmail.Text.Trim() == "")
                        errEmail.SetError(txtEmail, "Thiếu thông tin");
                    if (txtPhone.Text.Trim() == "")
                        errPhone.SetError(txtPhone, "Thiếu thông tin");
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() != ""  && txtName.Text.Trim() != "" && txtAddress.Text.Trim()  != "" && txtEmail.Text.Trim() != ""  && txtPhone.Text.Trim() != "")
            {

                CanBo cb = db.CanBoes.SingleOrDefault(x => x.MaCB.ToString() == txtID.Text);
                cb.MaCB = Convert.ToInt32(txtID.Text);
                cb.Hovaten = txtName.Text;
                cb.Gioitinh = rdoMale.Checked ? "Nam" : "Nữ";
                cb.Ngaysinh = dtBirthday.Value;
                cb.Quequan = txtAddress.Text;
                cb.MaBM = Convert.ToInt16(cboSubject.SelectedValue);
                cb.MaTD = cboLevel.SelectedValue.ToString();
                cb.MaCV = cboPosition.SelectedValue.ToString();
                cb.Email = txtEmail.Text;
                cb.DT = txtPhone.Text;
                cb.Hinhanh = Global.ImgToBase64(picture.Image, picture.Image.RawFormat);
                db.SaveChanges();
                MessageBox.Show("Đã sửa thành công !");
                frmCadres_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CanBo d = db.CanBoes.SingleOrDefault(x => x.MaCB.ToString() == txtID.Text);
                db.CanBoes.Remove(d);
                db.SaveChanges();
                MessageBox.Show("Đã xoá thành công !");
                frmCadres_Load(sender, e);
            }
        }

        private void dgvLecturer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtID.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[0].Value);
                txtName.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[1].Value);
                if (dgvLecturer.Rows[e.RowIndex].Cells[2].Value.Equals("Nam"))
                    rdoMale.Checked = true;
                else
                    rdoFemale.Checked = true;
                dtBirthday.Value = Convert.ToDateTime(dgvLecturer.Rows[e.RowIndex].Cells[3].Value);
                txtAddress.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[4].Value);
                cboSubject.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[5].Value);
                cboLevel.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[6].Value);
                cboPosition.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[7].Value);
                txtEmail.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[8].Value);
                txtPhone.Text = Convert.ToString(dgvLecturer.Rows[e.RowIndex].Cells[9].Value);
                picture.Image = Global.Base64ToImg((byte[])dgvLecturer.Rows[e.RowIndex].Cells[10].Value);
            }
        }
        private void tsbExport_Click(object sender, EventArgs e)
        {
            if (dgvLecturer.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvLecturer.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvLecturer.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvLecturer.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvLecturer.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvLecturer.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            frmCadresReport frm = new frmCadresReport();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            dtBirthday.Value = DateTime.Now;           
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhone.Clear();

            var data = from d in db.CanBoes
                       select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
            dgvLecturer.DataSource = data.ToList();
        }
    }
}
