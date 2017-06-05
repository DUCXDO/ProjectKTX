using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO.DAO_class
{
    public interface ITaiSanDAO
    {

    }

    public class TaiSanDAO : ITaiSanDAO
    {
        public TAISAN ThemTS(TAISANDTO ts)
        {
            try
            {
                // khai báo và khởi tạo đối tượng kết nối với database
                KTXEntities KTXe = new KTXEntities();

                TAISAN add = new TAISAN();
                add.MaTS = ts.MaTS;
                add.SoLuong = ts.SoLuong;
                add.TenTS = ts.TenTS;
                add.TinhTrang = ts.TinhTrang;
                //Thêm mới 
                TAISAN result = KTXe.TAISANs.Add(add);
                //Lưu thay đổi
                KTXe.SaveChanges();
                //trả về đối tượng mới thêm để xác định kết quả
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TAISAN XoaTS(String maTS)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                TAISAN delete = KTXe.TAISANs.Find(maTS);
                TAISAN result = KTXe.TAISANs.Remove(delete);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TAISAN SuaTS(TAISAN ts)
        {
            try
            {
                KTXEntities KTXe = new KTXEntities();
                TAISAN edit = KTXe.TAISANs.Find(ts);
                edit.SoLuong = ts.SoLuong;
                edit.TenTS = ts.TenTS;
                edit.TinhTrang = ts.TinhTrang;
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
            catch (Exception e)
            {
                return null;
            }

        }

        public IEnumerable<TAISAN> TimTatCaTS()
        {

            KTXEntities KTXe = new KTXEntities();
            IEnumerable<TAISAN> result = KTXe.TAISANs.AsEnumerable();
            return result;

        }

        public TAISAN TimTSTheoMaTS(String maTS)
        {

            KTXEntities KTXe = new KTXEntities();
            TAISAN result = KTXe.TAISANs.SingleOrDefault(x => x.MaTS == maTS);
            return result;

        }

        public IEnumerable<TAISAN> TimSV(TAISANDTO ts)
        {

            KTXEntities KTXe = new KTXEntities();
            IEnumerable<TAISAN> result = KTXe.TAISANs.AsQueryable().Where(x =>
            (ts.MaTS == null || x.MaTS == ts.MaTS) &&
            (ts.TenTS == null || x.TenTS == ts.TenTS));
            return result;
        }
    }
}
