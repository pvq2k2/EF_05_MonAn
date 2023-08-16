using EF_05_MonAn.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.IServices
{
    internal interface IMonAnServices
    {
        public LogType ThemMonAnVaoLoaiMonAn(int LoaiMonAnID);
        public LogType ThemDanhSachCongThuc(int MonAnID, int SoLuong);
        public LogType XoaLoaiMonAn(int LoaiMonAnID);
        public LogType TimKiemMonAn(string TenMon, string TenNguyenLieu);
    }
}
