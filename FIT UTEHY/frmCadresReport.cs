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
    public partial class frmCadresReport : Form
    {
        public frmCadresReport()
        {
            InitializeComponent();
        }

        private void frmCadresReport_Load(object sender, EventArgs e)
        {
            QLCBEntities db = new QLCBEntities();

            var data = db.CanBoes.Select(cb => new
            {
                cb.MaCB,
                cb.Hovaten,
                cb.Gioitinh,
                cb.Ngaysinh,
                cb.Quequan,
                cb.BoMon.TenBM,
                cb.TrinhDo.TenTD,
                cb.ChucVu.TenCV,
                cb.Email,
                cb.DT
            }).ToList();
            rptReportCadres rpt = new rptReportCadres();
            rpt.SetDataSource(data.ToList());


            crystalReportCadres.ReportSource = rpt;
            crystalReportCadres.RefreshReport();
        }
    }
}
