using EF_05_MonAn.Helper;
using EF_05_MonAn.IServices;
using EF_05_MonAn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Services
{
    public class MonAnServices : IMonAnServices
    {
        private readonly AppDbContext dbContext;

        public MonAnServices()
        {
            dbContext = new AppDbContext();
        }

        public LogType ThemDanhSachCongThuc(int MonAnID, int SoLuong)
        {
            var FindMonAn = dbContext.MonAn.FirstOrDefault(x => x.MonAnID == MonAnID);
            if (FindMonAn == null) return LogType.KhongTimThayMonAn;

            
            var ListCongThuc = new List<CongThuc>();
            for (int i = 0; i < SoLuong; i++) { 
                var congThuc = new CongThuc();
                congThuc.MonAnID = MonAnID;
                NguyenLieu? FindNguyenLieu;
                Console.WriteLine("Nhap nguyen lieu thu {0}", i+1);
                do
                {
                    congThuc.NguyenLieuID = InputHelper.InputInt("Nhap nguyen lieu ID: ", "Vui long nhap vao so!");
                    FindNguyenLieu = dbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuID == congThuc.NguyenLieuID);
                    if (FindNguyenLieu == null)
                    {
                        Console.WriteLine("Khong tim thay nguyen lieu");
                    }
                } while (FindNguyenLieu == null);

                congThuc.SoLuong = InputHelper.InputInt("Nhap so luong: ", "Vui long nhap vao so!");
                congThuc.DonViTinh = InputHelper.InputString("Nhap don vi tinh: ", "Vui long nhap don vi tinh khong duoc qua 10 ky tu", maxValue: 10);

                Console.WriteLine();

                ListCongThuc.Add(congThuc);
                FindMonAn.CachLam += $"{FindNguyenLieu.TenNguyenLieu} : {congThuc.SoLuong} {congThuc.DonViTinh}\n";
            }

            dbContext.CongThuc.AddRange(ListCongThuc);
            dbContext.SaveChanges();

            dbContext.MonAn.Update(FindMonAn);
            dbContext.SaveChanges();

            return LogType.ThanhCong;

        }

        public LogType ThemMonAnVaoLoaiMonAn(int LoaiMonAnID)
        {
            var FindLoaiMonAn = dbContext.LoaiMonAn.FirstOrDefault(x => x.LoaiMonAnID == LoaiMonAnID);
            if (FindLoaiMonAn == null) return LogType.KhongTimThayLoaiMonAn;

            Console.WriteLine("-----Nhap mon an-----");
            MonAn monAn = new MonAn();
            monAn.LoaiMonAnID = LoaiMonAnID;
            monAn.TenMon = InputHelper.InputString("Nhap ten mon an: ", "Ten mon an khong duoc qua 20 ki tu!", maxValue: 20);
            monAn.GiaBan = InputHelper.InputInt("Nhap gia ban: ", "Vui long nhap vao so!");
            monAn.GioiThieu = InputHelper.InputString("Nhap gioi thieu: ");

            dbContext.MonAn.Add(monAn);
            dbContext.SaveChanges();
            return LogType.ThanhCong;
        }

        public LogType TimKiemMonAn(string TenMon, string TenNguyenLieu)
        {
            var FindMonAn = dbContext.MonAn
                .Include(monAn => monAn.ListCongThuc)
                .ThenInclude(congThuc => congThuc.NguyenLieu)
                .ToList()
                .Where(monAn => monAn.TenMon.Contains(TenMon, StringComparison.OrdinalIgnoreCase) && monAn.ListCongThuc.Any(congThuc => congThuc.NguyenLieu.TenNguyenLieu.Contains(TenNguyenLieu, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (FindMonAn.Count == 0) return LogType.KhongTimThayMonAn;

            Console.WriteLine($"Cac mon an chua nguyen lieu '{TenNguyenLieu}' va co ten '{TenMon}':");
            foreach (var monAn in FindMonAn)
            {
                Console.WriteLine($"Mon an [{monAn.TenMon}]");
            }

            return LogType.ThanhCong;
        }

        public LogType XoaLoaiMonAn(int LoaiMonAnID)
        {
            var FindLoaiMonAn = dbContext.LoaiMonAn.FirstOrDefault(x => x.LoaiMonAnID == LoaiMonAnID);
            if (FindLoaiMonAn == null) return LogType.KhongTimThayLoaiMonAn;
            dbContext.LoaiMonAn.Remove(FindLoaiMonAn);
            dbContext.SaveChanges();
            Console.WriteLine($"Da xoa loai mon an co ten '{FindLoaiMonAn.TenLoai}' co id la {FindLoaiMonAn.LoaiMonAnID}");

            return LogType.ThanhCong;
        }
    }
}
