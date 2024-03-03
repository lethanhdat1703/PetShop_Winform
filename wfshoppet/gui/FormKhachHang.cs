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
using wfshoppet.bus;
namespace wfshoppet.gui
{
    public partial class FormKhachHang : Form
    {
        private XuLyKhachHang xuly;
        public FormKhachHang()
        {
            InitializeComponent();
            xuly = new XuLyKhachHang();
        }
        private void hienThiDanhSachKhachHang(List<CKhachHang> dskh)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dskh;
            dgvkh.DataSource = bs;
            clear();
        }
        private void clear()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtsdt.Text = "";
            txtdiachi.Text = "";
            txtmakh.Focus();
            dgvkh.ClearSelection();
        }
        private int getSelectedRow()
        {
            if (dgvkh.SelectedRows.Count > 0)
                return dgvkh.SelectedRows[0].Index;
            return -1;
        }
        private CKhachHang taokhachhang()
        {
            return new CKhachHang(txtmakh.Text, txttenkh.Text, txtsdt.Text, txtdiachi.Text);
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (xuly.them(taokhachhang()) == true)
            {
                hienThiDanhSachKhachHang(xuly.DsKhachHang);
              
            }
            else
                MessageBox.Show("Mã Khách Hàng " + txtmakh.Text + " Bị Trùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvkh_SelectionChanged(object sender, EventArgs e)
        {
            int index = getSelectedRow();
            if (index == -1) return;
            CKhachHang kh = xuly.DsKhachHang[index];
            txtmakh.Text = kh.MaKhachHang;
            txttenkh.Text = kh.TenKhachHang;
            txtsdt.Text = kh.SoDienThoai;
            txtdiachi.Text = kh.DiaChi;
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            hienThiDanhSachKhachHang(xuly.DsKhachHang);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow();
            if (index == -1) return;
            xuly.xoa(dgvkh.Rows[index].Cells[0].Value.ToString());
            hienThiDanhSachKhachHang(xuly.DsKhachHang);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow();
            if (index == -1) return;
            CKhachHang kh = taokhachhang();
            string makh = dgvkh.Rows[index].Cells[0].Value.ToString();
            kh.MaKhachHang = makh;
            xuly.sua(kh);
            hienThiDanhSachKhachHang(xuly.DsKhachHang);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            MenuForm frm = new MenuForm();
            this.Hide();
            frm.Show();
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Text.Length<15&&Text.Length>10)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Điệnthoại là kí tự số ", "Thông Báo ");
                }
            }
            else
            {
                MessageBox.Show("Số kí tự vượt quá quy định!!!");
            }
        }

        private void txttenkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Họ tên phải là kí tự chữ ", "Thông Báo ");
            }
        }

        private void txttenkh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
