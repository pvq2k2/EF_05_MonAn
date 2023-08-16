using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Models
{
    public class NguyenLieu
    {
        public int NguyenLieuID { get; set; }
        public string TenNguyenLieu { get; set; }
        public string GhiChu { get; set; }

        public List<CongThuc> ListCongThuc { get; set; }
    }
}
