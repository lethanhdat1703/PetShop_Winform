using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfshoppet.dto;
using wfshoppet.dao;
namespace wfshoppet.dto
{
    [Serializable]
    class CChiTietPhieuMua
    {
        private string m_soPM;
        private CThuCung m_thuCung;
        private int m_soLuong;
        private double m_donGia;

        public CChiTietPhieuMua(string soPM, CThuCung thuCung, int soLuong, double donGia)
        {
            SoPM = soPM;
            ThuCung = thuCung;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public CChiTietPhieuMua() : this(null, null, 0, 0) { }

        public double ThanhTien { get => SoLuong * DonGia; }

        public string SoPM { get => m_soPM; set => m_soPM = value; }
        public int SoLuong { get => m_soLuong; set => m_soLuong = value; }
        public double DonGia { get => m_donGia; set => m_donGia = value; }
        public CThuCung ThuCung { get => m_thuCung; set => m_thuCung = value; }
    }
}
