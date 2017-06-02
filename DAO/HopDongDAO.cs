using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IHopDongDAO
    {
        HOPDONG themHD(HOPDONG hd);
    }

    public class HopDongDAO : IHopDongDAO
    {
        public HOPDONG ThemHD(HOPDONG hd)
        {
            try
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
            catch (Exception e)
            {
                //trả về null để biết là có lỗi
                return null;
            }
        }

        public SINHVIEN XoaSV(SINHVIEN sv)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                SINHVIEN delete = KTXe.SINHVIENs.Find(sv.MaSV);
                SINHVIEN result = KTXe.SINHVIENs.Remove(delete);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public SINHVIEN SuaSV(SINHVIEN sv)
        {
            try
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
                { return edit; }
                else
                { return null; }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<SINHVIEN> TimTatCaSV()
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                IEnumerable<SINHVIEN> result = KTXe.SINHVIENs.AsEnumerable();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<SINHVIEN> TimSV(SINHVIEN sv)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                IEnumerable<SINHVIEN> result = KTXe.SINHVIENs.AsQueryable().Where(x =>
                (sv.MaSV == null || x.MaSV == sv.MaSV) &&
                (sv.NgaySinh == null || x.NgaySinh == sv.NgaySinh) &&
                (sv.SoCMND == 0) || (x.SoCMND == sv.SoCMND) &&
                (sv.SoDT == null) || (x.SoDT == sv.SoDT));
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
