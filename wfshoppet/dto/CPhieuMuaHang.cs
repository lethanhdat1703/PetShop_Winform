using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfshoppet.dto
{
    [Serializable]
    class CPhieuMuaHang
    {
        private CKhachHang m_tenkh;
        private string m_makh;
        private string m_diachi;
        private string m_sodienthoai;
        public string SoPM { set; get; }
        public DateTime NgayLap { set; get; }

        internal List<CChiTietPhieuMua> ChiTietPhieuMuaHang { get; set; }
        public CKhachHang TenKhachHang { get => m_tenkh; set => m_tenkh = value; }
        public string MaKhachHang { get => m_makh; set => m_makh = value; }
        public string DiaChi { get => m_diachi; set => m_diachi = value; }
        public string SoDienThoai { get => m_sodienthoai; set => m_sodienthoai = value; }
        public CPhieuMuaHang(string soPM, DateTime ngayLap, string makh, CKhachHang tenkh, string diachi, string sodienthoai, List<CChiTietPhieuMua> dsChiTietPhieuMuaHang)
        {
            SoPM = soPM;
            NgayLap = ngayLap;
            TenKhachHang = tenkh;
            MaKhachHang = makh;
            DiaChi = diachi;
            SoDienThoai = sodienthoai;
            ChiTietPhieuMuaHang = dsChiTietPhieuMuaHang;
        }

        public CPhieuMuaHang() : this(null, DateTime.Now, null, null, null, null, new List<CChiTietPhieuMua>())
        {
        }

        public double ThanhTien
        {
            get
            {
                double tt = 0;
                foreach (CChiTietPhieuMua chitiet in ChiTietPhieuMuaHang)
                    tt += chitiet.ThanhTien;
                return tt;
            }
        }
    }
}
