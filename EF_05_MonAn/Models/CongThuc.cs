using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Models
{
    public class CongThuc
    {
        public int CongThucID { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }

        public int NguyenLieuID { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        public int MonAnID { get; set; }
        public MonAn MonAn { get; set; }
    }
}
