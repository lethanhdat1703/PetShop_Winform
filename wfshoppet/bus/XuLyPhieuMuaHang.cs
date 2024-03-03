using System.Collections.Generic;
using wfshoppet.dto;
using wfshoppet.dao;
namespace wfshoppet.bus
{
    class XuLyPhieuMuaHang
    {
        public List<CThuCung> DsThuCung { get; set; }
        public List<CPhieuMuaHang> DsPhieuMuaHang { get; set; }
        public List<CKhachHang> DsKhachHang { get; set; }

        public XuLyPhieuMuaHang()
        {
            DsThuCung = TruyCapDuLieu.getInstance().DsThuCung;
            DsPhieuMuaHang = TruyCapDuLieu.getInstance().DsPhieuMuaHang;
            DsKhachHang = TruyCapDuLieu.getInstance().DsKhachHang;

        }

        public void them1(CPhieuMuaHang pmh)
        {
            DsPhieuMuaHang.Add(pmh);
        }

        public void them(CPhieuMuaHang pmh, CThuCung tc, int soLuong, double donGia)
        {
            CChiTietPhieuMua ctpmh = null;
            foreach (CChiTietPhieuMua m_ctpmh in pmh.ChiTietPhieuMuaHang)
                if (m_ctpmh.ThuCung.MaThuCung.Equals(tc.MaThuCung))
                {
                    ctpmh =  m_ctpmh;
                    break;
                }
            if (ctpmh == null)
            {
                ctpmh = new CChiTietPhieuMua(pmh.SoPM, tc, 0, tc.DonGia);
                pmh.ChiTietPhieuMuaHang.Add(ctpmh);
            }
            ctpmh.SoLuong += soLuong;
        }

        public void xoa(string soPM)
        {
            CPhieuMuaHang pmh = tim(soPM);
            if (pmh != null)
                DsPhieuMuaHang.Remove(pmh);
        }

        public CPhieuMuaHang tim(string soPM)
        {
            foreach (CPhieuMuaHang pmh in DsPhieuMuaHang)
            {
                if (pmh.SoPM.Equals(soPM))
                    return pmh;
            }

            return null;
        }
    }

}
