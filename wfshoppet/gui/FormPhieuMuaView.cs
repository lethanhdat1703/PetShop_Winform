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
    public partial class FormPhieuMuaView : Form
    {
        XuLyPhieuMuaHang xuly;
        public string sopm;
         CPhieuMuaHang pmh;
        public FormPhieuMuaView()
        {
            InitializeComponent();
            
        }
        private void hienthipm(CPhieuMuaHang pm)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CChiTietPhieuMuaView.getChiTietPhieuMuaHangView(pm);
            dataGridView1.DataSource = bs;
        }
        private void FormPhieuMuaView_Load_1(object sender, EventArgs e)
        {

            xuly = new XuLyPhieuMuaHang();
            CPhieuMuaHang pm = xuly.tim(sopm);
            textTenKH.Text = pm.TenKhachHang.ToString();
            dtpngaylap.Value = pm.NgayLap.Date;
            txtsopm.Text = pm.SoPM.ToString();
            textsdt.Text = pm.SoDienThoai;
            textdc.Text = pm.DiaChi;
            hienthipm(pm);
        }
        private void hienthiChiTietPhieuMuaHang(CPhieuMuaHang pm)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CChiTietPhieuMuaView.getChiTietPhieuMuaHangView(pm);
            dataGridView1.DataSource = bs;
        }

        private void txtsopm_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
