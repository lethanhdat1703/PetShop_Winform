using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfshoppet.dto
{
    [Serializable]
    class CThuCung
    {

        private string m_mathucung;
        private string m_tenthucung;
        private string m_donvitinh;
        private double m_donGia;
        private CLoaiThuCung m_loaithu;

        public string MaThuCung { get => m_mathucung; set => m_mathucung = value; }
        public string TenThuCung { get => m_tenthucung; set => m_tenthucung = value; }
        public string Donvitinh { get => m_donvitinh; set => m_donvitinh = value; }
        public double DonGia { get => m_donGia; set => m_donGia = value; }

        public CLoaiThuCung LoaiThu { get => m_loaithu; set => m_loaithu = value; }
        public CThuCung(string maThuCung, string tenThuCung, string donvitinh, double donGia, CLoaiThuCung loaithu)
        {
            MaThuCung = maThuCung;
            TenThuCung = tenThuCung;
            Donvitinh = donvitinh;
            DonGia = donGia;
            LoaiThu = loaithu;
        }

        public CThuCung() : this(null, null, null, 0, null)
        {
        }
    }
}
