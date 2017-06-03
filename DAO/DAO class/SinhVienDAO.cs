using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ISinhVienDAO
    {
        SINHVIEN ThemSV(SINHVIEN sv);
        SINHVIEN XoaSV(SINHVIEN sv);
        SINHVIEN SuaSV(SINHVIEN sv);
        IEnumerable<SINHVIEN> TimSV(SINHVIEN sv);
        IEnumerable<SINHVIEN> TimTatCaSV();
        SINHVIEN TimSVTheoMaSV(String maSV);
    }

    public class SinhVienDAO : ISinhVienDAO
    {
        public SINHVIEN ThemSV(SINHVIEN sv)
        {

            // khai báo và khởi tạo đối tượng kết nối với database
            KTXEntities KTXe = new KTXEntities();
            //Thêm mới 
            SINHVIEN result = KTXe.SINHVIENs.Add(sv);
            //Lưu thay đổi
            KTXe.SaveChanges();
            //trả về đối tượng mới thêm để xác định kết quả
            return result;

        }

        public SINHVIEN XoaSV(SINHVIEN sv)
        {

            KTXEntities KTXe = new KTXEntities();
            SINHVIEN delete = KTXe.SINHVIENs.Find(sv.MaSV);
            SINHVIEN result = KTXe.SINHVIENs.Remove(delete);
            return result;

        }

        public SINHVIEN SuaSV(SINHVIEN sv)
        {

            KTXEntities KTXe = new KTXEntities();
            SINHVIEN edit = KTXe.SINHVIENs.Find(sv);
            edit.NgaySinh = sv.NgaySinh;
            edit.SoCMND = sv.SoCMND;
            edit.SoDT = sv.SoDT;
            edit.TenSV = sv.TenSV;
            edit.DiaChi = sv.DiaChi;
            int result = KTXe.SaveChanges();
            if (result == 1)
            {
                return edit;
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<SINHVIEN> TimTatCaSV()
        {

            KTXEntities KTXe = new KTXEntities();
            IEnumerable<SINHVIEN> result = KTXe.SINHVIENs.AsEnumerable();
            return result;
            
        }

        public SINHVIEN TimSVTheoMaSV(String maSV)
        {

            KTXEntities KTXe = new KTXEntities();
            SINHVIEN result = KTXe.SINHVIENs.SingleOrDefault(x => x.MaSV == maSV);
            return result;

        }

        public IEnumerable<SINHVIEN> TimSV(SINHVIEN sv)
        {

            KTXEntities KTXe = new KTXEntities();
            IEnumerable<SINHVIEN> result = KTXe.SINHVIENs.AsQueryable().Where(x =>
            (sv.MaSV == null || x.MaSV == sv.MaSV) &&
            (sv.NgaySinh == null || x.NgaySinh == sv.NgaySinh) &&
            (sv.SoCMND == 0) || (x.SoCMND == sv.SoCMND) &&
            (sv.SoDT == null) || (x.SoDT == sv.SoDT));
            return result;

        }
    }
}
