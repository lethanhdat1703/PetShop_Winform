using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfshoppet.dto
{
    [Serializable]
    class CKhachHang
    {
        private string m_makh;
        private string m_tenkh;
        private string m_sodienthoai;
        private string m_diachi;

        public string MaKhachHang { get => m_makh; set => m_makh = value; }
        public string TenKhachHang { get => m_tenkh; set => m_tenkh = value; }
        public string SoDienThoai { get => m_sodienthoai; set => m_sodienthoai = value; }
        public string DiaChi { get => m_diachi; set => m_diachi = value; }

        public CKhachHang() : this("", "", "", "") { }

        public CKhachHang(string makh, string tenkh, string sodienthoai, string diachi)
        {
            MaKhachHang = makh;
            TenKhachHang = tenkh;
            SoDienThoai = sodienthoai;
            DiaChi = diachi;
        }
        public override string ToString()
        {
            return TenKhachHang;
        }
    }
}
