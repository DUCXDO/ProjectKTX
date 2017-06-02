using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IPhieuThuDAO
    {
        PHIEUTHU ThemPT(PHIEUTHU pt);
        PHIEUTHU XoaPT(PHIEUTHU pt);
        IEnumerable<PHIEUTHU> TimTatCaPT();
        IEnumerable<PHIEUTHU> TimPT(PHIEUTHU pt);
    }
        

    class PhieuThuDAO : IPhieuThuDAO
    {
        public PHIEUTHU ThemPT(PHIEUTHU pt)
        {
            try
            {
                // khai báo và khởi tạo đối tượng kết nối với database
                KTXEntities KTXe = new KTXEntities();
                //Thêm mới 
                PHIEUTHU result = KTXe.PHIEUTHUs.Add(pt);
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

        public PHIEUTHU XoaPT(PHIEUTHU pt)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                PHIEUTHU delete = KTXe.PHIEUTHUs.Find(pt.SoPT);
                PHIEUTHU result = KTXe.PHIEUTHUs.Remove(delete);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<PHIEUTHU> TimTatCaPT()
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                IEnumerable<PHIEUTHU> result = KTXe.PHIEUTHUs.AsEnumerable();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<PHIEUTHU> TimPT(PHIEUTHU pt)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                IEnumerable<PHIEUTHU> result = KTXe.PHIEUTHUs.AsQueryable().Where(x =>
                (pt.SoHD == null || x.SoHD == pt.SoHD) &&
                (pt.SoPT == null || x.SoPT == pt.SoPT) &&
                (pt.NgayLap == null) || (x.NgayLap.Date == pt.NgayLap.Date));
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

