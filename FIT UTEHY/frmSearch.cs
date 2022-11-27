using ControlzEx.Standard;
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
    public partial class frmSearch : Form
    {
        QLCBEntities db = new QLCBEntities();

        public frmSearch()
        {
            InitializeComponent();
        }
        //private void LoadDB()
        //{
        //    var data = from d in db.CanBoes
        //               select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
        //    dgvSearch.DataSource = data.ToList();
        //    cboSubject.DataSource = db.BoMons.ToList();
        //    cboSubject.ValueMember = "MaBM";
        //    cboSubject.DisplayMember = "TenBM";
        //}
        //private void frmSubject_Load(object sender, EventArgs e)
        //{
        //    LoadDB();
        //}

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    //var data = from d in db.CanBoes
        //    //           where d.Hovaten.Contains(txtKeyword.Text) && d.MaBM == (short)cboSubject.SelectedValue
        //    //           select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
        //    //dgvSubject.DataSource = data.ToList();
        //}

       
        int i = 0;
        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            i=1;

        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            i=2;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtKey.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập từ khoá", "Nhập từ khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (i == 1)
                    {
                        var data = from d in db.CanBoes
                                   select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };

                        if(ckbSubject.Checked == false)
                        {
                         data = from d in db.CanBoes
                                   where (d.MaCB.ToString()).Contains(txtKey.Text)
                                   select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
                        }
                        else
                        {
                             data = from d in db.CanBoes
                                       where (d.MaCB.ToString()).Contains(txtKey.Text) && d.MaBM.ToString() == cboSubject.SelectedValue.ToString()
                                       select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
                        }
                        dgvSearch.DataSource = data.ToList();
                        txtKey.Clear();
                    }
                    if (i == 2)
                    {
                        var data = from d in db.CanBoes
                                   select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };

                        if (ckbSubject.Checked == false)
                        {
                            data = from d in db.CanBoes
                                   where (d.MaCB.ToString()).Contains(txtKey.Text)
                                   select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
                        }
                        else
                        {
                             data = from d in db.CanBoes
                                       where d.Hovaten.Contains(txtKey.Text) && d.MaBM.ToString() == cboSubject.SelectedValue.ToString()
                                   select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
                        }
                        dgvSearch.DataSource = data.ToList();
                        txtKey.Clear();
                    }
                    


                }
            }
            catch
            {
                MessageBox.Show("Tìm kiếm sai");
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            var data = from d in db.CanBoes
                       select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
            dgvSearch.DataSource = data.ToList();

            cboSubject.DataSource = db.BoMons.ToList();
            cboSubject.ValueMember = "MaBM";
            cboSubject.DisplayMember = "TenBM";
        }

        private void cboSubject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ckbSubject.Checked == true)
            {
                var data = db.GetCanBoByMaBM((short)cboSubject.SelectedValue);
                dgvSearch.DataSource = data.ToList();
            }
        }

        private void ckbSubject_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbSubject.Checked == false)
            {
                var data = from d in db.CanBoes
                           select new { d.MaCB, d.Hovaten, d.Gioitinh, d.Ngaysinh, d.Quequan, d.BoMon.TenBM, d.TrinhDo.TenTD, d.ChucVu.TenCV, d.Email, d.DT, d.Hinhanh };
                dgvSearch.DataSource = data.ToList();
            }
        }
    }
}
