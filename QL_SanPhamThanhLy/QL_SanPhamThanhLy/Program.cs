using QL_SanPhamThanhLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QL_SanPhamThanhLy
{
    internal class Program
    {
        static List<SanPham> dsSP = new List<SanPham>();

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n==== MENU QUẢN LÝ SẢN PHẨM THANH LÝ ====");
                Console.WriteLine("1. Nhập thông tin sản phẩm");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Sắp xếp sản phẩm");
                Console.WriteLine("4. Thoát");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1": NhapThongTin(); break;
                    case "2": HienThiDanhSach(); break;
                    case "3": SapXep(); break;
                    case "4": return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }

        static void NhapThongTin()
        {
            Console.Write("Nhập mã sản phẩm: ");
            string ma = Console.ReadLine();
            if (dsSP.Any(sp => sp.MaSP == ma))
            {
                Console.WriteLine("Mã sản phẩm đã tồn tại!");
                return;
            }

            Console.Write("Nhập tên sản phẩm: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập loại sản phẩm: ");
            string loai = Console.ReadLine();
            Console.Write("Nhập đơn giá: ");
            double gia = double.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng: ");
            int sl = int.Parse(Console.ReadLine());

            SanPham sp = new SanPhamThanhLy(ma, ten, loai, gia, sl);
            dsSP.Add(sp);

            Console.WriteLine("✅ Thêm sản phẩm thành công!");
        }

        static void HienThiDanhSach()
        {
            Console.WriteLine("\n{0,-10}{1,-20}{2,-15}{3,10}{4,15}{5,15}",
                "Mã SP", "Tên sản phẩm", "Loại SP", "SL", "Đơn giá", "Tổng tiền");
            Console.WriteLine(new string('-', 90));

            foreach (var sp in dsSP)
            {
                Console.WriteLine(sp.ToString());
            }
        }

        static void SapXep()
        {
            dsSP = dsSP.OrderBy(sp => sp.LoaiSP)
                       .ThenBy(sp => sp.TenSP)
                       .ToList();
            Console.WriteLine("\n Danh sách sau khi sắp xếp:");
            HienThiDanhSach();
        }
    }
}
