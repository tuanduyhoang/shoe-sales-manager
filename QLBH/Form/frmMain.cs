using QLBH.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmMain : Form

    {
        bool isThoat = true;
        //System.Timers.Timer t;
        //int h, m, s;
        public frmMain(string tentk)
        {
            InitializeComponent();
            //lbUserName.Text = tentk;
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            frmDMChatLieu frmChatLieu = new frmDMChatLieu();
            frmChatLieu.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect(); //Mở kết nối
            //t = new System.Timers.Timer();
            //t.Interval = 1000;
            //t.Elapsed += OnTimeEvent;
            //t.Start();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanvien frmNV = new frmDMNhanvien();
            frmNV.ShowDialog();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frmKH = new frmDMKhachHang();
            frmKH.ShowDialog();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHang frmHH = new frmDMHang();
            frmHH.ShowDialog();
        }

        private void mnuHDBH_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHDB = new frmHoaDonBan();
            frmHDB.ShowDialog();
        }

        

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //t.Stop();
           //Application.DoEvents();
        }

        private void rpBC_Click(object sender, EventArgs e)
        {
            crBaoCao crbc = new crBaoCao();
            crbc.ShowDialog();
        }
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            //Invoke(new Action(() =>
            //{
            //    s += 1;
            //    if (s == 60)
            //    {
            //        s = 0;
            //        m += 1;
            //    }
            //    if (m == 60)
            //    {
            //        m = 0;
            //        h += 1;
            //    }
            //    txtResult.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            //}));

        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            frmDangNhap formDangNhap = new frmDangNhap();
            formDangNhap.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
            {
                Application.Exit();
            }
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            //CPS doiMK = new CPS();
            //doiMK.ShowDialog();
        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }

        private void mnuTKHD_Click(object sender, EventArgs e)
        {
            frmTimKiem tk = new frmTimKiem();
            tk.ShowDialog();
        }
    }
}
