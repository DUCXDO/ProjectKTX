using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IPhongDAO
    {
    }

    public class PhongDAO : IPhongDAO
    {
        public PHONG ThemP(PHONG p)
        {
            try
            {
                // khai báo và khởi tạo đối tượng kết nối với database
                KTXEntities KTXe = new KTXEntities();
                //Thêm mới 
                PHONG result = KTXe.PHONGs.Add(p);
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

        public PHONG XoaP(PHONG p)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                PHONG delete = KTXe.PHONGs.Find(p.MaPhong);
                PHONG result = KTXe.PHONGs.Remove(delete);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PHONG SuaP(PHONG p)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                PHONG edit = KTXe.PHONGs.Find(p);
                edit.SoNguoiTD = p.SoNguoiTD;
                edit.ViTriP = p.ViTriP;
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

        public IEnumerable<PHONG> TimTatCaP()
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                IEnumerable<PHONG> result = KTXe.PHONGs.AsEnumerable();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<PHONG> TimSV(PHONG p)
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
