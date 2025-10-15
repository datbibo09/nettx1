using System;
using System.Collections.Generic;
using System.Text;

namespace KhachHang
{
   

    internal class KhachHangVIP : KhachHang
    {
        public KhachHangVIP() { }

        public KhachHangVIP(string maKH, DateTime ngaySinh, int soLuongMua, double donGia)
            : base(maKH, ngaySinh, soLuongMua, donGia)
        {
        }

        public override double TinhTongTien()
        {
            double tongTien = base.TinhTongTien();
            double giamGia = 0;

            if (tongTien <= 1000)
                giamGia = 0.1;
            else
                giamGia = 0.2;

            return tongTien * (1 - giamGia);
        }

        public override string ToString()
        {
            double tongTienGoc = base.TinhTongTien();
            double giamGia = tongTienGoc <= 1000 ? 0.1 : 0.2;
            double tongPhaiTra = TinhTongTien();

            return string.Format("{0,-10}{1,-15:dd-MM-yyyy}{2,10}{3,15:N0}{4,15}{5,15:N0}",
                MaKH, NgaySinh, SoLuongMua, DonGia, giamGia * 100 + "%", tongPhaiTra);
        }

    }
}
