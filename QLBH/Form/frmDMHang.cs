using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using QLBH.Class;


namespace QLBH
{
    public partial class frmDMHang : Form
    {
        private DataTable tblH; //Bảng hàng
        public frmDMHang()
        {
            InitializeComponent();
        }

        private void frmDMHang_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblChatLieu";
            txtMaHang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cboMaChatLieu, "sMaChatLieu", "sTenChatLieu");
            cboMaChatLieu.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            cboMaChatLieu.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblHang";
            tblH = Class.Functions.GetDataToTable(sql);
            dgvHang.DataSource = tblH;
            dgvHang.Columns[0].HeaderText = "Mã hàng";
            dgvHang.Columns[1].HeaderText = "Tên hàng";
            dgvHang.Columns[2].HeaderText = "Chất liệu";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvHang.Columns[5].HeaderText = "Đơn giá bán";
            dgvHang.Columns[6].HeaderText = "Ghi chú";
            dgvHang.Columns[0].Width = 80;
            dgvHang.Columns[1].Width = 140;
            dgvHang.Columns[2].Width = 80;
            dgvHang.Columns[3].Width = 80;
            dgvHang.Columns[4].Width = 100;
            dgvHang.Columns[5].Width = 100;
            dgvHang.Columns[6].Width = 300;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHang_Click(object sender, EventArgs e)
        {
            string MaChatLieu;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHang.Text = dgvHang.CurrentRow.Cells["sMaHang"].Value.ToString();
            txtTenHang.Text = dgvHang.CurrentRow.Cells["sTenHang"].Value.ToString();
            MaChatLieu = dgvHang.CurrentRow.Cells["sMaChatLieu"].Value.ToString();
            sql = "SELECT sTenChatLieu FROM tblChatLieu WHERE sMaChatLieu=N'" + MaChatLieu + "'";
            cboMaChatLieu.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgvHang.CurrentRow.Cells["fSoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells["fDonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvHang.CurrentRow.Cells["fDonGiaBan"].Value.ToString();
            sql = "SELECT sGhichu FROM tblHang WHERE sMaHang = N'" + txtMaHang.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHang.Enabled = true;
            txtMaHang.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtGhiChu.Enabled = true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (cboMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaChatLieu.Focus();
                return;
            }
            
            sql = "SELECT sMaHang FROM tblHang WHERE sMaHang=N'" + txtMaHang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            sql = "INSERT INTO tblHang(sMaHang,sTenHang,sMaChatLieu,fSoLuong,fDonGiaNhap, fDonGiaBan,sGhiChu) VALUES(N'"
                + txtMaHang.Text.Trim() + "',N'" + txtTenHang.Text.Trim() +
                "',N'" + cboMaChatLieu.SelectedValue.ToString() +
                "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                "," + txtDonGiaBan.Text + ",'"  + txtGhiChu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (cboMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaChatLieu.Focus();
                return;
            }
           
            sql = "UPDATE tblHang SET sTenHang=N'" + txtTenHang.Text.Trim().ToString() +
                "',sMaChatLieu=N'" + cboMaChatLieu.SelectedValue.ToString() +
                "',fSoLuong=" + txtSoLuong.Text +
                 "',sGhiChu=N'" + txtGhiChu.Text + "' WHERE sMaHang=N'" + txtMaHang.Text + "'";
           Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblHang WHERE sMaHang=N'" + txtMaHang.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }
        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    string sql;
        //    if ((txtMaHang.Text == "") && (txtTenHang.Text == "") && (cboMaChatLieu.Text == ""))
        //    {
        //        MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    sql = "SELECT * from tblHang WHERE 1=1";
        //    if (txtMaHang.Text != "")
        //        sql += " AND sMaHang LIKE N'%" + txtMaHang.Text + "%'";
        //    if (txtTenHang.Text != "")
        //        sql += " AND sTenHang LIKE N'%" + txtTenHang.Text + "%'";
        //    if (cboMaChatLieu.Text != "")
        //        sql += " AND sMaChatLieu LIKE N'%" + cboMaChatLieu.SelectedValue + "%'";
        //    if (txtSoLuong.Text != "")
        //        sql += " AND fSoLuong <= " + txtSoLuong.Text;
        //    tblH = Functions.GetDataToTable(sql);
        //    if (tblH.Rows.Count == 0)
        //        MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    dgvHang.DataSource = tblH;
        //    ResetValues();
        //}

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnHienThi_Click(object sender, EventArgs e)
        //{

        //        string sql;
        //        sql = "SELECT sMaHang,sTenHang,sMaChatLieu,fSoLuong,fDonGiaNhap,fDonGiaBan,sGhichu FROM tblHang";
        //        tblH = Functions.GetDataToTable(sql);
        //        dgvHang.DataSource = tblH;


        //}
        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    string sql;
        //    //string sqlMoney;
        //    /*if ((txtMaHang.Text == "") || (txtTenHang.Text == "") && (cbMaChatLieu.Text == ""))
        //    {
        //        MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }*/
        //    sql = "SELECT * from tblHang WHERE 1=1";
        //    if (txtMaHang.Text != "")
        //        sql += " AND sMaHang LIKE N'%" + txtMaHang.Text + "%'";
        //    if (txtTenHang.Text != "")
        //        sql += " AND sTenHang LIKE N'%" + txtTenHang.Text + "%'";
        //    if (cbMaChatLieu.Text != "")
        //        sql += " AND sMaChatLieu LIKE N'%" + cbMaChatLieu.SelectedValue + "%'";
        //    if (txtSoLuong.Text != "")
        //        sql += " AND fSoLuong <= " + txtSoLuong.Text;
        //    tblH = Class.Functions.GetDataToTable(sql);
        //    if (tblH.Rows.Count == 0)
        //        MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    GridViewHang.DataSource = tblH;
        //    ResetValues();
        //}





        //private void btnLoc_Click(object sender, EventArgs e)
        //{
        //    //string sql;
        //    //if (textBox1.Text != "" && textBox2.Text != "")
        //    //{
        //    //    sql = "SELECT * FROM tblHang where fDonGiaNhap >" + float.Parse(textBox1.Text) + "AND fDonGiaNhap <" + float.Parse(textBox2.Text);
        //    //    tblH = Class.Functions.GetDataToTable(sql);
        //    //    dgvHang.DataSource = tblH;

        //    //}
        //}

        //private void btnIn_Click(object sender, EventArgs e)
        //{
        //    crHangHoa crhh = new crHangHoa();
        //    crhh.ShowDialog();
        //}
        //Khối lệnh sau sẽ sắp xếp kết quả theo thứ tự giảm dần bởi trường NAME.
        //SELECT * FROM CUSTOMERS
        //ORDER BY NAME DESC;
        //SELECT* FROM CUSTOMERS
        //ORDER BY NAME, SALARY;
    }
}
