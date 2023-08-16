using EF_05_MonAn.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Helper
{
    public enum LogType
    {
        KhongTimThayMonAn,
        KhongTimThayLoaiMonAn,
        ThanhCong
    }
    public class LogHelper
    {
        public static void MonAnLog(LogType log)
        {
            switch (log)
            {
                case LogType.ThanhCong:
                    Console.WriteLine(MonAnRes.ThanhCong);
                    break;
                case LogType.KhongTimThayMonAn:
                    Console.WriteLine(MonAnRes.KhongTimThayMonAn);
                    break;
                case LogType.KhongTimThayLoaiMonAn:
                    Console.WriteLine(MonAnRes.KhongTimThayLoaiMonAn);
                    break;
            }
        }
    }
}
