using System.Collections.Generic;
using wfshoppet.dto;
using wfshoppet.dao;
namespace wfshoppet.bus
{
    internal class XuLyKhachHang
    {
        private List<CKhachHang> dsKhachHang;


        public XuLyKhachHang()
        {
            dsKhachHang = TruyCapDuLieu.getInstance().DsKhachHang;
        }
        public List<CKhachHang> DsKhachHang { get => dsKhachHang; set => dsKhachHang = value; }

        public bool them(CKhachHang kh)
        {
            if (tim(kh.MaKhachHang) == null)
            {
                dsKhachHang.Add(kh);
                return true;
            }
            else
                return false;
        }

        public void xoa(string makh)
        {
            CKhachHang kh = tim(makh);
            if (kh != null)
                dsKhachHang.Remove(kh);
        }

        public void sua(CKhachHang kh)
        {
            CKhachHang KH = tim(kh.MaKhachHang);
            if (KH != null)
            {
                KH.MaKhachHang = kh.MaKhachHang;
                KH.TenKhachHang = kh.TenKhachHang;
                KH.DiaChi = kh.DiaChi;
                KH.SoDienThoai = kh.SoDienThoai;

            }
        }

        public CKhachHang tim(string makh)
        {
            foreach (CKhachHang kh in DsKhachHang)
            {
                if (kh.MaKhachHang.Equals(makh))
                    return kh;
            }
            return null;
        }
    }
}
