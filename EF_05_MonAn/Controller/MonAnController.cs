using EF_05_MonAn.Helper;
using EF_05_MonAn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Controller
{
    public class MonAnController
    {
        MonAnServices services;

        public MonAnController()
        {
            services = new MonAnServices();
        }

        public void ThucThi(char c)
        {
            switch (c)
            {
                case '1':
                    int LoaiMonAnID_Add = InputHelper.InputInt("Nhap ID loai mon an muon them: ", "Vui long nhap vao la mot so!");
                    LogHelper.MonAnLog(services.ThemMonAnVaoLoaiMonAn(LoaiMonAnID_Add));
                    break;
                case '2':
                    int MonAnID = InputHelper.InputInt("Nhap ID mon an muon them: ", "Vui long nhap vao la mot so!");
                    int SoLuong = InputHelper.InputInt("Nhap so luong muon them: ", "Vui long nhap vao la mot so!");
                    LogHelper.MonAnLog(services.ThemDanhSachCongThuc(MonAnID, SoLuong));
                    break;
                case '3':
                    int LoaiMonAnID_Remove = InputHelper.InputInt("Nhap ID loai mon an muon them: ", "Vui long nhap vao la mot so!");
                    LogHelper.MonAnLog(services.XoaLoaiMonAn(LoaiMonAnID_Remove));
                    break;
                case '4':
                    string TenMon = InputHelper.InputString("Nhap ten mon: ");
                    string TenNguyenLieu = InputHelper.InputString("Ten nguyen lieu: ");
                    LogHelper.MonAnLog(services.TimKiemMonAn(TenMon, TenNguyenLieu));
                    break;
                case '5':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Khong co chuc nang nay, vui long nhap lai!");
                    break;
            }
            Console.WriteLine("\nNhan phim bat ky de tiep tuc!");
            Console.ReadKey();
        }
    }
}
