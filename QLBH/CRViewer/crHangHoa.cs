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
    public partial class crHangHoa : Form
    {
        public crHangHoa()
        {
            InitializeComponent();
        }

       

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"E:\HSK\QLBH\QLBH\QLBH\CrystalReports\CrHangHoa.rpt");
            crystalReportViewer2.ReportSource = rpt;
            crystalReportViewer2.Refresh();
        }
    }
}
