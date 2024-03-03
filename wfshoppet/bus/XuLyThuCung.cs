using System.Collections.Generic;
using wfshoppet.dto;
using wfshoppet.dao;
namespace wfshoppet.bus
{
    class XuLyThuCung
    {
        private List<CThuCung> dsThuCung;
        private List<CLoaiThuCung> dsLoaiThu;
        public XuLyThuCung()
        {
            DsThuCung = TruyCapDuLieu.getInstance().DsThuCung;
            DsLoaiThu = TruyCapDuLieu.getInstance().DsLoaiThu;
        }
        public List<CLoaiThuCung> DsLoaiThu { get => dsLoaiThu; set => dsLoaiThu = value; }
        public List<CThuCung> DsThuCung { get => dsThuCung; set => dsThuCung = value; }

        public bool them(CThuCung tc)
        {
            if (tim(tc.MaThuCung) == null)
            {
                dsThuCung.Add(tc);
                return true;
            }
            else
                return false;
        }
        public CThuCung tim(string maThuCung)
        {
            foreach (CThuCung tc in DsThuCung)
                if (tc.MaThuCung.Equals(maThuCung))
                    return tc;
            return null;
        }
        public void xoa(string maThuCung)
        {
            CThuCung tc = tim(maThuCung);
            if (tc != null)
            {
                DsThuCung.Remove(tc);
            }
        }

        public void sua(string maThuCung, string tenthucung, string donvitinh, double dongia, CLoaiThuCung lt)
        {
            CThuCung tc = tim(maThuCung);
            if (tc != null)
            {
                tc.MaThuCung = maThuCung;
                tc.TenThuCung = tenthucung;
                tc.Donvitinh = donvitinh;
                tc.DonGia = dongia;
                tc.LoaiThu = lt;
            }

        }
        public void sua(CThuCung newtc)
        {
            CThuCung tc = tim(newtc.MaThuCung);
            if (tc != null)
            {
                tc.TenThuCung = newtc.TenThuCung;
                tc.Donvitinh = newtc.Donvitinh;
                tc.DonGia = newtc.DonGia;
                tc.LoaiThu = newtc.LoaiThu;
            }
        }
    }
}