using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SanPhamThanhLy
{
    internal class SanPhamThanhLy : SanPham
    {
        private double donGia;
        private int soLuong;

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Đơn giá phải >= 0");
                donGia = value;
            }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng phải >= 0");
                soLuong = value;
            }
        }

        public SanPhamThanhLy() { }

        public SanPhamThanhLy(string maSP, string tenSP, string loaiSP, double donGia, int soLuong)
            : base(maSP, tenSP, loaiSP)
        {
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public override void NhapThongTin(string maSP, string tenSP, string loaiSP)
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
        }

        public override double TinhTongTien()
        {
            return SoLuong * DonGia;
        }

        public override string ToString()
        {
            return string.Format("{0,-10}{1,-20}{2,-15}{3,10}{4,15:N0}{5,15:N0}",
                MaSP, TenSP, LoaiSP, SoLuong, DonGia, TinhTongTien());
        }
    }
}
