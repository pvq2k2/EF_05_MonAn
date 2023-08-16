using EF_05_MonAn.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05_MonAn.View
{
    public class MonAnView
    {
        MonAnController controller;

        public MonAnView()
        {
            controller = new MonAnController();
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("1. Them mon an vao loai mon an");
                Console.WriteLine("2. Them danh sach cong thuc cho mon an");
                Console.WriteLine("3. Xoa mon an");
                Console.WriteLine("4. Tim kiem mon an theo ten va nguyen lieu che bien mon");
                Console.WriteLine("5. Thoat");
                Console.Write("Chon chuc nang: ");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                controller.ThucThi(c);
            }
        }
    }
}
