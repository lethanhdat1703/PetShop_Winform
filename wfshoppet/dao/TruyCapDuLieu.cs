using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using wfshoppet.dto;
namespace wfshoppet.dao
{
    [Serializable]
    class TruyCapDuLieu
    {
        private static TruyCapDuLieu instance = null;
        private List<CPhieuMuaHang> dsPhieuMuaHang;
        private List<CThuCung> dsThuCung;
        private List<CLoaiThuCung> dsLoaiThu;
        private List<CKhachHang> dsKhachHang;
        internal List<CPhieuMuaHang> DsPhieuMuaHang { get => dsPhieuMuaHang; }
        internal List<CThuCung> DsThuCung { get => dsThuCung; }
        internal List<CLoaiThuCung> DsLoaiThu { get => dsLoaiThu; }
        internal List<CKhachHang> DsKhachHang { get => dsKhachHang; }

        private TruyCapDuLieu()
        {
            dsThuCung = new List<CThuCung>();
            dsPhieuMuaHang = new List<CPhieuMuaHang>();
            dsKhachHang = new List<CKhachHang>();
            dsLoaiThu = new List<CLoaiThuCung>();
        }

        public static TruyCapDuLieu getInstance()
        {
            if (instance == null)
                if (!docFile("qlshoppet.dat")) //doc du lieu tu file                    
                    instance = new TruyCapDuLieu();
            return instance;
        }

        public static bool docFile(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                instance = (TruyCapDuLieu)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
        }
        public static bool ghiFile(string tenFile)
        {
            try
            {
                FileStream fs = new FileStream(tenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, getInstance());
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
        }
    }
}
