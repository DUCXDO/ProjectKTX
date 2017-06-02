using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class SinhVIenBUS
    {
        private ISinhVienDAO _sv = new SinhVienDAO();
        public ISinhVienDAO sv;
       
        public SinhVIenBUS()
        {
            sv = _sv;
        }

        public String ThemSV(String maSV, String tenSV, DateTime ngaySinh, int soCMND, String soDT, String diaChi)
        {
            try
            {
                if(maSV == null)
                {
                    return "Mã sinh viên không được để trống!";
                }
                else if(tenSV == null)
                {
                    return "Tên sinh viên không được để trống!";
                }
                else if(ngaySinh == null)
                {
                    return "Ngày sinh không được để trống!";
                }
                else if(soCMND == 0)
                {
                    return "Số chứng minh nhân dân không được để trống!";
                }
                else if(soDT == null)
                {
                    return "Số điện thoại không được để trống!0";
                }
                else
                {
                    SINHVIEN add = new SINHVIEN();
                    add.NgaySinh = ngaySinh;
                    add.SoCMND = soCMND;
                    add.SoDT = soDT;
                    add.TenSV = tenSV;
                    add.MaSV = maSV;
                    add.DiaChi = diaChi;
                    SINHVIEN result = sv.ThemSV(add);
                    if(result != null)
                    {
                        return null;
                    }else
                    {
                        return "Hệ thống đã xảy ra lỗi, xin vui lòng thử lại!";
                    }
                }
            }catch(Exception e)
            {
                return "Hệ thống đã xảy ra lỗi, xin vui lòng thử lại!";
            }
        }


        public String SuaSV(String maSV, String tenSV, DateTime ngaySinh, int soCMND, String soDT, String diaChi)
        {
            try
            {
                SINHVIEN check = sv.TimSVTheoMaSV(maSV);
                if (check == null)
                {
                    return "Đã xảy ra lỗi trong việc tìm sinh viên bạn muốn sửa, xin vui lòng thử lại!";
                }
                else
                {
                    SINHVIEN edit = new SINHVIEN();
                    edit.NgaySinh = ngaySinh;
                    edit.SoCMND = soCMND;
                    edit.TenSV = tenSV;
                    edit.NgaySinh = ngaySinh;
                    edit.SoDT = soDT;
                    edit.DiaChi = diaChi;
                    SINHVIEN result = sv.SuaSV(edit);
                    if (result == null)
                    {
                        return "Đã xảy ra lỗi trong quá trình sửa thông tin, xin vui lòng thử lại!";
                    }
                    else
                    {
                        return null;
                    }
                }
            }catch(Exception e)
            {
                return "Hệ thống đã xảy ra lỗi, xin vui lòng thử lại!";
            }
        }

        public String XoaSV(String maSV)
    }
}
