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
    public partial class FormThuCung : Form
    {
        private XuLyThuCung xuly;
        public FormThuCung()
        {
            InitializeComponent();
            xuly = new XuLyThuCung();
        }
        private void clear()
        {
            txtmatc.Text = "";
            txttentc.Text = "";
            txtdvt.Text = "";
            txtdongia.Text = "";
            cboltc.SelectedIndex = 0;
            txtmatc.Focus();
        }
        private void hienthiDanhSachThuCung(List<CThuCung> dstc)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dstc;
            dgvqltc.DataSource = bs;
            dgvqltc.ClearSelection();
        }
        private void hienThiDanhSachLoaiThu(List<CLoaiThuCung> dslt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dslt;
            
            cboltc.DataSource = bs;
        }
        private void FormThuCung_Load(object sender, EventArgs e)
        {
            hienThiDanhSachLoaiThu(xuly.DsLoaiThu);
            hienthiDanhSachThuCung(xuly.DsThuCung);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            CLoaiThuCung lt = xuly.DsLoaiThu[cboltc.SelectedIndex];

            if (xuly.them(new CThuCung(txtmatc.Text, txttentc.Text, txtdvt.Text, float.Parse(txtdongia.Text), lt)) == true)
            {
                hienthiDanhSachThuCung(xuly.DsThuCung);
                clear();
            }
            else
                MessageBox.Show("Mã Thú Cưng" + txtmatc.Text + " Bị Trùng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvqltc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvqltc.SelectedRows.Count == 0) return;
            int index = dgvqltc.SelectedRows[0].Index;
            CThuCung tc = xuly.DsThuCung[index];
            txtmatc.Text = tc.MaThuCung;
            txttentc.Text = tc.TenThuCung;
            txtdvt.Text = tc.Donvitinh;
            txtdongia.Text = tc.DonGia.ToString();
            CLoaiThuCung lt = xuly.DsLoaiThu[cboltc.SelectedIndex];
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvqltc.SelectedRows.Count == 0) return;
            string matc = dgvqltc.SelectedRows[0].Cells[0].Value.ToString();
            xuly.xoa(matc);
            hienthiDanhSachThuCung(xuly.DsThuCung);
            clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvqltc.SelectedRows.Count == 0) return;
            string matc = dgvqltc.SelectedRows[0].Cells[0].Value.ToString();
            xuly.sua(matc, txtmatc.Text, txtdvt.Text, float.Parse(txtdongia.Text.Trim()), xuly.DsLoaiThu[cboltc.SelectedIndex]
            );
            hienthiDanhSachThuCung(xuly.DsThuCung);
            clear();
        }

      

       

        

        private void txttentc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên phải là kí tự chữ ", "Thông Báo ");
            }
        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Đơn giá phải là kí tự số ", "Thông Báo ");
            }
        }
    }
}
