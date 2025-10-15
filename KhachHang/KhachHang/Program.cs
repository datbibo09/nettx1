using KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhachHang
{
    internal class Program
    {
        static List<KhachHang> dsKH = new List<KhachHang>();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhập thông tin khách hàng");
                Console.WriteLine("2. Hiển thị danh sách khách hàng");
                Console.WriteLine("3. Tìm khách hàng có số lượng mua lớn nhất");
                Console.WriteLine("4. Thoát");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        NhapThongTin();
                        break;
                    case "2":
                        HienThiDanhSach();
                        break;
                    case "3":
                        TimKhachMuaNhieuNhat();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                        break;
                }
            }
        }

        // ====== a. Nhập thông tin ======
        static void NhapThongTin()
        {
            Console.WriteLine("\n1. Khách hàng thường");
            Console.WriteLine("2. Khách hàng VIP");
            Console.Write("Chọn loại khách hàng: ");
            string loai = Console.ReadLine();

            Console.Write("Nhập mã khách hàng: ");
            string ma = Console.ReadLine();

            if (dsKH.Any(kh => kh.MaKH == ma))
            {
                Console.WriteLine("❌ Mã khách hàng đã tồn tại!");
                return;
            }

            Console.Write("Nhập ngày sinh (dd-MM-yyyy): ");
            DateTime ns = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", null);

            Console.Write("Nhập số lượng mua: ");
            int sl = int.Parse(Console.ReadLine());

            Console.Write("Nhập đơn giá: ");
            double dg = double.Parse(Console.ReadLine());

            if (loai == "2")
            {
                dsKH.Add(new KhachHangVIP(ma, ns, sl, dg));
            }
            else
            {
                dsKH.Add(new KhachHang(ma, ns, sl, dg));
            }

            Console.WriteLine(" Thêm khách hàng thành công!");
        }

        // ====== b. Hiển thị danh sách ======
        static void HienThiDanhSach()
        {
            Console.WriteLine("\nMã KH     Ngày sinh      SL mua        Đơn giá        Giảm giá   Tổng tiền");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var kh in dsKH)
            {
                Console.WriteLine(kh.ToString());
            }
        }

        // ====== c. Tìm khách hàng có số lượng mua lớn nhất ======
        static void TimKhachMuaNhieuNhat()
        {
            if (dsKH.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng!");
                return;
            }

            int maxSL = dsKH.Max(kh => kh.SoLuongMua);
            var khMax = dsKH.Where(kh => kh.SoLuongMua == maxSL);

            Console.WriteLine("\nKhách hàng có số lượng mua lớn nhất:");
            Console.WriteLine("Mã KH     Ngày sinh      SL mua        Đơn giá        Giảm giá   Tổng tiền");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var kh in khMax)
                Console.WriteLine(kh.ToString());
        }
    }
}
