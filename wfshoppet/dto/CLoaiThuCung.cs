using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfshoppet.dto
{
    [Serializable]
    class CLoaiThuCung
    {
        private string m_maloaithu;
        private string m_tenloaithu;
        public string MaLoaiThu { get => m_maloaithu; set => m_maloaithu = value; }
        public string TenLoaiThu { get => m_tenloaithu; set => m_tenloaithu = value; }

        public CLoaiThuCung(string maloai, string tenloai)
        {
            m_maloaithu = maloai;
            m_tenloaithu = tenloai;
        }
        public CLoaiThuCung()
        {
            m_maloaithu = "";
            m_tenloaithu = "";

        }
        public override string ToString()
        {
            return TenLoaiThu;
        }
    }
}
