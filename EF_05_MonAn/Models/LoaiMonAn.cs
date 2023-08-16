using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.Models
{
    public class LoaiMonAn
    {
        public int LoaiMonAnID { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }

        public List<MonAn> ListMonAn { get; set; }
    }
}
