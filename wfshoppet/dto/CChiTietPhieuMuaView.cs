using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfshoppet.dto
{
   
    class CChiTietPhieuMuaView
    {
        public string mathucung { get; set; }
        public string tenthucung { get; set; }
        public string dvt { get; set; }
        public string dongia { get; set; }
        public string soluong { get; set; }
        public string thanhtien { get; set; }

        public static List<CChiTietPhieuMuaView> getChiTietPhieuMuaHangView(CPhieuMuaHang pmh)
        {
            List<CChiTietPhieuMuaView> ds = new List<CChiTietPhieuMuaView>();
            foreach (CChiTietPhieuMua ctpmh in pmh.ChiTietPhieuMuaHang)
            {
                CChiTietPhieuMuaView viewItem = new CChiTietPhieuMuaView();
                viewItem.mathucung = ctpmh.ThuCung.MaThuCung;
                viewItem.tenthucung = ctpmh.ThuCung.TenThuCung;
                viewItem.dongia = ctpmh.ThuCung.DonGia.ToString();
                viewItem.soluong = ctpmh.SoLuong.ToString();
                viewItem.thanhtien = ctpmh.ThanhTien.ToString();
                viewItem.dvt = ctpmh.ThuCung.Donvitinh;
                ds.Add(viewItem);
            }
            return ds;
        }
    }
}
