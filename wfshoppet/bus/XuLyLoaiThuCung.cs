using System.Collections.Generic;
using wfshoppet.dto;
using wfshoppet.dao;
namespace wfshoppet.bus
{
    class XuLyLoaiThuCung
    {
        private List<CLoaiThuCung> dsLoaiThu;

        public XuLyLoaiThuCung()
        {
            dsLoaiThu = TruyCapDuLieu.getInstance().DsLoaiThu;
        }
        public List<CLoaiThuCung> DsLoaiThu { get => dsLoaiThu; set => dsLoaiThu = value; }
        public bool them(CLoaiThuCung lt)
        {
            if (tim(lt.MaLoaiThu) == null)
            {
                DsLoaiThu.Add(lt);
                return true;
            }
            else
                return false;
        }

        public void xoa(string malt)
        {
            CLoaiThuCung lt = tim(malt);
            if (lt != null)
                DsLoaiThu.Remove(lt);
        }

        public void sua(CLoaiThuCung lt)
        {
            CLoaiThuCung m_lt = tim(lt.MaLoaiThu);
            if (m_lt != null)
            {
                m_lt.TenLoaiThu = lt.TenLoaiThu;
                m_lt.MaLoaiThu = lt.MaLoaiThu;

            }
        }

        public CLoaiThuCung tim(string malt)
        {
            foreach (CLoaiThuCung lt in DsLoaiThu)
            {
                if (lt.MaLoaiThu.Equals(malt))
                    return lt;
            }
            return null;
        }
    }
}
