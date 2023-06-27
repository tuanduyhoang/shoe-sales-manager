using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class crNhanVien : Form
    {
        public crNhanVien()
        {
            InitializeComponent();
        }

        private void CRViewerNV_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"E:\\HSK\\QLBH\\QLBH\\QLBH\\CrystalReport1.rpt");
            CRViewerNV.ReportSource = rpt;
            CRViewerNV.Refresh();
        }
    }
}
