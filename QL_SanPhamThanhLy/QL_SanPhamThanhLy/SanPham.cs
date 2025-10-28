using System;
using System.Collections.Generic;
using System.Text;
namespace QL_SanPhamThanhLy { 



    // Lớp trừu tượng SanPham
    internal abstract class SanPham
    {
        private string maSP;
        private string tenSP;
        private string loaiSP;

        public string MaSP
        {
            get { return maSP; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Mã sản phẩm không được để trống");
                maSP = value;
            }
        }

        public string TenSP
        {
            get { return tenSP; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Tên sản phẩm không được để trống");
                tenSP = value;
            }
        }

        public string LoaiSP
        {
            get { return loaiSP; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Loại sản phẩm không được để trống");
                loaiSP = value;
            }
        }

        // Constructor không tham số
        public SanPham() { }

        // Constructor có tham số (thay cho nhập)
        public SanPham(string maSP, string tenSP, string loaiSP)
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
        }

        // Phương thức trừu tượng
        public abstract void NhapThongTin(string maSP, string tenSP, string loaiSP);
        public abstract double TinhTongTien();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            SanPham sp = (SanPham)obj;
            return MaSP == sp.MaSP;
        }

        public override int GetHashCode()
        {
            return MaSP.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0,-10}{1,-20}{2,-15}", MaSP, TenSP, LoaiSP);
        }
    }
}
