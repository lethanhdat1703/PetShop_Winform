using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfshoppet.dao;
namespace wfshoppet.gui
{
    public partial class MenuForm : Form
    {
      
        public MenuForm()
        {
            InitializeComponent();
        }
       

        private void btnqlpm_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormPhieuMuaHang());
            label1.Text = btnqlpm.Text;
        }

        private void btnkh_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormKhachHang());
            label1.Text = btnkh.Text;
        }

        private void btnltc_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormLoaiThuCung());
            label1.Text = btnltc.Text;

        }

        private void btnghifile_Click(object sender, EventArgs e)
        {
            if (TruyCapDuLieu.ghiFile("qlshoppet.dat"))
                MessageBox.Show("Ghi file thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn Có Thật Sự Muốn Thoát Không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private Form currentFormChild;
        private void OpenFormChild(Form childForm)
        {
            if (currentFormChild!=null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelmenu.Controls.Add(childForm);
            panelmenu.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      

        private void btnqltc_Click(object sender, EventArgs e)
        {
            OpenFormChild(new FormThuCung());
            label1.Text = btnqltc.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MenuForm f = new MenuForm();
            this.Hide();
            f.Show();
        }

       

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

      
    }
}
