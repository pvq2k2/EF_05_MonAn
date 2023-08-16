using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Models
{
    public class MonAn
    {
        public int MonAnID { get; set; }
        public string TenMon { get; set; }
        public int GiaBan { get; set; }
        public string GioiThieu { get; set; }
        public string CachLam { get; set; }

        public int LoaiMonAnID { get; set; }
        public LoaiMonAn LoaiMonAn { get; set; }

        public List<CongThuc> ListCongThuc { get; set; }
    }
}
