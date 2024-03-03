using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfshoppet.bus;
using wfshoppet.dto;
namespace wfshoppet.gui
{
    public partial class FormLoaiThuCung : Form
    {
        private XuLyLoaiThuCung xuly;
        public FormLoaiThuCung()
        {
            InitializeComponent();
            xuly = new XuLyLoaiThuCung();
        }
        private void hienThiDanhSachLoaiThuCung(List<CLoaiThuCung> dslt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dslt;
            dgvloaitc.DataSource = bs;
            clear();
        }
        private void clear()
        {
            txtmaloai.Text = "";
            txttenloai.Text = "";
            txtmaloai.Focus();
            dgvloaitc.ClearSelection();
        }
        private int getSelectedRow()
        {
            if (dgvloaitc.SelectedRows.Count > 0)
                return dgvloaitc.SelectedRows[0].Index;
            return -1;
        }
        private CLoaiThuCung taoloaithu()
        {
            return new CLoaiThuCung(txtmaloai.Text, txttenloai.Text);
        }
        private void FormLoaiThuCung_Load(object sender, EventArgs e)
        {
            hienThiDanhSachLoaiThuCung(xuly.DsLoaiThu);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            CLoaiThuCung lt = new CLoaiThuCung();

            if (xuly.them(taoloaithu()) == true)
                hienThiDanhSachLoaiThuCung(xuly.DsLoaiThu);
            else
                MessageBox.Show("Mã Loại Thú" + lt.MaLoaiThu + " Bị Trùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow();
            if (index == -1) return;
            xuly.xoa(dgvloaitc.Rows[index].Cells[0].Value.ToString());

            hienThiDanhSachLoaiThuCung(xuly.DsLoaiThu);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow();
            if (index == -1) return;
            CLoaiThuCung lt = taoloaithu();
            string malt = dgvloaitc.Rows[index].Cells[0].Value.ToString();
            lt.MaLoaiThu = malt;
            xuly.sua(lt);
            hienThiDanhSachLoaiThuCung(xuly.DsLoaiThu);
        }

        private void dgvloaitc_SelectionChanged(object sender, EventArgs e)
        {
            int index = getSelectedRow();
            if (index == -1) return;
            CLoaiThuCung lt = xuly.DsLoaiThu[index];
            txtmaloai.Text = lt.MaLoaiThu;
            txttenloai.Text = lt.TenLoaiThu;
        }

        private void txttenloai_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên phải là kí tự chữ ", "Thông Báo ");
            }
        }
    }
}
