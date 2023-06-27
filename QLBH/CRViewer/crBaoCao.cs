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
    public partial class crBaoCao : Form
    {
        public crBaoCao()
        {
            InitializeComponent();
        }

        private void crBaoCao_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"E:\\HSK\\QLBH\\QLBH\\QLBH\\CrystalReports\\CrHD.rpt");
            //ParameterFieldDefinition pfd = rpt.DataDefinition.ParameterFields["nguoilap"];
            //ParameterValues pv = new ParameterValues();
            //ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //pdv.Value = txtnguoilap.Text;
            //pv.Add(pdv);
            //pfd.CurrentValues.Clear();
            //pfd.ApplyCurrentValues(pv);
            // rpt.RecordSelectionFormula = "{tblSach.iSoLuong} > 40";
            //rpt.GroupSelectionFormula = "{tblSach.sLoaiSach}";
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
        //public void ShowReport()
        //{
        //    ReportDocument reportDocument = new ReportDocument();
        //    string path = "E:\\HSK\\QLBH\\QLBH\\QLBH\\CrystalReports\\CrHD.rpt";

        //    reportDocument.Load(path);

        //    crystalReportViewer1.ReportSource = reportDocument;
        //    Show();
        //}
    }
}
