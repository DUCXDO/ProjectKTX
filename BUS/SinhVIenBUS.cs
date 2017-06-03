using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.ComponentModel.DataAnnotations;

namespace BUS
{
    public class SinhVIenBUS
    {
        private readonly ISinhVienDAO _sv;
        private readonly IPhongDAO _p;

        public SinhVIenBUS(ISinhVienDAO sv, IPhongDAO p)
        {
            _sv = sv;
            _p = p;
        }

        //Hàm check cái thành phần hợp lệ
        public String kiemTraSinhVien(SINHVIEN sv)
        {
            var validationContext = new ValidationContext(sv, null, null);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(sv, validationContext, validationResults);
               
            if(isValid == true)
            {
                return null;
            }
            else
            {
                String result = String.Empty;
                foreach(var r in validationResults)
                {
                    result += r.ErrorMessage + "\n";
                }
                return result;
            }
        }

        //Hàm thêm sinh viên
        public String ThemSV(SINHVIEN sv)
        {
            String check = kiemTraSinhVien(sv);
            if (check != null)
            {
                return check;
            }
            else
            {
                SINHVIEN result = _sv.ThemSV(sv);
                if (result != null)
                {
                    return null;
                }
                else
                {
                    return "Đã xảy ra lỗi trong quá trình thêm sinh viên, xin vui lòng thử lại!";
                }
            }
        }


        public String SuaSV(SINHVIEN sv)
        {

            String check = kiemTraSinhVien(sv);
            if (check != null)
            {
                return check;
            }
            else
            {
                SINHVIEN checkSVTonTai = _sv.TimSVTheoMaSV(sv.MaSV);
                if (checkSVTonTai == null)
                {
                    return "Không tìm thấy thông tin cần sửa, xin vui lòng thử lại!";
                }
                else
                {
                    SINHVIEN result = _sv.SuaSV(sv);
                    if (result == null)
                    {
                        return "Đã xảy ra lỗi trong quá trình sửa thông tin, xin vui lòng thử lại!";
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public String XoaSV(String maSV)
        {

            SINHVIEN check = _sv.TimSVTheoMaSV(maSV);
            if (check == null)
            {
                return "Không tìm thấy dữ liệu cần xóa, xin vui lòng thử lại!";
            }
            else
            {
                SINHVIEN result = _sv.XoaSV(check);
                if (result == null)
                {
                    return "Đã xảy ra lỗi trong quá trình xóa sinh viên, xin vui lòng thử lại!";
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<SINHVIEN> TimSV(SINHVIEN sv)
        {
            SINHVIEN lookFor = new SINHVIEN();
            IEnumerable<SINHVIEN> result = _sv.TimSV(lookFor);
            return result;

        }
    }
}
