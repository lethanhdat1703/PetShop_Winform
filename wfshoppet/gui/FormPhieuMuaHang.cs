using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfshoppet.dto;
using wfshoppet.dao;
using wfshoppet.bus;
namespace wfshoppet.gui
{
    public partial class FormPhieuMuaHang : Form
    {
        private XuLyPhieuMuaHang xuly;
        private CPhieuMuaHang pmh;
        private List<CPhieuMuaHang> ds;
        public FormPhieuMuaHang()
        {
            InitializeComponent();
           xuly = new XuLyPhieuMuaHang();
        }
        private void hienthiPhieuMuaHang()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xuly.DsPhieuMuaHang;
            dgvpm.DataSource = bs;
        }
        private void hienthiChiTietPhieuMuaHang(CPhieuMuaHang pm)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CChiTietPhieuMuaView.getChiTietPhieuMuaHangView(pm);
            dgvpm.DataSource = bs;
        }
        private void AddNewPhieuMuaHang()
        {

            pmh = new CPhieuMuaHang();
            txtsopm.Text = "";
            dtpngaylap.Value = DateTime.Today;
            txtmakh.Text = "";
            cbotenkh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            dgvqlpm.DataSource = CChiTietPhieuMuaView.getChiTietPhieuMuaHangView(pmh);//lấy dữ liệu trong chi tiết phiếu mua view để hiển thị lên datagridview
            cbotentc.SelectedIndex = 0;

            txtsopm.Focus();
        }
        private void FormPhieuMuaHang_Load(object sender, EventArgs e)
        {
            pmh = new CPhieuMuaHang();
            xuly = new XuLyPhieuMuaHang();
            hienthiPhieuMuaHang();
            BindingSource bs1 = new BindingSource();
            BindingSource bs = new BindingSource();
            bs.DataSource = xuly.DsThuCung;
            bs1.DataSource = xuly.DsKhachHang;
            cbotentc.DataSource = bs;
            cbotenkh.DataSource = bs1;
        }
       
        private void btnlappm_Click(object sender, EventArgs e)
        {
            if (pmh.ChiTietPhieuMuaHang.Count == 0) return;
            int dem = 0;
            dem = dgvpm.Rows.Count-1;
            dem++;
            pmh.SoPM = txtsopm.Text = "PM" + dem;
            pmh.NgayLap = dtpngaylap.Value;
            pmh.TenKhachHang = xuly.DsKhachHang[cbotenkh.SelectedIndex];//chọn thuộc tính đã chỉ định
            pmh.MaKhachHang = txtmakh.Text;
            pmh.DiaChi = txtdiachi.Text;
            pmh.SoDienThoai = txtsdt.Text;
            xuly.them1(pmh);
            hienthiPhieuMuaHang();
            AddNewPhieuMuaHang();
        }

        private void cbotentc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CThuCung tc = xuly.DsThuCung[cbotentc.SelectedIndex];//chọn thuộc tính đã chỉ định
            txtmatc.Text = tc.MaThuCung;
            txtdvt.Text = tc.Donvitinh;
            txtdongia.Text = tc.DonGia.ToString();
            txtloai.Text = tc.LoaiThu.TenLoaiThu;

        }


        private void cbotenkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            CKhachHang kh = xuly.DsKhachHang[cbotenkh.SelectedIndex];
            txtmakh.Text = kh.MaKhachHang;//Hiển thị lên textbox
            txtdiachi.Text = kh.DiaChi;//Hiển thị lên textbox
            txtsdt.Text = kh.SoDienThoai;//Hiển thị lên textbox
        }
        
        private void btnchontc_Click(object sender, EventArgs e)
        {
            
            CThuCung tc = xuly.DsThuCung[cbotentc.SelectedIndex];
            int soLuong = 0;
            try
            {
                soLuong += int.Parse(txtsoluong.Text.Trim());
            }
            catch (Exception) { }
            if (soLuong <= 0) return;

            xuly.them(pmh, tc, soLuong, tc.DonGia);
            dgvqlpm.DataSource = CChiTietPhieuMuaView.getChiTietPhieuMuaHangView(pmh);
            txtsoluong.Text = "";

        }

        private void btnxempm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvpm.SelectedRows)
            {
                string sopm = r.Cells[0].Value.ToString();
                FormPhieuMuaView f = new FormPhieuMuaView();
                f.sopm = sopm;
                f.ShowDialog();
                break;

            }
        }
       
        private void btntaopmnew_Click(object sender, EventArgs e)
        {
            AddNewPhieuMuaHang();
        }
        public void kiemTra(DateTime ngay)
        {
            bool flag = false;
            xuly = new XuLyPhieuMuaHang();
            ds = new List<CPhieuMuaHang>();
            foreach (CPhieuMuaHang pm in xuly.DsPhieuMuaHang)
            {
                if (dtplocpm.Value==pm.NgayLap)
                {
                    ds.Add(pm);
                    flag = true;
                }
                hienthi(ds);
            }
            if (flag==false)
            {
                MessageBox.Show("Không có phiếu mua nào vào ngày " + dtplocpm.Value.Day + "/" + dtplocpm.Value.Month + "/" + dtplocpm.Value.Year, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void hienthi(List<CPhieuMuaHang> ds)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;
            dgvpm.DataSource = bs;
        }
        private void btnloc_Click(object sender, EventArgs e)
        {
            kiemTra(dtplocpm.Value);
            xuly = new XuLyPhieuMuaHang();
            ds = new List<CPhieuMuaHang>();
            foreach (CPhieuMuaHang pm in xuly.DsPhieuMuaHang)
            {
                if (dtplocpm.Value == pm.NgayLap)
                {
                    ds.Add(pm);
                }
                hienthi(ds);
            }
        }

      
        private void btnxoa_Click_1(object sender, EventArgs e)
        {
           
            if (dgvpm.SelectedRows.Count == 0) 
                return;
            string sopm = dgvpm.SelectedRows[0].Cells[0].Value.ToString();//lấy dữ liệu ở cột sopm trong Row đang chọn trên View
            xuly.xoa(sopm);
            hienthiPhieuMuaHang();
        }
    }
}
