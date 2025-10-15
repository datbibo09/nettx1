using System;
using System.Collections.Generic;
using System.Text;

namespace KhachHang
{
    

    internal class KhachHang
    {
        private string maKH;
        private DateTime ngaySinh;
        private int soLuongMua;
        private double donGia;

        // ====== Thuộc tính ======
        public string MaKH
        {
            get { return maKH; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã khách hàng không được để trống!");
                maKH = value;
            }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public int SoLuongMua
        {
            get { return soLuongMua; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng mua phải >= 0!");
                soLuongMua = value;
            }
        }

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Đơn giá phải >= 0!");
                donGia = value;
            }
        }

        // ====== Constructor ======
        public KhachHang() { }

        public KhachHang(string maKH, DateTime ngaySinh, int soLuongMua, double donGia)
        {
            this.maKH = maKH;
            this.ngaySinh = ngaySinh;
            this.soLuongMua = soLuongMua;
            this.donGia = donGia;
        }

        // ====== Phương thức ======
        public virtual double TinhTongTien()
        {
            return soLuongMua * donGia;
        }

        public override string ToString()
        {
            return string.Format("{0,-10}{1,-15:dd-MM-yyyy}{2,10}{3,15:N0}{4,15}{5,15:N0}",
                MaKH, NgaySinh, SoLuongMua, DonGia, "-", TinhTongTien());
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            KhachHang other = (KhachHang)obj;
            return MaKH == other.MaKH;
        }

        public override int GetHashCode()
        {
            return MaKH.GetHashCode();
        }
    }
}
